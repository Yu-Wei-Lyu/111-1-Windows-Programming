using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class SelectBox : Shape
    {
        private const string SHAPE_TYPE = "SelectBox";

        // Draw
        public override void Draw(IGraphics graphics)
        {
            if(this.referenceShapeFirst != null)
            {
                this.X1 = referenceShapeFirst.X1;
                this.Y1 = referenceShapeFirst.Y1;
                this.X2 = referenceShapeFirst.X2;
                this.Y2 = referenceShapeFirst.Y2;
            }
            graphics.DrawSelectBox(this.X1, this.Y1, this.X2, this.Y2);
        }

        // HintDraw
        public override void PreviewDraw(IGraphics graphics)
        {
            // do nothing   
        }

        // GetShapeType
        public override string GetShapeType()
        {
            return SHAPE_TYPE;
        }
    }
}
