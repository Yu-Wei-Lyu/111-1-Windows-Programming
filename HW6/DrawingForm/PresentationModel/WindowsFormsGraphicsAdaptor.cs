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

        // DrawRectangle
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            PointF leftTop = new PointF((float)x1, (float)y1);
            PointF rightTop = new PointF((float)x2, (float)y1);
            PointF leftBottom = new PointF((float)x2, (float)y2);
            PointF rightBottom = new PointF((float)x1, (float)y2);
            _graphics.DrawPolygon(Pens.Black, new PointF[] { leftTop, rightTop, leftBottom, rightBottom });
        }

        // DrawTriangle
        public void DrawTriangle(double x1, double y1, double x2, double y2)
        {
            float triangleWidth = (float)x2 - (float)x1;
            float topPointX = (float)x1 + triangleWidth / 2;
            PointF top = new PointF(topPointX, (float)y1);
            PointF leftBottom = new PointF((float)x2, (float)y2);
            PointF rightBottom = new PointF((float)x1, (float)y2);
            _graphics.DrawPolygon(Pens.Black, new PointF[] { leftBottom, top, rightBottom });
        }
    }
}
