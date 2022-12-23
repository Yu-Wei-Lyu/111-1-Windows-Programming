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
        private const string DEFAULT_STATE = "SelectBox";
        private double _firstPointX = 0;
        private double _firstPointY = 0;
        private bool _isSelected = false;
        private bool _isPressed = false;
        private bool _isMoving = false;
        private Shape _hint = null;
        private Shape _selectedBox = null;
        private string _currentShapeType = DEFAULT_STATE;
        private Shapes _shapes;
        private ShapeFactory _shapeFactory;
        private CommandManager _commandManager;
        private string _selectHintText = "";
        private StateClickHandler _stateHandler;

        public Model()
        {
            _shapes = new Shapes();
            _shapeFactory = new ShapeFactory();
            _commandManager = new CommandManager();
            _stateHandler = new StatePointer();
        }

        // SetDrawingState
        public void SetStateDrawing()
        {
            this.HandleShapeToolButtonClick();
            _stateHandler = new StateDrawing();
        }

        // SetPointerState
        public void SetStatePointer()
        {
            this.HandleShapeToolButtonClick();
            _stateHandler = new StatePointer();
        }

        // SetPointerState
        public void SetStateLine()
        {
            this.HandleShapeToolButtonClick();
            _stateHandler = new StateLine();
        }

        // ChangeShape
        public void SetState(string state)
        {
            _currentShapeType = state;
            _isSelected = false;
            _selectHintText = "";
            this.NotifyModelChanged();
        }

        // PressedPointer
        public void PressedPointer(double pointX, double pointY)
        {
            if (pointX <= 0 && pointY <= 0)
                return;
            _hint = _stateHandler.Pressed(_shapes, _currentShapeType, pointX, pointY);
            _selectHintText = _stateHandler.GetHintText();
            _isSelected = (_selectHintText != "") ? true : false;
            if (_hint == null)
            {
                _isPressed = false;
                _isSelected = false;
                
            }
            else
                _isPressed = true;
        }

        // MovedPointer
        public void MovedPointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _hint = _stateHandler.Moved(_hint, pointX, pointY);
                _isMoving = true;
                this.NotifyModelChanged();
            }
        }

        // ReleasedPointer
        public void ReleasedPointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _currentShapeType = DEFAULT_STATE;
                _isMoving = false;
                _isPressed = false;
                Shape newShape = _stateHandler.Released(_shapes, _hint, pointX, pointY);
                _hint.SetPoints(0, 0, 0, 0);
                if (newShape == null)
                {
                    _isSelected = false;
                    _stateHandler = new StatePointer();
                    this.NotifyModelChanged();
                    return;
                }
                if(_stateHandler.GetHintText() == "")
                    _commandManager.Execute(new DrawCommand(this, newShape));
                _stateHandler = new StatePointer();
                this.NotifyModelChanged();
            }
        }

        // Clear
        public void Clear()
        {
            _stateHandler = new StatePointer();
            _isSelected = false;
            _selectHintText = "";
            _isPressed = false;
            _currentShapeType = DEFAULT_STATE;
            _shapes.Clear();
            _commandManager.ClearAll();
            this.NotifyModelChanged();
        }

        // ResetCurrentShape
        public void ResetCurrentShape()
        {
            _currentShapeType = DEFAULT_STATE;
        }

        // Draw
        public void PaintOn(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.DrawAllShapes(graphics);
            if ((_isPressed || _isSelected) && _hint != null)
                _hint.PreviewDraw(graphics);
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
            return _currentShapeType;
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
            _selectedBox = _shapeFactory.CreateShape(_currentShapeType, new double[] { shape.X1, shape.Y1, shape.X2, shape.Y2 });
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

        // LineModeUpdate
        public void LineModeReleasePoint(double pointX, double pointY)
        {
            _isMoving = false;
            _isPressed = false;
            if (_hint == null)
                return;
            Shape shape = _shapes.GetSelectedPointShape(pointX, pointY);
            if (shape != null && shape != _hint.referenceShapeFirst)
            {
                Shape newShape = _shapeFactory.CreateLine(_hint.referenceShapeFirst, shape);
                _commandManager.Execute(new DrawCommand(this, newShape));
            }
            _hint.SetPoints(0, 0, 0, 0);
            _currentShapeType = DEFAULT_STATE;
            this.NotifyModelChanged();
        }

        // LineModePressedPoint
        public void LineModePressedPoint(double pointX, double pointY)
        {
            Shape shape = _shapes.GetSelectedPointShape(pointX, pointY);
            if (shape == null)
            {
                return;
            }
            _hint = _shapeFactory.CreateLine(shape, null);
            _hint.X2 = pointX;
            _hint.Y2 = pointY;
            _isPressed = true;
            _isSelected = false;
            _selectHintText = "";
        }

        // HandleShapeToolButtonClick
        public void HandleShapeToolButtonClick()
        {
            _isSelected = false;
            if (_hint != null)
                _hint.SetPoints(0, 0, 0, 0);
        }
    }

}
