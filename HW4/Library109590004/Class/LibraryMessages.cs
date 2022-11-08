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
        private const string BORROWED_BOOK_NAME = "【{0}】{1}本";
        private const string BORROWED_BOOK_COUNT = "\n\n已成功借出！";
        private const string COMMA = "、";

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

        // Get borrowed books success text
        public string GetBorrowedSuccessText()
        {
            string borrowedSuccessText = "";
            int borrowingListCount = GetBorrowingListCount();
            for (int i = 0; i < borrowingListCount; i++)
            {
                int bookTag = GetBorrowingListTagByIndex(i);
                int bookBorrowingAmount = GetBorrowingListBookAmountByTag(bookTag);
                borrowedSuccessText += string.Format(BORROWED_BOOK_NAME, GetBookNameByTag(bookTag), bookBorrowingAmount);
                if (i != borrowingListCount - 1)
                    borrowedSuccessText += COMMA;
            }
            borrowedSuccessText += BORROWED_BOOK_COUNT;
            return borrowedSuccessText;
        }

        // GetBorrowingListCount
        public int GetBorrowingListCount()
        {
            return _library.GetBorrowingListCount();
        }

        // GetBorrowingListTagByIndex
        public int GetBorrowingListTagByIndex(int index)
        {
            return _library.GetBorrowingListTagByIndex(index);
        }

        // GetBorrowingListBookAmountByTag
        public int GetBorrowingListBookAmountByTag(int bookTag)
        {
            return _library.GetBorrowingListBookAmountByTag(bookTag);
        }

        // GetBookByTag(bookTag)
        public string GetBookNameByTag(int bookTag)
        {
            return _library.GetBookByTag(bookTag).Name;
        }
    }
}
