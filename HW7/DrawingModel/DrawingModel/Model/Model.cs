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
        private const string DEFAULT_STATE = "None";
        private const string SELECT_STATE = "SelectBox";
        private double _firstPointX = 0;
        private double _firstPointY = 0;
        private bool _isSelected = false;
        private bool _isPressed = false;
        private bool _isMoving = false;
        private Shape _hint = null;
        private Shape _selectedBox = null;
        private string _currentState = DEFAULT_STATE;
        private Shapes _shapes;
        private ShapeFactory _shapeFactory;
        private CommandManager _commandManager;
        private string _selectHintText = "";

        public Model()
        {
            _shapes = new Shapes();
            _shapeFactory = new ShapeFactory();
            _commandManager = new CommandManager();
        }

        // ChangeShape
        public void SetState(string state)
        {
            _currentState = state;
            if (_shapes.IsShapeType(state))
            {
                _isSelected = false;
                _selectHintText = "";
            }
            this.NotifyModelChanged();
        }

        // PressedPointer
        public void PressedPointer(double pointX, double pointY)
        {
            if (pointX <= 0 && pointY <= 0)
                return;
            if (_shapes.IsLine(_currentState))
            {
                Shape shape = _shapes.GetSelectedPointShape(pointX, pointY);
                if(shape != null)
                {
                    _hint = _shapeFactory.CreateShape(_currentState, new double[] { 0, 0, 0, 0 });
                    _hint.referenceShapeFirst = shape;
                }
                return;
            }
            if (_shapes.IsShapeType(_currentState))
            {
                _isSelected = false;
                _selectHintText = "";
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
            if (_isPressed && _shapes.IsShapeType(_currentState))
            {
                _hint.X2 = pointX;
                _hint.Y2 = pointY;
                _isMoving = true;
                this.NotifyModelChanged();
            }
        }

        // ReleasedPointer
        public void ReleasedPointer(double pointX, double pointY)
        {
            if (!_shapes.IsShapeType(_currentState))
                this.SelectStateUpdate(pointX, pointY);
            if (_isPressed && _shapes.IsShapeType(_currentState))
            {
                _isMoving = false;
                _isPressed = false;
                Shape newShape = _shapeFactory.CreateShape(_currentState, new double[] { _firstPointX, _firstPointY, pointX, pointY });
                _currentState = DEFAULT_STATE;
                _commandManager.Execute(new DrawCommand(this, newShape));
                this.NotifyModelChanged();
            }
        }

        // Clear
        public void Clear()
        {
            _isSelected = false;
            _selectHintText = "";
            _isPressed = false;
            _currentState = DEFAULT_STATE;
            _shapes.Clear();
            _commandManager.ClearAll();
            this.NotifyModelChanged();
        }

        // ResetCurrentShape
        public void ResetCurrentShape()
        {
            _currentState = DEFAULT_STATE;
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
            _selectHintText = "";
            _commandManager.Undo();
            this.NotifyModelChanged();
        }

        // Redo
        public void Redo()
        {
            _isSelected = false;
            _selectHintText = "";
            _commandManager.Redo();
            this.NotifyModelChanged();
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

        // SelectStateUpdate
        public void SelectStateUpdate(double pointX, double pointY)
        {
            Shape shape = _shapes.GetSelectedPointShape(pointX, pointY);
            if (shape == null)
            {
                _isSelected = false;
                _selectHintText = "";
                this.NotifyModelChanged();
                return;
            }
            _isSelected = true;
            _selectHintText = this.GetLeftTopAndRightBottomPoint(shape);
            _currentState = SELECT_STATE;
            _selectedBox = _shapeFactory.CreateShape(_currentState, new double[] { shape.X1, shape.Y1, shape.X2, shape.Y2 });
            this.NotifyModelChanged();
        }

        // GetSelectLabelText
        public string GetSelectLabelText()
        {
            return _selectHintText;
        }

        // GetLeftTopRightBottomPoint
        public string GetLeftTopAndRightBottomPoint(Shape shape)
        {
            double largeX = (shape.X2 < shape.X1) ? shape.X1 : shape.X2;
            double smallX = (shape.X2 >= shape.X1) ? shape.X1 : shape.X2;
            double largeY = (shape.Y2 < shape.Y1) ? shape.Y1 : shape.Y2;
            double smallY = (shape.Y2 >= shape.Y1) ? shape.Y1 : shape.Y2;
            _selectHintText = string.Format("Select：{0}({1}, {2}, {3}, {4})", shape.GetShapeType(), smallX, smallY, largeX, largeY);
            return _selectHintText;
        }
    }

}
