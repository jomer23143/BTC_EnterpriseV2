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
            await ViewChart();
        }


        private async Task ViewChart()
        {
            var url = "https://app.btcp-enterprise.com/api/kit-list";
            using var client = new HttpClient();

            try
            {
                var json = await client.GetStringAsync(url);
                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var chartData = apiResponse.data
                    .Select(p => new
                    {
                        MoId = p.mo_id,
                        OrderQuantity = float.Parse(p.order_quantity),
                        Description = p.description,
                        Pcn = p.pcn_number,
                        BoomItem = p.bom_item
                    })
                    .ToList();

                var moIds = chartData.Select(x => x.MoId).ToArray();
                var orderQuantities = chartData.Select(x => x.OrderQuantity).ToArray();
                var descriptions = chartData.Select(x => x.Description).ToArray();
                var pcn = chartData.Select(x => x.Pcn).ToArray();
                var boomItems = chartData.Select(x => x.BoomItem).ToArray();

                panel_chart.Controls.Clear();

                var columnSeries = new ColumnSeries<float>
                {
                    Values = orderQuantities,
                    Name = "Total Order Quantity",
                    Fill = new SolidColorPaint(SKColors.CornflowerBlue),


                    XToolTipLabelFormatter = point =>
                                              $"{descriptions[point.Index]}"
                    ////$"🔹 PCN Number    : {pcn[point.Index]}\n" +
                    ////$"🔹 BOM Item      : {boomItems[point.Index]}\n" +
                    ////$"🔹 Order Quantity: {orderQuantities[point.Index]}"

                };


                var chart = new CartesianChart
                {
                    Series = new ISeries[] { columnSeries },
                    ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X,
                    XAxes = new[]
                    {
                new Axis
                {
                    Labels = moIds,
                    LabelsRotation = 15,
                    Name = "MO ID",
                    TextSize = 12
                }
            },
                    YAxes = new[]
                    {
                new Axis
                {
                    Labeler = value => ((int)value).ToString(),
                    Name = "Order Quantity",
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
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show($"Failed to load chart data: {ex.Message}");
            }
        }

        public class CustomChartData
        {
            public string MoId { get; set; }
            public float OrderQuantity { get; set; }
            public string Description { get; set; }
            public string Pcn { get; set; }
            public string BoomItem { get; set; }
        }

        public class ApiResponse
        {
            public int current_page { get; set; }
            public List<KitListItem> data { get; set; }
            public string first_page_url { get; set; }
            public int from { get; set; }
            public int last_page { get; set; }
            public string last_page_url { get; set; }
            public List<Link> links { get; set; }
            public object next_page_url { get; set; }
            public string path { get; set; }
            public int per_page { get; set; }
            public object prev_page_url { get; set; }
            public int to { get; set; }
            public int total { get; set; }
        }

        public class KitListItem
        {
            public int id { get; set; }
            public object kit_list_type_id { get; set; }
            public int? kit_list_status_id { get; set; }
            public string mo_id { get; set; }
            public string pcn_number { get; set; }
            public string description { get; set; }
            public string location { get; set; }
            public string bom_item { get; set; }
            public string bom_revision_number { get; set; }
            public string order_quantity { get; set; }
            public string order_date { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public Status status { get; set; }
        }

        public class Status
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string color { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }
        public class Link
        {
            public string url { get; set; }
            public string label { get; set; }
            public bool active { get; set; }
        }

    }
}
