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
        virtual public bool IsContain(double pointX, double pointY)
        {
            double largeX = (X2 < X1) ? X1 : X2;
            double smallX = (X2 >= X1) ? X1 : X2;
            double largeY = (Y2 < Y1) ? Y1 : Y2;
            double smallY = (Y2 >= Y1) ? Y1 : Y2;
            return (pointX <= largeX && pointX >= smallX) && (pointY <= largeY && pointY >= smallY);
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
        public Shape referenceShapeFirst
        {
            get;
            set;
        }
        public Shape referenceShapeSecond
        {
            get;
            set;
        }
    }
}
