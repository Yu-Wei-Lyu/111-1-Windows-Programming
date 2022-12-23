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
            this.PreviewDraw(graphics);
        }

        // HintDraw
        public override void PreviewDraw(IGraphics graphics)
        {
            graphics.DrawSelectBox(this.X1, this.Y1, this.X2, this.Y2);
        }

        // GetShapeType
        public override string GetShapeType()
        {
            return SHAPE_TYPE;
        }

        // SetPoints
        public override void SetPointsByReference(Shape shape)
        {
            this.X1 = shape.X1;
            this.Y1 = shape.Y1;
            this.X2 = shape.X2;
            this.Y2 = shape.Y2;
        }
    }
}
