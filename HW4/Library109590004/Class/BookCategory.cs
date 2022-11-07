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

        public BookCategory(string bookCategory, Book book)
        {
            _name = bookCategory;
            _books = new List<Book>() 
            { 
                book
            };
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

        // RemoveBook
        public void RemoveContainBook(Book book)
        {
            if (_books.Contains(book))
                _books.Remove(book);
        }
    }
}
