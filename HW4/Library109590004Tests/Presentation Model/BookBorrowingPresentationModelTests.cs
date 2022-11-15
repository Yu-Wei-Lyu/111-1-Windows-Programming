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
            _libraryModel.AddBookTagToBorrowingList(5);
            _libraryModel.AddBookTagToBorrowingList(8);
            _libraryModel.SetBorrowingAmountByIndex(0, 2);
            _libraryModel.SetBorrowingAmountByIndex(1, 2);
            _libraryModel.AddBookTagToBorrowingList(0);
            _presentationModel.JudgeEditing();
            Assert.AreEqual("2", _presentationModel.GetCurrentAmount());
            Assert.AreEqual("借書違規", _presentationModel.GetErrorMessageBoxTitle());
            Assert.AreEqual("同本書一次限借2本", _presentationModel.GetErrorMessageBoxText());
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
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetTag()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetBookButtonLocation()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetBookButtonSize()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetBookDetail()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestIsBorrowingListFull()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetBookAmount()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetCurrentBookAmount()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestIsBorrowingButtonEnable()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestIsAddListButtonEnable()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestIsUpButtonEnable()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestIsDownButtonEnable()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestSetCategoryPageCountByIndex()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetCategoryBooksCountByIndex()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetCurrentCategoryPageCount()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetCurrentPage()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetCurrentPageFirstIndex()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetCurrentPageLastIndex()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetCurrentCategoryFirstPageLastIndex()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestSetPageUp()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestSetPageDown()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetCurrentCategoryPageIndex()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetCurrentPageLabel()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestJudgeAddBorrowingListButtonEnable()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetBookAmountText()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestAddBookTagToBorrowingList()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestRemoveBookFromBorrowingList()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetBorrowingBooksAmount()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetBorrowingListFullText()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetBorrowedSuccessText()
        {
            Assert.Fail();
        }
    }
}