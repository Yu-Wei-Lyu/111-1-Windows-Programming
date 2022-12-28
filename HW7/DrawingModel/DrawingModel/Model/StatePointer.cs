using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class StatePointer : AbstractState
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
        public override AbstractShape Pressed(Shapes shapes, string shapeType, double pointX, double pointY)
        {
            this.ShapeType = shapeType;
            return this.HandleSelect(shapes, pointX, pointY);
        }

        // Moved
        public override AbstractShape Moved(AbstractShape shape, double pointX, double pointY)
        {
            return shape;
        }

        // Released
        public override AbstractShape Released(Shapes shapes, AbstractShape movedShape, double pointX, double pointY)
        {
            return this.HandleSelect(shapes, pointX, pointY);
        }

        // HandleSelect
        public AbstractShape HandleSelect(Shapes shapes, double pointX, double pointY)
        {
            AbstractShape referenceShape = shapes.GetSelectedPointShape(pointX, pointY);
            if (referenceShape == null)
            {
                this.HintText = "";
                return null;
            }
            this.HintText = string.Format(SELECT_HINT_TEXT, referenceShape.GetShapeType(), (int)referenceShape.GetSmallX(), (int)referenceShape.GetSmallY(), (int)referenceShape.GetLargeX(), (int)referenceShape.GetLargeY());
            AbstractShape newShape = this._shapeFactory.CreateShape(this.ShapeType);
            newShape.ReferenceShape1 = referenceShape;
            return newShape;
        }
    }
}