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
        private const string SHAPE_TYPE_TRIANGLE = "Triangle";
        private const string SHAPE_TYPE_SELECTBOX = "SelectBox";

        // CreateShape
        public Shape CreateShape(string shapeType, double[] points)
        {
            Shape shape = null;
            if (shapeType == SHAPE_TYPE_RECTANGLE)
                shape = new Rectangle();
            if (shapeType == SHAPE_TYPE_TRIANGLE)
                shape = new Triangle();
            if (shapeType == SHAPE_TYPE_SELECTBOX)
                shape = new SelectBox();
            int pointIndex = 0;
            shape.X1 = points[pointIndex++];
            shape.Y1 = points[pointIndex++];
            shape.X2 = points[pointIndex++];
            shape.Y2 = points[pointIndex++];
            return shape;
        }
    }
}
