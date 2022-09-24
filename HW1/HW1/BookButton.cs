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
        private Point _point;
        private Size _size;
        private int _tag;

        public BookButton()
        {
        }

        public BookButton(object parent, int tag, Point point, Size size)
        {
            _tag = tag;
            _point = point;
            _size = size;
            this.Tag = tag;
            this.Text = BOOK + tag;
            this.Parent = (Control)parent;
            this.Location = point;
            this.Size = size;
        }

        // Button tag getter
        public int GetTag()
        {
            return _tag;
        }
    }
}
