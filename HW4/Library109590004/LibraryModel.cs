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
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler _modelChanged;
        public event ModelChangedEventHandler _modelChangedDeleteRow;
        private const string IMAGE_FILE = "../../../image/";
        
        private const string IMAGE_FILE_NAME = IMAGE_FILE + "{0}.jpg";
        private const string SOURCE_FILE_NAME = "../../../hw4_books_source.txt";
        private const string BOOK_WORD = "BOOK";
        private const string BORROWED_BOOK_NAME = "【{0}】{1}本";
        private const string BORROWED_BOOK_COUNT = "\n\n已成功借出！";
        private const string COMMA = "、";
        private const string RETURNED_SUCCESS = "【{0}】已成功歸還{1}本";
        private List<Book> _books;
        private List<BookItem> _bookItems;
        private List<BookCategory> _bookCategories;
        private Dictionary<int, int> _borrowingList; // bookTag, bookBorrowingAmount
        private BorrowedList _borrowedList;
        private string _returnedBookName;
        private int _tag;
        private int _returnAmount;

        // Notify observer
        public void NotifyObserver()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        // NotifyObserverDeleteRow
        public void NotifyObserverDeleteRow()
        {
            if (_modelChangedDeleteRow != null)
                _modelChangedDeleteRow();
        }

        public LibraryModel()
        {
            _tag = -1;
            _books = new List<Book>();
            _bookItems = new List<BookItem>();
            _bookCategories = new List<BookCategory>();
            _borrowingList = new Dictionary<int, int>();
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
                    book.SetImagePath(string.Format(IMAGE_FILE_NAME, imageNameId));
                    imageNameId++;
                    int categoryIndex = _bookCategories.FindIndex(category => bookCategory.Equals(category.Name));
                    if (categoryIndex >= 0)
                        _bookCategories[categoryIndex].AddBook(book);
                    else
                        _bookCategories.Add(new BookCategory(bookCategory, book));
                    _books.Add(book);
                    BookItem bookItem = new BookItem(bookAmount);
                    _bookItems.Add(bookItem);
                }
            }
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

        // Set tag by string convert to integer
        public void SetTag(string value)
        {
            _tag = int.Parse(value);
        }

        // Get book image by tag
        public Image GetBookImageByTag(int tag)
        {
            return Image.FromFile(GetBookImagePathByTag(tag));
        }

        // Get book image path by tag
        public string GetBookImagePathByTag(int tag)
        {
            return _books[tag].GetImagePath();
        }

        // Book getter
        public Book GetBookByTag(int tag)
        {
            return _books[tag];
        }

        // UpdateBookDetail
        public void UpdateBookDetailByTag(int bookTag, Book book)
        {
            _books[bookTag] = book;
            foreach (BookCategory bookCategory in _bookCategories)
            {
                bookCategory.RemoveBook(book);
            }
        }

        // Get category books count by index
        public int GetCategoryBooksCountByIndex(int index)
        {
            return _bookCategories[index].GetBooksCount();
        }

        // Book tag getter by index
        public int GetBookTag(int categoryIndex, int bookIndex)
        {
            List<Book> bookCategory = _bookCategories[categoryIndex].GetBooks();
            return _books.FindIndex(bookCategory[bookIndex].IsSameBook);
        }

        // Get current book amount
        public int GetCurrentBookAmount()
        {
            return (_tag == -1) ? 0 : _bookItems[_tag].Amount;
        }

        // Get book amount by index
        public int GetBookAmountByTag(int bookTag)
        {
            return _bookItems[bookTag].Amount;
        }

        // Get current book format to cells
        public string[] GetCurrentBookCells()
        {
            return new string[] { "", GetCurrentBookName(), 1.ToString(), GetCurrentBookId(), GetCurrentBookAuthor(), GetCurrentBookPublication() };
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

        // Get category name by index
        public string GetCategoryNameByIndex(int index)
        {
            return _bookCategories[index].Name;
        }

        // Get category name by book tag
        public string GetCategoryNameByBookTag(int bookTag)
        {
            BookCategory bookCategory = _bookCategories.Find(x => x.GetBooks().Contains(GetBookByTag(bookTag)));
            return bookCategory.Name;
        }

        // Get books count
        public int GetBooksCount()
        {
            return _books.Count;
        }

        // Book count getter
        public int GetBooksCount(int index)
        {
            return _bookCategories[index].GetBooksCount();
        }

        // Add book tag to borrowing list
        public void AddBookTagToBorrowingList(int bookTag)
        {
            _borrowingList.Add(bookTag, 1);
        }

        // Set book borrowing amount
        public void SetBorrowingAmountByIndex(int index, int amount)
        {
            int key = _borrowingList.ElementAt(index).Key;
            _borrowingList[key] = amount;
        }

        // Is Borrowing list contain this book tag
        public bool IsBorrowingListContain(int bookTag)
        {
            return _borrowingList.ContainsKey(bookTag);
        }

        // Remove book from borrowing list by index
        public void RemoveBookFromBorrowingList(int index)
        {
            _borrowingList.Remove(_borrowingList.ElementAt(index).Key);
        }

        // Get borrowing list count
        public int GetBorrowingBooksCount()
        {
            int borrowingBooksAmount = 0;
            foreach (KeyValuePair<int, int> item in _borrowingList)
                borrowingBooksAmount += item.Value;
            return borrowingBooksAmount;
        }

        // Get borrowing list tag by index
        public int GetBorrowingListTagByIndex(int index)
        {
            return _borrowingList.ElementAt(index).Key;
        }

        // Get borrowed books success text
        public string GetBorrowedSuccessText()
        {
            int borrowingListCount = _borrowingList.Count;
            string borrowedSuccessText = "";
            for (int i = 0; i < borrowingListCount; i++)
            {
                int bookTag = _borrowingList.ElementAt(i).Key;
                int bookBorrowingAmount = _borrowingList[bookTag];
                borrowedSuccessText += string.Format(BORROWED_BOOK_NAME, _books[bookTag].Name, bookBorrowingAmount);
                _bookItems[bookTag].Amount -= bookBorrowingAmount;
                _borrowedList.Add(new BorrowedItem(_books[bookTag], bookTag, bookBorrowingAmount));
                if (i == borrowingListCount - 1)
                    break;
                borrowedSuccessText += COMMA;
            }
            borrowedSuccessText += string.Format(BORROWED_BOOK_COUNT, _borrowingList.Count);
            _borrowingList.Clear();
            NotifyObserver();
            return borrowedSuccessText;
        }

        // GetBorrowedListTagByIndex
        public int GetBorrowedListTagByIndex(int index)
        {
            return _borrowedList.GetBorrowedListTagByIndex(index);
        }

        // Get borrowed item amount by tag
        public int GetBorrowedItemAmountByTag(int bookTag)
        {
            return _borrowedList.GetBorrowedItemAmountByTag(bookTag);
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
        public void ReturnBookToLibrary(int index, int returnAmount)
        {
            BorrowedItem borrowedItem = _borrowedList.GetBorrowedItem(index);
            int bookTag = borrowedItem.BookTag;
            _returnedBookName = borrowedItem.GetBookName();
            _borrowedList.ReduceBorrowedAmountByIndex(index, returnAmount);
            if (borrowedItem.BorrowedAmount == 0)
            {
                RemoveBorrowedItemByIndex(index);
                NotifyObserverDeleteRow();
            }
            _bookItems[bookTag].Amount += returnAmount;
            _returnAmount = returnAmount;
            NotifyObserver();
        }

        // RemoveBorrowedItemByIndex
        private void RemoveBorrowedItemByIndex(int index)
        {
            _borrowedList.Remove(index);
        }

        // Get return book text
        public string GetReturnBookText()
        {
            return string.Format(RETURNED_SUCCESS, _returnedBookName, _returnAmount);
        }

        // Add book amount by tag
        public void AddBookAmountByTag(int bookTag, string addAmount)
        {
            _bookItems[bookTag].Amount += int.Parse(addAmount);
            NotifyObserver();
        }
    }
}
