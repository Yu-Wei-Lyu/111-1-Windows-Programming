using DrawingModel;
using System.ComponentModel;

namespace DrawingApp.PresentationModel
{
    public class StoreAppPresentationModel
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        public event PropertyChangedEventHandler PropertyChanged;
        Model _model;
        private bool _isRectangleButtonEnabled;
        private bool _isLineButtonEnabled;
        private bool _isTriangleButtonEnabled;
        private bool _isClearButtonEnabled;

        public StoreAppPresentationModel(Model model)
        {
            this._model = model;
            _isRectangleButtonEnabled = true;
            _isLineButtonEnabled = true;
            _isTriangleButtonEnabled = true;
        }

        // Draw
        public void Draw(IGraphics graphics)
        {
            _model.PaintOn(graphics);
        }

        // NotifyModelChanged
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        public bool IsRectangleButtonEnabled
        {
            get
            {
                return _isRectangleButtonEnabled;
            }
            set
            {
                _isRectangleButtonEnabled = value;
                NotifyModelChanged();
            }
        }

        public bool IsLineButtonEnabled
        {
            get
            {
                return _isLineButtonEnabled;
            }
            set
            {
                _isLineButtonEnabled = value;
                NotifyModelChanged();
            }
        }

        public bool IsTriangleButtonEnabled
        {
            get
            {
                return _isTriangleButtonEnabled;
            }
            set
            {
                _isTriangleButtonEnabled = value;
                NotifyModelChanged();
            }
        }

        public bool IsClearButtonEnabled
        {
            get
            {
                return _isClearButtonEnabled;
            }
            set
            {
                _isClearButtonEnabled = value;
                NotifyModelChanged();
            }
        }

        // NotifyPropertyChanged
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // HandleRectangleButtonClick
        public void HandleRectangleButtonClick()
        {
            IsRectangleButtonEnabled = false;
            IsLineButtonEnabled = true;
            IsTriangleButtonEnabled = true;
        }

        // HandleLineButtonClick
        public void HandleLineButtonClick()
        {
            IsRectangleButtonEnabled = true;
            IsLineButtonEnabled = false;
            IsTriangleButtonEnabled = true;
        }

        // HandleTriangleButtonClick
        public void HandleTriangleButtonClick()
        {
            IsRectangleButtonEnabled = true;
            IsLineButtonEnabled = true;
            IsTriangleButtonEnabled = false;
        }

        // HandleClearButtonClick
        public void HandleClearButtonClick()
        {
            IsRectangleButtonEnabled = true;
            IsLineButtonEnabled = true;
            IsTriangleButtonEnabled = true;
        }

        // ClearButtonClick
        public void SetToDefaultButtonEnabled()
        {
            if (_model.IsStateKeep())
                this.HandleLineButtonClick();
            else
                this.HandleClearButtonClick();
        }
    }
}
