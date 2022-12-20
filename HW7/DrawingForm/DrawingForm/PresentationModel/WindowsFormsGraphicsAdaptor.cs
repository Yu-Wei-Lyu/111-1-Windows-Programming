using System.Windows.Forms;
using System.Drawing;
using DrawingModel;

namespace DrawingForm.Presentation
{
    public class WindowsFormsGraphicsAdaptor : IGraphics
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

        // GetRectanglePoints
        public PointF[] GetRectanglePoints(double x1, double y1, double x2, double y2)
        {
            PointF leftTop = new PointF((float)x1, (float)y1);
            PointF rightTop = new PointF((float)x2, (float)y1);
            PointF leftBottom = new PointF((float)x2, (float)y2);
            PointF rightBottom = new PointF((float)x1, (float)y2);
            return new PointF[] { leftTop, rightTop, leftBottom, rightBottom };
        }

        // GetTrianglePoints
        public PointF[] GetTrianglePoints(double x1, double y1, double x2, double y2)
        {
            float triangleWidth = (float)x2 - (float)x1;
            float topPointX = (float)x1 + triangleWidth / 2;
            PointF top = new PointF(topPointX, (float)y1);
            PointF leftBottom = new PointF((float)x2, (float)y2);
            PointF rightBottom = new PointF((float)x1, (float)y2);
            return new PointF[] { leftBottom, top, rightBottom };
        }

        // HintRectangle
        public void PreviewRectangle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawPolygon(Pens.Black, GetRectanglePoints(x1, y1, x2, y2));
        }

        // DrawRectangle
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            _graphics.FillPolygon(Brushes.Yellow, GetRectanglePoints(x1, y1, x2, y2));
            _graphics.DrawPolygon(Pens.Black, GetRectanglePoints(x1, y1, x2, y2));
        }

        // HintTriangle
        public void PreviewTriangle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawPolygon(Pens.Black, GetTrianglePoints(x1, y1, x2, y2));
        }

        // DrawTriangle
        public void DrawTriangle(double x1, double y1, double x2, double y2)
        {
            _graphics.FillPolygon(Brushes.Orange, GetTrianglePoints(x1, y1, x2, y2));
            _graphics.DrawPolygon(Pens.Black, GetTrianglePoints(x1, y1, x2, y2));
        }

        // DrawSelectBox
        public void DrawSelectBox(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawPolygon(Pens.Red, GetRectanglePoints(x1, y1, x2, y2));
        }
    }
}
