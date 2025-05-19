using BTC_EnterpriseV2.Forms;
using BTCP_EnterpriseV2.Forms;
using BTCP_EnterpriseV2.YaoUI;

namespace BTC_EnterpriseV2.SideBar
{
    public partial class Kitlist_Sidebar : Form
    {
        public Kitlist_Sidebar()
        {
            InitializeComponent();
            YUI yUI = new YUI();
            yUI.RoundedButton(btn_kitlist, 8, Color.FromArgb(109, 180, 62));
            yUI.RoundedButton(btn_ncticket, 8, Color.FromArgb(109, 180, 62));
            yUI.RoundedButton(btn_abi, 8, Color.FromArgb(109, 180, 62));
        }

        private void btn_kitlist_Click(object sender, EventArgs e)
        {
            // Use 'OfType' to safely cast and find the form
            MainDashboard? mainDashboard = Application.OpenForms.OfType<MainDashboard>().FirstOrDefault();

            KitlistRecieving kitlist = new KitlistRecieving();

            if (mainDashboard != null)
            {
                mainDashboard.LoadChildForm(kitlist);
            }
            else
            {
                MessageBox.Show("Main Dashboard not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Kitlist_Sidebar_SizeChanged(object sender, EventArgs e)
        {
            YUI yUI = new YUI();
            yUI.RoundedButton(btn_kitlist, 8, Color.FromArgb(109, 180, 62));
            yUI.RoundedButton(btn_ncticket, 8, Color.FromArgb(109, 180, 62));
            yUI.RoundedButton(btn_abi, 8, Color.FromArgb(109, 180, 62));
        }
    }
}
