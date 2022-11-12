using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class BorrowedItem
    {
        private const string DEFAULT_RETURN_AMOUNT = "1";
        private const string RETURN_BOOK = "歸還";
        private const string DATE_FORMAT = "{0:yyyy/MM/dd}";
        private const int THIRTY_DAYS = 30;
        private Book _book;
        private int _bookTag;
        private int _bookAmount;
        private DateTime _borrowedDate;
        private DateTime _latestReturnDate;

        public BorrowedItem(Book book, int bookTag, int amount, DateTime nowDate)
        {
            _book = book;
            _bookTag = bookTag;
            _bookAmount = amount;
            _borrowedDate = nowDate;
            _latestReturnDate = _borrowedDate.AddDays(THIRTY_DAYS);
        }

        public int BookTag
        {
            get
            {
                return _bookTag;
            }
        }

        // GetBookName
        public string GetBookName()
        {
            return _book.Name;
        }

        // GetBookId
        public string GetBookId()
        {
            return _book.Id;
        }

        // GetBookAuthor
        public string GetBookAuthor()
        {
            return _book.Author;
        }

        // GetBookPublication
        public string GetBookPublication()
        {
            return _book.Publication;
        }

        public int BorrowedAmount
        {
            get
            {
                return _bookAmount;
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

        // Is same book
        public bool IsSameBook(BorrowedItem borrowedItem)
        {
            return _bookTag == borrowedItem.BookTag;
        }

        // AddBorrowedBookAmount
        public void AddBorrowedBookAmount(int amount)
        {
            _bookAmount += amount;
        }

        // ReduceBorrowedAmount
        public void SetMinusBorrowedAmount(int amount)
        {
            _bookAmount -= amount;
        }

        // Borrowed items cell
        public string[] GetBorrowedItemCells()
        {
            return new string[] { RETURN_BOOK, DEFAULT_RETURN_AMOUNT, GetBookName(), _bookAmount.ToString(), GetBorrowedDate(), GetLatestReturnDate(), GetBookId(), GetBookAuthor(), GetBookPublication() };
        }
    }
}
