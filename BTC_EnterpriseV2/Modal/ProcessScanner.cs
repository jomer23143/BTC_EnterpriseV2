using System.Diagnostics;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using BTCP_EnterpriseV2.YaoUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static BTC_EnterpriseV2.ProcessForm.Sub_AssyFrm;

namespace BTC_EnterpriseV2.Modal
{
    public partial class ProcessScanner : Form
    {
        public string serialnumber;
        public string processname;
        public string moid;
        public int rowindex;
        public string qty;
        public string count;
        public string processId;
        public int tempqty = 0;
        public int tempcount = 0;
        public event Action<string?> SerialScanned = delegate { };
        private const string ApiUrl = "https://app.btcp-enterprise.com/api/scan-serial";
        public ProcessScanner(int rowindex, string processid, string processname, string generatedseril, string qty, string count)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            YUI yUI = new YUI();
            yUI.RoundedFormsDocker(this, 8);
            yUI.RoundedButton(button1, 6, Color.Tomato);
            yUI.RoundedTextBox(txt_serialnumber, 6, Color.White);
            yUI.RoundedPanelDocker(panel_processname, 6);
            yUI.RoundedPanelDocker(panel_dgv, 6);
            this.rowindex = rowindex;
            this.processId = processid;
            this.lbl_processname.Text = processname;
            this.qty = qty;
            this.count = count;
            this.serialnumber = generatedseril;
        }

        private async void ProcessScanner_Load(object sender, EventArgs e)
        {
            tempqty = int.Parse(qty);
            tempcount = int.Parse(count);
            lbl_scancount.Text = count + " out of " + qty;
            lbl_generatedserial.Text = serialnumber;
            await Get_SubAsy_Process(serialnumber);
        }

        private async void txt_serialnumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txt_serialnumber.Text))
                {
                    MessageBox.Show("Please enter a serial number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tempcount < tempqty)
                {
                    await Get_Process_response(
                        lbl_generatedserial.Text,
                        processId,
                        txt_serialnumber.Text.Trim()
                    );

                    txt_serialnumber.Clear();
                    tempcount++;

                    lbl_scancount.Text = $"{tempcount} out of {tempqty}";


                    if (tempcount == tempqty)
                    {
                        MessageBox.Show("All required items have been scanned.", "Scan Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("You have already met the required number of items.", "Scanning Validator", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_serialnumber_TextChanged(object sender, EventArgs e)
        {

        }

        public async Task Get_SubAsy_Process(string serial)
        {
            try
            {
                var serialClean = serial.Trim();
                var postData = new { serial_number = serialClean };
                string json = JsonConvert.SerializeObject(postData);
                Debug.WriteLine("Request JSON: " + json);

                string jsonResponse = await WebRequestApi.PostRequest(ApiUrl, json);
                Debug.WriteLine("Response: " + jsonResponse);

                if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
                {
                    MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var token = JToken.Parse(jsonResponse);

                if (token.Type == JTokenType.Object && token["message"] != null)
                {
                    var error = token.ToObject<ApiErrorResponse>();
                    MessageBox.Show($"Error: {error.message}", "Serial Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (token.Type == JTokenType.Array)
                {
                    var result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
                    var data = result?.FirstOrDefault();

                    if (data.process != null && data.process.Any())
                    {
                        foreach (var proc in data.process)
                        {
                            if (proc.serial != null && proc.serial.Any())
                            {
                                //lbl_generatedserial.Text = data.;
                                LoadProcessData(proc.serial);
                                break; // Load only the first process with serials
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No valid serial data found in process.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


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

        private void LoadProcessData(List<Sub_Asy_Process_Model.Serial> serials)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("NoProcess", "No.");
            dataGridView1.Columns.Add("serial_number", "Item Serial Number");

            // Set column width
            dataGridView1.Columns["NoProcess"].Width = 50;

            int index = 1;
            foreach (var serial in serials)
            {
                dataGridView1.Rows.Add(index++, serial.serial_number);
            }
        }



        public async Task Get_Process_response(string serial, string processid, string kitserial)
        {
            try
            {
                var processidClean = processid.Trim();
                var kitserialClean = kitserial.Trim();
                var serialClean = serial.Trim();
                var postData = new
                {
                    process_id = processidClean,
                    kit_serial = kitserialClean,
                    serial_number = serialClean
                };
                string json = JsonConvert.SerializeObject(postData);
                Debug.WriteLine("Request JSON: " + json);

                string jsonResponse = await WebRequestApi.PostRequest(ApiUrl, json);
                Debug.WriteLine("Response: " + jsonResponse);

                if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
                {
                    MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var token = JToken.Parse(jsonResponse);

                if (token.Type == JTokenType.Object && token["message"] != null)
                {
                    var error = token.ToObject<ApiErrorResponse>();
                    MessageBox.Show($"Error: {error.message}", "Serial Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (token.Type == JTokenType.Array)
                {
                    var result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
                    var data = result?.FirstOrDefault();

                    if (data == null)
                    {
                        MessageBox.Show("No valid process data returned.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    lbl_generatedserial.Text = data.serial_number;

                    ///   LoadProcessData(data.process);

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

    }
}
