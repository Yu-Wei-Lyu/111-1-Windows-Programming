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
        private string _imagePath;
        private int _tag;

        public Book(string name, string id, string author, string publication)
        {
            Name = name; // 名稱
            Id = id; // ISBN
            Author = author; // 作者
            Publication = publication; // 出版項
        }

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

        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
            }
        }

        // Determine it is the same book or not
        public bool IsSameBook(Book book)
        {
            return this.Tag == book.Tag;
        }

        // UpdateBookDetail
        public void UpdateBookDetail(Book book)
        {
            this.Name = book.Name;
            this.Id = book.Id;
            this.Author = book.Author;
            this.Publication = book.Publication;
            this.ImagePath = book.ImagePath;
        }
    }
}
