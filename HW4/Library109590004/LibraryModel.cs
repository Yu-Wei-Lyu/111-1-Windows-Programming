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
        public event ModelChangedEventHandler _modelChangedManagement;
        public event ModelChangedEventHandler _modelChangedDeleteRow;
        private const string IMAGE_FILE_NAME = "../../../image/{0}.jpg";
        private const string SOURCE_FILE_NAME = "../../../hw4_books_source.txt";
        private const string BOOK_WORD = "BOOK";
        private const string RETURNED_SUCCESS = "【{0}】已成功歸還{1}本";
        private List<Book> _books;
        private List<BookItem> _bookItems;
        private List<BookCategory> _bookCategories;
        private BorrowingList _borrowingList;
        private BorrowedList _borrowedList;
        private string _returnedBookName;
        private int _tag;
        private int _returnAmount;

        // Notify observer
        public void NotifyObserver(int channel)
        {
            if (channel == 0 && _modelChanged != null)
                _modelChanged();
            if (channel == 1 && _modelChangedManagement != null)
                _modelChangedManagement();
            if (channel == -1 && _modelChangedDeleteRow != null)
                _modelChangedDeleteRow();
        }

        public LibraryModel()
        {
            _tag = -1;
            _books = new List<Book>();
            _bookItems = new List<BookItem>();
            _bookCategories = new List<BookCategory>();
            _borrowingList = new BorrowingList();
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

        // RemoveCategoryBook
        private void RemoveCategoryBook(Book book)
        {
            for (int i = 0; i < _bookCategories.Count; i++)
            {
                int indexOfBook = _bookCategories[i].GetIndexOfBook(book);
                if (indexOfBook >= 0)
                    _bookCategories[i].RemoveIndexOfBook(indexOfBook);
            }
        }

        // UpdateBookDetail
        public void UpdateBookDetailByTag(int bookTag, Book newBook, string category)
        {
            _books[bookTag].UpdateBookDetail(newBook);
            if (GetCategoryNameByBookTag(bookTag) != category)
            {
                RemoveCategoryBook(_books[bookTag]);
                for (int i = 0; i < _bookCategories.Count; i++)
                {
                    if (_bookCategories[i].Name == category)
                    {
                        _bookCategories[i].AddBook(_books[bookTag]);
                        break;
                    }
                }
            }
            NotifyObserver(1);
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
        public string[] GetBookCells(int bookTag)
        {
            int borrowingBookAmount = (_borrowingList.ContainsKey(bookTag)) ? GetBorrowingListBookAmountByTag(bookTag) : 1;
            return new string[] { "", _books[bookTag].Name, borrowingBookAmount.ToString(), _books[bookTag].Id, _books[bookTag].Author, _books[bookTag].Publication};
        }

        // Book category length
        public int GetCategoryCount()
        {
            return _bookCategories.Count;
        }

        // Get category books count by index
        public int GetCategoryBooksCountByIndex(int index)
        {
            return _bookCategories[index].GetBooksCount();
        }

        // Get category name by index
        public string GetCategoryNameByIndex(int index)
        {
            return _bookCategories[index].Name;
        }

        // Get category name by book tag
        public string GetCategoryNameByBookTag(int bookTag)
        {
            Book book = GetBookByTag(bookTag);
            foreach (BookCategory bookCategory in _bookCategories)
            {
                foreach (Book libraryBook in bookCategory.GetBooks())
                {
                    if (libraryBook.IsSameBook(book))
                        return bookCategory.Name;
                }
            }
            return "";
        }

        // Get books count
        public int GetBooksCount()
        {
            return _books.Count;
        }

        // Add book tag to borrowing list
        public void AddBookTagToBorrowingList(int bookTag)
        {
            _borrowingList.Add(bookTag, 1);
        }

        // Set book borrowing amount
        public void SetBorrowingAmountByIndex(int index, int amount)
        {
            _borrowingList.SetBorrowingAmountByIndex(index, amount);
        }

        // Is Borrowing list contain this book tag
        public bool IsBorrowingListContain(int bookTag)
        {
            return _borrowingList.ContainsKey(bookTag);
        }

        // Remove book from borrowing list by index
        public void RemoveBookFromBorrowingList(int index)
        {
            _borrowingList.RemoveBookTagByIndex(index);
        }

        // Get borrowing list count
        public int GetBorrowingBooksCount()
        {
            return _borrowingList.GetBorrowingBooksAmount();
        }

        // Get borrowing list tag by index
        public int GetBorrowingListTagByIndex(int index)
        {
            return _borrowingList.GetBorrowingListTagByIndex(index);
        }

        // GetBorrowingListBookAmountByTag
        public int GetBorrowingListBookAmountByTag(int bookTag)
        {
            return _borrowingList.GetAmountByTag(bookTag);
        }

        // GetBorrowingListCount
        public int GetBorrowingListCount()
        {
            return _borrowingList.Count;
        }

        // AddBorrrowingToBorrowed
        public void AddBorrowingToBorrowed()
        {
            int borrowingListCount = GetBorrowingListCount();
            for (int i = 0; i < borrowingListCount; i++)
            {
                int bookTag = GetBorrowingListTagByIndex(i);
                int bookBorrowingAmount = GetBorrowingListBookAmountByTag(bookTag);
                _bookItems[bookTag].Amount -= bookBorrowingAmount;
                _borrowedList.Add(new BorrowedItem(_books[bookTag], bookTag, bookBorrowingAmount));
            }
            _borrowingList.Clear();
            NotifyObserver(0);
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
                RemoveBorrowedItemByIndex(index);
            _bookItems[bookTag].Amount += returnAmount;
            _returnAmount = returnAmount;
            NotifyObserver(0);
        }

        // RemoveBorrowedItemByIndex
        private void RemoveBorrowedItemByIndex(int index)
        {
            _borrowedList.Remove(index);
            NotifyObserver(-1);
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
            NotifyObserver(0);
        }
    }
}
