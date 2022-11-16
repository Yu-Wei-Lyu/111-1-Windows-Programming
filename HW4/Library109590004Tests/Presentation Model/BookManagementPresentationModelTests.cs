using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library109590004;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Library109590004.Tests
{
    [TestClass()]
    public class BookManagementPresentationModelTests
    {
        private const string TEST_FILE_PATH = "hw4_books_source.txt";
        LibraryModel _libraryModel;
        BookManagementPresentationModel _presentationModel;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _libraryModel = new LibraryModel(TEST_FILE_PATH);
            _presentationModel = new BookManagementPresentationModel(_libraryModel);
            _presentationModel.UpdateLibraryBooks();
        }

        // TestMethod
        [TestMethod()]
        public void TestBookManagementPresentationModel()
        {
            Assert.IsFalse(_presentationModel.IsApplyChanged);
            Assert.IsFalse(_presentationModel.IsBrowse);
            Assert.IsFalse(_presentationModel.IsGroupBoxEnabled);
            Assert.AreEqual("", _presentationModel.NameText);
            Assert.AreEqual("", _presentationModel.IdText);
            Assert.AreEqual("", _presentationModel.AuthorText);
            Assert.AreEqual("", _presentationModel.PublicationText);
            Assert.AreEqual("", _presentationModel.CategoryText);
            Assert.AreEqual("", _presentationModel.ImagePathText);
        }

        // TestMethod
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            _presentationModel.NotifyPropertyChanged("test");
            Assert.AreEqual(-1, _libraryModel.LibraryTag);
            _presentationModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                _libraryModel.LibraryTag = 8;
            };
            _presentationModel.NotifyPropertyChanged("test");
            Assert.AreEqual(8, _libraryModel.LibraryTag);
        }

        // TestMethod
        [TestMethod()]
        public void TestUpdateLibraryBooks()
        {
            _presentationModel.UpdateLibraryBooks();
            Assert.AreEqual("關於工作的9大謊言", _presentationModel.GetBookNameByTag(17));
        }

        // TestMethod
        [TestMethod()]
        public void TestGetBooksCount()
        {
            Assert.AreEqual(20, _presentationModel.GetBooksCount());
        }

        // TestMethod
        [TestMethod()]
        public void TestGetBookNameByTag()
        {
            Assert.AreEqual("托福應考勝經 : 核心單字", _presentationModel.GetBookNameByTag(15));
        }

        // TestMethod
        [TestMethod()]
        public void TestGetBookIdByTag()
        {
            Assert.AreEqual("805.179 835 2005", _presentationModel.GetBookIdByTag(13));
        }

        // TestMethod
        [TestMethod()]
        public void TestGetBookAuthorByTag()
        {
            Assert.AreEqual("國際語言中心委員會", _presentationModel.GetBookAuthorByTag(12));
        }

        // TestMethod
        [TestMethod()]
        public void TestGetBookCategoryByTag()
        {
            Assert.AreEqual("4月暢銷書", _presentationModel.GetBookCategoryByTag(7));
        }

        // TestMethod
        [TestMethod()]
        public void TestGetBookPublicationByTag()
        {
            Assert.AreEqual("原點出版 : 大雁發行, 2021[民110]", _presentationModel.GetBookPublicationByTag(0));
        }

        // TestMethod
        [TestMethod()]
        public void TestGetBookImagePathByTag()
        {
            Assert.AreEqual("../../../image/10.jpg", _presentationModel.GetBookImagePathByTag(9));
        }

        // TestMethod
        [TestMethod()]
        public void TestGetBookByTag()
        {
            Book expectedBook = new Book("零零落落", "851.486 8345:2 2022", "黃春明", "聯合文學, 2022[民111]");
            expectedBook.ImagePath = "../../../image/4.jpg";
            expectedBook.Tag = 3;
            Assert.IsTrue(expectedBook.IsSameBook(_presentationModel.GetBookByTag(3)));
        }

        // TestMethod
        [TestMethod()]
        public void TestSetSelectedTag()
        {
            _presentationModel.SetSelectedTag(5);
            Assert.AreEqual("494.35 8356:2 2022", _presentationModel.IdText);
        }

        // TestMethod
        [TestMethod()]
        public void TestJudgeIsApplyChanged()
        {
            _presentationModel.SetSelectedTag(0);
            _presentationModel.JudgeIsApplyChanged();
            Assert.IsFalse(_presentationModel.IsApplyChanged);
            _presentationModel.NameText = "modified";
            _presentationModel.JudgeIsApplyChanged();
            Assert.IsTrue(_presentationModel.IsApplyChanged);
            _presentationModel.IdText = "";
            _presentationModel.JudgeIsApplyChanged();
            Assert.IsFalse(_presentationModel.IsApplyChanged);
        }

        // TestMethod
        [TestMethod()]
        public void TestGetCategoriesNameList()
        {
            string[] exceptedStringArray = { "6月暢銷書", "4月暢銷書", "英文學習", "職場必讀" };
            CollectionAssert.AreEqual(exceptedStringArray, _presentationModel.GetCategoriesNameList());
        }

        // TestMethod
        [TestMethod()]
        public void TestGetCategoryNameByIndex()
        {
            string[] exceptedStringArray = { "6月暢銷書", "4月暢銷書", "英文學習", "職場必讀" };
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(exceptedStringArray[i], _presentationModel.GetCategoryNameByIndex(i));
            }
        }

        // TestMethod
        [TestMethod()]
        public void TestUpdateBookDetail()
        {
            Assert.AreEqual("964 8394:2-5 2021", _presentationModel.GetBookIdByTag(0));
            Assert.AreEqual("4月暢銷書", _presentationModel.GetBookCategoryByTag(5));
            _presentationModel.UpdateLibraryBooks();
            _presentationModel.SetSelectedTag(5);
            Assert.AreEqual("4月暢銷書", _presentationModel.GetBookCategoryByTag(5));
            _presentationModel.IdText = "職場英文";
            _presentationModel.UpdateBookDetail();
            _presentationModel.UpdateLibraryBooks();
            Assert.AreEqual("職場英文", _presentationModel.GetBookIdByTag(5));
        }
    }
}