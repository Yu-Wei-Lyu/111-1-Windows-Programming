using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class StateLine : StateClickHandler
    {
        private const string STATE_TYPE = "Line";
        private Shape _referenceShapeFirst;
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
            Shape referenceShapeFirst = shapes.GetSelectedPointShape(pointX, pointY);
            _referenceShapeFirst = referenceShapeFirst;
            this.KeepAlive = true;
            if (referenceShapeFirst == null)
                return null;
            Shape newShape = this._shapeFactory.CreateShape(shapeType);
            newShape.SetPointsByReference(referenceShapeFirst);
            newShape.X2 = pointX;
            newShape.Y2 = pointY;
            return newShape;
        }

        // Moved
        public override Shape Moved(Shape shape, double pointX, double pointY)
        {
            if (shape != null)
            {
                shape.X2 = pointX;
                shape.Y2 = pointY;
            }
            return shape;
        }

        // Released
        public override Shape Released(Shapes shapes, Shape movedShape, double pointX, double pointY)
        {
            Shape referenceShape = shapes.GetSelectedPointShape(pointX, pointY);
            if (_referenceShapeFirst == null || referenceShape == null || referenceShape == _referenceShapeFirst)
            {
                this.KeepAlive = true;
                return null;
            }
            Shape newShape = this._shapeFactory.CreateShape(this.ShapeType);
            newShape.SetPointsByReference(_referenceShapeFirst, referenceShape);
            this.KeepAlive = false;
            return newShape;
        }
    }
}
