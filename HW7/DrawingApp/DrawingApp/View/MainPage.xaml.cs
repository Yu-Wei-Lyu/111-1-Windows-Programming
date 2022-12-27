using DrawingApp.PresentationModel;
using DrawingModel;
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
        Model _model;
        StoreAppPresentationModel _presentationModel;
        IGraphics _graphics;
        private const int HALF = 2;

        public MainPage()
        {
            this.InitializeComponent();
            
            _graphics = new WindowsStoreGraphicsAdaptor(_canvas);
            _model = new Model();
            _presentationModel = new StoreAppPresentationModel(_model);
            _presentationModel._modelChanged += HandlePresentationModelChanged;
            _model._modelChanged += HandleModelChanged;

            _canvas.PointerPressed += HandleCanvasPressed;
            _canvas.PointerReleased += HandleCanvasReleased;
            _canvas.PointerMoved += HandleCanvasMoved;

            _clearToolButton.Click += HandleClearButtonClick;
            _rectangleToolButton.Click += HandleRectangleButtonClick;
            _triangleToolButton.Click += HandleTriangleButtonClick;
            _lineToolButton.Click += HandleLineButtonClick;

            _undo.IsEnabled = false;
            _undo.Click += UndoHandler;
            _redo.IsEnabled = false;
            _redo.Click += RedoHandler;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        // HandleClearButtonClick
        public void HandleRectangleButtonClick(object sender, RoutedEventArgs e)
        {
            _model.SetStateDrawing(((Button)sender).Content.ToString());
            _presentationModel.HandleRectangleButtonClick();
        }

        // HandleLineButtonClick
        public void HandleLineButtonClick(object sender, RoutedEventArgs e)
        {
            _model.SetStateLine();
            _presentationModel.HandleLineButtonClick();
        }

        // HandleClearButtonClick
        public void HandleTriangleButtonClick(object sender, RoutedEventArgs e)
        {
            _model.SetStateDrawing(((Button)sender).Content.ToString());
            _presentationModel.HandleTriangleButtonClick();
        }

        // HandleClearButtonClick
        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Clear();
            _presentationModel.HandleClearButtonClick();
        }

        // HandleCanvasPressed
        public void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            _model.PressedPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // HandleCanvasReleased
        public void HandleCanvasReleased(object sender, PointerRoutedEventArgs e)
        {
            _model.ReleasedPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
            _presentationModel.SetToDefaultButtonEnabled();
        }

        // HandleCanvasMoved
        public void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.MovedPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // HandleModelChanged
        public void HandleModelChanged()
        {
            _hintLabel.Text = _model.GetSelectLabelText();
            _presentationModel.Draw(_graphics);
            _redo.IsEnabled = _model.IsRedoEnabled;
            _undo.IsEnabled = _model.IsUndoEnabled;
            
        }

        // HandlePresentationModelChanged
        public void HandlePresentationModelChanged()
        {
            _rectangleToolButton.IsEnabled = _presentationModel.IsRectangleButtonEnabled;
            _lineToolButton.IsEnabled = _presentationModel.IsLineButtonEnabled;
            _triangleToolButton.IsEnabled = _presentationModel.IsTriangleButtonEnabled;
            _hintLabel.Text = _model.GetSelectLabelText();
        }

        // UndoHandler
        public void UndoHandler(object sender, RoutedEventArgs e)
        {
            _model.Undo();
        }

        // RedoHandler
        public void RedoHandler(object sender, RoutedEventArgs e)
        {
            _model.Redo();
        }
    }
}
