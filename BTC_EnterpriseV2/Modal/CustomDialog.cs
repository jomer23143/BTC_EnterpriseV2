namespace BTC_EnterpriseV2.Modal
{
    public partial class CustomDialog : Form
    {
        public DialogResult Result { get; private set; }

        public CustomDialog(string title, string message)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;

            lblTitle.Text = title;
            lblMessage.Text = message;

            // Rounded corners
            this.Paint += (s, e) =>
            {
                var radius = 20;
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
                path.CloseAllFigures();
                this.Region = new Region(path);
            };
        }

        private void CustomDialog_Load(object sender, EventArgs e)
        {

        }

        private void btn_proceed_Click(object sender, EventArgs e)
        {
            this.Result = DialogResult.OK;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Result = DialogResult.Cancel;
            this.Close();
        }
    }
}
