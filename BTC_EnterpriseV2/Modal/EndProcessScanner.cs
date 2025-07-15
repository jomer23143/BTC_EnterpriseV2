using BTCP_EnterpriseV2.YaoUI;

namespace BTC_EnterpriseV2.Modal
{
    public partial class EndProcessScanner : Form
    {

        private YUI yui = new YUI();
        public event Action<string?> rfidScaned = delegate { };
        public EndProcessScanner()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            yui.RoundedFormsDocker(this, 10);
            txt_rfid.Select();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_rfid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rfidScaned?.Invoke(txt_rfid.Text);
                //  MessageBox.Show("RFID Scanned: " + txt_rfid.Text, "RFID Scan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
