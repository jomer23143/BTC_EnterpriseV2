using BTC_EnterpriseV2.Forms;
using BTCP_EnterpriseV2.Forms;

namespace BTC_EnterpriseV2.SideBar
{
    public partial class MainSidebar : Form
    {
        public MainSidebar()
        {
            InitializeComponent();
        }

        private void btn_printqr_Click(object sender, EventArgs e)
        {
            MainDashboard? mainDashboard = Application.OpenForms.OfType<MainDashboard>().FirstOrDefault();

            PrintQRFrm printqr = new PrintQRFrm();

            if (mainDashboard != null)
            {
                mainDashboard.LoadChildForm(printqr);
            }
            else
            {
                MessageBox.Show("Main Dashboard not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
