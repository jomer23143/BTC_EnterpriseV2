using BTCP_EnterpriseV2.YaoUI;

namespace BTC_EnterpriseV2.ABI
{
    public partial class ABI_Frm : Form
    {
        public ABI_Frm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            YUI yui = new YUI();
            yui.RoundedFormsDocker(this, 8);

        }

        private void ABI_Frm_Load(object sender, EventArgs e)
        {

        }
    }
}
