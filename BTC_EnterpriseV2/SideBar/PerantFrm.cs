using System.Text.Json;
using BTC_EnterpriseV2.Forms;
using BTCP_EnterpriseV2.Class;
using BTCP_EnterpriseV2.YaoUI;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;

namespace BTC_EnterpriseV2.SideBar
{
    public partial class PerantFrm : Form
    {
        private bool isSidebarExpanded = false;
        YUI yUI = new YUI();
        private FormManager formManager;
        public PerantFrm()
        {
            InitializeComponent();
            formManager = new FormManager(panel_sidebarHolder, panel_display_holder);
            yUI.RoundedPanelDocker(panel_display_holder, 10);
            yUI.RoundedPanelDocker(panel_sidebarHolder, 10);
            yUI.RoundedPanelDocker(panel_chart, 10);
        }
        private void PerantFrm_SizeChanged(object sender, EventArgs e)
        {
            yUI.RoundedPanelDocker(panel_display_holder, 10);
            yUI.RoundedPanelDocker(panel_sidebarHolder, 10);
            yUI.RoundedPanelDocker(panel_chart, 10);
        }

        private async void PerantFrm_Load(object sender, EventArgs e)
        {
            await ViewChar();
        }


        private void btn_toggle_right_Click(object sender, EventArgs e)
        {
            if (isSidebarExpanded)
            {
                panel_sidebarHolder.Width = 295;
                isSidebarExpanded = true;
            }
            else
            {
                panel_sidebarHolder.Width = 60;
                isSidebarExpanded = false;

            }
            isSidebarExpanded = !isSidebarExpanded;
            this.PerformLayout();
            yUI.RoundedPanelDocker(panel_display_holder, 10);
            yUI.RoundedPanelDocker(panel_sidebarHolder, 10);
            yUI.RoundedPanelDocker(panel_chart, 10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formManager.OpenChildForm(new PrintQRFrm(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formManager.closeAForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formManager.OpenChildForm(new Warehousekitting(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formManager.OpenChildForm(new KitlistRecieving(), sender);
        }

        //for chart
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
                    YToolTipLabelFormatter = point => $"{descriptions[point.Index]}"
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
                    Labeler = value =>  ((int)value).ToString(),
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

        private void btn_logout_Click(object sender, EventArgs e)
        {

        }
    }
}
