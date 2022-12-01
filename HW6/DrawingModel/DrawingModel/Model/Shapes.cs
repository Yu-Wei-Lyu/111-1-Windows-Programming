using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Shapes
    {
        List<ShapeInterface> _shapes;

        public Shapes()
        {
            _shapes = new List<ShapeInterface>();
        }

        // Draw
        public void Draw(GraphicsInterface graphics)
        {

        }
    }
}
