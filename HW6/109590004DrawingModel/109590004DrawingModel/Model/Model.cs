using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel109590004
{
    class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        double _firstPointX;
        double _firstPointY;
        bool _isPressed = false;
        List<Line> _lines = new List<Line>();
        Line _hint = new Line();

        // PressedPointer
        public void PressedPointer(double pointX, double pointY)
        {
            if (pointX > 0 && pointY > 0)
            {
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
            if (_isPressed)
            {
                _hint.X2 = pointX;
                _hint.Y2 = pointY;
                NotifyModelChanged();
            }
        }

        // ReleasedPointer
        public void ReleasedPointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _isPressed = false;
                Line hint = new Line();
                hint.X1 = _firstPointX;
                hint.Y1 = _firstPointY;
                hint.X2 = pointX;
                hint.Y2 = pointY;
                _lines.Add(hint);
                NotifyModelChanged();
            }
        }

        // Clear
        public void Clear()
        {
            _isPressed = false;
            _lines.Clear();
            NotifyModelChanged();
        }

        // Draw
        public void Draw(GraphicsInterface graphics)
        {
            graphics.ClearAll();
            foreach (Line aLine in _lines)
                aLine.Draw(graphics);
            if (_isPressed)
                _hint.Draw(graphics);
        }

        // NotifyModelChanged
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }

}
