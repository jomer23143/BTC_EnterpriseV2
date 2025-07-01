using System.Data;
using System.Text;
using BTC_EnterpriseV2.Forms;
using BTCP_EnterpriseV2.YaoUI;
using Newtonsoft.Json;

namespace BTC_EnterpriseV2.Modal
{
    public partial class ScanSerialNumber : Form
    {
        Forms.Warehousekitting Kitlistfrm;
        string id = "";
        public int _rowid;
        private DataTable list_data;
        public ScanSerialNumber(DataTable data_list, int rowid)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            YUI yui = new YUI();
            yui.RoundedFormsDocker(this, 8);
            yui.RoundedButton(btnsave_serial, 6, Color.FromArgb(109, 180, 62));
            yui.RoundedTextBox(txtserial_number, 6, Color.White);
            txtserial_number.Focus();
            //this.Kitlistfrm = kitlist;
            this.list_data = data_list;
            this._rowid = rowid;
        }

        private void ScanSerialNumber_Load(object sender, EventArgs e)
        {
            id = Forms.Warehousekitting.kit_list_item_id.ToString();
            label1.Text = string.Format("IPN : {0}", Forms.Warehousekitting.kit_list_item_ipn);
            lbl_rowcount.Text = string.Format("0 out of {0}", Forms.Warehousekitting.total_pick_quantity);
            //dgSerialnumber.DataSource = Forms.Warehousekitting.list_serial;
            dgSerialnumber.DataSource = list_data;
            is_scan_initialize_datagridviewrows();
            txtserial_number.Focus();
        }

        private void is_scan_initialize_datagridviewrows()
        {
            int scancount = 0;

            for (int currentRow = 0; currentRow < dgSerialnumber.Rows.Count; currentRow++)
            {
                var value = dgSerialnumber.Rows[currentRow].Cells[coliscan.Name].Value;

                if (value != null && value.ToString() == "1")
                {
                    dgSerialnumber.Rows[currentRow].Cells[colscan.Name].Value = 1;
                    scancount++;
                }
                else
                {
                    dgSerialnumber.Rows[currentRow].Cells[colscan.Name].Value = 0;
                }
            }

            lbl_rowcount.Text = $"{scancount} out of {Forms.Warehousekitting.total_pick_quantity}";
        }


        int scan_qty = 0;

        private void txtserial_number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (DataGridViewRow row in dgSerialnumber.Rows)
                {
                    if (row.Cells[colpart_serial.Name].Value.ToString() == txtserial_number.Text)
                    {
                        if (Convert.ToBoolean(row.Cells[colscan.Name].Value) == false)
                        {
                            row.Cells[colscan.Name].Value = CheckState.Checked;
                            scan_qty = 1 + scan_qty;
                            lbl_rowcount.Text = string.Format("{0} of out {1}", scan_qty, Forms.Warehousekitting.total_pick_quantity);
                            //foreach (DataGridViewRow item in Kitlistfrm.dataGridView1.Rows)
                            //{
                            //    if (item.Cells[26].Value.ToString() == id)
                            //    {
                            //        item.Cells[26].Value = scan_qty;
                            //    }
                            //}
                        }
                        else
                        {
                            MessageBox.Show("Already Scan");
                        }
                    }
                }
                txtserial_number.SelectAll();
            }
        }

        private async void btnsave_serial_Click(object sender, EventArgs e)
        {
            List<Model.kitlist.serial_details> list_serial_details = new List<Model.kitlist.serial_details>();
            foreach (DataGridViewRow row in dgSerialnumber.Rows)
            {
                Model.kitlist.serial_details data = new Model.kitlist.serial_details()
                {
                    id = Convert.ToInt32(row.Cells[colid.Name].Value.ToString()),
                    is_scan = Convert.ToBoolean(row.Cells[colscan.Name].Value) == true ? 1 : 0
                };
                list_serial_details.Add(data);
            }
            Model.kitlist.scan_serial scan_Serial = new Model.kitlist.scan_serial()
            {
                kit_list_item_serial = list_serial_details
            };
            string json = JsonConvert.SerializeObject(scan_Serial);
            string responseData = "";
            HttpResponseMessage response = new HttpResponseMessage();
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                response = await client.PostAsync($@"https://app.btcp-enterprise.com/api/kit-list-item-serial/scan-serial", content);
                responseData = await response.Content.ReadAsStringAsync();
            }
            for (int i = 0; i < Kitlistfrm.dataGridView1.Rows.Count; i++)
            {
                if (Kitlistfrm.dataGridView1.Rows[i].Cells["colid"].Value.ToString() == _rowid.ToString())
                {
                    Kitlistfrm.dataGridView1.Rows[i].Cells["colkitted"].Value = scan_qty;
                }
            }

        }

        private async void refresh_modetails()
        {
            string url = $"https://app.btcp-enterprise.com/api/kit-list-item?mo_id={Warehousekitting.mo_number}&per_row=9999";
            string modetails = await GetMohDetails(url);
            Model.kitlist.GetData model_modetails = JsonConvert.DeserializeObject<Model.kitlist.GetData>(modetails);
            string res3 = JsonConvert.SerializeObject(model_modetails.data);
            List<Model.kitlist.manufacturing_order_items> model = (List<Model.kitlist.manufacturing_order_items>)JsonConvert.DeserializeObject(res3, typeof(List<Model.kitlist.manufacturing_order_items>));
            Kitlistfrm.dataGridView1.DataSource = model;
        }
        private async Task<string> GetMohDetails(string url)
        {
            DataTable dt = new DataTable();
            string responseData = "";
            await Task.Run(async () =>
            {

                using (HttpClient client = new HttpClient())
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(url),
                        //Content = new StringContent(data, Encoding.UTF8, "application/json")
                    };
                    HttpResponseMessage response = await client.SendAsync(request);
                    responseData = await response.Content.ReadAsStringAsync();
                }
            });
            return responseData;
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

        private void dgSerialnumber_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtserial_number.Focus();
        }

        private void dgSerialnumber_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtserial_number.Focus();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
