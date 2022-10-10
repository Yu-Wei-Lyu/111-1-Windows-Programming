using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library109590004
{
    public class BookBorrowingFormPresentationModel
    {
        private const string BOOK_TEXT = "Book ";
        private const string BOOK_REMAIN_COUNT = "剩餘數量：";
        private const string BOOK_BORROWING_COUNT = "借書數量：";
        private const int BOOK_BUTTON_SIZE_X = 86;
        private const int BOOK_BUTTON_SIZE_Y = 94;
        private const int BOOK_CATEGORY_TAB_CONTROL_X = 86;
        private const int BOOK_CATEGORY_TAB_CONTROL_Y = 94;
        bool _addBorrowingListEnable = false;
        bool _borrowButton = false;
        private int _bookNumber;
        Library _library;
        
        public BookBorrowingFormPresentationModel(Library library)
        {
            _library = library;
            _bookNumber = 0;
        }

        // Get category count
        public int GetCategoryCount()
        {
            return _library.GetCategoryCount();
        }

        // Get category name by index
        public string GetCategoryName(int index)
        {
            BookCategory bookCategory = _library.GetCategory(index);
            return bookCategory.Name;
        }

        // Get book count by index
        public int GetBookCount(int index)
        {
            BookCategory bookCategory = _library.GetCategory(index);
            return bookCategory.GetBooksCount();
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

        // Get book number show on tabPage
        public int GetBookNumber()
        {
            return _bookNumber++;
        }
    }
}
