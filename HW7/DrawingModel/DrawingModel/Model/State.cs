using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    abstract public class StateClickHandler
    {
        public string _shapeType;
        public ShapeFactory _shapeFactory = new ShapeFactory();
        // interface method
        public abstract Shape Pressed(Shapes shapes, string shapeType, double pointX, double pointY);

        // interface method
        public virtual Shape Moved(Shape shape, double pointX, double pointY)
        {
            shape.X2 = pointX;
            shape.Y2 = pointY;
            return shape;
        }

        // interface method
        public abstract Shape Released(Shapes shapes, Shape shape, double pointX, double pointY);
    }
}
