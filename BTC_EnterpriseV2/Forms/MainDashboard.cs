using System.Data;
using System.Text.Json;
using BTC_EnterpriseV2.Class;
using BTC_EnterpriseV2.Forms;
using BTC_EnterpriseV2.Modal;
using BTC_EnterpriseV2.ProcessForm;
using BTC_EnterpriseV2.ReportChart;
using BTC_EnterpriseV2.SideBar;
using BTC_EnterpriseV2.YaoUI;
using BTCP_EnterpriseV2.Class;
using BTCP_EnterpriseV2.YaoUI;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
namespace BTCP_EnterpriseV2.Forms
{
    public partial class MainDashboard : Form
    {
        private int borderSize = 2;
        private Size formSize;
        private ContextMenuStrip imageMenu = new ContextMenuStrip();
        private FormManager formManager;
        private UIManager UIManager;
        private Manage_SubAssy Manage_SubAssy;
        public MainDashboard()
        {
            InitializeComponent();
            UIControls.SetupUI(this, Setting_Click, Logout_Click);
            formManager = new FormManager(panel_menubar, panel_sidebar);
            UIManager = new UIManager(panel_menubar, panel_main_display);
            Manage_SubAssy = new Manage_SubAssy(panel_menubar, panel_Subassy_Display);
        }
        private void MainDashboard_SizeChanged(object sender, EventArgs e)
        {
            UIControls.SetupUI(this, Setting_Click, Logout_Click);
        }
        private void Setting_Click(object? sender, EventArgs e)
        {
            PasswordForm passwordForm = new PasswordForm();
            passwordForm.StartPosition = FormStartPosition.CenterScreen;
            passwordForm.ShowDialog(this);
            //this.Close();
        }

        private void Logout_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_time.Text = DateTime.Now.ToString("hh:mm tt").ToUpper();
            lbl_currentdate.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy");
        }
        public void LoadChildForm(Form childForm)
        {
            if (this.panel_main_display.Controls.Count > 0)
                this.panel_main_display.Controls.Clear(); // Remove existing controls

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel_main_display.Controls.Add(childForm);
            this.panel_main_display.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        //this is for main panel form
        public void Load_MainPanel(Form mainPanel)
        {
            if (this.panel_Subassy_Display.Controls.Count > 0)
                this.panel_Subassy_Display.Controls.Clear(); // Remove existing controls
            mainPanel.TopLevel = false;
            mainPanel.FormBorderStyle = FormBorderStyle.None;
            mainPanel.Dock = DockStyle.Fill;
            this.panel_Subassy_Display.Controls.Add(mainPanel);
            this.panel_Subassy_Display.Tag = mainPanel;
            mainPanel.BringToFront();
            mainPanel.Show();
        }
        //this is for load sidebar form
        public void LoadSideBar(Form Sidbar)
        {
            if (this.panel_sidebar.Controls.Count > 0)
                this.panel_sidebar.Controls.Clear(); // Remove existing controls

            Sidbar.TopLevel = false;
            Sidbar.FormBorderStyle = FormBorderStyle.None;
            Sidbar.Dock = DockStyle.Fill;
            this.panel_sidebar.Controls.Add(Sidbar);
            this.panel_sidebar.Tag = Sidbar;
            Sidbar.BringToFront();
            Sidbar.Show();
        }
        private void panel_menubar_MouseDown(object sender, MouseEventArgs e)
        {
            // DragForm.ReleaseCapture();
            // DragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private async void MainDashboard_Load(object sender, EventArgs e)
        {
            formManager.OpenChildForm(new MainSidebar(), sender);
            await ViewChar();


        }

        private void panel_main_display_SizeChanged(object sender, EventArgs e)
        {
            UIControls.SetupUI(this, Setting_Click, Logout_Click);
        }

        private void btn_warehouserecieving_Click(object sender, EventArgs e)
        {
            // formManager.OpenChildForm(new SideBar.WarehouseKitingSidebar(), sender);

        }
        private void BTN_Warehouse_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(BTN_Warehouse, new Point(0, BTN_Warehouse.Height));
        }
        private void btn_productionprocess_Click(object sender, EventArgs e)
        {
            if (this.panel_main_display.Controls.Count > 0)
                this.panel_main_display.Controls.Clear();
            if (this.panel_sidebar.Controls.Count > 0)
                this.panel_sidebar.Controls.Clear();
            GetModalFrm getmo = new GetModalFrm();
            var scannedMO = string.Empty;
            object[] responsedata;
            string boomid = string.Empty;
            // Create an instance of GetBoomItem
            GetBoomItemID_Class getBoomItemInstance = new GetBoomItemID_Class();

            // Subscribe to event
            getmo.SerialScanned += async (serial) =>
            {
                scannedMO = Convert.ToString(serial);
                responsedata = await getBoomItemInstance.getBoomID(scannedMO);
                Console.WriteLine($"Boom ID: {responsedata[0]}");
                if (responsedata.Length > 0)
                {
                    boomid = responsedata[0].ToString();
                }
                Console.WriteLine($"Boom Data Pass:", boomid);
                SegmentFrm prdsegment = new SegmentFrm(boomid);
                prdsegment.TopLevel = false;
                this.FormBorderStyle = FormBorderStyle.None;
                prdsegment.Dock = DockStyle.Fill;
                if (Application.OpenForms["MainDashboard"] is MainDashboard mainDashboard)
                {
                    mainDashboard.LoadChildForm(prdsegment);
                }
                else
                {
                    Console.WriteLine("MainDashboard form is not open.");
                }
            };
            this.FormBorderStyle = FormBorderStyle.None;
            getmo.ShowDialog(this);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.panel_sidebar.Controls.Count > 0)
                this.panel_sidebar.Controls.Clear();
            var segmentname = "Sub Assembly";
            SubAssy_Serial_Scanner showScanner = new SubAssy_Serial_Scanner(segmentname);
            var scannedSerial = string.Empty;
            object[] responsedata;
            string boomid = string.Empty;
            // Create an instance of GetBoomItem
            GetBoomItemID_Class getBoomItemInstance = new GetBoomItemID_Class();

            // Subscribe to event
            showScanner.SerialScanned += async (serial) =>
            {
                scannedSerial = Convert.ToString(serial);

                Manage_SubAssy.OpenChildForm(new Sub_AssyFrm(scannedSerial), sender);
            };
            this.FormBorderStyle = FormBorderStyle.None;
            showScanner.ShowDialog(this);

        }

        private async Task ViewChar()
        {
            var url = "https://app.btcp-enterprise.com/api/product?with_segment";
            using var client = new HttpClient();

            try
            {
                var json = await client.GetStringAsync(url);
                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var descriptionsGrouped = apiResponse.data
                    .GroupBy(p => p.description)
                    .Select(g => new
                    {
                        Description = g.Key,
                        Count = g.Count()
                    })
                    .ToList();

                var descriptions = descriptionsGrouped.Select(x => x.Description).ToArray();
                var counts = descriptionsGrouped.Select(x => x.Count).ToArray();

                panel_chart.Controls.Clear();

                var columnSeries = new ColumnSeries<int>
                {
                    Values = counts,
                    Name = "Product Count",
                    Fill = new SolidColorPaint(SKColors.CornflowerBlue),
                    //TooltipLabelFormatter = point => $"{descriptions[point.Index]}: {point.PrimaryValue}"
                };

                var chart = new CartesianChart
                {
                    Series = new ISeries[] { columnSeries },
                    ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X,
                    XAxes = new[] {
                new Axis {
                    Labels = descriptions,
                    LabelsRotation = 15,
                    Name = "Description",
                    TextSize = 12
                }
            },
                    YAxes = new[] {
                new Axis {
                    Labeler = value => value.ToString(),
                    Name = "Count",
                    TextSize = 12
                }
            },
                    LegendPosition = LiveChartsCore.Measure.LegendPosition.Top
                };

                chart.Dock = DockStyle.Fill;
                panel_chart.Controls.Add(chart);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error", ex.Message);
                MessageBox.Show($"Failed to load chart data: {ex.Message}");
            }
        }


        public class Product
        {
            public int id { get; set; }
            public string bom_item { get; set; }
            public string description { get; set; }
            public string bom_revision_number { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }

        public class ApiResponse
        {
            public List<Product> data { get; set; }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            if (this.panel_sidebar.Controls.Count > 0)
                this.panel_sidebar.Controls.Clear();
            Manage_SubAssy.closeAForm();
            UIManager.OpenChildForm(new Report1(), sender);

        }

        private void warehouseRecievingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //formManager.OpenChildForm(new SideBar.WarehouseKitingSidebar(), sender);
            Manage_SubAssy.OpenChildForm(new Warehousekitting(), sender);
        }

        private void kitlistRecievingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  formManager.OpenChildForm(new Kitlist_Sidebar(), sender);
            Manage_SubAssy.OpenChildForm(new KitlistRecieving(), sender);
        }


    }
}
