using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Line : Shape
    {
        private const string SHAPE_TYPE = "Line";
        private double _x1;
        private double _y1;
        private double _x2;
        private double _y2;

        public double X1
        {
            get
            {
                return _x1;
            }
            set
            {
                _x1 = value;
            }
        }

        public double X2
        {
            get
            {
                return _x2;
            }
            set
            {
                _x2 = value;
            }
        }

        public double Y1
        {
            get
            {
                return _y1;
            }
            set
            {
                _y1 = value;
            }
        }

        public double Y2
        {
            get
            {
                return _y2;
            }
            set
            {
                _y2 = value;
            }
        }

        // Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawTriangle(_x1, _y1, _x2, _y2);
        }

        // ViewDraw
        public override void PreviewDraw(IGraphics graphics)
        {
            graphics.PreviewTriangle(_x1, _y1, _x2, _y2);
        }

        // GetShapeType
        public override string GetShapeType()
        {
            return SHAPE_TYPE;
        }

        // GetCenter
        public double[] GetCenter()
        {
            double largerX = (_x2 < _x1) ? _x1 : _x2;
            double smallerX = (_x2 >= _x1) ? _x2 : _x1;
            double largerY = (_y2 < _y1) ? _y1 : _y2;
            double smallerY = (_y2 >= _y1) ? _y2 : _y1;
            return new double[] { (_x2 - _x1) / 2, (_y2 - _y1) / 2 };
        }

        // IsArea
        public bool IsArea(double x, double y)
        {
            double largerX = (_x2 < _x1) ? _x1 : _x2;
            double smallerX = (_x2 >= _x1) ? _x2 : _x1;
            double largerY = (_y2 < _y1) ? _y1 : _y2;
            double smallerY = (_y2 >= _y1) ? _y2 : _y1;
            return (x <= largerX && x >= smallerX) && (y <= largerY && y >= smallerY);
        }
    }
}
