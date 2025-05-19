using System.Drawing.Drawing2D;

namespace BTCP_EnterpriseV2.YaoUI
{
    public class YUI
    {
        private GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();

            path.StartFigure();

            // top left corner
            path.AddArc(rect.Left, rect.Top, radius * 2, radius * 2, 180f, 90f);
            path.AddLine(rect.Left + radius, rect.Top, rect.Right - radius, rect.Top);

            // top right corner
            path.AddArc(rect.Right - 2 * radius, rect.Top, radius * 2, radius * 2, 270f, 90f);
            path.AddLine(rect.Right, rect.Top + radius, rect.Right, rect.Bottom - radius);

            // bottom right corner
            path.AddArc(rect.Right - 2 * radius, rect.Bottom - 2 * radius, radius * 2, radius * 2, 0f, 90f);
            path.AddLine(rect.Right - radius, rect.Bottom, rect.Left + radius, rect.Bottom);

            // bottom left corner
            path.AddArc(rect.Left, rect.Bottom - 2 * radius, radius * 2, radius * 2, 90f, 90f);
            path.CloseFigure();

            return path;
        }

        public void RoundedFormsDocker(Form obj, int size)
        {
            var path = GetRoundedRectangle(obj.ClientRectangle, size);
            obj.Region = new Region(path);
        }

        public void RoundedPanelDocker(Panel obj, int v)
        {
            var path = GetRoundedRectangle(obj.ClientRectangle, 10);
            obj.Region = new Region(path);
        }

        public void RoundDataGridView(DataGridView obj)
        {
            var path = GetRoundedRectangle(obj.ClientRectangle, 15);
            obj.Region = new Region(path);
        }

        public void RoundedPanelModuleName(Panel obj)
        {
            var path = GetRoundedRectangle(obj.ClientRectangle, 10);
            obj.Region = new Region(path);
        }
        public void CirclePanel(Panel obj)
        {
            var path = GetRoundedRectangle(obj.ClientRectangle, 100);
            obj.Region = new Region(path);
        }

        public void RoundedButton(Button obj, int size, Color color)
        {
            var path = GetRoundedRectangle(obj.ClientRectangle, size);
            obj.Region = new Region(path);
            obj.BackColor = color;
        }
        public void RoundedTextBox(TextBox obj, int size, Color color)
        {
            var path = GetRoundedRectangle(obj.ClientRectangle, size);
            obj.Region = new Region(path);
            obj.BackColor = color;
        }
    }
}
