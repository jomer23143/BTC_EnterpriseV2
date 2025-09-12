using BTC_EnterpriseV2.Class;
using BTC_EnterpriseV2.Modal;
using BTC_EnterpriseV2.Utillities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Syncfusion.Windows.Forms.Chart;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace BTC_EnterpriseV2.Forms
{
    public partial class Warehouse_Kitting : Form
    {
        DataSet GetMoheaderDetails = new DataSet();
        public DataTable dt_items = new DataTable("warehouse_data");
        public DataTable list_serial = new DataTable("list_of_serials");
        int kit_list_id1 = 0;
        public SfDataGrid sfgrid;
        public static Warehouse_Kitting instance;
        public Warehouse_Kitting()
        {
            InitializeComponent();
            instance = this;
            Initialize_Grid();
            bunifuloading.Hide();
            btncomplete.Visible = false;
            btnincomplete.Visible = false;
            sfgrid = sfDataGrid1;
        }
        private void Initialize_Grid()
        {
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "group", HeaderText = "Group", Width = 100, Visible = true });
            this.sfDataGrid1.Columns.Add(new GridCheckBoxColumn { MappingName = "Selected", HeaderText = "", AllowCheckBoxOnHeader = false, AllowFiltering = false, CheckBoxSize = new Size(14, 14), Width = 80,Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "part_serial", HeaderText = "Serial Number", Width = 200, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ipn", HeaderText = "Internal  PN", MinimumWidth = 150 });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "description", HeaderText = "Description", Width = 300 ,AllowTextWrapping = true});
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "type", HeaderText = "Type", Width = 150 });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "manufacturing", HeaderText = "Mfg", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "manufacturing_product_code", HeaderText = "Mfg Product Code", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "source_location", HeaderText = "Location", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "stock", HeaderText = "Stock", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "unit_quantity", HeaderText = "Unit Quantity", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "mo_quantity", HeaderText = "MO Quantity", Width = 100, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "wip_quantity", HeaderText = "Wip Quantity", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "pick_quantity", HeaderText = "Pick Quantity", Width = 150  });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "short_quantity", HeaderText = "Short Quantity", Width = 100 });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "kit_quantity", HeaderText = "Kit Quantity", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "receive_quantity", HeaderText = "Recieved Quantity", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "reject_quantity", HeaderText = "Reject Quantity", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "unit", HeaderText = "Unit UOM", Width = 100 });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "invoice_number", HeaderText = "Invoice Number", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "kitted", HeaderText = "Kitted", Width = 100 });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "individual_kitting", HeaderText = "Individual Kitted", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "track", HeaderText = "Track", Width = 150 });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "rack", HeaderText = "Rack", Width = 150 ,Visible = false});
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "comment", HeaderText = "Comment", Width = 100 });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "created_at", HeaderText = "Created at", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "updated_at", HeaderText = "Updated at", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "status", HeaderText = "status", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "item_status", HeaderText = "Status", Width = 150, Visible = true });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "history", HeaderText = "history", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "id", HeaderText = "id", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "mo_id", HeaderText = "mo id", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "item_number", HeaderText = "item number", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "group", HeaderText = "group", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "kit_list_item_status_id", HeaderText = "kit list id", Width = 150, Visible = false });
            CellStyleInfo cellStyleInfo = new CellStyleInfo();
            cellStyleInfo.HorizontalAlignment = HorizontalAlignment.Center;
            List<CellButton> button_add = new List<CellButton>();
            button_add.Add(new CellButton() { Text = "Add Serial", Size = new Size(88, 28), Style = new ButtonCellStyleInfo() { Padding = new Padding(4, 0, 0, 4), BackColor = Color.CornflowerBlue } });
            List<CellButton> button_scan = new List<CellButton>();
            button_scan.Add(new CellButton() { Text = "Scan Serial", Size = new Size(88, 28), Style = new ButtonCellStyleInfo() { Padding = new Padding(4, 0, 0, 4), BackColor = Color.CornflowerBlue } });
           // this.sfDataGrid1.Columns.Add(new GridButtonColumn() {Buttons = button_add, MappingName = "Add_Serial", HeaderText = "Add Serial", AllowDefaultButtonText = true, Width = 100, CellStyle = cellStyleInfo, Orientation = Orientation.Vertical });
            this.sfDataGrid1.Columns.Add(new GridButtonColumn() { Buttons = button_scan, MappingName = "Scan_Serial", HeaderText = "Scan Serial", AllowDefaultButtonText = true, Width = 100, CellStyle = cellStyleInfo, Orientation = Orientation.Vertical });
        }
        private void Warehouse_Kitting_Load(object sender, EventArgs e)
        {

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
                // 1. Load MO Header and Item Details
                var moDataSet = KitList.GetMohDetails_DS(txtmo_number.Text.Trim());
                if (!IsValidDataSet(moDataSet))
                {
                    MessageBox.Show("No data found for the given MO number.");
                    return;
                }

                var headerRow = moDataSet.Tables[0].Rows[0];
                var itemList = DeserializeItemList(moDataSet.Tables[1]);

                var manufacturingOrder = BuildManufacturingOrder(headerRow, itemList);
                //var res = MessageBox.Show("Is Build America?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (res == DialogResult.Yes)
                //    manufacturingOrder.is_build_america_buy_america = true;
                //else
                //    manufacturingOrder.is_build_america_buy_america = false;
                // 2. Submit Header via API
                var postSuccess = await SubmitManufacturingOrderAsync(manufacturingOrder);
                if (!postSuccess) return;

                // 3. Retrieve Kit List Item Details
                var kitListDetails = await GetKitListItemDetailsAsync(txtmo_number.Text);
                if (kitListDetails == null)
                {
                    MessageBox.Show("Failed to load kit list item details.");
                    return;
                }
                //PopulateKitListUI_(itemList);
                PopulateKitListUI(kitListDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValidDataSet(DataSet ds)
        {
            return ds != null && ds.Tables.Count >= 2 && ds.Tables[1].Rows.Count > 0;
        }

        private List<Model.kitlist.item> DeserializeItemList(DataTable table)
        {
            string json = JsonConvert.SerializeObject(table);
            return JsonConvert.DeserializeObject<List<Model.kitlist.item>>(json) ?? new();
        }
        private Model.kitlist.manufacturing_order BuildManufacturingOrder(System.Data.DataRow row, List<Model.kitlist.item> items)
        {
            return new Model.kitlist.manufacturing_order
            {
                mo_id = row[0]?.ToString() ?? "",
                pcn_number = row[1]?.ToString() ?? "",
                description = row[2]?.ToString() ?? "",
                location = row[3]?.ToString() ?? "",
                bom_item = row[4]?.ToString() ?? "",
                bom_revision_number = row[5]?.ToString() ?? "",
                order_quantity = row[6]?.ToString() ?? "",
                order_date = row[7]?.ToString() ?? "",
                kit_date = row[8]?.ToString() ?? "",
                start_date = row[9]?.ToString() ?? "",
                end_date = row[10]?.ToString() ?? "",
                kit_list_items = items
            };
        }
        private async Task<bool> SubmitManufacturingOrderAsync(Model.kitlist.manufacturing_order man)
        {
            string json = JsonConvert.SerializeObject(man);

            using HttpClient client = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            string kitlist_api = GlobalApi.GetKitListUrl();
            var response = await client.PostAsync(kitlist_api, content);
            var responseData = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                dynamic? result = JsonConvert.DeserializeObject(responseData);
                if (result != null)
                {
                    kit_list_id1 = result.id ?? 0;
                    return true;
                }
            }

            return await HandleApiErrorAsync(responseData);
        }
        private async Task<bool> HandleApiErrorAsync(string responseData)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var apiError = JsonConvert.DeserializeObject<Model.kitlist.ApiError>(responseData);

                    bool moExists = apiError?.message == "Manufacturing Order already exist"
                        && apiError.errors?.ContainsKey("mo_id") == true
                        && apiError.errors["mo_id"].Contains("mo_id already exist");

                    if (moExists)
                    {
                        new CustomeAlert("Template", "Manufacturing Order already exists. Continuing the process...", CustomeAlert.Alertype.Warning).ShowDialog();
                        kit_list_id1 = apiError.id;
                        return true;
                    }

                    string fullMessage = apiError?.message ?? "Unknown error.";
                    if (apiError.errors != null)
                    {
                        foreach (var err in apiError.errors)
                        {
                            fullMessage += $"\n{err.Key}: {string.Join(", ", err.Value)}";
                        }
                    }

                    new CustomeAlert("Template", fullMessage, CustomeAlert.Alertype.Error).ShowDialog();
                }
                catch (Exception ex)
                {
                    new CustomeAlert("Template", ex.Message + "\n\nRaw Response:\n" + responseData, CustomeAlert.Alertype.Error).ShowDialog();
                }

                return false;
            });
        }
        private async Task<Model.kitlist.GetData?> GetKitListItemDetailsAsync(string mo_no)
        {
            var apiUrl = GlobalApi.GetMo();
            //Dictionary<string, object> postData = new Dictionary<string, object>()
            //{
            //    { "mo_id", mo_no },
            //   //{ "per_row", 9999 }
            //};
            string data = $"?mo_id ={mo_no}&per_row=9999";
           // var json = JsonConvert.SerializeObject(postData);
            var json_response = await WebRequestApi.GetData_httpclient(string.Format("{0}{1}", apiUrl,data));
            var json_token = JToken.Parse(json_response);
            //var json_token = await ApiHelper.PostJsonAsync(apiUrl, postData);
            return json_token?.ToObject<Model.kitlist.GetData>();

        }
        private void PopulateKitListUI(Model.kitlist.GetData model)
        {
            //next_page = (string)model.next_page_url;
            //btnprevious_page.Enabled = model.prev_page_url != null;
            //btnnext.Enabled = model.next_page_url != null;
            lbl_rowcount.Text = $"{model.to} out of {model.total}";
            var data = model.data ?? new();
            foreach (var row in data)
            {
                row.item_status = row?.status?.name?.ToUpper() ?? string.Empty;
                row.Selected = false;
            }
            
            sfDataGrid1.DataSource = data;
            bunifuloading.Hide();

            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    row.Cells[colkitted.Name].Value = row.Cells[colpickqty.Name].Value;
            //    row.Cells[colshortqty.Name].Value = Convert.ToInt64(row.Cells[colpickqty.Name].Value) - (String.IsNullOrWhiteSpace(row.Cells[colkitted.Name].Value.ToString()) ? 0 : Convert.ToInt64(row.Cells[colkitted.Name].Value));
            //}

            //if (dataGridView1.Rows.Count > 0)
            //{
            //    var firstRow = dataGridView1.Rows[0];
            //    kit_list_item_id = Convert.ToInt32(firstRow.Cells[colid.Name]?.Value ?? 0);
            //    kit_list_item_ipn = firstRow.Cells[colipn.Name]?.Value?.ToString() ?? "";
            //    total_pick_quantity = Convert.ToInt32(firstRow.Cells[colpickqty.Name]?.Value ?? 0);
            //}

            //btnAddSerial.Enabled = true;
            //btnscan.Enabled = true;
            btncomplete.Visible = true;
            btnincomplete.Visible = true;

            //mo_number = txtmo_number.Text;
        }
        private void PopulateKitListUI_(List<Model.kitlist.item> model)
        {
            //next_page = (string)model.next_page_url;
            //btnprevious_page.Enabled = model.prev_page_url != null;
            //btnnext.Enabled = model.next_page_url != null;
            lbl_rowcount.Text = $"{model.Count} out of {model.Count}";

            dt_items.Rows.Clear();
            dt_items.Columns.Clear();
            dt_items.Columns.Add("id");
            dt_items.Columns.Add("kit_list_item_id");
            dt_items.Columns.Add("kit_list_item_serial_number_status_id");
            dt_items.Columns.Add("kit_list_part_serial_number");
            dt_items.Columns.Add("is_scan");

            var data = model ?? new();
            foreach (var row in data)
            {
                //if (row?.status?.name?.ToUpper() == "COMPLETE")
                //{
                //    bunifuloading.Hide();
                //    MessageBox.Show("This MO number is already Complete");
                //    return;
                //}
                row.Selected = false;
                //foreach (var item in row.serial)
                //{
                //    dt_items.Rows.Add(
                //         item.id,
                //         item.kit_list_item_id,
                //         item.kit_list_item_serial_number_status_id,
                //         item.kit_list_part_serial_number,
                //         item.is_scan
                //     );
                //}

            }
            sfDataGrid1.DataSource = data;
            bunifuloading.Hide();

            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    row.Cells[colkitted.Name].Value = row.Cells[colpickqty.Name].Value;
            //    row.Cells[colshortqty.Name].Value = Convert.ToInt64(row.Cells[colpickqty.Name].Value) - (String.IsNullOrWhiteSpace(row.Cells[colkitted.Name].Value.ToString()) ? 0 : Convert.ToInt64(row.Cells[colkitted.Name].Value));
            //}

            //if (dataGridView1.Rows.Count > 0)
            //{
            //    var firstRow = dataGridView1.Rows[0];
            //    kit_list_item_id = Convert.ToInt32(firstRow.Cells[colid.Name]?.Value ?? 0);
            //    kit_list_item_ipn = firstRow.Cells[colipn.Name]?.Value?.ToString() ?? "";
            //    total_pick_quantity = Convert.ToInt32(firstRow.Cells[colpickqty.Name]?.Value ?? 0);
            //}

            //btnAddSerial.Enabled = true;
            //btnscan.Enabled = true;
            btncomplete.Visible = true;
            btnincomplete.Visible = true;

            //mo_number = txtmo_number.Text;
        }

        private void btncomplete_Click(object sender, EventArgs e)
        {
            SavedKittedQuantity(2); // 2 status for complete
        }
        private async void SavedKittedQuantity(int status)
        {
            bunifuloading.Show();
            //var list_kitted_quantity = new List<Model.kitlist.kitted_quantity>();
            //var sf_records = sfDataGrid1.View.Records;

            //foreach (var item in sf_records)
            //{
            //    if (item.Data is Model.kitlist.kitted_quantity obj) // Ensure item.Data is not null and of the correct type
            //    {
            //        list_kitted_quantity.Add(obj);
            //    }
            //}

            Model.kitlist.update_kitting_quantity list = new Model.kitlist.update_kitting_quantity
            {
                kit_list_id = kit_list_id1,
                kit_list_status_id = status
                //kit_list_items = list_kitted_quantity
            };
            PropertyInfo[] info = list.GetType().GetProperties();
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (PropertyInfo item in info)
            {
                dict.Add(item.Name, item.GetValue(list) ?? "");
            }
            string res = JsonConvert.SerializeObject(list);
            var api_response = await ApiHelper.PostJsonAsync(GlobalApi.GetKitlistItemScanBulkUrl(), dict, Global.UserToken);
            var json_obj = api_response?.ToObject<JObject>();
            bunifuloading.Hide();
            MessageBox.Show("Saved Kitted Quantity");
            txtmo_number.Clear();
            sfDataGrid1.DataSource = null;
            sfDataGrid1.Columns.Clear();
            Initialize_Grid();
        }

        private void btnincomplete_Click(object sender, EventArgs e)
        {
            SavedKittedQuantity(3); // 3 status for incomplete
        }

        private async void sfDataGrid1_CellClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            try
            {
                if (e.DataColumn.GridColumn.MappingName == "Add_Serial")
                {
                    string track = sfDataGrid1.View.GetPropertyAccessProvider().GetValue(e.DataRow.RowData, "track")?.ToString() ?? "";
                    int kit_list_item_id = Convert.ToInt32(sfDataGrid1.View.GetPropertyAccessProvider().GetValue(e.DataRow.RowData, "id")?.ToString());
                    if (track != "Serialized")
                    {
                        MessageBox.Show("Only Serialized IPN");
                        return;
                    }
                    list_serial.Rows.Clear();
                
                    var rows = dt_items.AsEnumerable().Where
                                (row => row.Field<string>("kit_list_item_id") == kit_list_item_id.ToString());
                    if (rows.Any())
                    {
                        list_serial = rows.CopyToDataTable<System.Data.DataRow>();//Copying the rows into the DataTable as DataRow
                    }
                    AddSerialNumber addSerialnumber = new AddSerialNumber(list_serial,"",0,0,"");
                    addSerialnumber.Show();
                }
                else if (e.DataColumn.GridColumn.MappingName == "Scan_Serial")
                {
                    list_serial.Rows.Clear();
                    dt_items.Rows.Clear();
                    dt_items.Columns.Clear();
                    dt_items.Columns.Add("id");
                    dt_items.Columns.Add("kit_list_item_id");
                    dt_items.Columns.Add("kit_list_item_serial_number_status_id");
                    dt_items.Columns.Add("kit_list_part_serial_number");
                    dt_items.Columns.Add("is_scan");
                    int row_index = e.DataRow.RowIndex;
                    string ipn = sfDataGrid1.View.GetPropertyAccessProvider().GetValue(e.DataRow.RowData, "ipn")?.ToString() ?? "";
                    string track = sfDataGrid1.View.GetPropertyAccessProvider().GetValue(e.DataRow.RowData, "track")?.ToString() ?? "";
                    int kit_list_item_id = Convert.ToInt32(sfDataGrid1.View.GetPropertyAccessProvider().GetValue(e.DataRow.RowData, "id")?.ToString());
                    string pick_quantity = sfDataGrid1.View.GetPropertyAccessProvider().GetValue(e.DataRow.RowData, "pick_quantity")?.ToString() ?? string.Empty;

                    string url = $@"https://app.btcp-enterprise.com/api/serial/view-serial?kit_list_item_id={kit_list_item_id}";
                    string responseData = await WebRequestApi.GetData_httpclient(url);
                    var serials = JsonConvert.DeserializeObject<List<Model.kitlist.get_serial>>(responseData) ?? new List<Model.kitlist.get_serial>();
                    foreach (var item in serials)
                    {
                        string[] data1 = new string[]
                         {
                            Convert.ToInt32(item.id).ToString(),
                            item.kit_list_item_id.ToString(),
                            item.kit_list_item_serial_number_status_id.ToString(),
                            item.kit_list_part_serial_number.ToString(),
                            Convert.ToInt32(item.is_scan).ToString()
                         };
                        dt_items.Rows.Add(data1);
                    }
                    var rows = dt_items.AsEnumerable().Where
                           (row => row.Field<string>("kit_list_item_id") == kit_list_item_id.ToString());
                    if (rows.Any())
                    {
                        list_serial = rows.CopyToDataTable<System.Data.DataRow>();//Copying the rows into the DataTable as DataRow
                    }
                    AddSerialNumber addSerialnumber = new AddSerialNumber(list_serial, pick_quantity, kit_list_item_id, row_index, ipn);
                    addSerialnumber.Show();
                    //ScanSerialNumber ScanSerialnumber = new ScanSerialNumber(list_serial, kit_list_item_id);
                    //ScanSerialnumber.Show();
                }

            }
            catch (Exception)
            {
            }
        }
    }
}
