using System.Data;
using System.Text;
using BTC_EnterpriseV2.Forms;
using BTCP_EnterpriseV2.YaoUI;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;

namespace BTC_EnterpriseV2.Modal
{
    public partial class ScanSerialNumber : Form
    {
        Forms.Warehousekitting Kitlistfrm;
        string id = "";
        public int _rowid;
        int total_count = 1;
        DataTable dt_serials;
        DialogResult dr = DialogResult.Cancel;
        public ScanSerialNumber(Warehousekitting kitlist, int rowid,DataTable dtSerials)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            YUI yui = new YUI();
            yui.RoundedFormsDocker(this, 8);
            yui.RoundedButton(btnsave_serial, 6, Color.FromArgb(109, 180, 62));
            yui.RoundedTextBox(txtserial_number, 6, Color.White);
            txtserial_number.Focus();
            this.Kitlistfrm = kitlist;
            this._rowid = rowid;
            dt_serials = dtSerials;
        }

        private void ScanSerialNumber_Load(object sender, EventArgs e)
        {
            //id = Forms.Warehousekitting.kit_list_item_id.ToString();
            //label1.Text = string.Format("IPN : {0}", Forms.Warehousekitting.kit_list_item_ipn);
            //foreach (DataRow item in Forms.Warehousekitting.list_serial.Rows)
            //{
            //    if (item["is_scan"].ToString() == "1")
            //    {
            //        total_count++;
            //    }
            //}
           
            //dgSerialnumber.DataSource = Forms.Warehousekitting.list_serial;
            load_serials();
            is_scan_initialize_datagridviewrows();
            txtserial_number.Focus();
        }
        private void load_serials()
        {
            dgSerialnumber.DataSource= dt_serials;

        }
        private void is_scan_initialize_datagridviewrows()
        {
            for (int currenrow = 0; currenrow < dgSerialnumber.Rows.Count; currenrow++)
            {
                var value = dgSerialnumber.Rows[currenrow].Cells[coliscan.Name].Value;

                if (value != null && value.ToString() == "1")
                {
                    lbl_rowcount.Text = string.Format("{0} out of {1}", total_count++, Forms.Warehousekitting.total_pick_quantity);
                    dgSerialnumber.Rows[currenrow].Cells[colscan.Name].Value = 1;
                }
                else
                {
                    dgSerialnumber.Rows[currenrow].Cells[colscan.Name].Value = 0;
                }
            }
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
           dr= DialogResult.OK;
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
