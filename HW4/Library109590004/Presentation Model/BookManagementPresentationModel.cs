using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class BookManagementPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        LibraryModel _library;
        List<Book> _books;

        public BookManagementPresentationModel(LibraryModel library)
        {
            _library = library;
            _books = new List<Book>();
        }

        // UpdateLibraryBooks
        public void UpdateLibraryBooks()
        {
            _books.Clear();
            for (int i = 0; i < GetBooksCount(); i++)
            {
                _books.Add(GetBookByTag(i));
            }
        }

        // GetBooksCount
        public int GetBooksCount()
        {
            return _library.GetBooksCount();
        }

        // GetBookNameByTag
        public string GetBookNameByTag(int tag)
        {
            return _books[tag].Name;
        }

        // GetBookIdByTag
        public string GetBookIdByTag(int tag)
        {
            return _books[tag].Id;
        }

        // GetBookAuthorByTag
        public string GetBookAuthorByTag(int tag)
        {
            return _books[tag].Author;
        }

        // GetBookCategoryByTag
        public string GetBookCategoryByTag(int tag)
        {
            return _library.GetCategoryNameByBookTag(tag);
        }

        // GetBookPublicationByTag
        public string GetBookPublicationByTag(int tag)
        {
            return _books[tag].Publication;
        }

        // GetBookImagePathByTag
        public string GetBookImagePathByTag(int tag)
        {
            return _books[tag].GetImagePath();
        }

        // GetBookByTag
        private Book GetBookByTag(int tag)
        {
            return _library.GetBookByTag(tag);
        }
    }
}
