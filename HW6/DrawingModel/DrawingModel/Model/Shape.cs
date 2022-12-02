using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Shape
    {
        // Virtual GetShapeType
        public virtual string GetShapeType()
        {
            return "Shape";
        }

        // Virtual CreateShape
        public virtual void CreateShape()
        {

        }
    }
}
