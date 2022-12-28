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
        private List<AbstractShape> _shapes;

        public Shapes()
        {
            _shapes = new List<AbstractShape>();
        }

        // DrawAllShapes
        public void DrawShapes(IGraphics graphics)
        {
            foreach (AbstractShape shape in _shapes)
            {
                if (!this.IsLine(shape))
                    shape.Draw(graphics);
            }
        }

        // DrawLines
        public void DrawLines(IGraphics graphics)
        {
            foreach (AbstractShape shape in _shapes)
            {
                if (this.IsLine(shape))
                    shape.Draw(graphics);
            }
        }

        // Clear
        public void Clear()
        {
            _shapes.Clear();
        }

        // Add
        public void Add(AbstractShape shape)
        {
            _shapes.Add(shape);
        }

        // RemoveAt
        public void RemoveLast()
        {
            _shapes.RemoveAt(_shapes.Count - 1);
        }

        // GetSelectedPointShape
        public AbstractShape GetSelectedPointShape(double pointX, double pointY)
        {
            AbstractShape shape = null;
            for (int i = 0; i < _shapes.Count; i++)
            {
                if (_shapes[i].IsContain(pointX, pointY))
                    shape = _shapes[i];
            }
            return shape;
        }

        // IsLine
        public bool IsLine(AbstractShape shape)
        {
            return shape.GetShapeType() == LINE;
        }
    }
}
