using System.Text;
using BTC_EnterpriseV2.Forms;
using BTCP_EnterpriseV2.YaoUI;
using Newtonsoft.Json;

namespace BTC_EnterpriseV2.Modal
{
    public partial class AddSerialNumber : Form
    {
        bool is_error = false;
        public AddSerialNumber()
        {
            InitializeComponent();
            YUI yui = new YUI();
            this.StartPosition = FormStartPosition.CenterScreen;
            yui.RoundedButton(btnsave_serial, 6, Color.FromArgb(109, 180, 62));
            yui.RoundedButton(btn_close, 6, Color.Salmon);
            yui.RoundedFormsDocker(this, 12);
        }

        private void AddSerialNumber_Load(object sender, EventArgs e)
        {
            bunifuloading.Hide();
            dgSerialnumber.DataSource = Warehousekitting.list_serial;
            //if (dgSerialnumber.Rows.Count > 1 )
            //    dgSerialnumber.Rows[0].Cells[0].Selected = false;
            //dgSerialnumber.Rows[dgSerialnumber.RowCount - 1].Selected = true;
            label1.Text = String.Format("IPN : {0}", Warehousekitting.kit_list_item_ipn);
        }

        private async void btnsave_serial_Click(object sender, EventArgs e)
        {
            for (int currentRow = 0; currentRow < dgSerialnumber.Rows.Count - 1; currentRow++)
            {
                string serial_number = dgSerialnumber.Rows[currentRow].Cells[colpart_serial.Name].Value.ToString();
                //string ipn = dgSerialnumber.Rows[currentRow].Cells[colipn.Name].Value.ToString();
                for (int row = 0; row < dgSerialnumber.Rows.Count - 1; row++)
                {
                    string serial_number_compare = dgSerialnumber.Rows[row].Cells[colpart_serial.Name].Value.ToString();
                    // string ipn_compare = dgSerialnumber.Rows[row].Cells[colipn.Name].Value.ToString();
                    if (currentRow != row)
                    {
                        if (serial_number == serial_number_compare)
                        {
                            is_error = true;
                            dgSerialnumber.Rows[currentRow].Cells[colpart_serial.Name].Style.BackColor = Color.Red;
                            break;
                        }
                        else
                        {
                            dgSerialnumber.Rows[currentRow].Cells[colpart_serial.Name].Style.BackColor = Color.White;
                        }
                    }
                }
            }
            if (is_error)
            {
                //MessageBox.Show($@"Duplicate Serial", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                is_error = false;
                return;
            }
            bunifuloading.Show();
            List<Model.kitlist.serial_number> list_serial_number = new List<Model.kitlist.serial_number>();
            foreach (DataGridViewRow item in dgSerialnumber.Rows)
            {
                if (item.IsNewRow)
                    continue;
                Model.kitlist.serial_number data_serial_number = new Model.kitlist.serial_number
                {
                    kit_list_item_id = Warehousekitting.kit_list_item_id,
                    kit_list_part_serial_number = item.Cells[colpart_serial.Name].Value.ToString()
                };
                list_serial_number.Add(data_serial_number);
            }
            Model.kitlist.add_serial_number list = new Model.kitlist.add_serial_number
            {
                kit_list_item_serial = list_serial_number
            };
            string res = JsonConvert.SerializeObject(list);
            string responseData = "";
            HttpResponseMessage response = new HttpResponseMessage();
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(res, Encoding.UTF8, "application/json");

                response = await client.PostAsync("https://app.btcp-enterprise.com/api/serial/save-serial", content);
                responseData = await response.Content.ReadAsStringAsync();
                if (response.StatusCode.ToString() == "422")
                {
                    bunifuloading.Hide();
                }
                else
                {
                    bunifuloading.Hide();
                    MessageBox.Show("Saved Serial Number");
                }
            }
        }

        private void dgSerialnumber_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowindx = (e.RowIndex + 1).ToString();
            var centerformat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowindx, this.Font, SystemBrushes.ControlText, headerBounds, centerformat);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close?. Closing this form without saving the data can cause cancer to user.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }

        }
    }
}
