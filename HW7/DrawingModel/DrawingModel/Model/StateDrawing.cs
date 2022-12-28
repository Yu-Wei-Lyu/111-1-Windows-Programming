using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class StateDrawing : AbstractState
    {
        private const string STATE_TYPE = "Drawing";
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
            ShapeFactory shapeFactory = new ShapeFactory();
            AbstractShape newShape = shapeFactory.CreateShape(shapeType);
            newShape.X1 = pointX;
            newShape.Y1 = pointY;
            newShape.X2 = pointX;
            newShape.Y2 = pointY;
            return newShape;
        }

        // Moved
        public override AbstractShape Moved(AbstractShape shape, double pointX, double pointY)
        {
            shape.X2 = pointX;
            shape.Y2 = pointY;
            return shape;
        }

        // Released
        public override AbstractShape Released(Shapes shapes, AbstractShape shape, double pointX, double pointY)
        {
            if (shape == null)
                return null;
            ShapeFactory shapeFactory = new ShapeFactory();
            AbstractShape newShape = shapeFactory.CreateShape(this.ShapeType);
            newShape.X1 = shape.X1;
            newShape.Y1 = shape.Y1;
            newShape.X2 = pointX;
            newShape.Y2 = pointY;
            return newShape;
        }
    }
}
