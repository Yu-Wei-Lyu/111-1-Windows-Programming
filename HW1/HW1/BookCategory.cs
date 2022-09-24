using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class BookCategory
    {
        private string _name;
        private List<Book> _books;
        public BookCategory()
        {
            const string NULL_DATA = "null";
            _name = NULL_DATA;
            _books = new List<Book>();
        }

        public BookCategory(string bookCategory)
        {
            _name = bookCategory;
            _books = new List<Book>();
        }

        // Book category name getter and setter
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        // Book list size getter
        public int GetBooksCount()
        {
            return _books.Count;
        }

        // Book getter
        public List<Book> GetBooks()
        {
            return _books;
        }

        // Book setter
        public void AddBook(Book book)
        {
            _books.Add(book);
        }
    }
}
