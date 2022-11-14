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
        public void TestGetBookDetail()
        {
            Book book = _libraryMessages.GetBookByTag(2);
            string bookDetail = "暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫\n編號：415.92 844 2021\n作者：艾德里安.雷恩\n出版項：遠流, 2021[民110]";
            Assert.AreEqual(bookDetail, _libraryMessages.GetBookDetail(2));
        }

        [TestMethod()]
        public void TestGetBorrowedSuccessText()
        {
            _libraryModel.AddBookTagToBorrowingList(0);
            _libraryModel.AddBookTagToBorrowingList(1);
            _libraryModel.SetBorrowingAmountByIndex(0, 2);
            string expectedText = "【微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書】2本、【創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡】1本\n\n已成功借出！";
            Assert.AreEqual(expectedText, _libraryMessages.GetBorrowedSuccessText());
        }

        [TestMethod()]
        public void TestGetBorrowingListCount()
        {
            Assert.AreEqual(0, _libraryMessages.GetBorrowingListCount());
            _libraryModel.AddBookTagToBorrowingList(2);
            Assert.AreEqual(1, _libraryMessages.GetBorrowingListCount());
        }

        [TestMethod()]
        public void TestGetBorrowingListTagByIndex()
        {
            _libraryModel.AddBookTagToBorrowingList(2);
            _libraryModel.AddBookTagToBorrowingList(0);
            _libraryModel.AddBookTagToBorrowingList(11);
            Assert.AreEqual(0, _libraryMessages.GetBorrowingListTagByIndex(1));
        }

        [TestMethod()]
        public void TestGetBorrowingListBookAmountByTag()
        {
            _libraryModel.AddBookTagToBorrowingList(8);
            _libraryModel.SetBorrowingAmountByIndex(0, 4);
            _libraryModel.AddBookTagToBorrowingList(2);
            _libraryModel.SetBorrowingAmountByIndex(1, 1);
            Assert.AreEqual(1, _libraryMessages.GetBorrowingListBookAmountByTag(2));
        }

        [TestMethod()]
        public void TestGetBookNameByTag()
        {
            Assert.AreEqual("工作焦慮 : 這個世代的上班族七成心裡都有病, 解決壓力與倦怠的8個方法", _libraryMessages.GetBookNameByTag(5));
        }
    }
}