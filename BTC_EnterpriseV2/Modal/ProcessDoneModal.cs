using BTC_EnterpriseV2.ProcessForm;
using BTC_EnterpriseV2.YaoUI;
using BTCP_EnterpriseV2.Forms;

namespace BTC_EnterpriseV2.Modal
{
    public partial class ProcessDoneModal : Form
    {
        public DialogResult Result { get; set; }
        private Manage_SubAssy Manage_SubAssy;
        public ProcessDoneModal(string processname)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            lbl_processname.Text = processname;
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Result = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Result = DialogResult.OK;
            this.Close();
        }

        private void btn_proceed_preassy_Click(object sender, EventArgs e)
        {
            MainDashboard? mainDashboard = Application.OpenForms.OfType<MainDashboard>().FirstOrDefault();

            Pre_AssyFrm preasy = new Pre_AssyFrm();

            if (mainDashboard != null)
            {
                mainDashboard.Load_MainPanel(preasy);
                this.Close();
            }
            else
            {
                MessageBox.Show("Main Dashboard not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
