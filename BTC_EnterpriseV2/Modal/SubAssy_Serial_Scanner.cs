using System.Data;
using System.Diagnostics;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using BTCP_EnterpriseV2.YaoUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static BTC_EnterpriseV2.ProcessForm.Sub_AssyFrm;

namespace BTC_EnterpriseV2.Modal
{
    public partial class SubAssy_Serial_Scanner : Form
    {
        public event Action<string?> SerialScanned = delegate { };
        public event Action<DataTable> Responsetable = delegate { };
        public string segmentname;
        private string MyMOID;
        private const string ApiUrl = "https://app.btcp-enterprise.com/api/scan-serial";
        public DataTable ipn_list = new DataTable("ipntable");
        public SubAssy_Serial_Scanner(string segmentname)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            YUI yUI = new YUI();
            yUI.RoundedFormsDocker(this, 8);
            yUI.RoundedTextBox(txt_serialnumber, 8, Color.White);
            txt_serialnumber.Focus();
            lbl_segmentname.Text = segmentname;
        }

        private void txt_serialnumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SerialScanned?.Invoke(txt_serialnumber.Text);
                //  ValidateIPN();
                this.Close();
            }
        }

        //private async void ValidateIPN()
        //{
        //    await Get_ScanData(txt_serialnumber.Text);
        //}
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            txt_serialnumber.Focus();
        }


        // First method to get the scan data from the API
        public async Task Get_ScanData(string serial)
        {
            try
            {
                var serialClean = serial.Trim();
                var postData = new { serial_number = serialClean };
                string json = JsonConvert.SerializeObject(postData);
                Debug.WriteLine("Request JSON: " + json);


                string jsonResponse = await WebRequestApi.PostRequest(ApiUrl, json);
                Debug.WriteLine("Response: " + jsonResponse);

                // Basic validation
                if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
                {
                    MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parse response
                var token = JToken.Parse(jsonResponse);

                // Handle error object
                if (token.Type == JTokenType.Object && token["message"] != null)
                {
                    var error = token.ToObject<ApiErrorResponse>();
                    MessageBox.Show($"Error: {error.message}", "Serial Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Handle valid array response
                if (token.Type == JTokenType.Array)
                {
                    var result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
                    var data = result?.FirstOrDefault();

                    if (data == null)
                    {
                        MessageBox.Show("No valid process data returned.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    var moid = data.mo_id;

                    ///From master jomer

                    ipn_list.Columns.Clear();
                    ipn_list.Columns.Add("IPN Number", typeof(string));
                    ipn_list.Columns.Add("Name", typeof(string));


                    foreach (var data_process in data.process)
                    {
                        ipn_list.Rows.Add(
                            data_process.ipn_number,
                            data_process.name
                        );

                    }
                    PostData(moid);
                    // GetData(moid);
                }
                else
                {
                    MessageBox.Show("Unexpected response format.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Error: {ex.Message}");
            }
        }

        // second method to post the data to the API
        private async void PostData(string moid)
        {
            try
            {

                var kitListDetails = await GetKitListItemDetailsAsync(moid);
                if (kitListDetails == null)
                {
                    MessageBox.Show("Failed to load kit list item details.");
                    return;
                }

                PopulateKitList_item(kitListDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //3rd method to get the kit list item details
        private async Task<Model.kitlist.GetData?> GetKitListItemDetailsAsync(string moId)
        {
            string url = $"https://app.btcp-enterprise.com/api/kit-list-item?mo_id={moId}&per_row=9999";
            string json = await GetMohDetails(url);
            return JsonConvert.DeserializeObject<Model.kitlist.GetData>(json);

        }

        private DataTable dt_items = new DataTable("dt_items");
        private void PopulateKitList_item(Model.kitlist.GetData model)
        {
            dt_items.Rows.Clear();
            dt_items.Columns.Clear();
            dt_items.Columns.Add("id");
            dt_items.Columns.Add("mo_id");
            dt_items.Columns.Add("ipn");
            dt_items.Columns.Add("description");
            dt_items.Columns.Add("unit_quantity");
            dt_items.Columns.Add("track");
            var data = model.data ?? new();
            foreach (var row in data)
            {
                dt_items.Rows.Add(
                    row.id,
                    row.mo_id,
                    row.ipn,
                    row.description,
                    row.unit_quantity,
                    row.track
                );
            }

            if (dt_items.Rows.Count > 0)
            {
                var filteredRows = dt_items.AsEnumerable()
                    .Where(r => ipn_list.AsEnumerable()
                        .Any(ipnRow => ipnRow.Field<string>("IPN Number") == r.Field<string>("ipn")));
                if (filteredRows.Any())
                {
                    var newtable = filteredRows.CopyToDataTable();

                    if (newtable.Rows.Count == ipn_list.Rows.Count)
                    {
                        MessageBox.Show("Matching items found for the scanned serial number.", "Items Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SerialScanned?.Invoke(txt_serialnumber.Text);
                        Responsetable?.Invoke(newtable);

                    }
                    else
                    {
                        MessageBox.Show("Incomplate IPN number.", "No Items", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("No items found for the scanned serial number.", "No Items", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("No items found for the scanned serial number.", "No Items", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

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




    }
}
