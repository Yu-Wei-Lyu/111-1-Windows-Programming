using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Library109590004
{
    public class Library
    {
        private List<Book> _books;
        private List<BookItem> _bookItems;
        private List<BookCategory> _bookCategories;

        public Library(string fileName)
        {
            _bookItems = new List<BookItem>();
            _bookCategories = new List<BookCategory>();
            _books = new List<Book>();

            const string BOOK_WORD = "BOOK";
            StreamReader file = new StreamReader(@fileName);
            while (!file.EndOfStream)
            {
                if (file.ReadLine() == BOOK_WORD)
                {
                    int bookAmount = int.Parse(file.ReadLine());
                    string bookCategory = file.ReadLine();
                    Book book = new Book(file.ReadLine(), file.ReadLine(), file.ReadLine(), file.ReadLine());
                    bool bookAdded = false;
                    
                    _books.Add(book);
                    _bookItems.Add(new BookItem(book, bookAmount));
                    for (int categoryIndex = 0; categoryIndex < _bookCategories.Count; categoryIndex++)
                    {
                        BookCategory category = _bookCategories[categoryIndex];
                        if (bookCategory == category.Name)
                        {
                            _bookCategories[categoryIndex].AddBook(book);
                            bookAdded = true;
                            break;
                        }
                    }
                    if (!bookAdded)
                    {
                        BookCategory newCategory = new BookCategory(bookCategory);
                        newCategory.AddBook(book);
                        _bookCategories.Add(newCategory);
                    }
                }
            }
        }

        // Book category list
        public List<BookCategory> GetCategories()
        {
            return _bookCategories;
        }

    }
}
