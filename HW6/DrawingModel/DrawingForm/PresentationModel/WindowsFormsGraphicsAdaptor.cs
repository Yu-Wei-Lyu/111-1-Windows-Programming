using System.Windows.Forms;
using System.Drawing;
using DrawingModel;

namespace DrawingForm.Presentation
{
    class WindowsFormsGraphicsAdaptor : GraphicsInterface
    {
        Graphics _graphics;

        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        // ClearAll
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        // DrawLine
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        // DrawRectangle
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        // DrawTriangle
        public void DrawTriangle(double x1, double y1, double x2, double y2)
        {
            Point leftBottom = new Point((int)x1, (int)y2);
            //_graphics.FillPolygon(Brushes.Black,)
            // FillPolygon(Brushes.Aquamarine, new Point[] { p, new Point(p.X - size, p.Y + (int)(size * Math.Sqrt(3))), new Point(p.X + size, p.Y + (int)(size * Math.Sqrt(3))) });
        }
    }
}
