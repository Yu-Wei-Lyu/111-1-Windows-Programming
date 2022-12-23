using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class StateDrawing : StateClickHandler
    {
        private ShapeFactory _shapeFactory = new ShapeFactory();

        // GetStateType
        public override string GetStateType()
        {
            return "Drawing";
        }

        // Pressed
        public override Shape Pressed(Shapes shapes, string shapeType, double pointX, double pointY)
        {
            this.ShapeType = shapeType;
            ShapeFactory shapeFactory = new ShapeFactory();
            Shape newShape = shapeFactory.CreateShape(shapeType);
            newShape.X1 = pointX;
            newShape.Y1 = pointY;
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
        public override Shape Released(Shapes shapes, Shape shape, double pointX, double pointY)
        {
            if (shape == null)
                return null;
            ShapeFactory shapeFactory = new ShapeFactory();
            Shape newShape = shapeFactory.CreateShape(this.ShapeType);
            newShape.X1 = shape.X1;
            newShape.Y1 = shape.Y1;
            newShape.X2 = pointX;
            newShape.Y2 = pointY;
            return newShape;
        }
    }
}
