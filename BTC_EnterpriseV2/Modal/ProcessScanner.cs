namespace BTC_EnterpriseV2.Modal
{
    public partial class ProcessScanner : Form
    {
        public string serialnumber;
        public string processname;
        public string moid;
        public int rowindex;
        public event Action<string?> SerialScanned = delegate { };
        public ProcessScanner(int rowindex)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.rowindex = rowindex;
        }

        private void ProcessScanner_Load(object sender, EventArgs e)
        {

        }

        private void txt_serialnumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SerialScanned?.Invoke(txt_serialnumber.Text);
                this.Close();
            }
        }
    }
}
