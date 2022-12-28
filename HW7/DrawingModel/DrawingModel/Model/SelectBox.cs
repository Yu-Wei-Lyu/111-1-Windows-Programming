using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class SelectBox : Shape
    {
        private const int HALF = 2;
        private const string SHAPE_TYPE = "SelectBox";
        private Shape _referenceShape;

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

        public override Shape ReferenceShape1
        {
            get
            {
                return _referenceShape;
            }
            set
            {
                if (value != null)
                {
                    this.X1 = value.X1;
                    this.Y1 = value.Y1;
                    this.X2 = value.X2;
                    this.Y2 = value.Y2;
                    _referenceShape = value;
                }
            }
        }
    }
}
