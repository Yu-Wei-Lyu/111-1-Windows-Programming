using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class BookItem
    {
        private Book _book;
        private int _amount;

        public BookItem()
        {
            _book = new Book();
            _amount = 0;
        }

        public BookItem(Book book, int bookAmount)
        {
            _book = book;
            _amount = bookAmount;
        }

        // Book  getter and setter
        public Book Book
        {
            get
            {
                return _book;
            }
            set
            {
                _book = value;
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
