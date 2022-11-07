using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Library109590004
{
    public class Book
    {
        private string _name;
        private string _id;
        private string _author;
        private string _publication;
        private string _image;

        public Book(string name, string id, string author, string publication)
        {
            _name = name; // 名稱
            _id = id; // ISBN
            _author = author; // 作者
            _publication = publication; // 出版項
        }

        // Book image setter
        public void SetImagePath(string imagePath)
        {
            _image = imagePath;
        }

        // Book image setter
        public string GetImagePath()
        {
            return _image;
        }

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

        // Determine it is the same book or not
        public bool IsSameBook(Book book)
        {
            return _name == book.Name && _author == book.Author && _id == book.Id && _publication == book.Publication;
        }

        // UpdateBookDetail
        public void UpdateBookDetail(Book book)
        {
            this.Name = book.Name;
            this.Id = book.Id;
            this.Author = book.Author;
            this.Publication = book.Publication;
            this.SetImagePath(book.GetImagePath());
        }
    }
}
