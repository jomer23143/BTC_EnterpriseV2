using System.Reflection;
using BTC_EnterpriseV2.ProcessForm;
using BTCP_EnterpriseV2.Forms;
using BTCP_EnterpriseV2.YaoUI;

namespace BTC_EnterpriseV2.Modal
{
    public partial class ScannerModal : Form
    {
        public string serialnumber;
        public string id;
        public string processname;
        public string moid;
        public string segment;
        private Sub_AssyFrm mysubass;
        public ScannerModal(string id, string processname, string moid, string segement, Sub_AssyFrm subform)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            YUI yUI = new YUI();
            yUI.RoundedFormsDocker(this, 10);
            yUI.RoundedButton(button1, 8, Color.SteelBlue);
            yUI.RoundedTextBox(txt_serialnumber, 8, Color.White);
            this.id = id;
            this.processname = processname;
            this.moid = moid;
            this.segment = segement;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  mysubass.qrcodecontroller();
            // mysubass.response();
            this.Close();
        }

        private async void txt_serialnumber_KeyDown(object sender, KeyEventArgs e)
        {
            string? assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (assemblyLocation == null)
            {
                throw new InvalidOperationException("The assembly location could not be determined.");
            }

            string path = Path.Combine(assemblyLocation, "Assets/scanneddone.gif");

            if (File.Exists(path))
            {
                using (var img = new Bitmap(path))
                {
                    pbimage.Image?.Dispose();
                    pbimage.Image = new Bitmap(img);
                }
            }

            await Task.Delay(1000);

            this.Close();
            if (Application.OpenForms["MainDashboard"] is MainDashboard mainDashboard)
            {
                string serialnumber = txt_serialnumber.Text;
                string mo = moid;
                string toplvlipn = moid;
                string station = processname;
                //ProcessForm.Sub_assyfrm subasy = new ProcessForm.Sub_assyfrm(mo,serialnumber,toplvlipn,segment,station);
                //mainDashboard.LoadChildForm(subasy);
            }
        }
    }
}
