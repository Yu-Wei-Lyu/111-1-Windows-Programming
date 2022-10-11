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

        public BookButton()
        {
        }

        public BookButton(int tag, string text, Point point, Size size)
        {
            this.Tag = tag;
            this.Text = text;
            this.Location = point;
            this.Size = size;
        }
    }
}
