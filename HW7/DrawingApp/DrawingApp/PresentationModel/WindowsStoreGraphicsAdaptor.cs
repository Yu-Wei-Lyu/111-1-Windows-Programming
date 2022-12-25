using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using DrawingModel;

namespace DrawingApp.PresentationModel
{
    public class WindowsStoreGraphicsAdaptor : IGraphics
    {
        private const int HALF = 2;
        private Canvas _canvas;
        private const float CIRCLE_RADIUS = 4;
        private const float CIRCLE_DIAMETER = 8;

        public WindowsStoreGraphicsAdaptor(Canvas canvas)
        {
            this._canvas = canvas;
        }

        // ClearAll
        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        // GetRectanglePoints
        public PointCollection GetRectanglePoints(double x1, double y1, double x2, double y2)
        {
            Windows.Foundation.Point leftTop = new Windows.Foundation.Point(x1, y1);
            Windows.Foundation.Point rightTop = new Windows.Foundation.Point(x2, y1);
            Windows.Foundation.Point leftBottom = new Windows.Foundation.Point(x2, y2);
            Windows.Foundation.Point rightBottom = new Windows.Foundation.Point(x1, y2);
            return new PointCollection
            {
                leftTop, rightTop, leftBottom, rightBottom
            };
        }

        // GetTrianglePoints
        public PointCollection GetTrianglePoints(double x1, double y1, double x2, double y2)
        {
            double triangleWidth = x2 - x1;
            double topPointX = x1 + triangleWidth / 2;
            Windows.Foundation.Point top = new Windows.Foundation.Point(topPointX, y1);
            Windows.Foundation.Point leftBottom = new Windows.Foundation.Point(x2, y2);
            Windows.Foundation.Point rightBottom = new Windows.Foundation.Point(x1, y2);
            return new PointCollection
            {
                leftBottom, top, rightBottom
            };
        }

        // GetRectangleWithStroke
        public Polygon GetRectangleWithStroke(double x1, double y1, double x2, double y2)
        {
            Polygon polygon = new Polygon();
            polygon.Points = GetRectanglePoints(x1, y1, x2, y2);
            polygon.Stroke = new SolidColorBrush(Colors.Black);
            return polygon;
        }

        // GetTriangleWithStroke
        public Polygon GetTriangleWithStroke(double x1, double y1, double x2, double y2)
        {
            Polygon polygon = new Polygon();
            polygon.Points = GetTrianglePoints(x1, y1, x2, y2);
            polygon.Stroke = new SolidColorBrush(Colors.Black);
            return polygon;
        }

        // HintRectangle
        public void PreviewRectangle(double x1, double y1, double x2, double y2)
        {
            _canvas.Children.Add(GetRectangleWithStroke(x1, y1, x2, y2));
        }

        // DrawRectangle
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            Polygon polygon = GetRectangleWithStroke(x1, y1, x2, y2);
            polygon.Fill = new SolidColorBrush(Colors.Yellow);
            _canvas.Children.Add(polygon);
        }

        // HintTriangle
        public void PreviewTriangle(double x1, double y1, double x2, double y2)
        {
            _canvas.Children.Add(GetTriangleWithStroke(x1, y1, x2, y2));
        }

        // DrawTriangle
        public void DrawTriangle(double x1, double y1, double x2, double y2)
        {
            Polygon polygon = GetTriangleWithStroke(x1, y1, x2, y2);
            polygon.Fill = new SolidColorBrush(Colors.Orange);
            _canvas.Children.Add(polygon);
        }

        public void DrawSelectBox(double x1, double y1, double x2, double y2)
        {
            Polygon polygon = new Polygon();
            polygon.Points = GetTrianglePoints(x1, y1, x2, y2);
            polygon.Stroke = 
            double width = x2 - x1;
            double height = y2 - y1;
            this.DrawSelectPoint(x1, y1, width, height);
            this.DrawSelectPoint(x1, y2, width, height);
            this.DrawSelectPoint(x2, y1, width, height);
            this.DrawSelectPoint(x2, y2, width, height);
        }

        // SelectPoint
        public void DrawSelectPoint(double pointX, double pointY, double width, double height)
        {
            _graphics.FillEllipse(Brushes.White, (float)pointX - CIRCLE_RADIUS, (float)pointY - CIRCLE_RADIUS, CIRCLE_DIAMETER, CIRCLE_DIAMETER);
            _graphics.DrawEllipse(Pens.Black, (float)pointX - CIRCLE_RADIUS, (float)pointY - CIRCLE_RADIUS, CIRCLE_DIAMETER, CIRCLE_DIAMETER);
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            float middlePointX = ((float)x1 + (float)x2) / HALF;
            PointF firstPoint = new PointF((float)x1, (float)y1);
            PointF secondPoint = new PointF(middlePointX, (float)y1);
            PointF thirdPoint = new PointF(middlePointX, (float)y2);
            PointF lastPoint = new PointF((float)x2, (float)y2);
            _graphics.DrawLine(Pens.Black, firstPoint, secondPoint);
            _graphics.DrawLine(Pens.Black, secondPoint, thirdPoint);
            _graphics.DrawLine(Pens.Black, thirdPoint, lastPoint);

        }
    }
}
