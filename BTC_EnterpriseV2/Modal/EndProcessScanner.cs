namespace BTC_EnterpriseV2.Modal
{
    public partial class EndProcessScanner : Form
    {
        public event Action<string?> SerialScanned = delegate { };
        string apiUrl = "https://app.btcp-enterprise.com/api/login-production";
        public EndProcessScanner()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void txt_serialnumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SerialScanned?.Invoke(txt_serialnumber.Text);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
