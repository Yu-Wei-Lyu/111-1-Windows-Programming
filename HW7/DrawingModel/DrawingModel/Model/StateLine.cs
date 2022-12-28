using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class StateLine : AbstractState
    {
        private const string STATE_TYPE = "Line";
        private AbstractShape _referenceShape1;
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
            AbstractShape referenceShapeFirst = shapes.GetSelectedPointShape(pointX, pointY);
            _referenceShape1 = referenceShapeFirst;
            this.KeepAlive = true;
            if (referenceShapeFirst == null)
                return null;
            AbstractShape newShape = this._shapeFactory.CreateShape(shapeType);
            newShape.ReferenceShape1 = referenceShapeFirst;
            newShape.X2 = pointX;
            newShape.Y2 = pointY;
            return newShape;
        }

        // Moved
        public override AbstractShape Moved(AbstractShape shape, double pointX, double pointY)
        {
            if (shape != null)
            {
                shape.X2 = pointX;
                shape.Y2 = pointY;
            }
            return shape;
        }

        // Released
        public override AbstractShape Released(Shapes shapes, AbstractShape movedShape, double pointX, double pointY)
        {
            AbstractShape referenceShape = shapes.GetSelectedPointShape(pointX, pointY);
            if (_referenceShape1 == null || referenceShape == null || referenceShape == _referenceShape1)
            {
                this.KeepAlive = true;
                return null;
            }
            AbstractShape newShape = this._shapeFactory.CreateShape(this.ShapeType);
            newShape.ReferenceShape1 = _referenceShape1;
            newShape.ReferenceShape2 = referenceShape;
            this.KeepAlive = false;
            return newShape;
        }
    }
}
