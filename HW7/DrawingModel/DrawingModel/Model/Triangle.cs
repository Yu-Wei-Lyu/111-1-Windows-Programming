using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Triangle : Shape
    {
        private const string SHAPE_TYPE = "Triangle";

        // Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawTriangle(X1, Y1, X2, Y2);
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
        //public override bool IsContain(double x, double y)
        //{
        //    return false;
        //    double product(Point p1, Point p2, Point p3)
        //    {
        //        //首先根据坐标计算p1p2和p1p3的向量，然后再计算叉乘
        //        //p1p2 向量表示为 (p2.x-p1.x,p2.y-p1.y)
        //        //p1p3 向量表示为 (p3.x-p1.x,p3.y-p1.y)
        //        return (p2.x - p1.x) * (p3.y - p1.y) - (p2.y - p1.y) * (p3.x - p1.x);
        //    }
        //    bool isInTriangle(Point p1, Point p2, Point p3, Point o)
        //    {
        //        //保证p1，p2，p3是逆时针顺序
        //        if (product(p1, p2, p3) < 0) return isInTriangle(p1, p3, p2, o);
        //        if (product(p1, p2, o) > 0 && product(p2, p3, o) > 0 && product(p3, p1, o) > 0)
        //            return true;
        //        return false;
        //    }
        //}
    }
}
