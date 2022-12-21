using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public interface IGraphics
    {
        // Interface method
        void ClearAll();
        // Interface method
        void PreviewRectangle(double x1, double y1, double x2, double y2);
        // Interface method
        void DrawRectangle(double x1, double y1, double x2, double y2);
        // InterFace method
        void PreviewTriangle(double x1, double y1, double x2, double y2);
        // InterFace method
        void DrawTriangle(double x1, double y1, double x2, double y2);
        // InterFace method
        void DrawSelectBox(double x1, double y1, double x2, double y2);
        // InterFace method
        void DrawLine(double x1, double y1, double x2, double y2);
    }
}
