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
        public int GetShapesQuantity()
        {
            return _shapes.Count;
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
