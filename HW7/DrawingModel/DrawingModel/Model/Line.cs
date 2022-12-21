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
        private const int HALF = 2;

        // Draw
        public override void Draw(IGraphics graphics)
        {
            if(this.referenceShapeFirst != null)
            {
                this.X1 = (this.referenceShapeFirst.X1 + this.referenceShapeFirst.X2) / HALF;
                this.Y1 = (this.referenceShapeFirst.Y1 + this.referenceShapeFirst.Y2) / HALF;
            }
            if(this.referenceShapeSecond != null)
            {
                this.X2 = (this.referenceShapeSecond.X1 + this.referenceShapeSecond.X2) / HALF;
                this.Y2 = (this.referenceShapeSecond.Y1 + this.referenceShapeSecond.Y2) / HALF;
            }
            graphics.dr
        }

        // ViewDraw
        public override void PreviewDraw(IGraphics graphics)
        {
            
        }

        // GetShapeType
        public override string GetShapeType()
        {
            return SHAPE_TYPE;
        }
    }
}
