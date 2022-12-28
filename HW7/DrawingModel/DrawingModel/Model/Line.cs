using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Line : Shape
    {
        private const string SHAPE_TYPE = "Line";
        private const int HALF = 2;
        private Shape _referenceShape1 = null;
        private Shape _referenceShape2 = null;

        // Draw
        public override void Draw(IGraphics graphics)
        {
            if (_referenceShape1 != null)
            {
                this.X1 = (_referenceShape1.X1 + _referenceShape1.X2) / HALF;
                this.Y1 = (_referenceShape1.Y1 + _referenceShape1.Y2) / HALF;
            }
            if (_referenceShape2 != null)
            {
                this.X2 = (_referenceShape2.X1 + _referenceShape2.X2) / HALF;
                this.Y2 = (_referenceShape2.Y1 + _referenceShape2.Y2) / HALF;
            }
            graphics.DrawLine(this.X1, this.Y1, this.X2, this.Y2);
        }

        // ViewDraw
        public override void PreviewDraw(IGraphics graphics)
        {
            this.Draw(graphics);
        }

        // IsContain
        public override bool IsContain(double pointX, double pointY)
        {
            return false;
        }

        // GetShapeType
        public override string GetShapeType()
        {
            return SHAPE_TYPE;
        }

        public override Shape ReferenceShape1
        {
            get
            {
                return _referenceShape1;
            }
            set
            {
                if (value != null)
                {
                    this.X1 = (value.X1 + value.X2) / HALF;
                    this.Y1 = (value.Y1 + value.Y2) / HALF;
                    _referenceShape1 = value;
                }
            }
        }

        public override Shape ReferenceShape2
        {
            get
            {
                return _referenceShape2;
            }
            set
            {
                if (value != null)
                {
                    this.X2 = (value.X1 + value.X2) / HALF;
                    this.Y2 = (value.Y1 + value.Y2) / HALF;
                    _referenceShape2 = value;
                }
            }
        }
    }
}
