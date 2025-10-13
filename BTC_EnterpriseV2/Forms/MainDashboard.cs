using System.Data;
using BTC_EnterpriseV2.Forms;
using BTC_EnterpriseV2.Modal;
using BTC_EnterpriseV2.ProcessForm;
using BTC_EnterpriseV2.Settings;
using BTC_EnterpriseV2.SideBar;
using BTC_EnterpriseV2.Utillities;
using BTC_EnterpriseV2.YaoUI;
using BTCP_EnterpriseV2.Class;
using BTCP_EnterpriseV2.YaoUI;
namespace BTCP_EnterpriseV2.Forms
{
    public partial class MainDashboard : Form
    {
        private int borderSize = 2;
        private Size formSize;
        private ContextMenuStrip imageMenu = new ContextMenuStrip();
        private FormManager formManager;
        private UIManager UIManager;
        private Manage_SubAssy Manage_SubAssy;
        private FormManager fulldisplaycontroll;
        private string processType = string.Empty;
        public MainDashboard()
        {
            InitializeComponent();
            UIControls.SetupUI(this, Setting_Click, Logout_Click);
            Manage_SubAssy = new Manage_SubAssy(panel_menubar, panel_Subassy_Display);
            fulldisplaycontroll = new FormManager(panel_menubar, panel_Subassy_Display);

        }
        private void MainDashboard_SizeChanged(object sender, EventArgs e)
        {
            UIControls.SetupUI(this, Setting_Click, Logout_Click);
        }
        private void Setting_Click(object? sender, EventArgs e)
        {
            PasswordForm passwordForm = new PasswordForm();
            passwordForm.StartPosition = FormStartPosition.CenterScreen;

            var passwordResult = passwordForm.ShowDialog();

            if (passwordResult == DialogResult.OK)
            {
                setupfrm setupForm = new setupfrm(this);
                setupForm.StartPosition = FormStartPosition.CenterScreen;
                setupForm.ShowDialog(this);
                Refresh_Main_Menu(sender);
            }
        }


        private void Logout_Click(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbl_operatorlogin.Text))
            {
                lbl_operatorlogin.Text = "";
            }
            else
            {
                MessageBox.Show("Please Log  Scan RFID first.", "Log In.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_time.Text = DateTime.Now.ToString("hh:mm tt").ToUpper();
            lbl_currentdate.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy");
        }

        public void Load_MainPanel(Form mainPanel)
        {
            if (this.panel_Subassy_Display.Controls.Count > 0)
                this.panel_Subassy_Display.Controls.Clear(); // Remove existing controls
            mainPanel.TopLevel = false;
            mainPanel.FormBorderStyle = FormBorderStyle.None;
            mainPanel.Dock = DockStyle.Fill;
            this.panel_Subassy_Display.Controls.Add(mainPanel);
            this.panel_Subassy_Display.Tag = mainPanel;
            mainPanel.BringToFront();
            mainPanel.Show();
        }

        private void panel_menubar_MouseDown(object sender, MouseEventArgs e)
        {
            // DragForm.ReleaseCapture();
            // DragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            Refresh_Main_Menu(sender);
        }
        private void Refresh_Main_Menu(object sender)
        {
            try
            {
                RegistrySupport_Operation registry = new RegistrySupport_Operation();
                String data = registry.Read(Def.REGKEY_SUB);
                if (data == null)
                {
                    data += String.Format($"BTC_ENTERPRISE<limiter>DEFualSection<limiter>DefualtCode<limiter>");
                    registry.Write(Def.REGKEY_SUB, data);
                }
                String[] programs = data.Split(new String[] { "<limiter1>" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String program in programs)
                {
                    String[] records = program.Split(new String[] { "<limiter>" }, StringSplitOptions.RemoveEmptyEntries);
                    if (records.Length >= 3)
                    {
                        var departmentName = records[0].Trim();
                        switch (processType = records[1].Trim())
                        {
                            case "101":
                                btn_subasemble.Visible = false;
                                lbl_departmemnt.Text = departmentName;
                                fulldisplaycontroll.OpenChildForm(new PerantFrm(), sender);
                                break;
                            case "102":
                                btn_subasemble.Visible = false;
                                lbl_departmemnt.Text = departmentName;
                                fulldisplaycontroll.OpenChildForm(new PerantFrm(), sender);
                                break;
                            case "1":
                                fulldisplaycontroll.closeAForm();
                                Manage_SubAssy.Reset();
                                btn_subasemble.Visible = true;
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "2":
                                fulldisplaycontroll.closeAForm();
                                Manage_SubAssy.Reset();
                                btn_subasemble.Visible = true;
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "3":
                                fulldisplaycontroll.closeAForm();
                                Manage_SubAssy.Reset();
                                btn_subasemble.Visible = true;
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "4":
                                btn_subasemble.Visible = true;
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "5":
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "6":
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "7":
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "8":
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "9":
                                lbl_departmemnt.Text = departmentName;
                                break;
                            default:
                                lbl_departmemnt.Text = departmentName;
                                break;

                        }


                    }
                    else
                    {
                        MessageBox.Show("Invalid data format in registry.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void panel_main_display_SizeChanged(object sender, EventArgs e)
        {
            UIControls.SetupUI(this, Setting_Click, Logout_Click);
        }


        private DataTable response_list;
        private void button2_Click(object sender, EventArgs e)
        {

            using var CheckProcessForm = new CheckFrm(this, lbl_operatorlogin.Text);

            CheckProcessForm.AfterScanned += (moid, segmentid, segmentname, processname, serialnumber, operatorName, token, processlist, subprocesslist) =>
        {
            string scannedSerial = serialnumber ?? string.Empty;
            string processType = segmentname ?? string.Empty;
            string Pname = processname ?? string.Empty;
            string MoId = moid ?? string.Empty;
            int _segmentID = segmentid;

            fulldisplaycontroll.OpenChildForm(new ProcessFrm(scannedSerial, _segmentID, MoId, processType, Pname, operatorName, token, processlist, subprocesslist), sender);
        };

            CheckProcessForm.ShowDialog(this);
        }


        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btn_home_Click(object sender, EventArgs e)
        {

            try
            {
                RegistrySupport_Operation registry = new RegistrySupport_Operation();
                String data = registry.Read(Def.REGKEY_SUB);
                if (data == null)
                {
                    data += String.Format($"BTC_ENTERPRISE<limiter>DEFualSection<limiter>DefualtCode<limiter>");
                    registry.Write(Def.REGKEY_SUB, data);
                }
                String[] programs = data.Split(new String[] { "<limiter1>" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String program in programs)
                {
                    String[] records = program.Split(new String[] { "<limiter>" }, StringSplitOptions.RemoveEmptyEntries);
                    if (records.Length >= 3)
                    {
                        var departmentName = records[0].Trim();
                        var processType = records[1].Trim();
                        if (processType != "101" && processType != "102")
                        {
                            fulldisplaycontroll.closeAForm();
                        }
                        else
                        {
                            Manage_SubAssy.closeAForm();
                            fulldisplaycontroll.OpenChildForm(new PerantFrm(), sender);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid data format in registry.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //fulldisplaycontroll.OpenChildForm(new PerantFrm(), sender);

        }

        private void warehouseRecievingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_SubAssy.OpenChildForm(new Warehousekitting(), sender);
        }

        private void kitlistRecievingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Manage_SubAssy.OpenChildForm(new KitlistRecieving(), sender);
        }
        private bool isSidebarExpanded = false;

        private void Btn_maximixe_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void settingimage_Click(object sender, EventArgs e)
        {

        }
    }
}
