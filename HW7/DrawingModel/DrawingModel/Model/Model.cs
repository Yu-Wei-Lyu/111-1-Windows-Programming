using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        double _firstPointX;
        double _firstPointY;
        bool _isPressed = false;
        bool _isMoving = false;
        IShape _hint = null;
        private string _currentShape;
        private Shapes _shapes;
        private ShapeFactory _shapeFactory;
        CommandManager _commandManager = new CommandManager();
        public event PropertyChangedEventHandler PropertyChanged;
        bool _isRedoEnabled;
        bool _isUndoEnabled;
        bool _isRectangleButtonEnabled;
        bool _isTriangleButtonEnabled;

        public Model()
        {
            _shapes = new Shapes();
            _shapeFactory = new ShapeFactory();
            _currentShape = "";
            _firstPointX = 0;
            _firstPointY = 0;
        }

        // ChangeShape
        public void SetShapeType(string shapeType)
        {
            _currentShape = shapeType;
        }

        // PressedPointer
        public void PressedPointer(double pointX, double pointY)
        {
            if (pointX > 0 && pointY > 0 && _currentShape != "")
            {
                _hint = _shapeFactory.CreateShape(_currentShape, new double[] { 0, 0, 0, 0 });
                _firstPointX = pointX;
                _firstPointY = pointY;
                _hint.X1 = _firstPointX;
                _hint.Y1 = _firstPointY;
                _isPressed = true;
            }
        }

        // MovedPointer
        public void MovedPointer(double pointX, double pointY)
        {
            if (_isPressed && _currentShape != "")
            {
                _hint.X2 = pointX;
                _hint.Y2 = pointY;
                _isMoving = true;
                NotifyModelChanged();
            }
        }

        // ReleasedPointer
        public void ReleasedPointer(double pointX, double pointY)
        {
            if (_isPressed && _currentShape != "")
            {
                _isMoving = false;
                _isPressed = false;
                IShape newShape = _shapeFactory.CreateShape(_currentShape, new double[] { _firstPointX, _firstPointY, pointX, pointY });
                _currentShape = "";
                _commandManager.Execute(new DrawCommand(this, newShape));
                NotifyModelChanged();
            }
        }

        // Clear
        public void Clear()
        {
            _isPressed = false;
            _currentShape = "";
            _shapes.Clear();
            _commandManager.ClearAll();
            NotifyModelChanged();
        }

        // ResetCurrentShape
        public void ResetCurrentShape()
        {
            _currentShape = "";
        }

        // Draw
        public void PaintOn(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.DrawAllShapes(graphics);
            if (_isPressed)
                _hint.PreviewDraw(graphics);
        }

        // NotifyModelChanged
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        // DrawShape
        public void DrawShape(IShape shape)
        {
            _shapes.Add(shape);
        }

        // DeleteShape
        public void DeleteShape()
        {
            _shapes.RemoveLast();
        }

        // Undo
        public void Undo()
        {
            _commandManager.Undo();
            NotifyModelChanged();
        }

        // Redo
        public void Redo()
        {
            _commandManager.Redo();
            NotifyModelChanged();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }

        // Notify
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
