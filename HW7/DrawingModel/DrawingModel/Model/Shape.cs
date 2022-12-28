using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{

    abstract public class Shape
    {
        private const int DOUBLE = 2;
        private const string LINE = "Line";

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
            return (pointX - smallX) * (largeX - pointX) >= 0 && (pointY - smallY) * (largeY - pointY) >= 0;
        }

        // SetPoints
        virtual public float GetHalfPointX()
        {
            return (float)this.X1 + ((float)this.X2 - (float)this.X1) / DOUBLE;
        }

        // GetShape
        virtual public double GetLargeX()
        {
            return (this.X1 > this.X2) ? this.X1 : this.X2;
        }

        // GetShape
        virtual public double GetLargeY()
        {
            return (this.Y1 > this.Y2) ? this.Y1 : this.Y2;
        }

        // GetShape
        virtual public double GetSmallX()
        {
            return (this.X1 < this.X2) ? this.X1 : this.X2;
        }

        // GetShape
        virtual public double GetSmallY()
        {
            return (this.Y1 < this.Y2) ? this.Y1 : this.Y2;
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

        virtual public Shape ReferenceShape1
        {
            get;
            set;
        }

        virtual public Shape ReferenceShape2
        {
            get;
            set;
        }
    }
}
