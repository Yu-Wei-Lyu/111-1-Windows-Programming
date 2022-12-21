using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Triangle : Shape
    {
        private const int HALF = 2;
        private const string SHAPE_TYPE = "Triangle";
        private PointF _top = new PointF();
        private PointF _leftBottom = new PointF();
        private PointF _rightBottom = new PointF();

        // Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawTriangle(X1, Y1, X2, Y2);
            SetTrianglePoints();
        }

        // ViewDraw
        public override void PreviewDraw(IGraphics graphics)
        {
            graphics.PreviewTriangle(X1, Y1, X2, Y2);
        }

        // GetShapeType
        public override string GetShapeType()
        {
            return SHAPE_TYPE;
        }

        // IsContain
        public override bool IsContain(double pointX, double pointY)
        {
            GraphicsPath myGraphicsPath = new GraphicsPath();
            Region myRegion = new Region();
            myGraphicsPath.Reset();
            System.Drawing.PointF inputPoint = new System.Drawing.PointF((float)pointX, (float)pointY);
            System.Drawing.PointF[] points = new PointF[] { _top, _leftBottom, _rightBottom };
            myGraphicsPath.AddPolygon(points);
            myRegion.MakeEmpty();
            myRegion.Union(myGraphicsPath);
            return myRegion.IsVisible(inputPoint);
        }

        // SetTrianglePoints
        public void SetTrianglePoints()
        {
            _top = new PointF((float)X1 + ((float)X2 - (float)X1) / HALF, (float)Y1);
            _leftBottom = new PointF((float)X2, (float)Y2);
            _rightBottom = new PointF((float)X1, (float)Y2);
        }
    }
}
