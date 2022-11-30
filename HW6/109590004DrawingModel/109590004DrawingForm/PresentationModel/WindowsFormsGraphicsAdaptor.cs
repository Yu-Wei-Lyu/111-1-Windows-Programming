using System.Windows.Forms;
using System.Drawing;
using DrawingModel109590004;

namespace DrawingForm109590004.Presentation
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
    }
}
