using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library109590004
{
    public class BookBorrowingPresentationModel
    {
        private const int BOOK_BUTTON_SIZE_X = 86;
        private const int BOOK_BUTTON_SIZE_Y = 94;
        bool _addBorrowingListEnable;
        private int _bookNumber;
        LibraryModel _library;
        
        public BookBorrowingPresentationModel(LibraryModel library)
        {
            _library = library;
            _bookNumber = 0;
            _addBorrowingListEnable = true;
        }

        // Get category count
        public int GetCategoryCount()
        {
            int categoryCount = _library.GetCategoryCount();
            return categoryCount;
        }

        // Get category name by index
        public string GetCategoryName(int index)
        {
            BookCategory bookCategory = _library.GetCategory(index);
            return bookCategory.Name;
        }

        // Get book count by index
        public List<int> GetCategoryBooksCount()
        {
            return _library.GetCategoryBooksCount();
        }

        // Get book button location by parent location and index
        public Point GetBookButtonLocation(int index)
        {

            return new Point(index * BOOK_BUTTON_SIZE_X, 0);
        }

        // Get book button size 
        public Size GetBookButtonSize()
        {
            return new Size(BOOK_BUTTON_SIZE_X, BOOK_BUTTON_SIZE_Y);
        }

        // Get book button tag by book tag
        public int GetBookTag(int categoryIndex, int bookIndex)
        {
            return _library.GetBookTag(categoryIndex, bookIndex);
        }

        // Get book number show on tabPage
        public int GetBookNumber()
        {
            return _bookNumber++;
        }

        // Get book detail by tag and set library tag
        public string GetBookDetail(string tag)
        {
            _library.Tag = int.Parse(tag);
            _addBorrowingListEnable = (_library.GetCurrentBookAmount() == 0) ? false : true;
            return _library.GetBookDetail(tag);
        }

        // Get book count by index
        public int GetBookCount(int index)
        {
            BookCategory bookCategory = _library.GetCategory(index);
            return bookCategory.GetBooksCount();
        }

        // Get current book amount
        public int GetCurrentBookAmount()
        {
            return _library.GetCurrentBookAmount();
        }

        // Get current book detail format
        public string[] GetCurrentBookCells()
        {
            return _library.AddCurrentBookCells();
        }

        // Get current book amount by minux one
        public int GetBookAmountByMinusOne()
        {
            return _library.GetCurrentBookAmountByMinusOne();
        }

        // Get book button enable state
        public bool IsAddListButtonEnable()
        {
            return (_library.GetCurrentBookAmount() == 0) ? false : true;
        }
    }
}
