using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class BorrowedList
    {
        private const string RETURN_BOOK = "歸還";
        private const string ONE = "1";
        private List<BorrowedItem> _borrowedItems;
        public BorrowedList()
        {
            _borrowedItems = new List<BorrowedItem>();
        }

        // get borrowed iten by index
        public BorrowedItem GetBorrowedItem(int index)
        {
            return _borrowedItems[index];
        }

        // Borrowed items list add
        public void Add(BorrowedItem borrowedItem)
        {
            _borrowedItems.Add(borrowedItem);
        }

        // Borrowed items list remove
        public void Remove(int index)
        {
            _borrowedItems.RemoveAt(index);
        }

        // Borrowed items cell
        public string[] GetBorrowedItemCells(int index)
        {
            BorrowedItem borrowedItem = _borrowedItems[index];
            Book book = borrowedItem.Book;
            return new string[] { RETURN_BOOK, book.Name, ONE, GetBorrowedDate(index), GetLatestReturnDate(index), book.Id, book.Author, book.Publication };
        }

        // Get borrowed date
        public string GetBorrowedDate(int index)
        {
            return _borrowedItems[index].GetBorrowedDate();
        }

        // Get last return date
        public string GetLatestReturnDate(int index)
        {
            return _borrowedItems[index].GetLatestReturnDate();
        }

        // Count attribute
        public int Count
        {
            get
            {
                return _borrowedItems.Count;
            }
        }
    }
}
