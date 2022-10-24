using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class BorrowedItem
    {
        private const string DATE_FORMAT = "{0:yyyy/MM/dd}";
        private const int THIRTY_DAYS = 30;
        private Book _book;
        private int _bookTag;
        private int _bookAmount;
        private DateTime _borrowedDate;
        private DateTime _latestReturnDate;

        public BorrowedItem(Book book, int bookTag)
        {
            _book = book;
            _bookTag = bookTag;
            _bookAmount = 1;
            _borrowedDate = DateTime.Now;
            _latestReturnDate = _borrowedDate.AddDays(THIRTY_DAYS);
        }

        public int BookTag
        {
            get
            {
                return _bookTag;
            }
        }

        public Book Book
        {
            get
            {
                return _book;
            }
        }

        // Get borrowed date
        public string GetBorrowedDate()
        {
            return string.Format(DATE_FORMAT, _borrowedDate);
        }

        // Get latest return date
        public string GetLatestReturnDate()
        {
            return string.Format(DATE_FORMAT, _latestReturnDate);
        }
    }
}
