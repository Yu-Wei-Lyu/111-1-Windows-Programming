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
        public string _hintText = "";
        // abstract Pressed
        public abstract Shape Pressed(Shapes shapes, string shapeType, double pointX, double pointY);

        // virtual Moved
        public virtual Shape Moved(Shape shape, double pointX, double pointY)
        {
            shape.X2 = pointX;
            shape.Y2 = pointY;
            return shape;
        }

        // abstract Released
        public abstract Shape Released(Shapes shapes, Shape shape, double pointX, double pointY);

        // GetHintText
        public virtual string GetHintText()
        {
            return this._hintText;
        }
    }
}
