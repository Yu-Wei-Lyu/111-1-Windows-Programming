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
    public class BackPackPresentationModelTests
    {
        private const string TEST_FILE_PATH = "hw4_books_source.txt";
        LibraryModel _libraryModel;
        BackPackPresentationModel _presentationModel;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _libraryModel = new LibraryModel(TEST_FILE_PATH);
            _presentationModel = new BackPackPresentationModel(_libraryModel);
        }

        [TestMethod()]
        public void TestNotifyObserver()
        {
            _presentationModel.SetMessageBoxResultAndEditingAmount(3, "No observer", "Nothing happened");
            Assert.AreEqual(-1, _libraryModel.LibraryTag);
            _presentationModel._modelChanged += delegate ()
            {
                _libraryModel.LibraryTag = 2;
            };
            _presentationModel.SetMessageBoxResultAndEditingAmount(2, "Just test", "Test content");
            Assert.AreEqual(2, _libraryModel.LibraryTag);
        }

        [TestMethod()]
        public void TestSetEditSelectBookTag()
        {
            _presentationModel.SetEditSelectBookTag(2);
            Assert.AreEqual(2, _presentationModel.GetEditSelectBookTag());
        }

        [TestMethod()]
        public void TestGetEditSelectBookTag()
        {
            Assert.AreEqual(-1, _presentationModel.GetEditSelectBookTag());
            _presentationModel.SetEditSelectBookTag(17);
            Assert.AreEqual(17, _presentationModel.GetEditSelectBookTag());
        }

        [TestMethod()]
        public void TestSetEditingAmount()
        {
            Assert.AreEqual("-1", _presentationModel.GetCurrentAmount());
            _presentationModel.SetEditingAmount("12");
            Assert.AreEqual("12", _presentationModel.GetCurrentAmount());
        }

        [TestMethod()]
        public void TestGetCurrentAmount()
        {
            Assert.AreEqual("-1", _presentationModel.GetCurrentAmount());
            _presentationModel.SetEditingAmount("1");
            Assert.AreEqual("1", _presentationModel.GetCurrentAmount());
        }

        [TestMethod()]
        public void TestGetBorrowedItemAmountByTag()
        {
            _libraryModel.AddBookTagToBorrowingList(2);
            _libraryModel.AddBookTagToBorrowingList(3);
            _libraryModel.SetBorrowingAmountByIndex(1, 2);
            _libraryModel.AddBorrowingToBorrowedByTime(DateTime.Now);
            Assert.AreEqual(2, _presentationModel.GetBorrowedItemAmountByTag(3));
            Assert.AreEqual(1, _presentationModel.GetBorrowedItemAmountByTag(2));
            Assert.AreEqual(0, _presentationModel.GetBorrowedItemAmountByTag(15));
        }

        [TestMethod()]
        public void TestGetErrorMessageBoxTitle()
        {
            Assert.AreEqual("", _presentationModel.GetErrorMessageBoxTitle());
            _presentationModel.SetMessageBoxResultAndEditingAmount(7, "This is title of message", "Nothing");
            Assert.AreEqual("This is title of message", _presentationModel.GetErrorMessageBoxTitle());
        }

        [TestMethod()]
        public void TestGetErrorMessageBoxText()
        {
            Assert.AreEqual("", _presentationModel.GetErrorMessageBoxText());
            _presentationModel.SetMessageBoxResultAndEditingAmount(2, "Title of message", "Text content");
            Assert.AreEqual("Text content", _presentationModel.GetErrorMessageBoxText());
        }

        [TestMethod()]
        public void TestSetMessageBoxResultAndEditingAmount()
        {
            _presentationModel.SetMessageBoxResultAndEditingAmount(10, "Tilte of news", "News content");
            Assert.AreEqual("10", _presentationModel.GetCurrentAmount());
            Assert.AreEqual("Tilte of news", _presentationModel.GetErrorMessageBoxTitle());
            Assert.AreEqual("News content", _presentationModel.GetErrorMessageBoxText());
        }

        [TestMethod()]
        public void TestJudgeEditing()
        {
            _libraryModel.AddBookTagToBorrowingList(2);
            _libraryModel.AddBookTagToBorrowingList(3);
            _libraryModel.SetBorrowingAmountByIndex(1, 2);
            _libraryModel.AddBorrowingToBorrowedByTime(DateTime.Now);
            _presentationModel.SetEditingAmount("0");
            _presentationModel.SetEditSelectBookTag(2);
            _presentationModel.JudgeEditing();
            Assert.AreEqual("1", _presentationModel.GetCurrentAmount());
            Assert.AreEqual("還書錯誤", _presentationModel.GetErrorMessageBoxTitle());
            Assert.AreEqual("您至少要歸還1本書", _presentationModel.GetErrorMessageBoxText());
            _presentationModel.SetEditingAmount("3");
            _presentationModel.SetEditSelectBookTag(3);
            _presentationModel.JudgeEditing();
            Assert.AreEqual("2", _presentationModel.GetCurrentAmount());
            Assert.AreEqual("還書錯誤", _presentationModel.GetErrorMessageBoxTitle());
            Assert.AreEqual("還書數量不能超過已借數量", _presentationModel.GetErrorMessageBoxText());
        }
    }
}