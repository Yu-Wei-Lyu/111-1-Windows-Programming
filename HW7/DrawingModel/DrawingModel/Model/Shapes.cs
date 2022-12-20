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
        List<string> _shapeTypes = new List<string>() { "Rectangle", "Line", "Triangle" };

        public Shapes()
        {
            _shapes = new List<Shape>();
            _shapeFactory = new ShapeFactory();
        }

        // CreateShape
        public void CreateShape(string shapeType, double[] points)
        {
            _shapes.Add(_shapeFactory.CreateShape(shapeType, points));
        }

        // GetShape
        public Shape GetShape(int index)
        {
            return _shapes[index];
        }

        // GetShapesAmount
        public int Count()
        {
            return _shapes.Count;
        }

        // DrawAllShapes
        public void DrawAllShapes(IGraphics graphics)
        {
            foreach (Shape shape in _shapes)
                shape.Draw(graphics);
        }

        // Clear
        public void Clear()
        {
            _shapes.Clear();
        }

        // Add
        public void Add(Shape shape)
        {
            _shapes.Add(shape);
        }

        // RemoveAt
        public void RemoveLast()
        {
            _shapes.RemoveAt(_shapes.Count - 1);
        }

        // GetSelectedPointShape
        public Shape GetSelectedPointShape(Point point)
        {
            Shape shape = null;
            for (int i = 0; i < _shapes.Count; i++)
            {
                if (_shapes[i].IsContain(point))
                {
                    shape =_shapes[i];
                }
            }
            return shape;
        }

        // IsShapeType
        public bool IsShapeType(string type)
        {
            return _shapeTypes.Contains(type);
        }
    }
}
