using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Line
    {
        private double _x1;
        private double _y1;
        private double _x2;
        private double _y2;

        // Draw line
        public void Draw(GraphicsInterface graphics)
        {
            graphics.DrawLine(_x1, _y1, _x2, _y2);
        }

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

    }
}
