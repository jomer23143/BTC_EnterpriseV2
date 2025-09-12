using BTC_EnterpriseV2.Class;
using BTC_EnterpriseV2.Utillities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTC_EnterpriseV2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var apiUrl = GlobalApi.GetLogin();
                var data = new Dictionary<string, object>
                {
                    { "rfid_no", textBox1.Text.Trim() }
                };
                var json_token = await ApiHelper.PostJsonAsync(apiUrl, data);
                var json_object = json_token?.ToObject<Model.LoginToken.Root>();

                // Ensure json_object is not null before accessing its properties
                if (json_object != null)
                {
                    Global.UserToken = json_object.token?.ToString();

                    var user_license = json_object?.user?.employee?.licenses?.Where(x => x.is_active == 1).ToList();
                    var dt_license = new List<Global.license>();
                    foreach (var item in user_license)
                    {
                        var license_name = new Global.license
                        {
                            id = item.id,
                            employee_id = item.employee_id,
                            license_id = item.license_id,
                            license_name = item.license?.name,
                            license_no = item.license?.license_no,
                            license_type_id = item.license?.license_type_id ?? 0,
                            license_type_name = item.license?.license_type?.name
                        };
                        dt_license.Add(license_name);
                    }
                    Global.dt_license = dt_license;
                   DialogResult = DialogResult.OK;
                }
                else
                {
                    // Handle the case where json_object is null (optional)
                    Global.UserToken = "null";
                    DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}
