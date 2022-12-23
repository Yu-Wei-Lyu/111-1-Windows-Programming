using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class StatePointer : StateClickHandler
    {
        // Pressed 
        public override Shape Pressed(Shapes shapes, string shapeType, double pointX, double pointY)
        {
            Shape referenceShape = shapes.GetSelectedPointShape(pointX, pointY);
            if (referenceShape == null)
            {
                this._hintText = "";
                return null;
            }
            else
            {
                this._hintText = string.Format("Select：{0}({1}, {2}, {3}, {4})", referenceShape.GetShapeType(), referenceShape.X1, referenceShape.Y1, referenceShape.X2, referenceShape.Y2);
                Shape newShape = this._shapeFactory.CreateSelectBox(referenceShape);
                return newShape;
            }
        }
        // Released
        public override Shape Released(Shapes shapes, Shape movedShape, double pointX, double pointY)
        {
            if (movedShape == null)
                return null;
            else
                return this.Pressed(shapes, this._shapeType, pointX, pointY);
        }
    }
}