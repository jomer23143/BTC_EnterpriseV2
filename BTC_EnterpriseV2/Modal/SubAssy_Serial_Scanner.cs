using System.Data;
using BTC_EnterpriseV2.Class;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using BTCP_EnterpriseV2;
using BTCP_EnterpriseV2.YaoUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static BTC_EnterpriseV2.ProcessForm.Sub_AssyFrm;

namespace BTC_EnterpriseV2.Modal
{
    public partial class SubAssy_Serial_Scanner : Form
    {
        // public event Action<string?> SerialScanned = delegate { };
        public delegate void serialScannedHandler(string serial, string processType, DataTable data_list, int id, string processname, string stationName);
        public event serialScannedHandler SerialScanned;
        public event Action<DataTable> Responsetable = delegate { };
        public string segmentname;
        private string MyMOID;
        private string name;
        private string processType;
        private int id = 0;
        private string statioName;
        private string processname = string.Empty;

        private string Scan_api = GlobalApi.GetScanSerialUrl();
        private string manufacturingOrder_Api = GlobalApi.GetManufacturingOrdersUrl();
        public DataTable ipn_list = new DataTable("ipntable");
        private DataTable dt_list_Station_Serial = new DataTable();
        public SubAssy_Serial_Scanner()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            YUI yUI = new YUI();
            yUI.RoundedFormsDocker(this, 8);
            yUI.RoundedTextBox(txt_serialnumber, 8, Color.White);
            txt_serialnumber.Focus();
            pictureBox1.Visible = false;
        }
        private void SubAssy_Serial_Scanner_Load_1(object sender, EventArgs e)
        {
            LoadDataRegistry();

        }
        private void txt_serialnumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // SerialScanned?.Invoke(txt_serialnumber.Text);

                ValidateIPN();
                panel_UI.Visible = false;
                pictureBox1.Visible = true;
            }
        }

        private async void ValidateIPN()
        {
            if (string.IsNullOrWhiteSpace(txt_serialnumber.Text))
            {
                ShowWarning("Please enter a serial number.");
                return;
            }

            switch (processType)
            {
                case "1":

                    break;
                case "2":

                    break;
                case "3": //Sub Assy
                    await Get_ScanData(txt_serialnumber.Text);
                    break;

                case "4"://Pre Assy
                    int perc = 45;
                    string barHtml = Utils.RenderProgressBar(perc, "orange", "white");
                    label_progress.Text = $"{perc}%";
                    var stationId = 2;
                    var theprocess = "Pre Assembly";
                    SerialScanned?.Invoke(txt_serialnumber.Text, processType, ipn_list, stationId, theprocess, statioName);
                    this.Close();
                    break;
                case "5": //Rain Test
                    //await Get_ScanData_PreAssy(txt_serialnumber.Text, 1, 2, 3);
                    //int perc = 45;
                    //string barHtml = Utils.RenderProgressBar(perc, "orange", "white");
                    //label_progress.Text = $"{perc}%";
                    var RstationId = 3;
                    var Rprocess = "Rain Test";
                    SerialScanned?.Invoke(txt_serialnumber.Text, processType, ipn_list, RstationId, Rprocess, statioName);
                    this.Close();
                    break;
                case "6": //Main Assembly
                    var MstationId = 4;
                    var Mprocess = "Main Assembly";
                    SerialScanned?.Invoke(txt_serialnumber.Text, processType, ipn_list, MstationId, Mprocess, statioName);
                    this.Close();
                    break;
                default:
                    ShowWarning("Invalid process type.");
                    return;
            }


        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            txt_serialnumber.Focus();
        }

        private static void ShowWarning(string message, string title = "Warning") =>
             MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private static void ShowInfo(string message, string title = "Info") =>
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

        private static void ShowError(string message, string title = "Error") =>
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

        private static bool IsValidJson(string json) =>
            !string.IsNullOrWhiteSpace(json) && !json.StartsWith("<");


        private void LoadDataRegistry()
        {
            try
            {
                RegistrySupport_Operation registry = new RegistrySupport_Operation();
                String data = registry.Read(Def.REGKEY_SUB);
                if (data == null)
                {
                    data += String.Format($"BTC_ENTERPRISE<limiter>DEFualSection<limiter>DefualtCode<limiter>");
                    registry.Write(Def.REGKEY_SUB, data);
                }
                String[] programs = data.Split(new String[] { "<limiter1>" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String program in programs)
                {
                    String[] records = program.Split(new String[] { "<limiter>" }, StringSplitOptions.RemoveEmptyEntries);
                    //setup_grid.Rows.Add(records);
                    if (records.Length >= 3)
                    {

                        processType = records[1].Trim();

                    }
                    else
                    {
                        MessageBox.Show("Invalid data format in registry.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        // First method to get the scan data from the API
        public async Task Get_ScanData(string serial)
        {
            try
            {

                var json = await WebRequestApi.PostRequest(Scan_api, JsonConvert.SerializeObject(new { serial_number = serial.Trim() }));

                if (!IsValidJson(json))
                {
                    ShowWarning("Invalid response from server.");
                    return;
                }

                JToken token;
                try
                {
                    token = JToken.Parse(json);
                }
                catch (JsonReaderException ex)
                {
                    ShowError($"JSON Parsing error: {ex.Message}");
                    return;
                }

                if (token.Type == JTokenType.Object && token["message"] != null)
                {
                    var error = token.ToObject<ApiErrorResponse>();
                    ShowInfo($"Error: {error?.message}", "Serial Not Found");
                    return;
                }

                if (token.Type != JTokenType.Array)
                {
                    ShowWarning("Unexpected response format.");
                    return;
                }

                var result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
                var data = result?.FirstOrDefault();

                if (data == null)
                {
                    ShowWarning("No valid process data returned.");
                    return;
                }

                MyMOID = data.mo_id;
                name = data.name;

                ipn_list.Clear();
                ipn_list.Columns.Clear();
                ipn_list.Columns.Add("IPN Number");
                ipn_list.Columns.Add("Name");

                foreach (var p in data.process)
                    ipn_list.Rows.Add(p.ipn_number, p.name);

                var filteredItems = await PostData(MyMOID);
                if (filteredItems == null || filteredItems.Rows.Count == 0)
                {
                    return;
                }

                SerialScanned?.Invoke(txt_serialnumber.Text, processType, filteredItems, id, processname, statioName);

                this.Close();
            }
            catch (Exception ex)
            {
                ShowError($"Unexpected API error: {ex.Message}");
                this.Close();
            }
        }


        private async Task<DataTable?> PostData(string moid)
        {
            try
            {
                var kitListDetails = await GetKitListItemDetailsAsync(moid);
                if (kitListDetails == null)
                {
                    MessageBox.Show("Failed to load kit list item details.");
                    return new DataTable();
                }

                var result = PopulateKitList_item(kitListDetails);

                // You can now decide what to do based on result
                if (result.Rows.Count == 0)
                {
                    SerialScanned?.Invoke(txt_serialnumber.Text, processType, dt_items, id, processname, statioName);
                    this.Close();
                }

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }




        //3rd method to get the kit list item details
        private async Task<Model.kitlist.GetData?> GetKitListItemDetailsAsync(string moId)
        {
            string url = $"https://app.btcp-enterprise.com/api/kit-list-item?mo_id={moId}&per_row=9999";
            var json = await GetMohDetails(url);
            return JsonConvert.DeserializeObject<Model.kitlist.GetData>(json);
        }


        private DataTable dt_items = new DataTable("dt_items");

        private DataTable PopulateKitList_item(Model.kitlist.GetData model)
        {
            dt_items.Clear();
            dt_items.Columns.Clear();
            dt_items.Columns.AddRange(new[]
            {
        new DataColumn("id"), new DataColumn("mo_id"), new DataColumn("ipn"),
        new DataColumn("description"), new DataColumn("unit_quantity"), new DataColumn("track")
    });

            foreach (var item in model?.data ?? new())
                dt_items.Rows.Add(item.id, item.mo_id, item.ipn, item.description, item.unit_quantity, item.track);

            var filtered = dt_items.AsEnumerable()
                .Where(r => ipn_list.AsEnumerable()
                    .Any(ipn => ipn["IPN Number"].ToString() == r["ipn"].ToString()))
                .ToList();

            // If no matching items, show warning and return an empty table (DO NOT close the form)
            if (!filtered.Any())
            {
                return dt_items.Clone();
            }

            var newTable = filtered.CopyToDataTable();

            // Warning if IPN count mismatch, but still continue
            if (newTable.Rows.Count != ipn_list.Rows.Count)
            {
                MessageBox.Show("Incomplete IPN number. You cannot continue this process.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return newTable;
        }

        private async Task<string> GetMohDetails(string url)
        {
            DataTable dt = new DataTable();
            string responseData = "";
            await Task.Run(async () =>
            {

                using (HttpClient client = new HttpClient())
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(url),

                    };
                    HttpResponseMessage response = await client.SendAsync(request);
                    responseData = await response.Content.ReadAsStringAsync();

                }
            });
            return responseData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubAssy_Serial_Scanner_Load(object sender, EventArgs e)
        {

            txt_serialnumber.Focus();
        }


        private static readonly HashSet<string> ExcludedStations = new()
              {
            "Rain Test", "Main Assembly", "In-station QC", "EOL Test", "Final Assembly", "Final QC", "Packing"
            };


        //    private void LoadProcessData(List<PrintQR_Model.Main> processes)
        //    {
        //        var dt = new DataTable("Segment_Station");
        //        dt.Columns.AddRange(new[] { new DataColumn("No"), new DataColumn("Segment"), new DataColumn("Station") });

        //        dt_list_Station_Serial.Clear();
        //        dt_list_Station_Serial.Columns.Clear();
        //        dt_list_Station_Serial.Columns.AddRange(new[] {
        //    new DataColumn("manufacturing_order_id"),
        //    new DataColumn("Station"),
        //    new DataColumn("serial_number")
        //});

        //        int index = 1;
        //        foreach (var proc in processes)
        //        {
        //            foreach (var segment in proc.segment)
        //            {
        //                if (ExcludedStations.Contains(segment.name)) continue;

        //                foreach (var station in segment.station)
        //                {
        //                    if (!dt.AsEnumerable().Any(r => r["Station"].ToString() == station.name))
        //                        dt.Rows.Add(index++, segment.name, station.name);

        //                    dt_list_Station_Serial.Rows.Add(segment.manufacturing_order_id, station.name, station.serial_number);
        //                }
        //            }
        //        }

        //        var matchedStation = dt_list_Station_Serial.AsEnumerable()
        //            .FirstOrDefault(r => r["serial_number"].ToString() == txt_serialnumber.Text)?["Station"]?.ToString();

        //        // if (!string.IsNullOrEmpty(matchedStation))
        //        // ShowInfo($"Station matched: {matchedStation}");
        //    }



        public async Task Get_ScanData_PreAssy(string serial, int stat, int seq, int segement)
        {
            var postData = new
            {
                serial_number = serial.Trim(),
                station = stat,
                sequence = seq,
            };
            string json = JsonConvert.SerializeObject(postData);
            string jsonResponse = await WebRequestApi.PostRequest(Scan_api, json);

            if (!IsValidJson(jsonResponse))
            {
                ShowWarning("Invalid response from server.");
                return;
            }

            JToken token;
            try
            {
                token = JToken.Parse(jsonResponse);
            }
            catch (JsonReaderException ex)
            {
                ShowError($"JSON Parsing error: {ex.Message}");
                return;
            }

            if (token.Type == JTokenType.Object && token["message"] != null)
            {
                var error = token.ToObject<ApiErrorResponse>();
                ShowInfo($"Error: {error?.message}", "Serial Not Found");
                return;
            }

            if (token.Type != JTokenType.Array)
            {
                ShowWarning("Unexpected response format.");
                return;
            }

            var result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
            var data = result?.FirstOrDefault();
            if (data == null)
            {
                ShowWarning("No valid process data returned.");
                return;
            }

            MyMOID = data.mo_id;
            name = data.name;

            bool allCompleted = result.All(station => station.manufacturing_order_station_status_id == 3);
            if (allCompleted)
            {
                MessageBox.Show("All processes are already completed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            foreach (var station in result)
            {
                int statusId = station.manufacturing_order_station_status_id;
                int stationId = station.id;
                int ordersegment = station.manufacturing_order_sequence_number;

                if (statusId == 3)
                {
                    continue;
                }
                else if (statusId == 1)
                {
                    var theprocess = ordersegment switch
                    {
                        2 => "Pre Assembly",
                        3 => "Rain Test",
                        4 => "Main Assembly",
                        _ => "Unknown"
                    };
                    statioName = station.name;

                    SerialScanned?.Invoke(txt_serialnumber.Text, processType, ipn_list, stationId, theprocess, statioName);
                    this.Close();
                    break;
                }
                else if (statusId == 2)
                {
                    ShowInfo($"Next process waiting for ABI: {station.name}", "Status Check");
                    break;
                }
                else
                {
                    this.Close();
                }

            }

        }

        private void btn_close2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}





