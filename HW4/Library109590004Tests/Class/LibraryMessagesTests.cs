using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library109590004;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004.Tests
{
    [TestClass()]
    public class LibraryMessagesTests
    {
        private const string TEST_FILE_PATH = "hw4_books_source.txt";
        private const string BOOK_DETAIL_FORMAT = "{0}\n編號：{1}\n作者：{2}\n出版項：{3}";
        private const string BORROWED_BOOK_NAME = "【{0}】{1}本";
        private const string BORROWED_BOOK_COUNT = "\n\n已成功借出！";
        private const string COMMA = "、";
        LibraryMessages _libraryMessages;
        LibraryModel _libraryModel;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _libraryModel = new LibraryModel(TEST_FILE_PATH);
            _libraryMessages = new LibraryMessages(_libraryModel);
        }

        [TestMethod()]
        public void LibraryMessagesTest()
        {
            Assert.AreEqual(_libraryModel.GetBookByTag(1), _libraryMessages.GetBookByTag(1));
        }

        [TestMethod()]
        public void GetBookDetailTest()
        {
            Book book = _libraryMessages.GetBookByTag(2);
            string bookDetail = string.Format(BOOK_DETAIL_FORMAT, book.Name, book.Id, book.Author, book.Publication);
            Assert.AreEqual(bookDetail, _libraryMessages.GetBookDetail(2));
        }

        [TestMethod()]
        public void GetBorrowedSuccessTextTest()
        {
            _libraryModel.AddBookTagToBorrowingList(0);
            _libraryModel.AddBookTagToBorrowingList(1);
            _libraryModel.SetBorrowingAmountByIndex(0, 2);
            string expectedText = "【微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書】2本、【創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡】1本\n\n已成功借出！";
            Assert.AreEqual(expectedText, _libraryMessages.GetBorrowedSuccessText());
        }
    }
}