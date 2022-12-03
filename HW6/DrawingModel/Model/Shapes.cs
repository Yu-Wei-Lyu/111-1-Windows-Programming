using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Shapes
    {
        ShapeFactory _shapeFactory;
        List<Shape> _shapes;

        public Shapes()
        {
            _shapes = new List<Shape>();
            _shapeFactory = new ShapeFactory();
        }

        // CreateShape
        public void CreateShape(string shapeType)
        {
            _shapes.Add(_shapeFactory.CreateShape(shapeType));
        }

        // GetShapesAmount
        public int GetShapesQuantity()
        {
            return _shapes.Count;
        }

        // SetPoints
        public void SetLastShapePoints(double[] points)
        {
            int indexOfLast = _shapes.Count - 1;
            int pointIndex = 0;
            _shapes[indexOfLast].X1 = points[pointIndex++];
            _shapes[indexOfLast].Y1 = points[pointIndex++];
            _shapes[indexOfLast].X2 = points[pointIndex++];
            _shapes[indexOfLast].Y2 = points[pointIndex++];
        }

        // DrawAllShapes
        public void DrawAllShapes(GraphicsInterface graphics)
        {
            foreach (Shape shape in _shapes)
                shape.Draw(graphics);
        }

        // Clear
        public void Clear()
        {
            _shapes.Clear();
        }
    }
}
