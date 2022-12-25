using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class StatePointer : StateClickHandler
    {
        private const string STATE_TYPE = "Pointer";
        private const string SELECT_HINT_TEXT = "Select：{0}({1}, {2}, {3}, {4})";
        private ShapeFactory _shapeFactory = new ShapeFactory();

        // GetStateType
        public override string GetStateType()
        {
            return STATE_TYPE;
        }

        // Pressed 
        public override Shape Pressed(Shapes shapes, string shapeType, double pointX, double pointY)
        {
            this.ShapeType = shapeType;
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
                this.HintText = "";
                return null;
            }
            this.HintText = string.Format(SELECT_HINT_TEXT, referenceShape.GetShapeType(), referenceShape.GetSmallX(), referenceShape.GetSmallY(), referenceShape.GetLargeX(), referenceShape.GetLargeY());
            Shape newShape = this._shapeFactory.CreateShape(this.ShapeType);
            newShape.SetPointsByReference(referenceShape);
            return newShape;
        }
    }
}