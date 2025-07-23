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
            //lbl_departmemnt.Text = ;
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
            this.Close();
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
                            case "1":
                                btn_subasemble.Visible = false;
                                lbl_departmemnt.Text = departmentName;
                                fulldisplaycontroll.OpenChildForm(new PerantFrm(), sender);
                                break;
                            case "2":
                                btn_subasemble.Visible = false;
                                lbl_departmemnt.Text = departmentName;
                                fulldisplaycontroll.OpenChildForm(new PerantFrm(), sender);
                                break;
                            case "3":
                                fulldisplaycontroll.closeAForm();
                                Manage_SubAssy.Reset();
                                btn_subasemble.Visible = true;
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "4":
                                fulldisplaycontroll.closeAForm();
                                Manage_SubAssy.Reset();
                                btn_subasemble.Visible = true;
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "5":
                                fulldisplaycontroll.closeAForm();
                                Manage_SubAssy.Reset();
                                btn_subasemble.Visible = true;
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "6":
                                btn_subasemble.Visible = true;
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
                            case "10":
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "11":
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
            using var scannerForm = new SubAssy_Serial_Scanner();

            string scannedSerial = string.Empty;
            string processType = string.Empty;


            scannerForm.SerialScanned += async (serial, processtype, itemsTable, id, processname, stationame) =>
            {
                scannedSerial = serial ?? string.Empty;
                processType = processtype ?? string.Empty;
                response_list = itemsTable ?? new DataTable("thedata");
                var ids = id;
                switch (processType)
                {
                    case "1":
                        // Handle process type 001 for Warehouse

                        break;

                    case "2":
                        // Handle process type 002 for kitlist Reciving

                        break;
                    case "3":
                        // Handle process type 3 for Sub Assembly segment 1 for sub assymble
                        fulldisplaycontroll.OpenChildForm(new Sub_AssyFrm(scannedSerial, response_list, 1, "Sub_Assembly"), sender);
                        break;
                    case "4":
                        fulldisplaycontroll.OpenChildForm(new Sub_AssyFrm(scannedSerial, response_list, 2, processname), sender);

                        break;
                    case "5":
                        fulldisplaycontroll.OpenChildForm(new Sub_AssyFrm(scannedSerial, response_list, 3, processname), sender);
                        break;
                    case "6":
                        fulldisplaycontroll.OpenChildForm(new Sub_AssyFrm(scannedSerial, response_list, 4, processname), sender);
                        break;
                    case "7":
                        fulldisplaycontroll.OpenChildForm(new Sub_AssyFrm(scannedSerial, response_list, 5, processname), sender);
                        break;
                    case "8":
                        fulldisplaycontroll.OpenChildForm(new Sub_AssyFrm(scannedSerial, response_list, 6, processname), sender);
                        break;
                    case "9":
                        fulldisplaycontroll.OpenChildForm(new Sub_AssyFrm(scannedSerial, response_list, 7, processname), sender);
                        break;
                    case "10":
                        fulldisplaycontroll.OpenChildForm(new Sub_AssyFrm(scannedSerial, response_list, 8, processname), sender);
                        break;
                    case "11":
                        fulldisplaycontroll.OpenChildForm(new Sub_AssyFrm(scannedSerial, response_list, 9, processname), sender);
                        break;

                    default:
                        MessageBox.Show("Invalid process type selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

            };

            scannerForm.ShowDialog(this);
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
                        if (processType != "1" && processType != "2")
                        {
                            Manage_SubAssy.closeAForm();
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
