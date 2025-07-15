using System.Data;
using BTC_EnterpriseV2.Class;
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
            //PasswordForm passwordForm = new PasswordForm();
            //passwordForm.StartPosition = FormStartPosition.CenterScreen;
            //passwordForm.ShowDialog(this);
            //this.Close();
            setupfrm setupForm = new setupfrm();
            setupForm.StartPosition = FormStartPosition.CenterScreen;
            setupForm.ShowDialog(this);

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
            DragForm.ReleaseCapture();
            DragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private async void MainDashboard_Load(object sender, EventArgs e)
        {
            LoadDataRegistry();
            fulldisplaycontroll.OpenChildForm(new PerantFrm(), sender);

        }


        private void LoadDataRegistry()
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
                    //setup_grid.Rows.Add(records);
                    if (records.Length >= 3)
                    {

                        switch (processType = records[1].Trim())
                        {
                            case "001":
                                lbl_departmemnt.Text = "-Warehouse Kitting-";
                                break;
                            case "002":
                                lbl_departmemnt.Text = "-Kitlist Reciving-";
                                break;
                            case "003":
                                lbl_departmemnt.Text = "-Sub Assembly-";
                                break;
                            case "004":
                                lbl_departmemnt.Text = "-Pre Assembly-";
                                break;
                            case "005":
                                lbl_departmemnt.Text = "-Rain Test-";
                                break;
                            case "006":
                                lbl_departmemnt.Text = "-Main Assembly-";
                                break;
                            case "007":
                                lbl_departmemnt.Text = "-In - Station QC-";
                                break;
                            case "008":
                                lbl_departmemnt.Text = "-EQL Test-";
                                break;
                            case "009":
                                lbl_departmemnt.Text = "-Final Assembly-";
                                break;
                            case "010":
                                lbl_departmemnt.Text = "-Final QC-";
                                break;
                            case "011":
                                lbl_departmemnt.Text = "-Final Packing-";
                                break;
                            default:
                                lbl_departmemnt.Text = "-Unknown Process Type-";
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


            scannerForm.SerialScanned += async (serial, processtype, itemsTable, id) =>
            {
                scannedSerial = serial ?? string.Empty;
                processType = processtype ?? string.Empty;
                response_list = itemsTable ?? new DataTable("thedata");
                var ids = id;


                switch (processType)
                {
                    case "001":
                        // Handle process type 001 for Warehouse

                        break;

                    case "002":
                        // Handle process type 002 for kitlist Reciving

                        break;
                    case "003":
                        // Handle process type 3 for Sub Assembly
                        fulldisplaycontroll.OpenChildForm(new Sub_AssyFrm(scannedSerial, response_list), sender);
                        break;
                    case "004":
                        // Handle process type 4 for Pre Assembly
                        Pre_Assy_Prerequeset_Handler pre_Assy_Prerequeset_Handler = new Pre_Assy_Prerequeset_Handler();
                        int dataresponse = await pre_Assy_Prerequeset_Handler.CheckPrerequesit(scannedSerial, 1, 1);
                        if (dataresponse == 1)
                        {
                            fulldisplaycontroll.OpenChildForm(new Pre_AssyFrm(ids, scannedSerial), sender);
                        }
                        else if (dataresponse == 0)
                        {
                            new CustomeAlert("Pre Assymble Warning", "Pre-requesite Holster is not yet done in Sub Assymble. 😌 ", CustomeAlert.Alertype.Warning).ShowDialog();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong.");
                        }

                        break;
                    case "005":
                        // Handle process type 5 for Rain Test
                        //  fulldisplaycontroll.OpenChildForm(new SubAssy_RecievingFrm(scannedSerial, response_list), sender);
                        break;
                    case "006":
                        // Handle process type 6 for Main Assembly
                        // fulldisplaycontroll.OpenChildForm(new SubAssy_RecievingFrm(scannedSerial, response_list), sender);
                        break;
                    case "007":
                        // Handle process type 7 for In - Station QC
                        //  fulldisplaycontroll.OpenChildForm(new SubAssy_RecievingFrm(scannedSerial, response_list), sender);
                        break;
                    case "008":
                        // Handle process type 8 for EQL Test
                        // fulldisplaycontroll.OpenChildForm(new SubAssy_RecievingFrm(scannedSerial, response_list), sender);
                        break;

                    case "009":
                        // Handle process type 9 for Final Assembly
                        //  fulldisplaycontroll.OpenChildForm(new FinalAssyFrm(scannedSerial, response_list), sender);
                        break;
                    case "010":
                        // Handle process type 10 for Final QC
                        // fulldisplaycontroll.OpenChildForm(new FinalQCFrm(scannedSerial, response_list), sender);
                        break;
                    case "011":
                        // Handle process type 11 for Final Packing
                        // fulldisplaycontroll.OpenChildForm(new FinalPackingFrm(scannedSerial, response_list), sender);
                        break;

                    default:
                        MessageBox.Show("Invalid process type selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                // Optional: open next form
                // Manage_SubAssy.OpenChildForm(new Sub_AssyFrm(scannedSerial), sender);
            };

            scannerForm.ShowDialog(this);
        }


        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            Manage_SubAssy.closeAForm();
            fulldisplaycontroll.OpenChildForm(new PerantFrm(), sender);

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
