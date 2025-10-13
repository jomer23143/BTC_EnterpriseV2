using System.Data;
using System.Diagnostics;
using BTC_EnterpriseV2.Class;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using BTCP_EnterpriseV2.Forms;
using BTCP_EnterpriseV2.YaoUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static BTC_EnterpriseV2.Model.OperatorModel;

namespace BTC_EnterpriseV2.Modal
{
    public partial class CheckFrm : Form
    {
        private object jsonResponse;
        private YUI yui = new YUI();
        public string? modulename;
        public string? type;
        private string loginApiUrl = GlobalApi.GetOperatorLoginUrl();
        private string ScanUrl = GlobalApi.GetScanSerialUrl();
        public DataTable tbl_process = new DataTable("tblprocess");
        public DataTable tbl_subprocess = new DataTable("tblsubp");
        private string segmentname;
        private int _segmentid;
        private string OperatorToken;
        private string operatorName;
        private int _Prcess_license_Id;
        private string moid;
        private string processname;
        private string serialnumber;
        private string _islogin;

        private MainDashboard maindash = new MainDashboard();



        public delegate void checkHandler(string moid, int segmentid, string segment, string processname, string serialnumber, string operatorname, string operatortoken, DataTable process_list, DataTable subprocess_list);
        public event checkHandler AfterScanned;

        public CheckFrm(MainDashboard main, string _isloginOperator)
        {
            InitializeComponent();
            this.maindash = main;
            this._islogin = _isloginOperator;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.StartPosition = FormStartPosition.CenterParent;
            //panel_rfid.Visible = true;
            //panel_scangeneratedserial.Visible = false;
            yui.RoundedFormsDocker(this, 8);
            yui.RoundedPanelModuleName(panel_idholder);
            yui.RoundedPanelModuleName(panel_nameHolder);
            yui.RoundedPanelModuleName(panel_positionHolder);
            yui.RoundedPanelModuleName(panel_rfidtextholder);
            yui.RoundedPanelModuleName(panel_generatedcodeform);
            yui.RoundedTextBox(txt_scan, 10, Color.White);
            yui.RoundedTextBox(txt_scangeneratedserial, 10, Color.White);
            yui.RoundedPanelDocker(panel_rfid, 8);
            yui.RoundedButton(btn_viewlicense, 18, Color.SlateBlue);
            txt_scan.TextAlign = HorizontalAlignment.Center;
            txt_scan.Select();

        }

        private void CheckFrm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_islogin))
            {
                panel_rfid.Visible = true;
                panel_scangeneratedserial.Visible = false;
            }
            else
            {
                var userId = SessionData.TempData.Rows[0]["id"].ToString();
                var fullName = SessionData.TempData.Rows[0]["FullName"].ToString();
                var position = SessionData.TempData.Rows[0]["Position"].ToString();
                var token = SessionData.TempData.Rows[0]["Token"].ToString();

                txt_id.Text = $"ID :{userId}";
                lbl_userinfo.Text = $"FullName : {fullName}";
                operatorName = fullName;
                lbl_position.Text = $"Position : {position}";
                OperatorToken = token;

                panel_scangeneratedserial.Visible = true;
                txt_scangeneratedserial.Select();
            }

            LoadRegistryAsync();
            //for test only
            //  Myrequest(loginApiUrl, "87139969");
        }

        private void LoadRegistryAsync()
        {
            Load_Registry loader = new Load_Registry();
            List<SegmentProcess> registryData = loader.LoadDataRegistry();

            foreach (var item in registryData)
            {
                segmentname = item.SegmentName;
                _segmentid = Convert.ToInt32(item.ProcessType);
            }

        }


        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_scan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txt_scan.Text))
            {
                string rifd = txt_scan.Text.Trim();
                Myrequest(loginApiUrl, rifd);
                txt_scangeneratedserial.Select();
            }

        }

        private async void txt_scangeneratedserial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txt_scangeneratedserial.Text))
            {
                label_scaninfo.Text = "Processing.....";
                await LoadSegmentProcessAsync(txt_scangeneratedserial.Text, _segmentid);
                txt_scangeneratedserial.Clear();
                txt_scangeneratedserial.Focus();

                var licenses = SessionData.TempDataLicense.AsEnumerable();

                //  Check if the operator has the license for this process
                var licenseRow = licenses.FirstOrDefault(row => row.Field<int>("id") == _Prcess_license_Id && row.Field<string>("expiry_date") != "N/A");

                if (licenseRow == null)
                {
                    MessageBox.Show("You are not registered for this process.",
                                    "Access Denied",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Check if the license is expired
                if (DateTime.TryParse(licenseRow.Field<string>("expiry_date"), out DateTime expiryDate))
                {
                    if (expiryDate < DateTime.Now)
                    {
                        MessageBox.Show("Your license for this process has expired. Please contact your Production Head for renewal.",
                                        "License Expired",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }
                }

                // All checks passed
                AfterScanned?.Invoke(moid, _segmentid, segmentname, processname, serialnumber,
                                     operatorName, OperatorToken, tbl_process, tbl_subprocess);

                e.Handled = true;
                this.Close();
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

                var response = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);


                if (response?.user?.employee == null)
                {
                    MessageBox.Show("Failed to parse API response.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                SessionData.TempData.Rows.Clear();
                SessionData.TempData.Rows.Add(
                response.user.employee.employee_id_no,
               $"{response.user.profile?.first_name} {response.user.profile?.last_name}".Trim(),
               response.user.job_title ?? "Unknown",
               response.token
           );


                txt_id.Text = $"ID : {response.user.employee.employee_id_no ?? "N/A"}";
                lbl_userinfo.Text = $"FullName : {response.user.profile?.first_name} {response.user.profile?.last_name}".Trim();
                operatorName = $"{response.user.profile?.first_name} {response.user.profile?.last_name}".Trim();
                maindash.lbl_operatorlogin.Text = operatorName;
                lbl_position.Text = $"Position : {response.user.job_title ?? "Unknown"}";
                OperatorToken = response.token;

                SessionData.TempDataLicense.Rows.Clear();

                foreach (var lic in response.user.employee.licenses)
                {
                    SessionData.TempDataLicense.Rows.Add(
                        lic.license?.id ?? 0,
                        lic.license?.name ?? "N/A",
                        lic.license_no ?? "N/A",
                        lic.product_id ?? 0,
                        lic.product_name ?? "N/A",
                        lic.expiry_date?.ToString("yyyy-MM-dd") ?? "N/A"

                    );
                }



                string defaultImagePath = Path.Combine(Application.StartupPath, "Assets", "Unknown.png");
                string imagePath = defaultImagePath;

                pb_rfid.Image = File.Exists(imagePath) ? Image.FromFile(imagePath) : null;

                await Task.Delay(100);

                panel_scangeneratedserial.Visible = true;


            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}\n\nResponse: {jsonResponse}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbl_userinfo.Text = "The Server has incounter a problem please contact IT.";
            }
            catch (Exception ex)
            {
                // MessageBox.Show($"Error: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("The operator ID is not registered in the system. You must register it before you can use the production system.", "Invalid User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_scan.Text = "";
            }
        }

        public async Task LoadSegmentProcessAsync(string serial, int segmentId)
        {
            try
            {
                DictionaryBuilder Dbuilder = new DictionaryBuilder();
                var postData = Dbuilder.BuildPostSubAssy(serial, segmentId);
                string json = JsonConvert.SerializeObject(postData);
                Debug.WriteLine("Request JSON: " + json);

                var token = await ApiHelper.PostTokenJsonAsync(ScanUrl, postData, OperatorToken);
                if (token == null) return;

                if (token.Type == JTokenType.Array)
                {
                    var result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
                    var data = result?.FirstOrDefault();

                    if (data == null)
                    {
                        return;
                    }

                    _Prcess_license_Id = data.license_id != null ? int.Parse(data.license_id) : 0;
                    InitTables();
                    tbl_process.Rows.Clear();
                    tbl_subprocess.Rows.Clear();

                    foreach (var mainprocess in data.process)
                    {
                        // Check if there are any duration records
                        if (mainprocess.duration != null && mainprocess.duration.Any())
                        {
                            // Iterate over every duration record
                            foreach (var durationItems in mainprocess.duration)
                            {

                                if (durationItems.manufacturing_order_process_type_id?.ToString()?.Trim() == "1")
                                {
                                    tbl_process.Rows.Add(
                                        mainprocess.id,
                                        mainprocess.name ?? "N/A",
                                        mainprocess.cycle_time ?? "N/A",
                                        durationItems.manufacturing_order_process_type_id ?? "N/A",
                                        durationItems.start_time,
                                        durationItems.end_time,
                                        durationItems.status?.Name ?? "Open",
                                        mainprocess.status?.Color ?? "White",
                                        durationItems.remarks ?? ""
                                    );
                                }
                            }
                        }
                        else
                        {
                            // Add one row for the process even if it has NO duration records
                            tbl_process.Rows.Add(
                                mainprocess.id,
                                mainprocess.name ?? "N/A",
                                mainprocess.cycle_time ?? "N/A",
                                "N/A",
                                null,
                                null,
                                mainprocess.status?.Name ?? "Open",
                                mainprocess.status?.Color ?? "White",
                                ""
                            );
                        }
                    }


                    foreach (var process in data.process ?? new List<Sub_Asy_Process_Model.Process>())
                    {
                        if (process.sub_process != null)
                        {
                            foreach (var sub in process.sub_process)
                            {
                                tbl_subprocess.Rows.Add(
                                    sub.id,
                                    sub.manufacturing_order_process_id,
                                    sub.name ?? "N/A",
                                    sub.ipn_number ?? "",
                                    sub.serial_quantity ?? 0,
                                    sub.serial_count ?? 0,
                                    sub.is_kit_list,
                                    sub.is_serial,
                                    sub.is_torque,
                                    0,
                                    sub.machine_tool_torque_range?.ToString() ?? "",
                                    sub.machine_tool_torque_name?.ToString() ?? "",
                                    sub.machine_tool_torque_value?.ToString() ?? "",
                                    sub.is_chemical,
                                    sub.chemical_name?.ToString() ?? "",
                                    sub.chemical_expiration?.ToString() ?? ""
                                );
                            }
                        }
                    }

                    bool anyIsKitList = data.process.Any(p => p.is_kit_list == 1);

                    moid = data.mo_id;
                    processname = data.name;
                    serialnumber = data.serial_number;

                    var durationItem = data.duration?.FirstOrDefault();
                    var rawStartTime = data.duration?.FirstOrDefault()?.start_time;
                    var rawEndTime = data.duration?.FirstOrDefault()?.end_time;

                    if (durationItem == null)
                    {
                        MessageBox.Show("No duration data found.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bool isSubAssembly = segmentId == 1;

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



        private void InitTables()
        {
            if (tbl_process.Columns.Count == 0)
            {
                tbl_process.Columns.Add("id", typeof(int));
                tbl_process.Columns.Add("name", typeof(string));
                tbl_process.Columns.Add("cycle_time", typeof(string));
                tbl_process.Columns.Add("manufacturing_order_process_type_id", typeof(string));
                tbl_process.Columns.Add("start_time", typeof(string));
                tbl_process.Columns.Add("end_time", typeof(string));
                tbl_process.Columns.Add("status", typeof(string));
                tbl_process.Columns.Add("color", typeof(string));
                tbl_process.Columns.Add("remark", typeof(string));

                // ⭐ NEW COLUMN: Stores the collection of duration records
                tbl_process.Columns.Add("DurationRecords", typeof(List<Sub_Asy_Process_Model.Duration>));
            }

            if (tbl_subprocess.Columns.Count == 0)
            {
                tbl_subprocess.Columns.Add("id", typeof(int));
                tbl_subprocess.Columns.Add("manufacturing_order_process_id", typeof(int));
                tbl_subprocess.Columns.Add("name", typeof(string));
                tbl_subprocess.Columns.Add("ipn_number", typeof(string));
                tbl_subprocess.Columns.Add("serial_quantity", typeof(int));
                tbl_subprocess.Columns.Add("serial_count", typeof(int));
                tbl_subprocess.Columns.Add("is_kit_list", typeof(int));
                tbl_subprocess.Columns.Add("is_serial", typeof(int));
                tbl_subprocess.Columns.Add("is_torque", typeof(int));
                tbl_subprocess.Columns.Add("torque_count", typeof(string));
                tbl_subprocess.Columns.Add("machine_tool_torque_range", typeof(string));
                tbl_subprocess.Columns.Add("machine_tool_torque_name", typeof(string));
                tbl_subprocess.Columns.Add("machine_tool_torque_value", typeof(string));
                tbl_subprocess.Columns.Add("is_chemical", typeof(string));
                tbl_subprocess.Columns.Add("chemical_name", typeof(string));
                tbl_subprocess.Columns.Add("chemical_expiration", typeof(string));
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            new ToastForm("This is a success message!").Show();
        }
    }
}
