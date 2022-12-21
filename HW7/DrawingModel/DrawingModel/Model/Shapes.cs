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
        private const string RECTANGLE = "Rectangle";
        private const string LINE = "Line";
        private const string TRIANGLE = "Triangle";
        private ShapeFactory _shapeFactory;
        private List<Shape> _shapes;
        private List<string> _shapeTypes;

        public Shapes()
        {
            _shapes = new List<Shape>();
            _shapeFactory = new ShapeFactory();
            _shapeTypes = new List<string>() 
            {
                RECTANGLE, 
                LINE, 
                TRIANGLE
            };
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
        public int GetCount()
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
        public Shape GetSelectedPointShape(double pointX, double pointY)
        {
            Shape shape = null;
            for (int i = 0; i < _shapes.Count; i++)
            {
                if (_shapes[i].IsContain(pointX, pointY) && !this.IsLine(_shapes[i].GetShapeType()))
                    shape = _shapes[i];
            }
            return shape;
        }

        // IsShapeType
        public bool IsShapeType(string type)
        {
            return _shapeTypes.Contains(type);
        }

        // IsLine
        public bool IsLine(string type)
        {
            return type == LINE;
        }
    }
}
