using System.Diagnostics;
using System.Text.RegularExpressions;
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
            yUI.RoundedTextBox(txt_serialnumber, 6, Color.White);
            yUI.RoundedPanelDocker(panel_processname, 6);

            this.rowindex = rowindex;
            this.processId = processid;
            this.lbl_processname.Text = processname;
            this.qty = qty;
            this.count = count;
            this.serialnumber = generatedseril;
            lbl_msg.Text = "Please scan the serial number of the item to be processed.";
        }

        private async void ProcessScanner_Load(object sender, EventArgs e)
        {
            tempqty = int.Parse(qty);
            tempcount = int.Parse(count);
            lbl_scancount.Text = count + " out of " + qty;
            lbl_generatedserial.Text = serialnumber;
            int myprocessid = int.Parse(processId);
            await Get_ScannedItems(serialnumber, myprocessid);
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

                    lbl_scancount.Text = $"{tempcount} out of {tempqty}";


                    if (tempcount == tempqty)
                    {
                        DialogResult = MessageBox.Show("All required items have been scanned. Would you like to close the Modal?", "Scan Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (DialogResult == DialogResult.Yes)
                        {
                            this.Close();
                        }
                        else
                        {
                            return;
                        }

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

        public async Task Get_ScannedItems(string serial, int processId)
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
                        var matchingProcess = data.process.FirstOrDefault(p => p.id == processId);

                        if (matchingProcess != null && matchingProcess.serial != null)
                        {
                            LoadProcessData(matchingProcess.serial);
                        }
                        else
                        {
                            MessageBox.Show("No matching process ID or serial data found.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No valid process data found.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                // Sanitize inputs
                var postData = new
                {
                    process_id = processid.Trim(),
                    kit_serial = kitserial.Trim(),
                    serial_number = serial.Trim()
                };
                string json = JsonConvert.SerializeObject(postData);

                string jsonResponse = await WebRequestApi.PostRequest(ApiUrl, json);

                // Check if the response is empty or invalid HTML
                if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
                {
                    ShowMessage("Invalid response from server.", Color.Red);
                    return;
                }
                var token = JToken.Parse(jsonResponse);

                // Handle object-based response (likely error/info)
                if (token.Type == JTokenType.Object && token["message"] != null)
                {
                    string message = token["message"]?.ToString();
                    string kitSerialError = token["errors"]?["kit_serial"]?.FirstOrDefault()?.ToString();

                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        ShowMessage(message, Color.Orange);
                    }
                    else if (!string.IsNullOrWhiteSpace(kitSerialError))
                    {
                        ShowMessage(kitSerialError, Color.Red);
                    }
                    else
                    {
                        ShowMessage("An unknown error occurred.", Color.Red);
                    }

                    return;
                }
                // Handle array-based response (expected successful data)
                if (token.Type == JTokenType.Array)
                {
                    List<Sub_Asy_Process_Model.Root> result;
                    try
                    {
                        result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
                    }
                    catch (Exception parseEx)
                    {
                        ShowMessage("Failed to parse process data.", Color.Red);
                        //  Debug.WriteLine("Parse Error: " + parseEx);
                        return;
                    }

                    var data = result?.FirstOrDefault();

                    if (data == null)
                    {
                        ShowMessage("No valid process data returned.", Color.Red);
                        return;
                    }
                    lbl_generatedserial.Text = data.serial_number;
                    // LoadProcessData(data.process);
                    tempcount++;
                    ShowMessage("Process data retrieved successfully.", Color.Green);
                }
                else
                {
                    ShowMessage("Unexpected response format.", Color.Red);
                }
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❗ API Error: {ex}");
                // i try to catch json from the errorr message
                var match = Regex.Match(ex.Message, @"\{.*\}", RegexOptions.Singleline);
                if (match.Success)
                {
                    try
                    {
                        var token = JToken.Parse(match.Value);
                        string message = token["message"]?.ToString();
                        string kitSerialError = token["errors"]?["kit_serial"]?.FirstOrDefault()?.ToString();

                        if (!string.IsNullOrWhiteSpace(message))
                            ShowMessage(message, Color.Orange);
                        else if (!string.IsNullOrWhiteSpace(kitSerialError))
                            ShowMessage(kitSerialError, Color.Red);
                        else
                            ShowMessage("An unknown error occurred.", Color.Red);

                        return;
                    }
                    catch (Exception parseEx)
                    {
                        Debug.WriteLine("Failed to parse error JSON: " + parseEx);
                    }
                }

                ShowMessage("Serial not found. It may be invalid, unregistered, or entered incorrectly.", Color.Red);
            }

        }

        private void ShowMessage(string message, Color color)
        {
            lbl_msg.ForeColor = color;
            lbl_msg.Text = message;
        }


        private void LoadProcessData2(string serial)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("NoProcess", "No.");
            dataGridView1.Columns.Add("serial_number", "Item Serial Number");

            dataGridView1.Columns["NoProcess"].Width = 50;

            int index = 1;
            //foreach (var serial in serials)
            //{
            //    dataGridView1.Rows.Add(index++, serial.serial_number);
            //}
        }

    }
}
