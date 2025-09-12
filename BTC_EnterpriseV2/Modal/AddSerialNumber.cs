using System.Data;
using System.Text;
using BTC_EnterpriseV2.Class;
using BTC_EnterpriseV2.Forms;
using BTCP_EnterpriseV2.YaoUI;
using Newtonsoft.Json;
using Syncfusion.Data.Extensions;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Interactivity;

namespace BTC_EnterpriseV2.Modal
{
    public partial class AddSerialNumber : Form
    {
        bool is_error = false;
        private int is_kit_list = 0;
        private DataTable list_data;
        string pick_quantity;
        int kit_list_item_id;
        int row_index;
        Forms.Warehouse_Kitting Warehousekitting;
        string ipn;
        public AddSerialNumber(DataTable list_Serial, string _pick_quantity,int _kit_list_item_id,int _row_index,string _ipn)
        {
            InitializeComponent();
            YUI yui = new YUI();
            this.StartPosition = FormStartPosition.CenterScreen;
            yui.RoundedButton(btnsave_serial, 6, Color.FromArgb(109, 180, 62));
            yui.RoundedButton(btn_close, 6, Color.Salmon);
            yui.RoundedFormsDocker(this, 12);
            // this.is_kit_list = is_kit_list;
            this.list_data = list_Serial;
            this.pick_quantity = _pick_quantity;
            this.kit_list_item_id = _kit_list_item_id;
            this.row_index = _row_index;
            this.ipn = _ipn;
        }

        private void AddSerialNumber_Load(object sender, EventArgs e)
        {
            bunifuloading.Hide();
            foreach (System.Data.DataRow item in list_data.Rows)
            {
                dgSerialnumber.Rows.Add(item["kit_list_part_serial_number"].ToString(), item["kit_list_item_id"].ToString());
            }
            int rows_count = dgSerialnumber.Rows.Count;
            label1.Text = String.Format("IPN : {0}",ipn );
            lbl_rowcount.Text = string.Format("{0} out of {1}", rows_count, pick_quantity);
            txtserial_number.Focus();
           

        }

        private async void btnsave_serial_Click(object sender, EventArgs e)
        {
            //for (int currentRow = 0; currentRow < dgSerialnumber.Rows.Count; currentRow++)
            //{
            //    string serial_number = dgSerialnumber.Rows[currentRow].Cells[colpart_serial.Name].Value.ToString() ?? string.Empty;

            //    for (int row = 0; row < dgSerialnumber.Rows.Count - 1; row++)
            //    {
            //        string serial_number_compare = dgSerialnumber.Rows[row].Cells[colpart_serial.Name].Value.ToString() ?? string.Empty;

            //        if (currentRow != row)
            //        {
            //            if (serial_number == serial_number_compare)
            //            {
            //                is_error = true;
            //                dgSerialnumber.Rows[currentRow].Cells[colpart_serial.Name].Style.BackColor = Color.Red;
            //                break;
            //            }
            //            else
            //            {
            //                dgSerialnumber.Rows[currentRow].Cells[colpart_serial.Name].Style.BackColor = Color.White;
            //            }
            //        }
            //    }
            //}
            //if (is_error)
            //{

            //    is_error = false;
            //    return;
            //}
            bunifuloading.Show();

            var list_serial_number = new List<Model.kitlist.serial_number>();
            foreach (DataGridViewRow item in dgSerialnumber.Rows)
            {
                Model.kitlist.serial_number data_serial_number = new Model.kitlist.serial_number
                {
                    kit_list_item_id = kit_list_item_id,
                    kit_list_part_serial_number = item.Cells[colpart_serial.Name].Value.ToString() ?? string.Empty
                };
                list_serial_number.Add(data_serial_number);
            }
            int res_qty = Convert.ToInt32(pick_quantity) - dgSerialnumber.Rows.Count;
            string comment = string.Empty;
            int kit_list_item_status_id;
            if (res_qty == 0)
            {
                comment = "OKAY";
                kit_list_item_status_id = 2;
            }
            else
            {
                comment = "LACKING";
                kit_list_item_status_id = 3;
            }
            var kit_list_item = new Model.kitlist.Root
            {
                kit_list_item_id = kit_list_item_id,
                short_quantity = Convert.ToInt32(pick_quantity) - dgSerialnumber.Rows.Count,
                kit_quantity = dgSerialnumber.Rows.Count,
                comment = comment,
                kit_list_item_status_id = kit_list_item_status_id,
                kit_list_item_serial = list_serial_number
            };

            string res = JsonConvert.SerializeObject(kit_list_item);
            string responseData = "";
           
            HttpResponseMessage response = new HttpResponseMessage();
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(res, Encoding.UTF8, "application/json");
                string save_serial_url = GlobalApi.GetSaveSerialUrl();
                response = await client.PostAsync(save_serial_url, content);
                responseData = await response.Content.ReadAsStringAsync();
                if (response.StatusCode.ToString() == "422")
                {
                    bunifuloading.Hide();
                }
                else
                {
                    bunifuloading.Hide();
                    var records = Warehouse_Kitting.instance.sfgrid.GetRecordAtRowIndex(row_index);
                    Warehouse_Kitting.instance.sfgrid.View.GetPropertyAccessProvider().SetValue(records, "kitted", dgSerialnumber.Rows.Count.ToString());
                    int short_qty = (Convert.ToInt32(Warehouse_Kitting.instance.sfgrid.View.GetPropertyAccessProvider().GetValue(records, "pick_quantity")) - Convert.ToInt32(Warehouse_Kitting.instance.sfgrid.View.GetPropertyAccessProvider().GetValue(records, "kitted")));
                    Warehouse_Kitting.instance.sfgrid.View.GetPropertyAccessProvider().SetValue(records, "short_quantity", short_qty.ToString());
                    Warehouse_Kitting.instance.sfgrid.View.GetPropertyAccessProvider().SetValue(records, "comment", short_qty == 0?"OKAY":"LACKING");
                    Warehouse_Kitting.instance.sfgrid.View.GetPropertyAccessProvider().SetValue(records, "item_status", short_qty == 0 ? "COMPLETE" : "LACKING");
                    Warehouse_Kitting.instance.sfgrid.Refresh();
                    this.Close();
                    MessageBox.Show("Saved Serial Number");;
                }
            }
        }

        private void dgSerialnumber_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView ?? new DataGridView();
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

        private void txtserial_number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (DataGridViewRow item in dgSerialnumber.Rows)
                {
                    if (item.Cells["colpart_serial"]?.Value.ToString() == txtserial_number.Text.ToUpper().Trim())
                    {
                        MessageBox.Show("Already Added");
                        return;
                    }
                }
                int rows_count = dgSerialnumber.Rows.Count;
                if (rows_count == Convert.ToUInt32(pick_quantity))
                {
                    MessageBox.Show("You have reached the maximum pick quantity.");
                    return;
                }
                dgSerialnumber.Rows.Add(txtserial_number.Text.ToUpper().Trim(), kit_list_item_id);
                lbl_rowcount.Text = string.Format("{0} out of {1}", rows_count + 1, pick_quantity);
                txtserial_number.Clear();
                txtserial_number.Focus();
                txtserial_number.SelectAll();

            }
        }
    }
}
