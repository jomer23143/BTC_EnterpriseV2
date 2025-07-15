using BTC_EnterpriseV2.Utillities;
using BTCP_EnterpriseV2;
using BTCP_EnterpriseV2.YaoUI;

namespace BTC_EnterpriseV2.Settings
{
    public partial class setupfrm : Form
    {
        public setupfrm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            YUI yUI = new YUI();
            yUI.RoundedFormsDocker(this, 10);
            yUI.RoundedButton(btn_save, 6, Color.FromArgb(17, 40, 86));
        }


        private void LoadData()
        {
            try
            {
                RegistrySupport_Operation registry = new RegistrySupport_Operation();
                String data = registry.Read(Def.REGKEY_SUB);
                if (data == null)
                {
                    data += String.Format($"BTC_ENTERPRISE<limiter>DEFualSection<limiter>DefualtCode<limiter>");
                    registry.Write(Def.REGKEY_SUB, data);
                }
                String[] programs = data.Split(new String[] { "<limiter1>" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String program in programs)
                {
                    String[] records = program.Split(new String[] { "<limiter>" }, StringSplitOptions.RemoveEmptyEntries);
                    //setup_grid.Rows.Add(records);
                    if (records.Length >= 3)
                    {
                        txtname.Text = records[0].Trim();
                        txtcode.Text = records[1].Trim();

                    }
                    else
                    {
                        MessageBox.Show("Invalid data format in registry.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setupfrm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            String data = "";

            String sectname = txtname.Text.Trim();
            String sectCode = txtcode.Text.Trim();
            String projectName = "BTC_ENTERPRISE";
            if (sectname.Length == 0 || sectCode.Length == 0)
            {
                MessageBox.Show("Please enter a valid section name and code.");
                return;
            }
            data += String.Format("{0}<limiter>{1}<limiter>{2}<limiter>", sectname, sectCode, projectName);

            RegistrySupport_Operation registry = new RegistrySupport_Operation();
            if (registry.Write(Def.REGKEY_SUB, data))
            {
                Close();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
