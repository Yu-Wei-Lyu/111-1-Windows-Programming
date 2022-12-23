using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class StateLine : StateClickHandler
    {
        private const string SHAPE_TYPE_LINE = "Line";
        private Shape _referenceShapeFirst;

        // Pressed
        public override Shape Pressed(Shapes shapes, string shapeType, double pointX, double pointY)
        {
            Shape referenceShapeFirst = shapes.GetSelectedPointShape(pointX, pointY);
            _referenceShapeFirst = referenceShapeFirst;
            if (referenceShapeFirst == null)
                return null;
            Shape newShape = this._shapeFactory.CreateShape(SHAPE_TYPE_LINE);
            newShape.SetPointsByReference(referenceShapeFirst);
            newShape.X2 = pointX;
            newShape.Y2 = pointY;
            return newShape;
        }

        // Moved
        public override Shape Moved(Shape shape, double pointX, double pointY)
        {
            shape.X2 = pointX;
            shape.Y2 = pointY;
            return shape;
        }

        // Released
        public override Shape Released(Shapes shapes, Shape movedShape, double pointX, double pointY)
        {
            Shape referenceShape = shapes.GetSelectedPointShape(pointX, pointY);
            if (referenceShape == null || referenceShape.IsSame(_referenceShapeFirst))
                return null;
            Shape newShape = this._shapeFactory.CreateShape(SHAPE_TYPE_LINE);
            newShape.SetPointsByReference(_referenceShapeFirst, referenceShape);
            return newShape;
        }
    }
}
