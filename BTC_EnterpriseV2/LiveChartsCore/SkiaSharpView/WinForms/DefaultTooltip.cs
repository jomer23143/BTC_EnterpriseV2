using LiveChartsCore.Kernel;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView.Painting;

namespace LiveChartsCore.SkiaSharpView.WinForms
{
    internal class DefaultTooltip : IChartTooltip
    {
        public SolidColorPaint Background { get; set; }
        public SolidColorPaint TextPaint { get; set; }
        public SolidColorPaint BorderPaint { get; set; }
        public int BorderThickness { get; set; }

        public void Hide(LiveChartsCore.Chart chart)
        {
            throw new NotImplementedException();
        }

        public void Show(IEnumerable<ChartPoint> foundPoints, LiveChartsCore.Chart chart)
        {
            //  throw new NotImplementedException();
        }
    }
}