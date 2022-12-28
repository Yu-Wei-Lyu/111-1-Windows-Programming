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
        private const string SHAPE_TYPE_RECTANGLE = "Rectangle";
        private const string SHAPE_TYPE_LINE = "Line";
        private const string SHAPE_TYPE_TRIANGLE = "Triangle";
        private const string DEFAULT_STATE = "SelectBox";
        private bool _isSelected = false;
        private bool _isPressed = false;
        private AbstractShape _hint = null;
        private string _currentShapeType = DEFAULT_STATE;
        private Shapes _shapes;
        private ShapeFactory _shapeFactory;
        private CommandManager _commandManager;
        private string _selectHintText = "";
        private AbstractState _stateHandler;

        public Model()
        {
            _shapes = new Shapes();
            _shapeFactory = new ShapeFactory();
            _commandManager = new CommandManager();
            _stateHandler = new StatePointer();
        }

        // SetDrawingState
        public void SetStateDrawing(string shapeType)
        {
            this.HandleShapeToolButtonClick();
            this.SetState(shapeType);
            _stateHandler = new StateDrawing();
        }

        // SetPointerState
        public void SetStateLine()
        {
            this.HandleShapeToolButtonClick();
            this.SetState(SHAPE_TYPE_LINE);
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
            UpdateHintText();
            _isSelected = (_selectHintText != "") ? true : false;
            if (_hint == null)
            {
                _isPressed = false;
                _isSelected = false;
                ResetState();
            }
            else
                _isPressed = true;
            this.NotifyModelChanged();
        }

        // MovedPointer
        public void MovedPointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _hint = _stateHandler.Moved(_hint, pointX, pointY);
            }
            this.NotifyModelChanged();
        }

        // ReleasedPointer
        public void ReleasedPointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                AbstractShape newShape = _stateHandler.Released(_shapes, _hint, pointX, pointY);
                if (newShape == null)
                {
                    _isSelected = false;
                    UpdateHintText();
                    ResetState();
                    this.NotifyModelChanged();
                    return;
                }
                if (_stateHandler.GetHintText() == "")
                    _commandManager.Execute(new DrawCommand(this, newShape));
                ResetState();
            }
            this.NotifyModelChanged();
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
        public void ResetState()
        {
            if (!_stateHandler.KeepAlive)
            {
                _stateHandler = new StatePointer();
                _currentShapeType = DEFAULT_STATE;
            }
            _isPressed = false;
        }

        // Draw
        public void PaintOn(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.DrawLines(graphics);
            _shapes.DrawShapes(graphics);
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
        public void DrawShape(AbstractShape shape)
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

        // GetSelectLabelText
        public string GetSelectLabelText()
        {
            return _selectHintText;
        }

        // HandleShapeToolButtonClick
        public void HandleShapeToolButtonClick()
        {
            _isSelected = false;
            if (_hint != null)
                _hint = null;
        }

        // UpdateHintText

        public void UpdateHintText()
        {
            _selectHintText = _stateHandler.GetHintText();
        }

        // IsStateKeep
        public bool IsStateKeep()
        {
            return _stateHandler.KeepAlive;
        }
    }

}
