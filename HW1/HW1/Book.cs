using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class Book
    {
        private string _name;
        private string _id;
        private string _author;
        private string _publication;
        public Book() 
        { 
        }

        public Book(string name, string id, string author, string publication)
        {
            _name = name; // 名稱
            _id = id; // ISBN
            _author = author; // 作者
            _publication = publication; // 出版項
        }

        // Book id getter and setter
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        // Book name getter and setter
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

        // Book author getter and setter
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
            }
        }

        // Book author getter and setter
        public string Publication
        {
            get
            {
                return _publication;
            }
            set
            {
                _publication = value;
            }
        }

        // Determine whether it is the same book
        public bool IsSameBook(Book book)
        {
            return _name == book.Name && _author == book.Author && _id == book.Id && _publication == book.Publication;
        }
    }
}
