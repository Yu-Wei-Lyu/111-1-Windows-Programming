using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Triangle : Shape
    {
        private const int DOUBLE = 2;
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
            this.SetTrianglePoints();
            PointF clickPoint = new PointF((float)pointX, (float)pointY);
            double fullTriangleArea = GetTriangleArea(_top, _rightBottom, _leftBottom);
            double triangleArea1 = GetTriangleArea(_top, _rightBottom, clickPoint);
            double triangleArea2 = GetTriangleArea(_top, clickPoint, _leftBottom);
            double triangleArea3 = GetTriangleArea(clickPoint, _rightBottom, _leftBottom);
            double a = Math.Abs(triangleArea1 * triangleArea2 * triangleArea3);
            if (Math.Abs(triangleArea1 * triangleArea2 * triangleArea3) - 0 < 1) 
                return true;
            else
                return Math.Abs(fullTriangleArea - (triangleArea1 + triangleArea2 + triangleArea3)) < 1;
        }

        // SetTrianglePoints
        public void SetTrianglePoints()
        {
            _top = new PointF(this.GetHalfPointX(), (float)this.Y1);
            _leftBottom = new PointF((float)this.X2, (float)this.Y2);
            _rightBottom = new PointF((float)this.X1, (float)this.Y2);
        }

        // GetTriangleArea
        public double GetTriangleArea(PointF point1, PointF point2, PointF point3)
        {
            double side1 = this.GetSideLength(point1, point2);
            double side2 = this.GetSideLength(point1, point3);
            double side3 = this.GetSideLength(point2, point3);
            double halfCircleArgument = (side1 + side2 + side3) / DOUBLE;
            return Math.Sqrt(halfCircleArgument * (halfCircleArgument - side1) * (halfCircleArgument - side2) * (halfCircleArgument - side3));
        }

        // GetSideLength
        public double GetSideLength(PointF point1, PointF point2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(point1.X - point2.X), DOUBLE) + Math.Pow(Math.Abs(point1.Y - point2.Y), DOUBLE));
        }
    }
}
