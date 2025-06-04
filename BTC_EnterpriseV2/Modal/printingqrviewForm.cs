using System.Diagnostics;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static BTC_EnterpriseV2.ProcessForm.Sub_AssyFrm;

namespace BTC_EnterpriseV2.Modal
{
    public partial class printingqrviewForm : Form
    {
        public string ApiUrl;
        public string theid;
        public string themoid;
        public printingqrviewForm(string api, string id, string moid, string serial)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;

            this.ApiUrl = api;
            this.theid = id;
            this.themoid = moid;
            lbl_moid.Text = moid;
            lbl_serial.Text = serial;
        }
        private void printingqrviewForm_Load(object sender, EventArgs e)
        {

            _ = InitializeViewAsync();
        }

        private async Task InitializeViewAsync()
        {

            await Get_ViewPrint(themoid);

        }
        public async Task Get_ViewPrint(string moid)
        {
            try
            {
                var ApiUrlApiUrl = $"{ApiUrl}&mo_id={moid}";
                // API call
                string jsonResponse = await WebRequestApi.GetData_httpclient(ApiUrlApiUrl);
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

                // Expecting an object with a "data" property
                if (token.Type == JTokenType.Object && token["data"] != null)
                {
                    var rootObj = token.ToObject<PrintQR_Model.RootWrapper>();
                    var dataList = rootObj?.data;

                    if (dataList == null || dataList.Count == 0)
                    {
                        MessageBox.Show("No valid process data returned.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    LoadProcessData(dataList);
                    pb_loader.Visible = false;
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

        private void LoadProcessData(List<PrintQR_Model.Main> processes)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Setup columns
            dataGridView1.Columns.Add("No", "#");
            dataGridView1.Columns.Add("name", "Station Name");
            dataGridView1.Columns.Add("product_ref_code", "Ref Code");
            dataGridView1.Columns.Add("serial_number", "Serial Number");
            dataGridView1.Columns.Add("is_serial", "Is Serial");
            dataGridView1.Columns.Add("id", "Station ID");

            dataGridView1.Columns["id"].Visible = false;

            int index = 1;

            foreach (var process in processes)
            {
                foreach (var segment in process.segment)
                {
                    // Only process segments that belong to the specified manufacturing order ID
                    if (segment.manufacturing_order_id == theid)
                    {
                        foreach (var station in segment.station)
                        {
                            dataGridView1.Rows.Add(
                                index++,
                                station.name,
                                station.product_ref_code,
                                station.serial_number,
                                station.is_serial,
                                station.id
                            );
                        }
                    }
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

