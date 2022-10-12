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
        private const string PAGE_INITIALIZE = "Page：1 / {0}";
        private const string PAGE_CURRENT = "Page：{0} / {1}";
        private const int BOOK_BUTTON_LIMIT = 3;
        private const int BOOK_BUTTON_SIZE_X = 86;
        private const int BOOK_BUTTON_SIZE_Y = 94;
        private bool _addBorrowingListEnable;
        private bool _pageUpEnable;
        private bool _pageDownEnable;
        private int _pageCategoryIndex;
        private int _pageCurrent;
        private int _pageTotal;
        LibraryModel _library;
        
        public BookBorrowingPresentationModel(LibraryModel library)
        {
            _library = library;
            _addBorrowingListEnable = true;
            _pageUpEnable = false;
            _pageCurrent = 1;
            _pageCategoryIndex = 0;
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
            return new Point((index % BOOK_BUTTON_LIMIT) * BOOK_BUTTON_SIZE_X, 0);
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

        // Get book image by book tag
        public Image GetBookImageByTag(int tag)
        {
            return _library.GetBookImageByTag(tag);
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

        // Get page up button enable state
        public bool IsUpButtonEnable()
        {
            return _pageUpEnable;
        }

        // Get page down button enable state
        public bool IsDownButtonEnable()
        {
            return _pageDownEnable;
        }

        // Get category page total count by index
        public void SetCategoryPageCountByIndex(int index)
        {
            int categoryBooksCount = GetCategoryBooksCountByIndex(index);
            int pageTotal = (categoryBooksCount % BOOK_BUTTON_LIMIT != 0) ? categoryBooksCount / BOOK_BUTTON_LIMIT + 1 : categoryBooksCount / BOOK_BUTTON_LIMIT;
            _pageTotal = pageTotal;
            _pageCategoryIndex = index;
            _pageCurrent = 1;
            _pageUpEnable = false;
            _pageDownEnable = (_pageCurrent == _pageTotal) ? false : true;
        }

        // Get category books count by index
        public int GetCategoryBooksCountByIndex(int index)
        {
            return _library.GetCategoryBooksCountByIndex(index);
        }

        // Get category page total count
        public int GetCurrentCategoryPageCount()
        {
            return _pageTotal;
        }

        // Get current page
        public int GetCurrentPage()
        {
            return _pageCurrent;
        }

        // Get current page first index
        public int GetCurrentPageFirstIndex()
        {
            return (GetCurrentPage() - 1) * BOOK_BUTTON_LIMIT;
        }

        // Get current page last index
        public int GetCurrentPageLastIndex()
        {
            int lastIndex = GetCurrentPage() * BOOK_BUTTON_LIMIT - 1;
            int categoryCount = GetCategoryBooksCountByIndex(_pageCategoryIndex);
            return (lastIndex < categoryCount) ? lastIndex : categoryCount;
        }

        // Get category first page last index
        public int GetCurrentCategoryFirstPageLastIndex()
        {
            int categoryCount = GetCategoryBooksCountByIndex(_pageCategoryIndex);
            return (categoryCount > BOOK_BUTTON_LIMIT) ? BOOK_BUTTON_LIMIT : categoryCount;
        }

        // Page up
        public void SetPageUp()
        {
            _pageCurrent -= 1;
            _pageUpEnable = (_pageCurrent == 1) ? false : true;
            _pageDownEnable = (_pageCurrent == _pageTotal) ? false : true;
        }

        // Page down
        public void SetPageDown()
        {
            _pageCurrent += 1;
            _pageUpEnable = (_pageCurrent == 1) ? false : true;
            _pageDownEnable = (_pageCurrent == _pageTotal) ? false : true;
        }

        // Get category page index
        public int GetCurrentCategoryPageIndex()
        {
            return _pageCategoryIndex;
        }

        // Get page label init
        public string GetPageLabelInitialize()
        {
            return string.Format(PAGE_INITIALIZE, GetFirstCategoryPageCount());
        }

        // Get first category page count
        private int GetFirstCategoryPageCount()
        {
            SetCategoryPageCountByIndex(0);
            return _pageTotal;
        }

        // Get current page label
        public string GetCurrentPageLabel()
        {
            return string.Format(PAGE_CURRENT, GetCurrentPage(), GetCurrentCategoryPageCount());
        }
    }
}
