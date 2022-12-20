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
        double _firstPointX = 0;
        double _firstPointY = 0;
        bool _isSelected = false;
        bool _isPressed = false;
        bool _isMoving = false;
        Shape _hint = null;
        Shape _selectedBox = null;
        private string _currentState = "None";
        private Shapes _shapes;
        private ShapeFactory _shapeFactory;
        CommandManager _commandManager = new CommandManager();
        List<string> _shapeState = new List<string>() { "Triangle", "Rectangle", "Line" };

        public Model()
        {
            _shapes = new Shapes();
            _shapeFactory = new ShapeFactory();
        }

        // ChangeShape
        public void SetState(string state)
        {
            _currentState = state;
            if (_shapeState.Contains(state))
                _isSelected = false;
            NotifyModelChanged();
        }

        // PressedPointer
        public void PressedPointer(double pointX, double pointY)
        {
            if (pointX > 0 && pointY > 0 && _shapeState.Contains(_currentState))
            {
                _isSelected = false;
                _hint = _shapeFactory.CreateShape(_currentState, new double[] { 0, 0, 0, 0 });
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
            if (_isPressed && _shapeState.Contains(_currentState))
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
            if (!_shapeState.Contains(_currentState))
            {
                Shape shape = _shapes.GetSelectedPointShape(pointX, pointY);
                if (shape == null)
                {
                    _isSelected = false;
                    return;
                }
                _isSelected = true;
                _currentState = "SelectBox";
                _selectedBox = _shapeFactory.CreateShape(_currentState, new double[] { shape.X1, shape.Y1, shape.X2, shape.Y2 });
                NotifyModelChanged();
            }

            if (_isPressed && _shapeState.Contains(_currentState))
            {
                _isMoving = false;
                _isPressed = false;
                Shape newShape = _shapeFactory.CreateShape(_currentState, new double[] { _firstPointX, _firstPointY, pointX, pointY });
                _currentState = "None";
                _commandManager.Execute(new DrawCommand(this, newShape));
                NotifyModelChanged();
            }
        }

        // Clear
        public void Clear()
        {
            _isSelected = false;
            _isPressed = false;
            _currentState = "None";
            _shapes.Clear();
            _commandManager.ClearAll();
            NotifyModelChanged();
        }

        // ResetCurrentShape
        public void ResetCurrentShape()
        {
            _currentState = "None";
        }

        // Draw
        public void PaintOn(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.DrawAllShapes(graphics);
            if (_isPressed)
                _hint.PreviewDraw(graphics);
            if (_isSelected)
                _selectedBox.Draw(graphics);
        }

        // NotifyModelChanged
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        // DrawShape
        public void DrawShape(Shape shape)
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
            _isSelected = false;
            _commandManager.Undo();
            NotifyModelChanged();
        }

        // Redo
        public void Redo()
        {
            _isSelected = false;
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

        // GetCurrentShapeType
        public string GetState()
        {
            return _currentState;
        }
    }

}
