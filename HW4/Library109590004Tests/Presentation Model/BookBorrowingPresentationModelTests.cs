using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library109590004;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Library109590004.Tests
{
    [TestClass()]
    public class BookBorrowingPresentationModelTests
    {
        private const string TEST_FILE_PATH = "hw4_books_source.txt";
        private const string TRASH_CAN_IMAGE = "image/trash_can.png";
        PrivateObject _privateObject;
        LibraryModel _libraryModel;
        BookBorrowingPresentationModel _presentationModel;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _libraryModel = new LibraryModel(TEST_FILE_PATH);
            _presentationModel = new BookBorrowingPresentationModel(_libraryModel, TRASH_CAN_IMAGE);
            _privateObject = new PrivateObject(_presentationModel);
        }

        [TestMethod()]
        public void TestNotifyObserver()
        {
            Assert.AreEqual(-1, _libraryModel.LibraryTag);
            _presentationModel.SetMessageBoxResultAndEditingAmount(1, "", "");
            Assert.AreEqual(-1, _libraryModel.LibraryTag);
            _presentationModel._modelChanged += delegate ()
            {
                _libraryModel.LibraryTag = 2;
            };
            _presentationModel.SetMessageBoxResultAndEditingAmount(2, "a", "b");
            Assert.AreEqual(2, _libraryModel.LibraryTag);
        }

        [TestMethod()]
        public void TestGetTrashCanImage()
        {
            Assert.AreEqual("image/trash_can.png", _presentationModel.GetTrashCanImage());
        }

        [TestMethod()]
        public void TestSetEditSelectBookTag()
        {
            _presentationModel.SetEditSelectBookTag(22);
            Assert.AreEqual(22, _privateObject.GetFieldOrProperty("_editSelectBookTag"));
        }

        [TestMethod()]
        public void TestSetMessageBoxResultAndEditingAmount()
        {
            _presentationModel.SetMessageBoxResultAndEditingAmount(1, "111", "await");
            Assert.AreEqual("1", _presentationModel.GetCurrentAmount());
            Assert.AreEqual("111", _presentationModel.GetErrorMessageBoxTitle());
            Assert.AreEqual("await", _presentationModel.GetErrorMessageBoxText());
        }

        [TestMethod()]
        public void TestSetEditingAmount()
        {
            _presentationModel.SetEditingAmount("5");
            Assert.AreEqual(5, _privateObject.GetFieldOrProperty("_editingAmount"));
        }

        [TestMethod()]
        public void TestJudgeEditing()
        {
            _presentationModel.SetEditSelectBookTag(1);
            _presentationModel.SetEditingAmount("2");
            _presentationModel.JudgeEditing();
            Assert.AreEqual("1", _presentationModel.GetCurrentAmount());
            Assert.AreEqual("庫存狀態", _presentationModel.GetErrorMessageBoxTitle());
            Assert.AreEqual("該書本剩餘數量不足", _presentationModel.GetErrorMessageBoxText());
            _presentationModel.SetEditSelectBookTag(0);
            _presentationModel.SetEditingAmount("3");
            _presentationModel.JudgeEditing();
            Assert.AreEqual("2", _presentationModel.GetCurrentAmount());
            Assert.AreEqual("借書違規", _presentationModel.GetErrorMessageBoxTitle());
            Assert.AreEqual("同本書一次限借2本", _presentationModel.GetErrorMessageBoxText());
            _libraryModel.AddBookTagToBorrowingList(2);
            _libraryModel.AddBookTagToBorrowingList(4);
            _libraryModel.AddBookTagToBorrowingList(8);
            _libraryModel.SetBorrowingAmountByIndex(0, 2);
            _libraryModel.SetBorrowingAmountByIndex(1, 2);
            _libraryModel.SetBorrowingAmountByIndex(2, 2);
            _presentationModel.JudgeEditing();
            _presentationModel.SetEditSelectBookTag(1);
            Assert.AreEqual("1", _presentationModel.GetCurrentAmount());
            Assert.AreEqual("", _presentationModel.GetErrorMessageBoxTitle());
            Assert.AreEqual("每次借書限借五本，您的借書單已滿", _presentationModel.GetErrorMessageBoxText());
        }

        [TestMethod()]
        public void TestGetCurrentAmount()
        {
            _presentationModel.SetMessageBoxResultAndEditingAmount(1, "111", "await");
            Assert.AreEqual("1", _presentationModel.GetCurrentAmount());
        }

        [TestMethod()]
        public void TestGetErrorMessageBoxTitle()
        {
            _presentationModel.SetMessageBoxResultAndEditingAmount(1, "111", "await");
            Assert.AreEqual("111", _presentationModel.GetErrorMessageBoxTitle());
        }

        [TestMethod()]
        public void TestGetErrorMessageBoxText()
        {
            _presentationModel.SetMessageBoxResultAndEditingAmount(1, "111", "await");
            Assert.AreEqual("await", _presentationModel.GetErrorMessageBoxText());
        }

        [TestMethod()]
        public void TestGetBookAmountByTag()
        {
            Assert.AreEqual(5, _presentationModel.GetBookAmountByTag(0));
        }

        [TestMethod()]
        public void TestGetTag()
        {
            Assert.AreEqual(-1, _presentationModel.GetTag());
            _libraryModel.LibraryTag = 1;
            Assert.AreEqual(1, _presentationModel.GetTag());
        }

        [TestMethod()]
        public void TestGetBookButtonLocation()
        {
            Assert.AreEqual(new Point(0, 0), _presentationModel.GetBookButtonLocation(0));
            Assert.AreEqual(new Point(86, 0), _presentationModel.GetBookButtonLocation(1));
            Assert.AreEqual(new Point(172, 0), _presentationModel.GetBookButtonLocation(5));
        }

        [TestMethod()]
        public void TestGetBookButtonSize()
        {
            Assert.AreEqual(new Size(86, 94), _presentationModel.GetBookButtonSize());
        }

        [TestMethod()]
        public void TestGetBookDetail()
        {
            Assert.AreEqual("", _presentationModel.GetBookDetail());
            _libraryModel.LibraryTag = 1;
            string expectedString = "創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡\n編號：176.51 8564 2022\n作者：羅瑞塔.葛蕾吉亞諾.布魯\n出版項：閱樂國際文化出版";
            Assert.AreEqual(expectedString, _presentationModel.GetBookDetail());
        }

        [TestMethod()]
        public void TestIsBorrowingListFull()
        {
            _libraryModel.AddBookTagToBorrowingList(1);
            _libraryModel.AddBookTagToBorrowingList(8);
            _libraryModel.AddBookTagToBorrowingList(11);
            _libraryModel.AddBookTagToBorrowingList(17);
            Assert.IsFalse(_presentationModel.IsBorrowingListFull());
            _libraryModel.SetBorrowingAmountByIndex(0, 2);
            _libraryModel.SetBorrowingAmountByIndex(1, 2);
            Assert.IsTrue(_presentationModel.IsBorrowingListFull());
        }

        [TestMethod()]
        public void TestGetBookAmountByLibraryTag()
        {
            Assert.AreEqual(0, _presentationModel.GetBookAmountByLibraryTag());
            _libraryModel.LibraryTag = 5;
            Assert.AreEqual(1, _presentationModel.GetBookAmountByLibraryTag());
        }

        [TestMethod()]
        public void TestGetCurrentBookAmount()
        {
            Assert.AreEqual(0, _presentationModel.GetCurrentBookAmount());
            _libraryModel.LibraryTag = 7;
            Assert.AreEqual(3, _presentationModel.GetCurrentBookAmount());
        }

        [TestMethod()]
        public void TestIsBorrowingButtonEnable()
        {
            Assert.IsFalse(_presentationModel.IsBorrowingButtonEnable());
            _presentationModel.AddCurrentBookTagToBorrowingList();
            Assert.IsTrue(_presentationModel.IsBorrowingButtonEnable());
        }

        [TestMethod()]
        public void TestIsAddListButtonEnable()
        {
            Assert.IsFalse(_presentationModel.IsAddListButtonEnable());
            _libraryModel.LibraryTag = 2;
            _presentationModel.JudgeAddBorrowingListButtonEnable();
            Assert.IsTrue(_presentationModel.IsAddListButtonEnable());
        }

        [TestMethod()]
        public void TestIsUpButtonEnable()
        {
            Assert.IsFalse(_presentationModel.IsUpButtonEnable());
            _presentationModel.SetPageDown();
            Assert.IsTrue(_presentationModel.IsUpButtonEnable());
        }

        [TestMethod()]
        public void TestIsDownButtonEnable()
        {
            Assert.IsFalse(_presentationModel.IsDownButtonEnable());
            _presentationModel.SetCategoryPageCountByIndex(1);
            Assert.IsTrue(_presentationModel.IsDownButtonEnable());
        }

        [TestMethod()]
        public void TestSetCategoryPageCountByIndex()
        {
            _presentationModel.SetCategoryPageCountByIndex(0);
            Assert.AreEqual(0, _presentationModel.GetCurrentCategoryPageIndex());
            _presentationModel.SetCategoryPageCountByIndex(3);
            Assert.AreEqual(3, _presentationModel.GetCurrentCategoryPageIndex());
        }

        [TestMethod()]
        public void TestGetCategoryBooksCountByIndex()
        {
            Assert.AreEqual(4, _presentationModel.GetCategoryBooksCountByIndex(0));
            Assert.AreEqual(3, _presentationModel.GetCategoryBooksCountByIndex(3));
        }

        [TestMethod()]
        public void TestGetCurrentCategoryPageCount()
        {
            _presentationModel.SetCategoryPageCountByIndex(0);
            Assert.AreEqual(2, _presentationModel.GetCurrentCategoryPageCount());
        }

        [TestMethod()]
        public void TestGetCurrentPage()
        {
            _presentationModel.SetCategoryPageCountByIndex(1);
            Assert.AreEqual(1, _presentationModel.GetCurrentPage());
            _presentationModel.SetPageDown();
            Assert.AreEqual(2, _presentationModel.GetCurrentPage());
        }

        [TestMethod()]
        public void TestGetCurrentPageFirstIndex()
        {
            _presentationModel.SetCategoryPageCountByIndex(1);
            Assert.AreEqual(0, _presentationModel.GetCurrentPageFirstIndex());
            _presentationModel.SetPageDown();
            Assert.AreEqual(3, _presentationModel.GetCurrentPageFirstIndex());
        }

        [TestMethod()]
        public void TestGetCurrentPageLastIndex()
        {
            _presentationModel.SetCategoryPageCountByIndex(1);
            Assert.AreEqual(3, _presentationModel.GetCurrentPageLastIndex());
            _presentationModel.SetPageDown();
            Assert.AreEqual(5, _presentationModel.GetCurrentPageLastIndex());
        }

        [TestMethod()]
        public void TestGetCurrentCategoryFirstPageLastIndex()
        {
            _presentationModel.SetCategoryPageCountByIndex(0);
            Assert.AreEqual(3, _presentationModel.GetCurrentCategoryFirstPageLastIndex());
            _presentationModel.SetCategoryPageCountByIndex(3);
            Assert.AreEqual(3, _presentationModel.GetCurrentCategoryFirstPageLastIndex());
        }

        [TestMethod()]
        public void TestSetPageUp()
        {
            _presentationModel.SetCategoryPageCountByIndex(0);
            Assert.AreEqual(1, _presentationModel.GetCurrentPage());
            _presentationModel.SetPageDown();
            Assert.AreEqual(2, _presentationModel.GetCurrentPage());
            _presentationModel.SetPageDown();
            _presentationModel.SetPageUp();
            _presentationModel.SetPageUp();
            Assert.AreEqual(1, _presentationModel.GetCurrentPage());
        }

        [TestMethod()]
        public void TestSetPageDown()
        {
            _presentationModel.SetCategoryPageCountByIndex(2);
            Assert.AreEqual(1, _presentationModel.GetCurrentPage());
            _presentationModel.SetPageDown();
            Assert.AreEqual(2, _presentationModel.GetCurrentPage());
            _presentationModel.SetPageDown();
            _presentationModel.SetPageDown();
        }

        [TestMethod()]
        public void TestGetCurrentCategoryPageIndex()
        {
            _presentationModel.SetCategoryPageCountByIndex(1);
            Assert.AreEqual(1, _presentationModel.GetCurrentCategoryPageIndex());
        }

        [TestMethod()]
        public void TestGetCurrentPageLabel()
        {
            _presentationModel.SetCategoryPageCountByIndex(0);
            Assert.AreEqual("Page：1 / 2", _presentationModel.GetCurrentPageLabel());
            _presentationModel.SetCategoryPageCountByIndex(2);
            Assert.AreEqual("Page：1 / 3", _presentationModel.GetCurrentPageLabel());
            _presentationModel.SetPageDown();
            Assert.AreEqual("Page：2 / 3", _presentationModel.GetCurrentPageLabel());
        }

        [TestMethod()]
        public void TestJudgeAddBorrowingListButtonEnable()
        {
            Assert.IsFalse(_presentationModel.IsAddListButtonEnable());
            _libraryModel.LibraryTag = 1;
            _presentationModel.JudgeAddBorrowingListButtonEnable();
            _libraryModel.AddBookTagToBorrowingList(1);
            Assert.IsTrue(_presentationModel.IsAddListButtonEnable());
            _libraryModel.AddBorrowingToBorrowedByTime(DateTime.Now);
            _presentationModel.JudgeAddBorrowingListButtonEnable();
            Assert.IsFalse(_presentationModel.IsAddListButtonEnable());
        }

        [TestMethod()]
        public void TestGetBookAmountText()
        {
            _libraryModel.LibraryTag = 1;
            Assert.AreEqual("剩餘數量：1", _presentationModel.GetBookAmountText());
            _libraryModel.LibraryTag = 0;
            Assert.AreEqual("剩餘數量：5", _presentationModel.GetBookAmountText());
        }

        [TestMethod()]
        public void TestAddCurrentBookTagToBorrowingList()
        {
            _libraryModel.LibraryTag = 2;
            _presentationModel.AddCurrentBookTagToBorrowingList();
            _libraryModel.LibraryTag = 5;
            _presentationModel.AddCurrentBookTagToBorrowingList();
            Assert.AreEqual("借書數量：2", _presentationModel.GetBorrowingBooksAmount());
        }

        [TestMethod()]
        public void TestRemoveBookFromBorrowingList()
        {
            _libraryModel.LibraryTag = 2;
            _presentationModel.AddCurrentBookTagToBorrowingList();
            Assert.AreEqual(2, _libraryModel.GetBorrowingListTagByIndex(0));
            _presentationModel.RemoveBookFromBorrowingList(0);
            Assert.AreEqual("借書數量：0", _presentationModel.GetBorrowingBooksAmount());
            _libraryModel.LibraryTag = 7;
            _presentationModel.AddCurrentBookTagToBorrowingList();
            _libraryModel.LibraryTag = 1;
            _presentationModel.AddCurrentBookTagToBorrowingList();
            _libraryModel.LibraryTag = 11;
            _libraryModel.SetBorrowingAmountByIndex(0, 2);
            Assert.AreEqual(2, _libraryModel.GetBorrowingListBookAmountByTag(7));
            _presentationModel.RemoveBookFromBorrowingList(0);
            Assert.AreEqual(1, _libraryModel.GetBorrowingBooksCount());
        }

        [TestMethod()]
        public void TestGetBorrowingBooksAmount()
        {
            Assert.AreEqual("借書數量：0", _presentationModel.GetBorrowingBooksAmount());
            _libraryModel.LibraryTag = 17;
            _presentationModel.AddCurrentBookTagToBorrowingList();
            Assert.AreEqual("借書數量：1", _presentationModel.GetBorrowingBooksAmount());
            _libraryModel.LibraryTag = 0;
            _presentationModel.AddCurrentBookTagToBorrowingList();
            _libraryModel.SetBorrowingAmountByIndex(1, 2);
            Assert.AreEqual("借書數量：3", _presentationModel.GetBorrowingBooksAmount());
        }

        [TestMethod()]
        public void TestGetBorrowingListFullText()
        {
            Assert.AreEqual("每次借書限借五本，您的借書單已滿", _presentationModel.GetBorrowingListFullText());
        }

        [TestMethod()]
        public void TestGetBorrowedSuccessText()
        {
            _libraryModel.AddBookTagToBorrowingList(0);
            _libraryModel.AddBookTagToBorrowingList(1);
            _libraryModel.SetBorrowingAmountByIndex(0, 2);
            string expectedText = "【微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書】2本、【創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡】1本\n\n已成功借出！";
            Assert.AreEqual(expectedText, _presentationModel.GetBorrowedSuccessText());
        }
    }
}