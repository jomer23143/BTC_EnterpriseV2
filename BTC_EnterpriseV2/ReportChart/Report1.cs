using System.Text.Json;
using BTCP_EnterpriseV2.YaoUI;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;

namespace BTC_EnterpriseV2.ReportChart
{
    public partial class Report1 : Form
    {
        public Report1()
        {
            InitializeComponent();
            YUI yui = new YUI();
            yui.RoundedPanelDocker(panel_chart, 10);
        }

        private void Report1_SizeChanged(object sender, EventArgs e)
        {
            YUI yui = new YUI();
            yui.RoundedPanelDocker(panel_chart, 10);
        }
        private async void Report1_Load(object sender, EventArgs e)
        {
            await ViewChar();
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


    }
}
