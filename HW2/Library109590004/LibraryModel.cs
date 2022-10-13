using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Library109590004
{
    public class LibraryModel
    {
        private const string TRASH_CAN_FILE_NAME = "../../../image/trash_can.png";
        private const string IMAGE_FILE_NAME = "../../../image/{0}.jpg";
        private const string SOURCE_FILE_NAME = "../../../hw2_books_source.txt";
        private const string BOOK_WORD = "BOOK";
        private const string BORROWED_BOOK_NAME = "【{0}】";
        private const string BORROWED_BOOK_COUNT = "\n\n{0}本書已成功借出！";
        private const string RETURNED_SUCCESS = "已成功歸還";
        private const string COMMA = "、";
        private const string ONE = "1";
        private const int BOOK_BORROWING_LIMIT = 5;
        private List<Book> _books;
        private List<BookItem> _bookItems;
        private List<BookCategory> _bookCategories;
        private List<int> _borrowingList;
        private BorrowedList _borrowedList;
        private string _returnedBookName;
        private Image _trashCan;
        private int _tag;

        public LibraryModel()
        {
            _tag = -1;
            _trashCan = Image.FromFile(TRASH_CAN_FILE_NAME);
            _books = new List<Book>();
            _bookItems = new List<BookItem>();
            _bookCategories = new List<BookCategory>();
            _borrowingList = new List<int>();
            _borrowedList = new BorrowedList();

            StreamReader file = new StreamReader(SOURCE_FILE_NAME);
            int imageNameId = 1;
            while (!file.EndOfStream)
            {
                if (file.ReadLine() == BOOK_WORD)
                {

                    int bookAmount = int.Parse(file.ReadLine());
                    string bookCategory = file.ReadLine();
                    Book book = new Book(file.ReadLine(), file.ReadLine(), file.ReadLine(), file.ReadLine());

                    int categoryIndex = _bookCategories.FindIndex(category => bookCategory.Equals(category.Name));
                    if (categoryIndex >= 0)
                    {
                        _bookCategories[categoryIndex].AddBook(book);
                    }
                    else
                    {
                        _bookCategories.Add(new BookCategory(bookCategory, book));
                    }
                    _books.Add(book);
                    BookItem bookItem = new BookItem(bookAmount);
                    try
                    {
                        bookItem.Image = Image.FromFile(string.Format(IMAGE_FILE_NAME, imageNameId));
                    }
                    catch
                    {
                        bookItem.Image = null;
                    }
                    imageNameId++;
                    _bookItems.Add(bookItem);
                }
            }
        }

        // Get book image by tag
        public Image GetBookImageByTag(int tag)
        {
            return _bookItems[tag].Image;
        }

        // Book getter
        public Book GetBook(int tag)
        {
            return _books[tag];
        }

        // Book list getter
        public List<Book> GetBooks()
        {
            return _books;
        }

        // Get category books count by index
        public int GetCategoryBooksCountByIndex(int index)
        {
            return _bookCategories[index].GetBooksCount();
        }

        // Book tag getter by book
        public int GetBookTag(Book book)
        {
            return _books.FindIndex(book.IsSameBook);
        }

        // Book tag getter by index
        public int GetBookTag(int categoryIndex, int bookIndex)
        {
            List<Book> bookCategory = _bookCategories[categoryIndex].GetBooks();
            return GetBookTag(bookCategory[bookIndex]);
        }

        // Get each category books amount
        public List<int> GetCategoryBooksCount()
        {
            List<int> categoryBooksCount = new List<int>();
            for (int i = 0; i < _bookCategories.Count; i++)
            {
                categoryBooksCount.Add(_bookCategories[i].GetBooksCount());
            }
            return categoryBooksCount;
        }

        // Book amount minus
        public void BookAmountMinusOne()
        {
            _bookItems[_tag].Amount -= 1;
        }

        // Current book amount getter

        public int GetCurrentBookAmountByMinusOne()
        {
            _bookItems[_tag].Amount -= 1;
            return _bookItems[_tag].Amount;
        }

        // Book item list getter
        public BookItem GetCurrentBookTagItem()
        {
            return _bookItems[_tag];
        }

        // Get current book amount
        public int GetCurrentBookAmount()
        {
            if (_tag == -1)
                return 0;
            else
                return _bookItems[_tag].Amount;
        }

        // Get current book format to cells
        public string[] GetCurrentBookCells()
        {
            return new string[] { "", GetCurrentBookName(), ONE, GetCurrentBookId(), GetCurrentBookAuthor(), GetCurrentBookPublication() };
        }

        // Current book name getter
        public string GetCurrentBookName()
        {
            return _books[_tag].Name;
        }

        // Current book id getter
        public string GetCurrentBookId()
        {
            return _books[_tag].Id;
        }

        // Current book author getter
        public string GetCurrentBookAuthor()
        {
            return _books[_tag].Author;
        }

        // Current book publication getter
        public string GetCurrentBookPublication()
        {
            return _books[_tag].Publication;
        }

        // Book category length
        public int GetCategoryCount()
        {
            return _bookCategories.Count;
        }

        // Book category getter
        public BookCategory GetCategory(int index)
        {
            return _bookCategories[index];
        }

        // Book category list getter
        public List<BookCategory> GetCategories()
        {
            return _bookCategories;
        }

        // Book detail string getter
        public string GetBookDetail(int tag)
        {
            Book book = _books[tag];
            const string BOOK_DETAIL_FORMAT = "{0}\n編號：{1}\n作者：{2}\n{3}";
            string bookDetail = string.Format(BOOK_DETAIL_FORMAT, book.Name, book.Id, book.Author, book.Publication);
            return bookDetail;
        }

        // Get trash can image
        public Image GetTrashCanImage()
        {
            return _trashCan;
        }

        // Library tag attribute
        public int Tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
            }
        }

        // Add book tag to borrowing list
        public void AddBookTagToBorrowingList(int bookTag)
        {
            _borrowingList.Add(bookTag);
        }

        // Is Borrowing list contain this book tag
        public bool IsBorrowingListContain(int bookTag)
        {
            return _borrowingList.Contains(bookTag);
        }

        // Remove book from borrowing list by index
        public void RemoveBookFromBorrowingList(int index)
        {
            _borrowingList.RemoveAt(index);
        }

        // Get borrowing list count
        public int GetBorrowingBooksAmount()
        {
            return _borrowingList.Count;
        }

        // Borrowing list have contain 5 book tag
        public bool IsBorrowingListFull()
        {
            return GetBorrowingBooksAmount() == BOOK_BORROWING_LIMIT;
        }

        // Get borrowing list tag by index
        public int GetBorrowingListTagByIndex(int index)
        {
            return _borrowingList[index];
        }

        // Get borrowed books success text
        public string GetBorrowedSuccessText()
        {
            int borrowingListCount = _borrowingList.Count;
            string borrowedSuccessText = "";
            for (int i = 0; i < borrowingListCount; i++)
            {
                int bookTag = _borrowingList[i];
                borrowedSuccessText += string.Format(BORROWED_BOOK_NAME, _books[bookTag].Name);
                _bookItems[bookTag].Amount -= 1;
                _borrowedList.Add(new BorrowedItem(GetBook(bookTag), bookTag));
                if (i == borrowingListCount - 1)
                    break;
                borrowedSuccessText += COMMA;
            }
            borrowedSuccessText += string.Format(BORROWED_BOOK_COUNT, _borrowingList.Count);
            _borrowingList.Clear();
            return borrowedSuccessText;
        }

        // Get borrowed list count
        public int GetBorrowedListCount()
        {
            return _borrowedList.Count;
        }

        // Borrowed items cell
        public string[] GetBorrowedItemCells(int index)
        {
            return _borrowedList.GetBorrowedItemCells(index);
        }

        // Return book back to library
        public void ReturnBookToLibrary(int index)
        {
            BorrowedItem borrowedItem = _borrowedList.GetBorrowedItem(index);
            int bookTag = borrowedItem.BookTag;
            _returnedBookName = _borrowedList.GetBorrowedItem(index).Book.Name;
            _bookItems[bookTag].Amount += 1;
            _borrowedList.Remove(index);
        }

        // GetReturnBookText
        public string GetReturnBookText()
        {
            return string.Format(BORROWED_BOOK_NAME + RETURNED_SUCCESS, _returnedBookName);
        }
    }
}
