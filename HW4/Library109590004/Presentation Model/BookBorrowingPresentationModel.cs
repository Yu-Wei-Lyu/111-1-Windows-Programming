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
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler _modelChanged;
        private const string TRASH_CAN_IMAGE = "../../../image/trash_can.png";
        private const string BORROWED_FULL = "每次借書限借五本，您的借書單已滿";
        private const string PAGE_CURRENT = "Page：{0} / {1}";
        private const string BOOK_BORROWING = "借書數量：";
        private const string BOOK_REMAIN = "剩餘數量：";
        private const string MESSAGE_BOX_TITLE_INVENTORY_STATUS = "庫存狀態";
        private const string MESSAGE_BOX_TEXT_INVENTORY_NOT_ENOUGH = "該書本剩餘數量不足";
        private const string MESSAGE_BOX_BORROWING_VIOLATE = "借書違規";
        private const string MESSAGE_BOX_BORROWING_LIMIT = "同本書一次限借2本";
        private const int BOOK_BORROWING_LIMIT = 5;
        private const int TWO = 2;
        private const int BOOK_BUTTON_LIMIT = 3;
        private const int BOOK_BUTTON_SIZE_X = 86;
        private const int BOOK_BUTTON_SIZE_Y = 94;
        private bool _addBorrowingListEnable;
        private bool _borrowingEnable;
        private bool _pageUpEnable;
        private bool _pageDownEnable;
        private string _errorMessageText;
        private string _errorMessageTitle;
        private int _pageCategoryIndex;
        private int _pageCurrent;
        private int _pageTotal;
        private int _editingAmount;
        private int _editSelectBookTag;
        LibraryModel _library;
        LibraryMessages _messages;
        private Image _trashCan;

        // Get trash can image
        public Image GetTrashCanImage()
        {
            return _trashCan;
        }

        // Notify observer
        public void NotifyObserver()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        public BookBorrowingPresentationModel(LibraryModel library)
        {
            _library = library;
            _messages = new LibraryMessages(library);
            _addBorrowingListEnable = false;
            InitializePageVariable();
            _errorMessageText = "";
            _errorMessageTitle = "";
            _trashCan = Image.FromFile(TRASH_CAN_IMAGE);
        }

        // InitializeVariable
        public void InitializePageVariable()
        {
            _borrowingEnable = false;
            _pageUpEnable = false;
            _pageCurrent = 1;
            _pageTotal = 1;
            _pageCategoryIndex = 0;
        }

        // SetEditSelectBookTag
        public void SetEditSelectBookTag(int value)
        {
            _editSelectBookTag = value;
        }

        // SetMessageBosResultAndEditingAmount
        private void SetMessageBoxResultAndEditingAmount(int amount, string title, string text)
        {
            _editingAmount = amount;
            _errorMessageTitle = title;
            _errorMessageText = text;
            NotifyObserver();
        }

        // SetEditingAmount
        public void SetEditingAmount(string value)
        {
            _editingAmount = int.Parse(value);
        }

        // JudgeEditing
        public void JudgeEditing()
        {
            int selectedBookRemainAmount = GetBookAmountByTag(_editSelectBookTag);
            if (_editingAmount > selectedBookRemainAmount)
                SetMessageBoxResultAndEditingAmount(selectedBookRemainAmount, MESSAGE_BOX_TITLE_INVENTORY_STATUS, MESSAGE_BOX_TEXT_INVENTORY_NOT_ENOUGH);
            if (_editingAmount > TWO)
                SetMessageBoxResultAndEditingAmount(TWO, MESSAGE_BOX_BORROWING_VIOLATE, MESSAGE_BOX_BORROWING_LIMIT);
            if (_library.GetBorrowingBooksCount() > BOOK_BORROWING_LIMIT)
                SetMessageBoxResultAndEditingAmount(BOOK_BORROWING_LIMIT - _library.GetBorrowingBooksCount() + _editingAmount, "", BORROWED_FULL);
        }

        // GetCurrentAmount
        public string GetCurrentAmount()
        {
            return _editingAmount.ToString();
        }

        // Show error message box title
        public string GetErrorMessageBoxTitle()
        {
            return _errorMessageTitle;
        }

        // Show error message
        public string GetErrorMessageBoxText()
        {
            return _errorMessageText;
        }

        // GetBookAmountByTag
        private int GetBookAmountByTag(int bookTag)
        {
            return _library.GetBookAmountByTag(bookTag);
        }

        // Get tag
        private int GetTag()
        {
            return _library.Tag;
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

        // Get book detail by tag and set library tag
        public string GetBookDetail()
        {
            int tag = GetTag();
            _addBorrowingListEnable = (_library.GetCurrentBookAmount() == 0 || tag == -1) ? false : true;
            return (tag == -1) ? "" : _messages.GetBookDetail(tag);
        }

        // Borrowing list have contain 5 book tag
        public bool IsBorrowingListFull()
        {
            return _library.GetBorrowingBooksCount() >= BOOK_BORROWING_LIMIT;
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

        // Reset book select
        public void JudgeAddBorrowingListButtonEnable()
        {
            _addBorrowingListEnable = (_library.GetCurrentBookAmount() == 0 || GetTag() == -1) ? false : true;
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
            if (_library.GetBorrowingBooksCount() == 0)
            {
                _borrowingEnable = false;
            }
        }

        // Get borrowing list count
        public string GetBorrowingBooksAmount()
        {
            return BOOK_BORROWING + _library.GetBorrowingBooksCount();
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
