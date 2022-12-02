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

        // DrawRectangle
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Polyline polyline = new Windows.UI.Xaml.Shapes.Polyline();
            polyline.Points.Add(new Windows.Foundation.Point(x1, y1));
            polyline.Points.Add(new Windows.Foundation.Point(x2, y1));
            polyline.Points.Add(new Windows.Foundation.Point(x2, y2));
            polyline.Points.Add(new Windows.Foundation.Point(x1, y2));
            polyline.Points.Add(new Windows.Foundation.Point(x1, y1));
            polyline.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(polyline);
        }

        // DrawTriangle
        public void DrawTriangle(double x1, double y1, double x2, double y2)
        {
            double triangleWidth = x2 - x1;
            double topPointX = x1 + triangleWidth / 2;
            Windows.UI.Xaml.Shapes.Polyline polyline = new Windows.UI.Xaml.Shapes.Polyline();
            polyline.Points.Add(new Windows.Foundation.Point(x1, y2));
            polyline.Points.Add(new Windows.Foundation.Point(x2, y2));
            polyline.Points.Add(new Windows.Foundation.Point(topPointX, y1));
            polyline.Points.Add(new Windows.Foundation.Point(x1, y2));
            polyline.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(polyline);
        }
    }
}
