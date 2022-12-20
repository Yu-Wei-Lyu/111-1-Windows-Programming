using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{

    abstract public class Shape
    {
        // Draw
        abstract public void Draw(IGraphics graphics);
        // HintDraw
        abstract public void PreviewDraw(IGraphics graphics);
        // GetShapeType
        abstract public string GetShapeType();
        // IsArea
        virtual public bool IsContain(Point point)
        {
            double largerX = (X2 < X1) ? X1 : X2;
            double smallerX = (X2 >= X1) ? X1 : X2;
            double largerY = (Y2 < Y1) ? Y1 : Y2;
            double smallerY = (Y2 >= Y1) ? Y1 : Y2;
            return (point.X <= largerX && point.X >= smallerX) && (point.Y <= largerY && point.Y >= smallerY);
        }

        // SetPoints
        virtual public void SetPoints(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public double X1
        {
            get;
            set;
        }
        public double Y1
        {
            get;
            set;
        }
        public double X2
        {
            get;
            set;
        }
        public double Y2
        {
            get;
            set;
        }
    }
}
