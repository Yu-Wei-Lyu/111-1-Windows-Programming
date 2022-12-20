using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    
    public abstract class Shape
    {
        // Draw
        public abstract void Draw(IGraphics graphics);
        // HintDraw
        public abstract void PreviewDraw(IGraphics graphics);
        // GetShapeType
        public abstract string GetShapeType();
        // IsArea
        public virtual bool IsContain(double x, double y)
        {
            double largerX = (X2 < X1) ? X1 : X2;
            double smallerX = (X2 >= X1) ? X1 : X2;
            double largerY = (Y2 < Y1) ? Y1 : Y2;
            double smallerY = (Y2 >= Y1) ? Y1 : Y2;
            return (x <= largerX && x >= smallerX) && (y <= largerY && y >= smallerY);
        }

        // SetPoints
        public virtual void SetPoints(double x1, double y1, double x2, double y2)
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
