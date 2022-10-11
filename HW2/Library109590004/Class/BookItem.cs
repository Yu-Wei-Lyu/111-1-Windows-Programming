using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Library109590004
{
    public class BookItem
    {
        private int _amount;
        private Image _bookImage;

        public BookItem()
        {
            _amount = 0;
            _bookImage = null;
        }

        public BookItem(int bookAmount)
        {
            _amount = bookAmount;
            _bookImage = null;
        }

        public Image Image
        {
            get
            {
                return _bookImage;
            }
            set
            {
                _bookImage = value;
            }
        }

        // Book  getter and setter
        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }
    }
}
