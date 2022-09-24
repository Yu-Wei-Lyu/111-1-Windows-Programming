using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Library109590004
{
    public class BookButton : Button
    {
        private const string BOOK = "Book ";
        private int _pointX; 
        private int _pointY;
        private int _sizeX;
        private int _sizeY;
        private int _tag;

        public BookButton()
        {
        }

        public BookButton(object parent, int tag, int pointX, int pointY, int sizeX, int sizeY)
        {
            _tag = tag;
            _pointX = pointX;
            _pointY = pointY;
            _sizeX = sizeX;
            _sizeY = sizeY;
            this.Tag = tag;
            this.Text = BOOK + tag;
            this.Parent = (Control)parent;
            this.Location = new Point(pointX, pointY);
            this.Size = new Size(sizeX, sizeY);
        }

        // Button tag getter
        public int GetTag()
        {
            return _tag;
        }
    }
}
