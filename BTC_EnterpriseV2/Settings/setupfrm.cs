using BTC_EnterpriseV2.Utillities;
using BTCP_EnterpriseV2;
using BTCP_EnterpriseV2.Forms;
using BTCP_EnterpriseV2.YaoUI;

namespace BTC_EnterpriseV2.Settings
{
    public partial class setupfrm : Form
    {
        private readonly MainDashboard _mainDashboard;
        public setupfrm(MainDashboard mainDashboard)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            YUI yUI = new YUI();
            yUI.RoundedFormsDocker(this, 10);
            yUI.RoundedButton(btn_save, 6, Color.FromArgb(17, 40, 86));
            _mainDashboard = mainDashboard;
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
                        lbl_deptname.Text = records[0].Trim();
                        cmb_code.Text = records[1].Trim();

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

            String sectname = lbl_deptname.Text.Trim();
            String sectCode = cmb_code.Text.Trim();
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

        private void cmb_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValue = cmb_code.SelectedItem?.ToString() ?? cmb_code.Text;
            DictionaryBuilder Dbuilder = new DictionaryBuilder();
            if (Dbuilder.CodeNameMap.TryGetValue(selectedValue, out string sectionName))
            {
                lbl_deptname.Text = sectionName;
                _mainDashboard.lbl_departmemnt.Text = sectionName;
            }
            else
            {
                lbl_deptname.Text = "Unknown Section";
            }
        }

    }
}