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
        private Shape _referenceShapeFirst;
        private Shape _referenceShapeSecond;

        // Draw
        public override void Draw(IGraphics graphics)
        {
            if (_referenceShapeFirst != null)
            {
                this.X1 = (_referenceShapeFirst.X1 + _referenceShapeFirst.X2) / HALF;
                this.Y1 = (_referenceShapeFirst.Y1 + _referenceShapeFirst.Y2) / HALF;
            }
            if (_referenceShapeSecond != null)
            {
                this.X2 = (_referenceShapeSecond.X1 + _referenceShapeSecond.X2) / HALF;
                this.Y2 = (_referenceShapeSecond.Y1 + _referenceShapeSecond.Y2) / HALF;
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

        // SetPointsByReference
        public override void SetReference(Shape referenceShape)
        {
            _referenceShapeFirst = referenceShape;
        }

        // SetPointsByReference
        public override void SetReference(Shape referenceShapeFirst, Shape referenceShapeSecond)
        {
            _referenceShapeFirst = referenceShapeFirst;
            _referenceShapeSecond = referenceShapeSecond;
        }
    }
}
