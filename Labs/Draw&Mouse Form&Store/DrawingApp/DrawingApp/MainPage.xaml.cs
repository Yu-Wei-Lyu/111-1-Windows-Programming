using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DrawingApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DrawingModel.Model _model;
        PresentationModel.PresentationModel _presentationModel;

        public MainPage()
        {
            this.InitializeComponent();
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _canvas.PointerPressed += HandleCanvasPressed;
            _canvas.PointerReleased += HandleCanvasReleased;
            _canvas.PointerMoved += HandleCanvasMoved;
            _clear.Click += HandleClearButtonClick;
            _model._modelChanged += HandleModelChanged;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Clear();
        }

        public void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            _model.PointerPressed(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        public void HandleCanvasReleased(object sender, PointerRoutedEventArgs e)
        {
            _model.PointerReleased(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        public void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.PointerMoved(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        public void HandleModelChanged()
        {
            _presentationModel.Draw();
        }
    }
}
