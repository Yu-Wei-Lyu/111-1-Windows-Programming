using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class BookBorrowingPresentationModel
    {
        private const string BORROWED_FULL = "每次借書限借五本，您的借書單已滿";
        private const string PAGE_CURRENT = "Page：{0} / {1}";
        private const string BOOK_BORROWING = "借書數量：";
        private const string BOOK_REMAIN = "剩餘數量：";
        private const int BOOK_BUTTON_LIMIT = 3;
        private const int BOOK_BUTTON_SIZE_X = 86;
        private const int BOOK_BUTTON_SIZE_Y = 94;
        private bool _openBackPackEnable;
        private bool _addBorrowingListEnable;
        private bool _borrowingEnable;
        private bool _pageUpEnable;
        private bool _pageDownEnable;
        private int _pageCategoryIndex;
        private int _pageCurrent;
        private int _pageTotal;
        private string _bookDetail;
        private string _bookRemain;
        LibraryModel _library;
        
        public BookBorrowingPresentationModel(LibraryModel library)
        {
            _library = library;
            _addBorrowingListEnable = false;
            _borrowingEnable = false;
            _pageUpEnable = false;
            _openBackPackEnable = true;
            _pageCurrent = 1;
            _pageTotal = 1;
            _pageCategoryIndex = 0;
        }

        // Set open backpack button enabled
        public void SetOpenBackPackButtonEnable(bool flag)
        {
            _openBackPackEnable = flag;
        }

        // Get open backpack button enabled
        public bool IsOpenBackPackButtonEnable()
        {
            return _openBackPackEnable;
        }

        // Get tag
        private int GetTag()
        {
            return _library.Tag;
        }

        // Get library
        public LibraryModel GetLibrary()
        {
            return _library;
        }

        // Set tag
        public void SetTag(int tag)
        {
            _library.Tag = tag;
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
        public string GetBookDetail()
        {
            int tag = GetTag();
            _addBorrowingListEnable = (_library.GetCurrentBookAmount() == 0 || tag == -1) ? false : true;
            if (tag == -1)
                return "";
            else
                return _library.GetBookDetail(tag);
        }

        // Get book count by index
        public int GetBookCount(int index)
        {
            BookCategory bookCategory = _library.GetCategory(index);
            return bookCategory.GetBooksCount();
        }

        // Get library current book amount
        public int GetBookAmount()
        {
            return _library.GetCurrentBookAmount();
        }

        // Get current book amount
        public int GetCurrentBookAmount()
        {
            int bookAmount = GetBookAmount();
            _addBorrowingListEnable = (bookAmount == 0 || _library.IsBorrowingListContain(GetTag()) == true) ? false : true;
            return bookAmount;
        }

        // Get current book detail format
        public string[] GetCurrentBookCells()
        {
            return _library.GetCurrentBookCells();
        }

        // Get current book amount by minux one
        public int GetBookAmountByMinusOne()
        {
            return _library.GetCurrentBookAmountByMinusOne();
        }

        // Get book button enable state
        public bool IsBorrowingButtonEnable()
        {
            return _borrowingEnable;
        }

        // Get add list button enable state
        public bool IsAddListButtonEnable()
        {
            return _addBorrowingListEnable;
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
            int lastIndex = GetCurrentPage() * BOOK_BUTTON_LIMIT;
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

        // Get current page label
        public string GetCurrentPageLabel()
        {
            return string.Format(PAGE_CURRENT, GetCurrentPage(), GetCurrentCategoryPageCount());
        }

        // Get trash can image
        public Image GetTrashCanImage()
        {
            return _library.GetTrashCanImage();
        }

        // Reset book select
        public void ResetBookSelect()
        {
            _library.Tag = -1;
            _bookRemain = BOOK_REMAIN;
            _addBorrowingListEnable = false;
        }

        // Get only book remain text
        public string GetBookInitializeText()
        {
            return BOOK_REMAIN;
        }

        // Get book remain amount
        public string GetBookAmountText()
        {
            return BOOK_REMAIN + GetCurrentBookAmount();
        }

        // Add book to borrowing list
        public void AddBookTagToBorrowingList()
        {
            _borrowingEnable = true;
            _library.AddBookTagToBorrowingList(GetTag());
        }

        // Remove book from borrowing list by index
        public void RemoveBookFromBorrowingList(int index)
        {
            int removeTag = _library.GetBorrowingListTagByIndex(index);
            if (GetTag() == removeTag)
            {
                _addBorrowingListEnable = true;
            }
            _library.RemoveBookFromBorrowingList(index);
            if (_library.GetBorrowingBooksAmount() == 0)
            {
                _borrowingEnable = false;
            }
        }

        // Borrowing list have contain 5 book tag
        public bool IsBorrowingListFull()
        {
            return _library.IsBorrowingListFull();
        }

        // Get borrowing list count
        public string GetBorrowingBooksAmount()
        {
            return BOOK_BORROWING + _library.GetBorrowingBooksAmount();
        }

        // Get borrowing list full text
        public string GetBorrowingListFullText()
        {
            return BORROWED_FULL;
        }

        // Get borrowed books success text
        public string GetBorrowedSuccessText()
        {
            _borrowingEnable = false;
            return _library.GetBorrowedSuccessText();
        }
    }
}
