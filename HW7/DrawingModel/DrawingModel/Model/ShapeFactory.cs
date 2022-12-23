using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class ShapeFactory
    {
        private const string SHAPE_TYPE_RECTANGLE = "Rectangle";
        private const string SHAPE_TYPE_LINE = "Line";
        private const string SHAPE_TYPE_TRIANGLE = "Triangle";
        private const string SHAPE_TYPE_SELECT_BOX = "SelectBox";

        // CreateShape
        public Shape CreateShape(string shapeType)
        {
            Shape shape = null;
            if (shapeType == SHAPE_TYPE_RECTANGLE)
                shape = new Rectangle();
            if (shapeType == SHAPE_TYPE_LINE)
                shape = new Line();
            if (shapeType == SHAPE_TYPE_TRIANGLE)
                shape = new Triangle();
            if (shapeType == SHAPE_TYPE_SELECT_BOX)
                shape = new SelectBox();
            return shape;
        }
    }
}
