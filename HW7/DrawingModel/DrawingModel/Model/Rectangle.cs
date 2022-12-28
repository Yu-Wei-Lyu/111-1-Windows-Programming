using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Rectangle : AbstractShape
    {
        private const string SHAPE_TYPE = "Rectangle";

        // Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(X1, Y1, X2, Y2);
        }

        // HintDraw
        public override void PreviewDraw(IGraphics graphics)
        {
            graphics.PreviewRectangle(X1, Y1, X2, Y2);
        }

        // GetShapeType
        public override string GetShapeType()
        {
            return SHAPE_TYPE;
        }
    }
}
