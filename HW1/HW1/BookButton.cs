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

        public BookButton()
        {
            this.Tag = -1;
            this.Text = BOOK + -1;
            this.Parent = this;
            this.Location = new Point(0, 0);
            this.Size = new Size(20, 10);
        }

        public BookButton(int tag, int pointX, int pointY, int sizeX, int sizeY)
        {
            this.Tag = tag;
            this.Text = BOOK + tag;
            this.Parent = this;
            this.Location = new Point(pointX, pointY);
            this.Size = new Size(sizeX, sizeY);
        }

        // Setting the button click event
        public void SetBookButtonClick(object sender, EventArgs e)
        {

        }
    }
}
