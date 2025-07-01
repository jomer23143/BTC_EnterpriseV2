using System.Data;
using System.Diagnostics;
using BTC_EnterpriseV2.Modal;
using BTC_EnterpriseV2.Model;
using BTC_EnterpriseV2.Utillities;
using BTCP_EnterpriseV2.YaoUI;
using Newtonsoft.Json.Linq;
using static BTC_EnterpriseV2.ProcessForm.Sub_AssyFrm;

namespace BTC_EnterpriseV2.Forms
{
    public partial class PrintQRFrm : Form
    {
        private const string ApiUrl = "https://app.btcp-enterprise.com/api/manufacuring-order?with_segment=1&with_station=1&with_process=0";
        private DataTable dt_list_Station_Serial = new DataTable();
        private string storedmoid = string.Empty;
        public PrintQRFrm()
        {
            InitializeComponent();
            pb_loader.Visible = false;
            YUI yUI = new YUI();
            yUI.RoundedTextBox(txt_moid, 5, Color.White);
            txt_moid.Select();
            btn_printallin1.Visible = false;
        }
        private void PrintQRFrm_Load(object sender, EventArgs e)
        {

        }
        private async void txt_moid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var moid = txt_moid.Text.Trim();
                storedmoid = moid; // Store the MO ID for later use
                pb_loader.Visible = true;
                await Get_Data(moid);
            }
        }

        public async Task Get_Data(string moid)
        {
            try
            {
                var ApiUrlApiUrl = $"{ApiUrl}&mo_id={moid}";
                // API call
                string jsonResponse = await WebRequestApi.GetData_httpclient(ApiUrlApiUrl);
                Debug.WriteLine("Response: " + jsonResponse);

                // Basic validation
                if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
                {
                    MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parse response
                var token = JToken.Parse(jsonResponse);

                // Handle error object
                if (token.Type == JTokenType.Object && token["message"] != null)
                {
                    var error = token.ToObject<ApiErrorResponse>();
                    MessageBox.Show($"Error: {error.message}", "Serial Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pb_loader.Visible = false;
                    return;
                }

                // Expecting an object with a "data" property
                if (token.Type == JTokenType.Object && token["data"] != null)
                {
                    var rootObj = token.ToObject<PrintQR_Model.RootWrapper>();
                    var dataList = rootObj?.data;

                    if (dataList == null || dataList.Count == 0)
                    {
                        MessageBox.Show("No valid process data returned.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    LoadProcessData(dataList);
                    pb_loader.Visible = false;
                }
                else
                {
                    MessageBox.Show("Unexpected response format.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Error: {ex.Message}");
            }
        }

        private void LoadProcessData(List<PrintQR_Model.Main> processes)
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("No", "#");
            dataGridView1.Columns.Add("Segment", "Segment Name");
            dataGridView1.Columns.Add("Station", "Station Name");
            dataGridView1.Rows.Add();

            DataTable dt = new DataTable("Segmet_Station");
            dt.Columns.Add("No");
            dt.Columns.Add("Segment");
            dt.Columns.Add("Station");

            DataTable dtstation_serial_number = new DataTable("Station_Serial_Number");
            dtstation_serial_number.Columns.Add("manufacturing_order_id");
            dtstation_serial_number.Columns.Add("Station");
            dtstation_serial_number.Columns.Add("serial_number");

            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
            {
                Name = "Printing",
                HeaderText = "View",
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            dataGridView1.Columns.Add(imgColumn);


            string defaultImagePath = Path.Combine(Application.StartupPath, "Assets", "file.png");
            Image originalImage = Image.FromFile(defaultImagePath);
            Image resizedImage = ResizeImage(originalImage, 60, 60);

            int index = 1;
            foreach (var process_list in processes)
            {
                var segment = process_list.segment;
                foreach (var segment_list in segment)
                {
                    var station = segment_list.station;
                    if (segment_list.name == "Rain Test") continue;
                    if (segment_list.name == "Main Assembly") continue;
                    if (segment_list.name == "In-station QC") continue;
                    if (segment_list.name == "EOL Test") continue;
                    if (segment_list.name == "Final Assembly") continue;
                    if (segment_list.name == "Final QC") continue;
                    if (segment_list.name == "Packing") continue;
                    foreach (var station_list in station)
                    {
                        bool exists = dt.AsEnumerable().Where(c => c.Field<string>("Station").Equals(station_list.name)).Count() > 0;
                        if (!exists)
                        {
                            dt.Rows.Add(index++, segment_list.name, station_list.name);
                        }
                        dtstation_serial_number.Rows.Add(segment_list.manufacturing_order_id, station_list.name, station_list.serial_number);
                        //dataGridView1.Rows.Add(index++, segment_list.name,station_list.name, resizedImage, resizedImage2);
                    }
                }
            }
            dt_list_Station_Serial = dtstation_serial_number;
            dataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(row["no"].ToString(), row["Segment"].ToString(), row["Station"].ToString(), resizedImage);
            }
            btn_printallin1.Visible = true;
            Image ResizeImage(Image img, int width, int height)
            {
                Bitmap bmp = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(img, 0, 0, width, height);
                }
                return bmp;
            }
            //dataGridView1.Rows.Clear();
            //dataGridView1.Columns.Clear();

            //dataGridView1.Columns.Add("No", "#");
            //dataGridView1.Columns.Add("serial_number", "Serial Number");
            //dataGridView1.Columns.Add("mo_id", "Manufacturer Order ID");
            //dataGridView1.Columns.Add("bom_item", "Boom Item");
            //dataGridView1.Columns.Add("bom_revision_number", "Boom Rev.no");

            //var idColumn = dataGridView1.Columns.Add("id", "ID");
            //dataGridView1.Columns["id"].Visible = false;

            //DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
            //{
            //    Name = "Printing",
            //    HeaderText = "Print QR",
            //    ImageLayout = DataGridViewImageCellLayout.Zoom
            //};
            //dataGridView1.Columns.Add(imgColumn);
            //DataGridViewImageColumn imgColumn1 = new DataGridViewImageColumn
            //{
            //    Name = "viewtree",
            //    HeaderText = "TreeView",
            //    ImageLayout = DataGridViewImageCellLayout.Zoom
            //};
            //dataGridView1.Columns.Add(imgColumn1);

            //string defaultImagePath = Path.Combine(Application.StartupPath, "Assets", "printer.png");
            //Image originalImage = Image.FromFile(defaultImagePath);
            //Image resizedImage = ResizeImage(originalImage, 60, 60);

            //string viewImagePath = Path.Combine(Application.StartupPath, "Assets", "search.png");
            //Image viewImage = Image.FromFile(viewImagePath);
            //Image resizedImage2 = ResizeImage(viewImage, 60, 60);


            //int index = 1;
            //foreach (var process in processes)
            //{
            //    dataGridView1.Rows.Add(index++, process.serial_number, process.mo_id, process.bom_item, process.bom_revision_number, process.id, resizedImage, resizedImage2);
            //}

            //Image ResizeImage(Image img, int width, int height)
            //{
            //    Bitmap bmp = new Bitmap(width, height);
            //    using (Graphics g = Graphics.FromImage(bmp))
            //    {
            //        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //        g.DrawImage(img, 0, 0, width, height);
            //    }
            //    return bmp;
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 &&
               e.ColumnIndex == dataGridView1.Columns["Printing"].Index)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                var station_name = row.Cells["Station"].Value?.ToString();
                //ViewStationGeneratedSerials qrprint = new ViewStationGeneratedSerials(station_name, dt_list_Station_Serial);
                ViewStationGeneratedSerials_1 qrprint1 = new ViewStationGeneratedSerials_1(storedmoid, station_name, dt_list_Station_Serial);
                qrprint1.ShowDialog();
            }
            //if (e.RowIndex >= 0 &&
            //   e.ColumnIndex == dataGridView1.Columns["Printing"].Index)
            //    //{
            //    var row = dataGridView1.Rows[e.RowIndex];

            //    // Get quantity and count values
            //    var id = row.Cells["id"].Value?.ToString();
            //    var moid = row.Cells["mo_id"].Value?.ToString();
            //    var serialNumber = row.Cells["serial_number"].Value?.ToString();
            //    var station_name = row.Cells["Station"].Value?.ToString();
            //    Printqrcodeform qrprint = new Printqrcodeform(ApiUrl, id, moid, serialNumber);
            //    qrprint.ShowDialog();
            //}
            //else if (e.RowIndex >= 0 &&
            //    e.ColumnIndex == dataGridView1.Columns["viewtree"].Index)
            //{
            //    var row = dataGridView1.Rows[e.RowIndex];

            //    var id = row.Cells["id"].Value?.ToString();
            //    var moid = row.Cells["mo_id"].Value?.ToString();
            //    var serialNumber = row.Cells["serial_number"].Value?.ToString();
            //    Debug.WriteLine($"View Tree for MO ID: {moid} with ID: {id}");
            //    printingqrviewForm printingqrviewForm = new printingqrviewForm(ApiUrl, id, moid, serialNumber);
            //    printingqrviewForm.ShowDialog();
            //}

        }
        private void btn_printallin1_Click(object sender, EventArgs e)
        {
            DataTable newdataforPrint = new DataTable("newdataforPrint");

            // Define columns
            newdataforPrint.Columns.Add("manufacturing_order_id", typeof(string));
            newdataforPrint.Columns.Add("Station", typeof(string));
            newdataforPrint.Columns.Add("serial_number", typeof(string));

            // Get the first manufacturing_order_id (as string)
            var firstBatchId = dt_list_Station_Serial.AsEnumerable()
                .Select(row => row.Field<string>("manufacturing_order_id"))
                .Distinct()
                .OrderBy(id => id)
                .FirstOrDefault();

            // Filter rows that belong to the first batch
            var firstBatchRows = dt_list_Station_Serial.AsEnumerable()
                .Where(row => row.Field<string>("manufacturing_order_id") == firstBatchId)
                .ToList();

            // Fill the new DataTable
            foreach (var row in firstBatchRows)
            {
                string moId = row.Field<string>("manufacturing_order_id");
                string station = row.Field<string>("Station");
                string serial = row.Field<string>("serial_number");

                newdataforPrint.Rows.Add(moId, station, serial);
            }

            printingqrviewForm printingqrviewForm = new printingqrviewForm(newdataforPrint);
            printingqrviewForm.ShowDialog();
        }

    }
}
