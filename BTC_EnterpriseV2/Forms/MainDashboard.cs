using System.Data;
using BTC_EnterpriseV2.Forms;
using BTC_EnterpriseV2.Modal;
using BTC_EnterpriseV2.ProcessForm;
using BTC_EnterpriseV2.SideBar;
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
            passwordForm.ShowDialog(this);
            //this.Close();
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

        private async void MainDashboard_Load(object sender, EventArgs e)
        {
            fulldisplaycontroll.OpenChildForm(new PerantFrm(), sender);

        }

        private void panel_main_display_SizeChanged(object sender, EventArgs e)
        {
            UIControls.SetupUI(this, Setting_Click, Logout_Click);
        }


        private DataTable response_list = new DataTable("response_list");

        private void button2_Click(object sender, EventArgs e)
        {

            var segmentname = "Sub Assembly";
            SubAssy_Serial_Scanner showScanner = new SubAssy_Serial_Scanner(segmentname);

            var scannedSerial = string.Empty;
            object[] responsedata = Array.Empty<object>(); // or default init
            string boomid = string.Empty;

            // Subscribe to SerialScanned
            showScanner.SerialScanned += (serial) =>
            {
                scannedSerial = Convert.ToString(serial);
                // Manage_SubAssy.OpenChildForm(new Sub_AssyFrm(scannedSerial, response_list), sender);
                fulldisplaycontroll.OpenChildForm(new Sub_AssyFrm(scannedSerial, response_list), sender);
            };


            this.FormBorderStyle = FormBorderStyle.None;
            showScanner.ShowDialog(this);
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


    }
}
