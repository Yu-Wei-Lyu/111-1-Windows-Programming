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
        private const string SHAPE_TYPE_SELECT_BOX = "Select";

        // CreateShape
        public Shape CreateShape(string shapeType, double[] points)
        {
            Shape shape = null;
            if (shapeType == SHAPE_TYPE_RECTANGLE)
                shape = new Rectangle();
            if (shapeType == SHAPE_TYPE_TRIANGLE)
                shape = new Triangle();
            if (shapeType == SHAPE_TYPE_SELECT_BOX)
                shape = new SelectBox();
            int pointIndex = 0;
            shape.X1 = points[pointIndex++];
            shape.Y1 = points[pointIndex++];
            shape.X2 = points[pointIndex++];
            shape.Y2 = points[pointIndex++];
            return shape;
        }

        // CreateLine
        public Shape CreateLine(Shape firstShape, Shape secondShape)
        {
            Shape line = new Line();
            line.referenceShapeFirst = firstShape;
            line.referenceShapeSecond = secondShape;
            return line;
        }

        // CreateLine
        public Shape CreateSelectBox(Shape shape)
        {
            Shape selectBox = new SelectBox();
            selectBox.referenceShapeFirst = shape;
            return selectBox;
        }
    }
}
