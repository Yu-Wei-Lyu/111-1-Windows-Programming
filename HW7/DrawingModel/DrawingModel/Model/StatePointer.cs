using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class StatePointer : StateClickHandler
    {
        private const string SHAPE_TYPE_SELECT_BOX = "SelectBox";
        // Pressed 
        public override Shape Pressed(Shapes shapes, string shapeType, double pointX, double pointY)
        {
            return this.HandleSelect(shapes, pointX, pointY);
        }

        // Moved
        public override Shape Moved(Shape shape, double pointX, double pointY)
        {
            return shape;
        }

        // Released
        public override Shape Released(Shapes shapes, Shape movedShape, double pointX, double pointY)
        {
            return this.HandleSelect(shapes, pointX, pointY);
        }

        // HandleSelect
        public Shape HandleSelect(Shapes shapes, double pointX, double pointY)
        {
            Shape referenceShape = shapes.GetSelectedPointShape(pointX, pointY);
            if (referenceShape == null)
            {
                this._hintText = "";
                return null;
            }
            else
            {
                this._hintText = string.Format("Select：{0}({1}, {2}, {3}, {4})", referenceShape.GetShapeType(), referenceShape.GetSmallX(), referenceShape.GetSmallY(), referenceShape.GetLargeX(), referenceShape.GetLargeY());
                Shape newShape = this._shapeFactory.CreateShape(SHAPE_TYPE_SELECT_BOX);
                newShape.SetPointsByReference(referenceShape);
                return newShape;
            }
        }
    }
}