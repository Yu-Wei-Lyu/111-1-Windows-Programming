using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using DrawingModel;

namespace DrawingApp.PresentationModel
{
    class WindowsStoreGraphicsAdaptor : GraphicsInterface
    {
        Canvas _canvas;

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

        // DrawRectangle
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            Polygon polygon = GetRectangleWithStroke(x1, y1, x2, y2);
            polygon.Fill = new SolidColorBrush(Colors.Yellow);
            _canvas.Children.Add(polygon);
        }

        // HintRectangle
        public void PreviewRectangle(double x1, double y1, double x2, double y2)
        {
            _canvas.Children.Add(GetRectangleWithStroke(x1, y1, x2, y2));
        }

        // DrawTriangle
        public void DrawTriangle(double x1, double y1, double x2, double y2)
        {
            Polygon polygon = GetTriangleWithStroke(x1, y1, x2, y2);
            polygon.Fill = new SolidColorBrush(Colors.Orange);
            _canvas.Children.Add(polygon);
        }

        // HintTriangle
        public void PreviewTriangle(double x1, double y1, double x2, double y2)
        {
            _canvas.Children.Add(GetTriangleWithStroke(x1, y1, x2, y2));
        }
    }
}
