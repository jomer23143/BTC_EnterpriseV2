using BTC_EnterpriseV2.Model;
using BTCP_EnterpriseV2.Forms;
using BTCP_EnterpriseV2.YaoUI;
using Newtonsoft.Json;

namespace BTC_EnterpriseV2.Forms
{
    public partial class UserIdentificationfrm : Form
    {
        private YUI yui = new YUI();
        private object? jsonResponse;
        public string? modulename;
        public string? type;
        public UserIdentificationfrm(string? modulename, string? type)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            yui.RoundedFormsDocker(this, 10);
            yui.RoundedTextBox(txt_id, 10, Color.SeaGreen);
            yui.RoundedButton(button1, 10, Color.Tomato);
            txt_scanid.Select();
            lbl_userinfo.Text = "Tap ID to Proceed.";
            lbl_position.Text = "";
            this.modulename = modulename;
            this.type = type;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_id_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txt_scanid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txt_scanid.Text))
            {
                lbl_userinfo.Text = "Processing...";

                string apiUrl = "https://app.btcp-enterprise.com/api/login-production";


                Myrequest(apiUrl, txt_scanid.Text);


                txt_scanid.Clear();
                txt_scanid.Focus();

                e.Handled = true;
            }
        }
        private async void Myrequest(string apiUrl, string rfid)
        {
            try
            {
                var postData = new { rfid_no = rfid };
                string json = JsonConvert.SerializeObject(postData);

                string jsonResponse = await Utillities.WebRequestApi.Operator_httpclient(apiUrl, json);

                Console.WriteLine($"Raw API Response: {jsonResponse}");

                if (string.IsNullOrEmpty(jsonResponse) || jsonResponse.Trim().StartsWith("<"))
                {
                    MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var response = JsonConvert.DeserializeObject<UserIdentifiactionModel>(jsonResponse);

                if (response == null || response.user == null)
                {
                    MessageBox.Show("Failed to parse API response.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                txt_id.Text = response?.user?.employee_id?.ToString() ?? "N/A";
                lbl_userinfo.Text = $"{response?.user.profile?.first_name ?? ""} {response?.user.profile?.last_name ?? ""}".Trim();
                lbl_position.Text = response?.user.job_title ?? "Unknown";


                string defaultImagePath = Path.Combine(Application.StartupPath, "Assets", "Unknown.png");
                string imagePath = defaultImagePath;

                pb_rfid.Image = File.Exists(imagePath) ? Image.FromFile(imagePath) : null;

                await Task.Delay(1000);


                string defaultImagePathRfid = Path.Combine(Application.StartupPath, "Assets", "rfid.png");
                txt_id.Text = "";
                lbl_userinfo.Text = "Tap ID to Proceed.";
                lbl_position.Text = "";
                pb_rfid.Image = Image.FromFile(defaultImagePathRfid);

                getLoadModule(modulename, type);
                this.Close();
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}\n\nResponse: {jsonResponse}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbl_userinfo.Text = "The Server has incounter a problem please contact IT.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void getLoadModule(string module, string type)
        {
            MainDashboard? mainDashboard = Application.OpenForms["MainDashboard"] as MainDashboard;
            if (mainDashboard == null)
            {
                MessageBox.Show("Main Dashboard not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (module)
            {
                case "Pre-Assy":
                    if (type == "S1")
                    {
                        //Forms.OperatorsVFrm s1frm = new Forms.OperatorsVFrm();
                        //mainDashboard.LoadChildForm(s1frm);
                    }
                    break;
                case "Material Inventory":
                    //Forms.Kitlistfrm kitlistfrm = new Forms.Kitlistfrm();
                    //mainDashboard.LoadChildForm(kitlistfrm);
                    break;
                case "OperatorsVFrm":
                    MessageBox.Show(type, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    MessageBox.Show("Module not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }


    }
}
