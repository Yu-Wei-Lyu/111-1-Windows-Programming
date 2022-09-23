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
        private List<Book> _books = new List<Book>();
        private BookCategory _category = new BookCategory();
        private BookItem _item = new BookItem();

        public Library()
        {
            const string FILE_NAME = "../../../hw1_books_source.txt";
            const string BOOK_WORD = "BOOK";
            StreamReader file = new StreamReader(@FILE_NAME);
            while (!file.EndOfStream)
            {
                if (file.ReadLine() == BOOK_WORD)
                {
                    int bookAmount = int.Parse(file.ReadLine());
                    string bookCategory = file.ReadLine();
                    Book book = new Book(file.ReadLine(), file.ReadLine(), file.ReadLine(), file.ReadLine());
                    _item.Add(book.name, bookAmount);
                    _category.Add(book.name, bookCategory);
                    _books.Add(book);
                }
            }
            count = _books.Count;
        }

        public int count
        {
            get;
            set;
        }

        // Get book in list with index
        public Book GetBook(int index)
        {
            return _books[index];
        }

        // Get book category by book name
        public string GetBookCategory(string bookName)
        {
            return _category.GetCategoryByBookName(bookName);
        }

        // Get book amount by book name
        public int GetBookAmount(string bookName)
        {
            return _item.GetAmountByBookName(bookName);
        }

        // Get category set
        public List<string> GetCategorySet()
        {
            List<string> categorySet = _category.GetCategorySet();
            return categorySet;
        }
    }
}
