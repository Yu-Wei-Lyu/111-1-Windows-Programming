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
        private const string SHAPE_TYPE = "Triangle";
        private Point _top;
        private Point _leftBottom;
        private Point _rightBottom;

        // Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawTriangle(X1, Y1, X2, Y2);
            double triangleWidth = X2 - X1;
            double topPointX = X1 + triangleWidth / 2;
            _top = new Point(topPointX, Y1);
            _leftBottom = new Point(X2, Y2);
            _rightBottom = new Point(X1, Y2);
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
        public override bool IsContain(Point point)
        {
            GraphicsPath myGraphicsPath = new GraphicsPath();
            Region myRegion = new Region();
            myGraphicsPath.Reset();
            System.Drawing.Point inputponint = new System.Drawing.Point((float)point.X, (float)point.Y);


            myGraphicsPath.AddPolygon(points);//points);

            myRegion.MakeEmpty();

            myRegion.Union(myGraphicsPath);
            //返回判斷點是否在多邊形裏
            return myRegion.IsVisible(inputponint);
            this.lblx.Text = myPoint.ToString();
            //return this.IsInTriangle(this._top, this._leftBottom, this._rightBottom, point);
        }

        // IsInTriangle
        public bool IsInTriangle(Point point1, Point point2, Point point3, Point mousePoint)
        {
            if (GetProductOfPoints(point1, point2, point3) < 0) 
                return IsInTriangle(point1, point3, point2, mousePoint);
            if (GetProductOfPoints(point1, point2, mousePoint) > 0 && GetProductOfPoints(point2, point3, mousePoint) > 0 && GetProductOfPoints(point3, point1, mousePoint) > 0)
                return true;
            return false;
        }

        // GetProductOfPoints
        public double GetProductOfPoints(Point p1, Point p2, Point p3)
        {
            return (p2.X - p1.X) * (p3.Y - p1.Y) - (p2.Y - p1.Y) * (p3.Y - p1.Y);
        }
    }
}
