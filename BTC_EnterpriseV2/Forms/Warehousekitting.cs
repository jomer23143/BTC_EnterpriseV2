using System.Data;
using System.Text;
using BTC_EnterpriseV2.Class;
using BTC_EnterpriseV2.Modal;
using BTCP_EnterpriseV2;
using BTCP_EnterpriseV2.YaoUI;
using Newtonsoft.Json;

namespace BTC_EnterpriseV2.Forms
{
    public partial class Warehousekitting : Form
    {
        private Dictionary<String, Dictionary<String, String>> dbConnectionSettings = new Dictionary<String, Dictionary<String, String>>();
        string next_page = "";
        string prev_page = "";
        public Point downPoint = Point.Empty;
        int kit_list_id1 = 0;
        public static int kit_list_item_id = 0;
        public static string kit_list_item_ipn = "";
        public static int total_pick_quantity = 0;
        public static DataTable list_serial = null;
        public static string mo_number = "";
        int rowid;
        DataSet GetMoheaderDetails = new DataSet();

        public Warehousekitting()
        {
            InitializeComponent();
            YUI yui = new YUI();
            yui.RoundedButton(btncomplete, 8, Color.FromArgb(109, 180, 62));
            yui.RoundedButton(btncomplete, 8, Color.FromArgb(109, 180, 62));
            yui.RoundedButton(btnserial, 8, Color.FromArgb(109, 180, 62));
            yui.RoundedButton(btnnext, 8, Color.FromArgb(109, 180, 62));
            yui.RoundedButton(btnprevious_page, 8, Color.FromArgb(109, 180, 62));
            yui.RoundedButton(btnscan, 8, Color.Teal);
            yui.RoundedButton(btnAddSerial, 8, Color.Teal);
            txtserial_number.Visible = false;
            label3.Visible = false;
            list_serial = null;
            list_serial = new DataTable("list_of_seials");
            list_serial.Columns.Add("id");
            list_serial.Columns.Add("kit_list_part_serial_number");
            list_serial.Columns.Add("is_scan");
        }



        private void Warehousekitting_Load(object sender, EventArgs e)
        {
            txtmo_number.Focus();
            bunifuloading.Hide();
            btnserial.Visible = false;
            btncomplete.Visible = false;
            btnincomplete.Visible = false;
            btnnext.Enabled = false;
            btnprevious_page.Enabled = false;
            btnnext.Visible = false;
            btnprevious_page.Visible = false;
            Connection.InitializeConnection();
            dbConnectionSettings = Utils.DBConnection;
        }

        private void txtmo_number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuloading.Show();
                PostData();
            }
        }

        private async void PostData()
        {
            try
            {
                GetMoheaderDetails = KitList.GetMohDetails_DS(txtmo_number.Text);
                if (GetMoheaderDetails == null || GetMoheaderDetails.Tables.Count < 2 || GetMoheaderDetails.Tables[1].Rows.Count == 0)
                {
                    MessageBox.Show("No data found for the given MO number.");
                    return;
                }

                // Convert item table to list
                string res = JsonConvert.SerializeObject(GetMoheaderDetails.Tables[1]);
                List<Model.kitlist.item> item = JsonConvert.DeserializeObject<List<Model.kitlist.item>>(res) ?? new();

                // Build main object
                var header = GetMoheaderDetails.Tables[0].Rows[0];
                var man = new Model.kitlist.manufacturing_order
                {
                    mo_id = header[0]?.ToString() ?? "",
                    pcn_number = header[1]?.ToString() ?? "",
                    description = header[2]?.ToString() ?? "",
                    location = header[3]?.ToString() ?? "",
                    bom_item = header[4]?.ToString() ?? "",
                    bom_revision_number = header[5]?.ToString() ?? "",
                    order_quantity = header[6]?.ToString() ?? "",
                    order_date = header[7]?.ToString() ?? "",
                    kit_date = header[8]?.ToString() ?? "",
                    start_date = header[9]?.ToString() ?? "",
                    end_date = header[10]?.ToString() ?? "",
                    kit_list_items = item
                };

                string res1 = JsonConvert.SerializeObject(man);
                string responseData = "";

                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent(res1, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("https://app.btcp-enterprise.com/api/kit-list", content);
                    responseData = await response.Content.ReadAsStringAsync();

                    // Catch error responses before continuing
                    if (!response.IsSuccessStatusCode)
                    {
                        try
                        {
                            var errorResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseData);

                            string errorMessage = "Unknown error occurred.";

                            if (errorResponse.ContainsKey("message"))
                            {
                                errorMessage = errorResponse["message"]?.ToString() ?? errorMessage;
                            }

                            if (errorResponse.ContainsKey("errors"))
                            {
                                var errors = errorResponse["errors"]?.ToString();
                                errorMessage += $"\nDetails: {errors}";
                            }

                            // MessageBox.Show(errorMessage, "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            CustomeAlert alert = new CustomeAlert("Template", "No Template Created for this MO", CustomeAlert.Alertype.Error);
                        }
                        catch
                        {
                            MessageBox.Show("Failed to parse error response:\n" + responseData, "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return;
                    }

                    dynamic tmp = JsonConvert.DeserializeObject(responseData);
                    kit_list_id1 = tmp?.id ?? 0;

                    string url = $"https://app.btcp-enterprise.com/api/kit-list-item?mo_id={txtmo_number.Text}&per_row=9999";
                    string modetails = await GetMohDetails(url);
                    var model_modetails = JsonConvert.DeserializeObject<Model.kitlist.GetData>(modetails);

                    if (model_modetails == null)
                    {
                        MessageBox.Show("Failed to load kit list item details.");
                        return;
                    }

                    next_page = model_modetails.next_page_url;
                    btnprevious_page.Enabled = model_modetails.prev_page_url != null;
                    btnnext.Enabled = model_modetails.next_page_url != null;

                    lbl_rowcount.Text = $"{model_modetails.to} out of {model_modetails.total}";

                    var model = model_modetails.data ?? new List<Model.kitlist.manufacturing_order_items>();

                    foreach (var row in model)
                    {
                        if (row?.status?.name?.ToUpper() == "COMPLETE")
                        {
                            bunifuloading.Hide();
                            MessageBox.Show("This MO number is already Complete");
                            return;
                        }
                    }

                    dataGridView1.DataSource = model;
                    bunifuloading.Hide();

                    // Set values from DataGridView
                    if (dataGridView1.Rows.Count > 0)
                    {
                        var firstRow = dataGridView1.Rows[0];
                        kit_list_item_id = Convert.ToInt32(firstRow.Cells[colid.Name]?.Value ?? 0);
                        kit_list_item_ipn = firstRow.Cells[colipn.Name]?.Value?.ToString() ?? "";
                        total_pick_quantity = Convert.ToInt32(firstRow.Cells[colpickqty.Name]?.Value ?? 0);
                    }

                    btnAddSerial.Enabled = true;
                    btnscan.Enabled = true;
                    btncomplete.Visible = true;
                    btnincomplete.Visible = true;

                    mo_number = txtmo_number.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private async void btnnext_Click(object sender, EventArgs e)
        {
            bunifuloading.Show();
            string modetails = await GetMohDetails(next_page + "&per_row=9999");
            Model.kitlist.GetData model_modetails = JsonConvert.DeserializeObject<Model.kitlist.GetData>(modetails);
            string res3 = JsonConvert.SerializeObject(model_modetails.data);
            next_page = model_modetails.next_page_url;
            prev_page = model_modetails.prev_page_url;
            if (next_page == null)
                btnnext.Enabled = false;
            if (prev_page != null)
                btnprevious_page.Enabled = true;
            lbl_rowcount.Text = model_modetails.to.ToString() + " out of " + model_modetails.total;
            List<Model.kitlist.manufacturing_order_items> model = (List<Model.kitlist.manufacturing_order_items>)JsonConvert.DeserializeObject(res3, typeof(List<Model.kitlist.manufacturing_order_items>));
            btnprevious_page.Enabled = true;
            bunifuloading.Hide();
            dataGridView1.DataSource = model;
        }

        private async void btnprevious_page_Click(object sender, EventArgs e)
        {
            bunifuloading.Show();
            string modetails = await GetMohDetails(prev_page + "&per_row=9999");
            Model.kitlist.GetData model_modetails = JsonConvert.DeserializeObject<Model.kitlist.GetData>(modetails);
            string res3 = JsonConvert.SerializeObject(model_modetails.data);
            next_page = model_modetails.next_page_url;
            prev_page = model_modetails.prev_page_url;
            if (prev_page == null)
                btnprevious_page.Enabled = false;
            if (next_page != null)
                btnnext.Enabled = true;
            lbl_rowcount.Text = model_modetails.to.ToString() + " out of " + model_modetails.total;
            List<Model.kitlist.manufacturing_order_items> model = (List<Model.kitlist.manufacturing_order_items>)JsonConvert.DeserializeObject(res3, typeof(List<Model.kitlist.manufacturing_order_items>));
            bunifuloading.Hide();
            dataGridView1.DataSource = model;
        }

        private void btncomplete_Click(object sender, EventArgs e)
        {
            SavedKittedQuantity(2);/// Status is Complete
        }
        private async void SavedKittedQuantity(int status)
        {
            bunifuloading.Show();
            List<Model.kitlist.kitted_quantity> list_kitted_quantity = new List<Model.kitlist.kitted_quantity>();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                Model.kitlist.kitted_quantity data_kitted_quantity = new Model.kitlist.kitted_quantity
                {
                    id = Convert.ToInt32(item.Cells[colid.Name].Value.ToString()),
                    kitted = item.Cells[colkitted.Name].Value.ToString(),
                    comment = item.Cells[colcomment.Name].Value == null ? "" : item.Cells[colcomment.Name].Value.ToString(),
                    kit_list_item_status_id = 1
                };

                list_kitted_quantity.Add(data_kitted_quantity);
            }
            Model.kitlist.update_kitting_quantity list = new Model.kitlist.update_kitting_quantity
            {
                kit_list_id = kit_list_id1,
                kit_list_status_id = status,
                kit_list_items = list_kitted_quantity
            };
            string res = JsonConvert.SerializeObject(list);
            string responseData = "";
            HttpResponseMessage response = new HttpResponseMessage();
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(res, Encoding.UTF8, "application/json");

                response = await client.PostAsync("https://app.btcp-enterprise.com/api/kit-list-item/scan-bulk", content);
                responseData = await response.Content.ReadAsStringAsync();
                if (response.StatusCode.ToString() == "422")
                {
                    bunifuloading.Hide();
                }
                else
                {
                    bunifuloading.Hide();
                    MessageBox.Show("Saved Kitted Quantity");
                    txtserial_number.Clear();
                    txtmo_number.Clear();
                    dataGridView1.DataSource = null;
                    initialize_datagridview_columns();
                }
            }
        }

        private void btnincomplete_Click(object sender, EventArgs e)
        {
            SavedKittedQuantity(3); /// Status is Incomplete
        }


        void initialize_datagridview_columns()
        {
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            //column.HeaderText = "Serial Number";
            //column.DataPropertyName = "part_serial";
            //column.Name = "colpart_serial";
            //column.Width = 180;
            //dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Internal PN";
            column.DataPropertyName = "ipn";
            column.Name = "colipn";
            column.Width = 100;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Description";
            column.DataPropertyName = "description";
            column.Name = "coldescription";
            column.Width = 300;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Type";
            column.DataPropertyName = "type";
            column.Name = "coltype";
            column.Width = 100;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "MFG";
            column.DataPropertyName = "manufacturing";
            column.Name = "colmfg";
            column.Width = 180;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "MFG Product Code";
            column.DataPropertyName = "manufacturing_product_code";
            column.Name = "colmfgprodcode";
            column.Width = 180;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Location";
            column.DataPropertyName = "source_location";
            column.Name = "collocation";
            column.Width = 180;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Stock";
            column.DataPropertyName = "stock";
            column.Name = "colstock";
            column.Width = 180;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Unit Quantity";
            column.DataPropertyName = "unit_quantity";
            column.Name = "colunitqty";
            column.Width = 80;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "MO Quantity";
            column.DataPropertyName = "mo_quantity";
            column.Name = "colmoqty";
            column.Width = 80;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "WIP Quantity";
            column.DataPropertyName = "wip_quantity";
            column.Name = "colwipqty";
            column.Width = 180;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Pick Quantity";
            column.DataPropertyName = "pick_quantity";
            column.Name = "colpickqty";
            column.Width = 80;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Short Quantity";
            column.DataPropertyName = "short_quantity";
            column.Name = "colshortqty";
            column.Width = 80;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Kit Quantity";
            column.DataPropertyName = "";
            column.Name = "colkit_quantity";
            column.Width = 80;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Received Quantity";
            column.DataPropertyName = "";
            column.Name = "colrecieved_quantity";
            column.Width = 80;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Reject Quantity";
            column.DataPropertyName = "";
            column.Name = "colreject_quantity";
            column.Width = 80;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Uni UOM";
            column.DataPropertyName = "unit";
            column.Name = "colunit";
            column.Width = 70;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Invoice #";
            column.DataPropertyName = "invoice_number";
            column.Name = "colinvoicenumber";
            column.Width = 180;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Kitted";
            column.DataPropertyName = "kitted";
            column.Name = "colkitted";
            column.Width = 80;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Individual Kitted";
            column.DataPropertyName = "individual_kitting";
            column.Name = "colindividualkitted";
            column.Width = 180;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Track";
            column.DataPropertyName = "track";
            column.Name = "coltrack";
            column.Width = 100;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Rack";
            column.DataPropertyName = "rack";
            column.Name = "colrack";
            column.Width = 180;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Comment";
            column.DataPropertyName = "comment";
            column.Name = "colcomment";
            column.Width = 200;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Created_at";
            column.DataPropertyName = "created_at";
            column.Name = "colcreated_at";
            column.Width = 180;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Update at";
            column.DataPropertyName = "updated_at";
            column.Name = "colupdated_at";
            column.Width = 180;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Status";
            column.DataPropertyName = "status";
            column.Name = "colstatus";
            column.Width = 180;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "history";
            column.DataPropertyName = "history";
            column.Name = "colhistory";
            column.Width = 180;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "id";
            column.DataPropertyName = "id";
            column.Name = "colid";
            column.Width = 180;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "mo id";
            column.DataPropertyName = "mo_id";
            column.Name = "colmo_id";
            column.Width = 180;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "item number";
            column.DataPropertyName = "item_number";
            column.Name = "colitem_number";
            column.Width = 180;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "group";
            column.DataPropertyName = "group";
            column.Name = "colgroup";
            column.Width = 180;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "Kit_list_id";
            column.DataPropertyName = "kit_list_item_status_id";
            column.Name = "colkit_list_status_item";
            column.Width = 70;
            column.Visible = false;
            dataGridView1.Columns.Add(column);

        }

        private async void btnAddSerial_Click(object sender, EventArgs e)
        {
            list_serial.Clear();
            string url = $@"https://app.btcp-enterprise.com/api/serial/view-serial?kit_list_item_id={kit_list_item_id}";
            string responseData = await GetMohDetails(url);
            List<Model.kitlist.get_serial> serials = (List<Model.kitlist.get_serial>)JsonConvert.DeserializeObject(responseData, typeof(List<Model.kitlist.get_serial>));
            foreach (var item in serials)
            {
                string[] data1 = new string[]
                 {
                    Convert.ToInt32(item.id).ToString(),
                    item.kit_list_part_serial_number,
                    Convert.ToInt32(item.is_scan).ToString()
                 };
                list_serial.Rows.Add(data1);
            }
            AddSerialNumber addSerialnumber = new AddSerialNumber();
            addSerialnumber.Show();
        }
    }
}
