﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{

    abstract public class Shape
    {
        public Shapes _shapes;
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

        // IsSame
        virtual public bool IsSame(Shape shape)
        {
            return this == shape;
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
        virtual public void SetPointsByReference(Shape referenceShape)
        {

        }

        // SetPoints
        virtual public void SetPointsByReference(Shape referenceShapeFirst, Shape referenceShapeSecond)
        {

        }

        // SetPoints
        virtual public void SetPoints(double x1, double y1)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x1;
            Y2 = y1;
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
