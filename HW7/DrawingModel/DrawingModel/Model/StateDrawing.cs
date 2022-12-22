using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class StateDrawing : StateClickHandler
    {
        // Pressed
        public override Shape Pressed(Shapes shapes, string shapeType, double pointX, double pointY)
        {
            this._shapeType = shapeType;
            ShapeFactory shapeFactory = new ShapeFactory();
            Shape newShape = shapeFactory.CreateShape(shapeType, new double[] { 0, 0, 0, 0 });
            newShape.X1 = pointX;
            newShape.Y1 = pointY;
            newShape.X2 = pointX;
            newShape.Y2 = pointY;
            return newShape;
        }

        // Released
        public override Shape Released(Shapes shapes, Shape shape, double pointX, double pointY)
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            Shape newShape = shapeFactory.CreateShape(_shapeType, new double[] { shape.X1, shape.Y1, pointX, pointY });
            return newShape;
        }
    }
}
