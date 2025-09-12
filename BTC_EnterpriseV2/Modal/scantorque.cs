using BTC_EnterpriseV2.Class;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using BTCP_EnterpriseV2.YaoUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BTC_EnterpriseV2.Modal
{
    public partial class scantorque : Form
    {
        private string processid;
        private string processname;
        private string PostTorque = GlobalApi.GetPostMaterialAssignTorqueUrl();
        public scantorque(string processid, string processname)
        {
            InitializeComponent();
            YUI yUI = new YUI();
            // yUI.RoundedFormsDocker(this, 8);
            yUI.RoundedTextBox(txt_torque, 6, Color.White);
            yUI.RoundedPanelDocker(panel_processname, 6);
            this.processid = processid;
            lbl_processname.Text = processname;
        }
        private async void txt_torque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txt_torque.Text))
                {
                    MessageBox.Show("Please enter a Torque serial number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                else
                {
                    await PostItemSerial(txt_torque.Text, processid);
                    txt_torque.Clear();
                    txt_torque.Select();
                }
            }
        }

        public async Task PostItemSerial(string serial, string processid)
        {
            try
            {
                // Sanitize inputs
                var postData = new
                {
                    name = serial.Trim(),
                    material_id = processid,

                };
                string json = JsonConvert.SerializeObject(postData);

                string jsonResponse = await WebRequestApi.PostRequest(PostTorque, json);

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
                }
                else
                {
                    ShowMessage("Successfully Scan", Color.Green);
                }
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, Color.Orange);
            }

        }
        private void ShowMessage(string message, Color color)
        {
            lbl_msg.ForeColor = color;
            lbl_msg.Text = message;
        }



    }
}
