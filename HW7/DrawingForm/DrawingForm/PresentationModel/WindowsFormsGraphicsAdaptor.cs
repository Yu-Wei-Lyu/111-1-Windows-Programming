using System.Windows.Forms;
using System.Drawing;
using DrawingModel;

namespace DrawingForm.Presentation
{
    public class WindowsFormsGraphicsAdaptor : IGraphics
    {
        private const int HALF = 2;
        private Graphics _graphics;
        private const float CIRCLE_RADIUS = 4;
        private const float CIRCLE_DIAMETER = 8;

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
            float topPointX = (float)x1 + triangleWidth / HALF;
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
            Pen pen = new Pen(Brushes.Red, 3);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            _graphics.DrawPolygon(pen, GetRectanglePoints(x1, y1, x2, y2));
            double width = x2 - x1;
            double height = y2 - y1;
            this.DrawSelectPoint(x1, y1, width, height);
            this.DrawSelectPoint(x1, y2, width, height);
            this.DrawSelectPoint(x2, y1, width, height);
            this.DrawSelectPoint(x2, y2, width, height);
        }

        // SelectPoint
        public void DrawSelectPoint(double pointX, double pointY, double width, double height)
        {
            _graphics.FillEllipse(Brushes.White, (float)pointX - CIRCLE_RADIUS, (float)pointY - CIRCLE_RADIUS, CIRCLE_DIAMETER, CIRCLE_DIAMETER);
            _graphics.DrawEllipse(Pens.Black, (float)pointX - CIRCLE_RADIUS, (float)pointY - CIRCLE_RADIUS, CIRCLE_DIAMETER, CIRCLE_DIAMETER);
        }

        // DrawLine
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            float middlePointX = ((float)x1 + (float)x2) / HALF;
            PointF firstPoint = new PointF((float)x1, (float)y1);
            PointF secondPoint = new PointF(middlePointX, (float)y1);
            PointF thirdPoint = new PointF(middlePointX, (float)y2);
            PointF lastPoint = new PointF((float)x2, (float)y2);
            _graphics.DrawLine(Pens.Black, firstPoint, secondPoint);
            _graphics.DrawLine(Pens.Black, secondPoint, thirdPoint);
            _graphics.DrawLine(Pens.Black, thirdPoint, lastPoint);
        }
    }
}
