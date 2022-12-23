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
            UpdateHintText();
            _isSelected = (_selectHintText != "") ? true : false;
            if (_hint == null)
            {
                _isPressed = false;
                _isSelected = false;
                _stateHandler = new StatePointer();
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
                _isMoving = true;
            }
            this.NotifyModelChanged();
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
                if (newShape == null)
                {
                    _isSelected = false;
                    UpdateHintText();
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
        public void ResetState()
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
                _hint.SetPoints(0, 0, 0, 0);
        }

        // UpdateHintText

        public void UpdateHintText()
        {
            _selectHintText = _stateHandler.GetHintText();
        }
    }

}
