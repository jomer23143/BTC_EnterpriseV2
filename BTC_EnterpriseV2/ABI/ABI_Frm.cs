using System.Diagnostics;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using BTCP_EnterpriseV2.YaoUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static BTC_EnterpriseV2.ProcessForm.Sub_AssyFrm;

namespace BTC_EnterpriseV2.ABI
{
    public partial class ABI_Frm : Form
    {
        public string thereason = "";
        public string segment = "";
        public string moid = "";
        public string generatedSerial = "";
        public string processname = "";
        private const string ApiUrl = "https://app.btcp-enterprise.com/api/scan-serial";
        public ABI_Frm(string segment, string moid, string generatedSerial, string processname)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            YUI yui = new YUI();
            yui.RoundedFormsDocker(this, 8);
            yui.RoundedButton(btn_submit, 8, Color.DarkSlateBlue);
            yui.RoundedButton(btn_cancel, 8, Color.Salmon);


            textBox_abi_reason.Visible = false;
            chckbox.Checked = false;

            this.segment = segment;
            this.moid = moid;
            this.generatedSerial = generatedSerial;
            this.processname = processname;

        }

        private void ABI_Frm_Load(object sender, EventArgs e)
        {

        }

        private void cmb_abi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (chckbox.Checked == true)
            {
                label_details.Text = string.Empty;

                textBox_abi_reason.Visible = true;
                cmb_abi.Enabled = false;
                textBox_abi_reason.Select();
                cmb_abi.Text = "";
            }
            else if (chckbox.Checked == false)
            {

                textBox_abi_reason.Text = string.Empty;
                textBox_abi_reason.Visible = false;
                cmb_abi.Enabled = true;
                label_details.Text = string.Empty;
            }
        }

        private void textBox_abi_reason_TextChanged(object sender, EventArgs e)
        {
            thereason = textBox_abi_reason.Text;
            label_details.Text = $"ABI with MOID: {moid}, Segment: {segment}, Process: {processname}, Generated Serial: {generatedSerial}, ABI Reason: {thereason}.";

        }


        public async Task Submit_ABI(string serial, int status)
        {
            try
            {

                var serialClean = serial.Trim();
                var statusClean = status;
                var postData = new
                {
                    serial_number = serialClean,
                    status_id = statusClean
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
        private async Task InitializeSubmitABIAsync()
        {
            //2 is for ABI status
            await Submit_ABI(generatedSerial, 2);
            MessageBox.Show($"ABI with MOID: {moid}, Segment: {segment}, Process: {processname}, Generated Serial: {generatedSerial}, ABI Reason: {thereason} has been submitted successfully.", "ABI Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private async void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                await InitializeSubmitABIAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to submit ABI: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
