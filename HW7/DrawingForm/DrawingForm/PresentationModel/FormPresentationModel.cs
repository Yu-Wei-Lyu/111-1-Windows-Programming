using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace DrawingForm.Presentation
{
    public class FormPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Model _model;
        private bool _isRectangleButtonEnabled;
        private bool _isLineButtonEnabled;
        private bool _isTriangleButtonEnabled;
        private bool _isClearButtonEnabled;

        public FormPresentationModel(Model model)
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
        
        public bool IsRectangleButtonEnabled
        {
            get
            {
                return _isRectangleButtonEnabled;
            }
            set
            {
                _isRectangleButtonEnabled = value;
                NotifyPropertyChanged("IsRectangleButtonEnabled");
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
                NotifyPropertyChanged("IsLineButtonEnabled");
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
                NotifyPropertyChanged("IsTriangleButtonEnabled");
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
                NotifyPropertyChanged("IsClearButtonEnabled");
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

        // RectangleButtonClick
        public void RectangleButtonClick()
        {
            IsRectangleButtonEnabled = false;
            IsLineButtonEnabled = true;
            IsTriangleButtonEnabled = true;
        }

        // LineButtonClick
        public void LineButtonClick()
        {
            IsRectangleButtonEnabled = true;
            IsLineButtonEnabled = false;
            IsTriangleButtonEnabled = true;
        }

        // TriangleButtonClick
        public void TriangleButtonClick()
        {
            IsRectangleButtonEnabled = true;
            IsLineButtonEnabled = true;
            IsTriangleButtonEnabled = false;
        }

        // ClearButtonClick
        public void ClearButtonClick()
        {
            IsRectangleButtonEnabled = true;
            IsLineButtonEnabled = true;
            IsTriangleButtonEnabled = true;
        }
    }
}
