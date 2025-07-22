using System.Diagnostics;
using System.Text.RegularExpressions;
using BTC_EnterpriseV2.Class;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using BTCP_EnterpriseV2.YaoUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BTC_EnterpriseV2.Modal
{
    public partial class PreAssy_ProcessScanner : Form
    {
        private string scanserial_api = GlobalApi.GetScanSerialUrl();

        public int station_id { get; set; }
        public int process_id { get; set; }

        public string toplevelserial { get; set; }
        public string process_name { get; set; }
        public PreAssy_ProcessScanner(int station_id, int process_id, string process_name, string toplevelserial)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.station_id = station_id;
            this.process_id = process_id;
            this.process_name = process_name;
            this.toplevelserial = toplevelserial;
            YUI yUI = new YUI();
            yUI.RoundedFormsDocker(this, 10);
            yUI.RoundedTextBox(txt_serial, 10, Color.White);
            txt_serial.Select();
        }

        private void PreAssy_ProcessScanner_Load(object sender, EventArgs e)
        {
            lbl_processname.Text = process_name;

        }

        private async void txt_serial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txt_serial.Text))
                {
                    ShowMessage("Please enter a serial number.", Color.Red);
                    return;
                }

                else
                {
                    await EndProcess(toplevelserial, station_id, process_id, txt_serial.Text.Trim());

                    return;
                }
            }
        }


        public async Task EndProcess(string serial_number, int segement, int processid, string kit_serila)
        {
            try
            {

                var postData = new
                {
                    serial_number = serial_number.Trim(),
                    manufacturing_order_segment_sequence_number = segement,
                    process_id = processid.ToString().Trim(),
                    kit_serial = kit_serila.ToString().Trim()
                };
                string json = JsonConvert.SerializeObject(postData);

                string jsonResponse = await WebRequestApi.PostRequest(scanserial_api, json);

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
                    //diri mag fucntion

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
                        string error = token["errors"]?.ToString();
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


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
