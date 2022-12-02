using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class ShapeFactory
    {
        private const string SHAPE_TYPE_RECTANGLE = "Rectangle";
        private const string SHAPE_TYPE_TRIANGLE = "Triangle";

        // CreateShape
        public Shape CreateShape(string shapeType)
        {
            Shape shape = null;
            if (shapeType == SHAPE_TYPE_RECTANGLE)
                shape = new Rectangle();
            if (shapeType == SHAPE_TYPE_TRIANGLE)
                shape = new Triangle();
            return shape;
            
            /*Type classType = Type.GetType(shapeType);
            object shape = Activator.CreateInstance(classType);
            return shape;*/
        }
    }
}
