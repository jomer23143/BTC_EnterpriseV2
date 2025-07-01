using System.Data;
using BTCP_EnterpriseV2.YaoUI;

namespace BTC_EnterpriseV2.Modal
{
    public partial class ViewScanedDetails : Form
    {
        private const string ApiUrl = "https://app.btcp-enterprise.com/api/scan-serial";

        public string serialnumber;
        public string processname;
        public string moid;
        public int rowindex;
        public string qty;
        public string count;
        public string processId;
        public int tempqty = 0;
        public int tempcount = 0;
        private DataTable data_items;

        public ViewScanedDetails(int rowindex, string processid, string processname, string generatedserial, DataTable dtitems)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            YUI yUI = new YUI();
            yUI.RoundedFormsDocker(this, 8);
            yUI.RoundedButton(btnClose, 6, Color.DarkSlateBlue);
            this.rowindex = rowindex;
            this.processId = processid;
            this.lbl_processname.Text = "Scanned Items of : " + processname;
            this.qty = qty;
            this.count = count;
            this.serialnumber = generatedserial;
            this.data_items = dtitems;
        }

        private async void ViewScanedDetails_Load(object sender, EventArgs e)
        {
            lbl_generatedserial.Text = serialnumber;
            int myprocessid = int.Parse(processId);
            LoadProcessData(data_items);
            //  await Get_ScannedItems(serialnumber, myprocessid);
        }



        //public async Task Get_ScannedItems(string serial, int processId)
        //{
        //    try
        //    {
        //        var serialClean = serial.Trim();
        //        var postData = new { serial_number = serialClean };
        //        string json = JsonConvert.SerializeObject(postData);
        //        Debug.WriteLine("Request JSON: " + json);

        //        string jsonResponse = await WebRequestApi.PostRequest(ApiUrl, json);
        //        Debug.WriteLine("Response: " + jsonResponse);

        //        if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
        //        {
        //            MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        var token = JToken.Parse(jsonResponse);

        //        if (token.Type == JTokenType.Object && token["message"] != null)
        //        {
        //            var error = token.ToObject<ApiErrorResponse>();
        //            MessageBox.Show($"Error: {error.message}", "Serial Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }

        //        if (token.Type == JTokenType.Array)
        //        {
        //            var result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
        //            var data = result?.FirstOrDefault();

        //            if (data.process != null && data.process.Any())
        //            {
        //                var matchingProcess = data.process.FirstOrDefault(p => p.id == processId);

        //                if (matchingProcess != null && matchingProcess.serial != null)
        //                {
        //                    LoadProcessData(matchingProcess.serial);
        //                }
        //                else
        //                {
        //                    MessageBox.Show("No matching process ID or serial data found.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("No valid process data found.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Unexpected response format.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //    catch (JsonReaderException ex)
        //    {
        //        MessageBox.Show($"JSON Error: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"API Error: {ex.Message}");
        //    }
        //}


        private void LoadProcessData(DataTable items)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("NoProcess", "No.");
            dataGridView1.Columns.Add("serial_number", "Item Serial Number");

            dataGridView1.Columns["NoProcess"].Width = 50;

            int index = 1;
            foreach (DataRow serial in items.Rows)
            {
                dataGridView1.Rows.Add(index++, serial[2]);
            }
        }




















        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
