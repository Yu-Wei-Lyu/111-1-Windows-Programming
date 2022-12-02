using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    interface GraphicsInterface
    {
        // Interface method
        void ClearAll();
        // Interface method
        void HintRectangle(double x1, double y1, double x2, double y2);
        // Interface method
        void DrawRectangle(double x1, double y1, double x2, double y2);
        // InterFace method
        void HintTriangle(double x1, double y1, double x2, double y2);
        // InterFace method
        void DrawTriangle(double x1, double y1, double x2, double y2);
    }
}
