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
            graphics.DrawSelectBox(X1, Y1, X2, Y2);
        }

        // HintDraw
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
