using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class LibraryMessages
    {
        LibraryModel _library;
        private const string BOOK_DETAIL_FORMAT = "{0}\n編號：{1}\n作者：{2}\n出版項：{3}";
        
        public LibraryMessages(LibraryModel library)
        {
            _library = library;
        }

        // Book detail string getter
        public string GetBookDetail(int tag)
        {
            Book book = GetBookByTag(tag);
            return string.Format(BOOK_DETAIL_FORMAT, book.Name, book.Id, book.Author, book.Publication);
        }

        // GetBookByTag 
        private Book GetBookByTag(int tag)
        {
            return _library.GetBookByTag(tag);
        }
    }
}
