using BTC_EnterpriseV2.Class;
using BTC_EnterpriseV2.Utillities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Syncfusion.Grouping;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Styles;
using Syncfusion.WinForms.ListView.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTC_EnterpriseV2.Forms
{
    public partial class Kitlist_Recieving : Form
    {
        int kitlist_id1 = 0;
        public Kitlist_Recieving()
        {
            InitializeComponent();
            Initialize_Grid();
            bunifuloading.Hide();
        }
        private void Initialize_Grid()
        {
            CellStyleInfo cellStyleInfo = new CellStyleInfo();
            cellStyleInfo.HorizontalAlignment = HorizontalAlignment.Center;
            string[] comment = { "OKAY", "LACKING", "EXIST" };
            GridComboBoxColumn gridComboBoxColumn = new GridComboBoxColumn();
            gridComboBoxColumn.MappingName = "comment";
            gridComboBoxColumn.HeaderText = "Comment";
            gridComboBoxColumn.ValueMember = "comment";
            gridComboBoxColumn.DisplayMember = "comment";
            gridComboBoxColumn.DropDownStyle = DropDownStyle.DropDownList;
            gridComboBoxColumn.DataSource = comment;
           
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "kit_list_received_id", HeaderText = "kit_list_received_id", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridCheckBoxColumn { MappingName = "selected", HeaderText = "", AllowCheckBoxOnHeader = true, AllowFiltering = false, CheckBoxSize = new Size(14, 14), Width = 80 });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "group", HeaderText = "Group", Width = 100, Visible = true });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "id", HeaderText = "id", Width = 150, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "kit_list_received_item_status_id", HeaderText = "status", Width = 200, Visible = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ipn", HeaderText = "Internal  PN", MinimumWidth = 150, AllowEditing = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "description", HeaderText = "Description", Width = 300, AllowTextWrapping = true, AllowHeaderTextWrapping = true, AllowEditing = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "type", HeaderText = "Type", Width = 150, AllowEditing = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "actual_quantity", HeaderText = "Pick Quantity", Width = 100, Visible = true, CellStyle = cellStyleInfo, AllowHeaderTextWrapping = true });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "short_quantity", HeaderText = "Short Quantity", Width = 100, CellStyle = cellStyleInfo, AllowHeaderTextWrapping = true });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "received_quantity", HeaderText = "Recieved Quantity", Width = 100, CellStyle = cellStyleInfo, AllowHeaderTextWrapping = true });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "unit", HeaderText = "Unit UOM", Width = 100, AllowEditing = false });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "track", HeaderText = "Track", Width = 150, AllowEditing = false });
            this.sfDataGrid1.Columns.Add(gridComboBoxColumn);
            //this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "comment", HeaderText = "Comment", Width = 150 });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "status", HeaderText = "Status", Width = 150, AllowEditing = false });

        }
        private void txtmo_number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Scan_Mo(txtmo_number.Text);
            }
        }
        private async void Scan_Mo(string mo_no)
        {
            bunifuloading.Show();
            var apiUrl = GlobalApi.GetMo();
            Dictionary<string, object> postData = new Dictionary<string, object>()
            {
                { "mo_id", mo_no },
            };
            var json_token = await ApiHelper.PostJsonAsync(GlobalApi.KitlistRecievingView(), postData,Global.UserToken);
            var json_object = json_token?.ToObject<List<Model.KITLIST_RECEIVING.Root>>();
            var sf_header = new List<Model.KITLIST_RECEIVING.Sf_Header>();
            foreach (var header in json_object)
            {
                if (header.kit_list_received_status_id == 2)
                {
                    bunifuloading.Hide();
                    MessageBox.Show("Already Complete");
                    //btncomplete.Visible = false;
                    //btnincomplete.Visible = false;
                }
                else if (header.kit_list_received_status_id == 3)
                {
                    MessageBox.Show("Incomplete");
                    btncomplete.Visible = true;
                    btnincomplete.Visible = true;
                }
                else
                {
                    btncomplete.Visible = true;
                    btnincomplete.Visible = true;
                }
                foreach (var received in header.items)
                {

                    var sf_data = new Model.KITLIST_RECEIVING.Sf_Header()
                    {
                        // Initialize properties here
                        group = received.kit_list_item.group,
                        kit_list_received_id = header.id,
                        selected = received.kit_list_received_item_status_id != 1 ? true : false,
                        id = received.id,
                        kit_list_received_item_status_id = received.kit_list_received_item_status_id,
                        ipn = received.kit_list_item.ipn,
                        description = received.kit_list_item.description,
                        type = received.kit_list_item.type,
                        actual_quantity = received.actual_quantity,
                        short_quantity = received.short_quantity,
                        received_quantity = received.received_quantity,
                        unit = received.kit_list_item.unit,
                        track = received.kit_list_item.track,
                        comment = received.comment == null ? "" : received.comment.ToString(),
                        status = received.status.name
                    };
                    sf_header.Add(sf_data);
                }
            }
            sfDataGrid1.DataSource = sf_header;
            bunifuloading.Hide();
            //var json_mo_details = JsonConvert.SerializeObject(json_object?);

            // // Ensure the deserialization handles possible null values
            // var model_mo_details = JsonConvert.DeserializeObject<List<Model.kitlist.manufacturing_order_items>>(json_mo_details)
            //                        ?? new List<Model.kitlist.manufacturing_order_items>();
            // foreach (var item in model_mo_details)
            // {
            //     item.item_status = item?.status?.name?.ToUpper() ?? string.Empty;
            //     if (item.kit_list_item_status_id == 1)
            //     {
            //         item.Selected = false; // Initialize Selected property to false    
            //     }
            //     else if (item.kit_list_item_status_id == 2)
            //     {
            //         item.Selected = true; // Initialize Selected property to true
            //     }
            //     item.short_quantity = (Convert.ToInt32(item.pick_quantity) - Convert.ToInt64(item.kitted)).ToString();
            // }
            // sfDataGrid1.DataSource = model_mo_details;
            // foreach (var item in model_mo_details)
            // {
            //     if (kitlist_id1 != 0) continue;
            //     kitlist_id1 = item.kit_list_item_status_id;
            // }
            // bunifuloading.Hide();
        }

        private void btncomplete_Click(object sender, EventArgs e)
        {
            saved_comment_status(2);//Complete
        }
        private void btnincomplete_Click(object sender, EventArgs e)
        {
            saved_comment_status(3);//Incomplete
        }
        private async void saved_comment_status(int status_header)
        {
            bunifuloading.Show();
            var mo_records = sfDataGrid1.View.Records;
            var list = new List<Model.KITLIST_RECEIVING.item_data>();
            int header_id = 0;
            foreach (var item in mo_records)
            {
                var obj = item?.Data as Model.KITLIST_RECEIVING.Sf_Header;
                if (obj == null) return;
                if (!obj.selected) continue;
                header_id = obj.kit_list_received_id;
                var item_data = new Model.KITLIST_RECEIVING.item_data
                {
                    id = obj.id,
                    kit_list_received_item_status_id = obj.short_quantity == 0 ? 2 : 3,
                    short_quantity = obj.short_quantity,
                    received_quantity = obj.received_quantity,
                    comment = obj.comment == null ? "" : obj.comment.ToString()
                };
                list.Add(item_data);
            }
            var item_list = new Model.KITLIST_RECEIVING.item_root()
            { items = list };
            var json = JsonConvert.SerializeObject(item_list);
            var json_token = await ApiHelper.PostJsonAsync(GlobalApi.kitlistRecievingItem, json,Global.UserToken);
            var json_obj_details = json_token?.ToObject<JObject>();
            var header_data = new Dictionary<string, object>()
            {
                { "id",header_id},
                { "kit_list_received_status_id",status_header}
            };
            var json_token_header = await ApiHelper.PostJsonAsync(GlobalApi.kitlistRecievingUpdateHeader, header_data,Global.UserToken);
            var json_obj = json_token_header?.ToObject<JObject>();
            if (json_obj["message"]?.ToString() == json_obj_details["message"]?.ToString())
            {
                bunifuloading.Hide();
                MessageBox.Show(json_obj["message"]?.ToString(), "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmo_number.Clear();
                sfDataGrid1.DataSource = null;
            }
            else
            {
                MessageBox.Show("Report to IT", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void sfDataGrid1_CellCheckBoxClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellCheckBoxClickEventArgs e)
        {
            SfDataGrid? grid = sender as SfDataGrid;
            var tableControl = grid.TableControl; // Access the TableControl instance
            int rowIndex = DataGridIndexResolver.ResolveToRecordIndex(tableControl, e.RowIndex); // Use the correct method with TableControl
            int columnIndex = DataGridIndexResolver.ResolveToGridVisibleColumnIndex(tableControl, e.ColumnIndex); // Use the correct method with TableControl
            var column = grid.Columns[columnIndex];
            if (column.GetType() == typeof(GridCheckBoxColumn) && column.MappingName == "selected")
            {
                if (rowIndex == -1)
                {
                    var record = grid.View.Records;
                    foreach (var item in record)
                    {
                        var obj = item.Data as Model.KITLIST_RECEIVING.Sf_Header ?? new Model.KITLIST_RECEIVING.Sf_Header();

                        if (obj.selected == false)
                        {
                            //if (obj.actual_quantity == obj.received_quantity)
                            //{
                            sfDataGrid1.View.GetPropertyAccessProvider().SetValue(obj, "received_quantity", obj.actual_quantity);
                            int short_quantity = obj.actual_quantity - Convert.ToInt32(sfDataGrid1.View.GetPropertyAccessProvider().GetValue(obj, "received_quantity"));
                            sfDataGrid1.View.GetPropertyAccessProvider().SetValue(obj, "short_quantity", short_quantity);
                            string comment = string.Empty;
                            string status = string.Empty;
                            if (short_quantity == 0)
                            { comment = "OKAY"; status = "COMPLETED"; }
                            else if (short_quantity < 0)
                            { comment = "LACKING"; status = "LACKING"; }
                            else
                            { comment = "EXIST"; status = "EXIST"; }
                            sfDataGrid1.View.GetPropertyAccessProvider().SetValue(obj, "comment", comment);
                            sfDataGrid1.View.GetPropertyAccessProvider().SetValue(obj, "status", status);
                            //}
                            //else
                            //    sfDataGrid1.View.GetPropertyAccessProvider().SetValue(obj, "comment", "LACKING");
                        }
                        else if (obj.selected == true)
                        {
                            sfDataGrid1.View.GetPropertyAccessProvider().SetValue(obj, "comment", "");
                            sfDataGrid1.View.GetPropertyAccessProvider().SetValue(obj, "status", "OPEN");
                        }
                    }
                    sfDataGrid1.Refresh();
                }
                else
                {
                    var record = grid.View.Records[rowIndex].Data as Model.KITLIST_RECEIVING.Sf_Header;

                    if (record.selected == false)
                    {
                        //if (record.actual_quantity == record.received_quantity)
                        //{
                        sfDataGrid1.View.GetPropertyAccessProvider().SetValue(record, "received_quantity", record.actual_quantity);
                        int short_quantity = record.actual_quantity - Convert.ToInt32(sfDataGrid1.View.GetPropertyAccessProvider().GetValue(record, "received_quantity"));
                        sfDataGrid1.View.GetPropertyAccessProvider().SetValue(record, "short_quantity", short_quantity);
                        string comment = string.Empty;
                        string status = string.Empty;
                        if (short_quantity == 0)
                        { comment = "OKAY"; status = "COMPLETED"; }
                        else if (short_quantity < 0)
                        { comment = "LACKING"; status = "LACKING"; }
                        else
                        { comment = "EXIST"; status = "EXIST"; }
                        sfDataGrid1.View.GetPropertyAccessProvider().SetValue(record, "comment", comment);
                        sfDataGrid1.View.GetPropertyAccessProvider().SetValue(record, "status", status);
                        sfDataGrid1.Refresh();
                        //}
                        //else
                        //    sfDataGrid1.View.GetPropertyAccessProvider().SetValue(record, "comment", "LACKING");
                    }
                    else if (record.selected == true)
                    {
                        sfDataGrid1.View.GetPropertyAccessProvider().SetValue(record, "comment", "");
                        sfDataGrid1.View.GetPropertyAccessProvider().SetValue(record, "status", "OPEN");
                    }

                }

            }
        }
        private void sfDataGrid1_CurrentCellEndEdit(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellEndEditEventArgs e)
        {
            SfDataGrid? grid = sender as SfDataGrid;
            var tableControl = grid.TableControl; // Access the TableControl instance
            int rowIndex = DataGridIndexResolver.ResolveToRecordIndex(tableControl, e.DataRow.RowIndex); // Use the correct method with TableControl
            int columnIndex = DataGridIndexResolver.ResolveToGridVisibleColumnIndex(tableControl, e.DataColumn.ColumnIndex); // Use the correct method with TableControl
            var column = grid.Columns[columnIndex];
            if (column.MappingName == "received_quantity")
            {
                sfDataGrid1.Refresh();
                var record = grid.View.Records[rowIndex].Data as Model.KITLIST_RECEIVING.Sf_Header;
                int short_qty = (Convert.ToInt32(record?.received_quantity) - Convert.ToInt32(record?.actual_quantity));
                sfDataGrid1.View.GetPropertyAccessProvider().SetValue(record, "short_quantity", short_qty);
                string comment = string.Empty;
                string status = string.Empty;
                if (short_qty == 0)
                { comment = "OKAY"; status = "COMPLETED"; }
                else if (short_qty < 0)
                { comment = "LACKING"; status = "LACKING"; }
                else
                { comment = "EXIST"; status = "EXIST"; }
                sfDataGrid1.View.GetPropertyAccessProvider().SetValue(record, "comment", comment);
                sfDataGrid1.View.GetPropertyAccessProvider().SetValue(record, "status", status);
                sfDataGrid1.Refresh();
            }
        }
    }
}
