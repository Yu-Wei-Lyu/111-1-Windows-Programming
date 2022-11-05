using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class BookItem
    {
        private int _amount;

        public BookItem(int bookAmount)
        {
            _amount = bookAmount;
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
