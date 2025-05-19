using BTC_EnterpriseV2.Forms;
using BTCP_EnterpriseV2.Forms;
namespace BTCP_EnterpriseV2.SideBar
{
    public partial class WarehouseKitingSidebar : Form
    {

        public WarehouseKitingSidebar()
        {
            InitializeComponent();
            YaoUI.YUI yui = new YaoUI.YUI();
            yui.RoundedButton(btn_warehousekiting, 8, Color.FromArgb(109, 180, 62));
            yui.RoundedButton(btn_ncticket, 8, Color.FromArgb(109, 180, 62));
            yui.RoundedButton(btn_abi, 8, Color.FromArgb(109, 180, 62));

        }
        private void Setting_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Settings clicked");
        }

        private void Logout_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void WarehouseKitingSidebar_Load(object sender, EventArgs e)
        {

        }

        private void WarehouseKitingSidebar_SizeChanged(object sender, EventArgs e)
        {
            YaoUI.YUI yui = new YaoUI.YUI();
            yui.RoundedButton(btn_warehousekiting, 8, Color.FromArgb(109, 180, 62));
            yui.RoundedButton(btn_ncticket, 8, Color.FromArgb(109, 180, 62));
            yui.RoundedButton(btn_abi, 8, Color.FromArgb(109, 180, 62));
        }

        private void btn_warehousekiting_Click(object sender, EventArgs e)
        {
#pragma warning disable CS8600 
            MainDashboard mainDashboard = (MainDashboard)Application.OpenForms["MainDashboard"];
#pragma warning restore CS8600
            Warehousekitting kitlist = new Warehousekitting();

            if (mainDashboard != null)
            {
                mainDashboard.LoadChildForm(kitlist);
            }
            else
            {
                MessageBox.Show("Main Dashboard not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ncticket_Click(object sender, EventArgs e)
        {

        }

        private void btn_abi_Click(object sender, EventArgs e)
        {

        }
    }
}
