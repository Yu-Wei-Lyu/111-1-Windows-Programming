using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    abstract public class AbstractState
    {
        private string _shapeType;
        private string _hintText = "";
        private bool _keepAlive = false;

        // abstract GetStateType
        public abstract string GetStateType();

        // abstract Pressed
        public abstract AbstractShape Pressed(Shapes shapes, string shapeType, double pointX, double pointY);

        // abstract Moved
        public abstract AbstractShape Moved(AbstractShape shape, double pointX, double pointY);

        // abstract Released
        public abstract AbstractShape Released(Shapes shapes, AbstractShape shape, double pointX, double pointY);

        // virtual GetHintText
        public virtual string GetHintText()
        {
            return this._hintText;
        }

        public string ShapeType
        {
            get
            {
                return _shapeType;
            }
            set
            {
                _shapeType = value;
            }
        }

        public string HintText
        {
            get
            {
                return _hintText;
            }
            set
            {
                _hintText = value;
            }
        }

        public bool KeepAlive
        {
            get
            {
                return _keepAlive;
            }
            set
            {
                _keepAlive = value;
            }
        }
    }
}
