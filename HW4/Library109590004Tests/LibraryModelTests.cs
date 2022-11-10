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
    public class LibraryModelTests
    {
        private const string TEST_FILE_PATH = "hw4_books_source.txt";
        LibraryModel _libraryModel;
        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _libraryModel = new LibraryModel(TEST_FILE_PATH);
        }
        [TestMethod()]
        public void NotifyObserverTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LibraryModelTest()
        {
            Assert.AreEqual(-1, _libraryModel.Tag);
            Assert.AreEqual(20, _libraryModel.GetBooksCount());
            Assert.AreEqual(0, _libraryModel.GetCurrentBookAmount());
            Assert.AreEqual(4, _libraryModel.GetCategoryCount());
            Assert.AreEqual(0, _libraryModel.GetBorrowingBooksCount());
            Assert.AreEqual(0, _libraryModel.GetBorrowedListCount());
        }

        [TestMethod()]
        public void SetTagTest()
        {
            _libraryModel.Tag = 2;
            Assert.AreEqual(2, _libraryModel.Tag);
            _libraryModel.SetTag("10");
            Assert.AreEqual(10, _libraryModel.Tag);
        }

        [TestMethod()]
        public void GetBookImagePathByTagTest()
        {
            Assert.AreEqual("../../../image/4.jpg", _libraryModel.GetBookImagePathByTag(3));
        }

        [TestMethod()]
        public void GetBookByTagTest()
        {
            Book book = _libraryModel.GetBookByTag(0);
            Assert.AreEqual("964 8394:2-5 2021", book.Id);
        }

        [TestMethod()]
        public void RemoveCategoryBookTest()
        {
            Book book = new Book("零零落落", "851.486 8345:2 2022", "黃春明", "聯合文學, 2022[民111]");
            book.SetImagePath("../../../image/4.jpg");
            //Assert.AreEqual(book, _libraryModel.GetBookByTag(3));
            Assert.AreEqual(5, _libraryModel.GetCategoryBooksCountByIndex(1));
            _libraryModel.RemoveCategoryBook(book);
            
        }

        [TestMethod()]
        public void UpdateBookDetailByTagTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetBookTagTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCurrentBookAmountTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetBookAmountByTagTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetBookCellsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCategoryCountTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCategoryBooksCountByIndexTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCategoryNameByIndexTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCategoryNameByBookTagTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetBooksCountTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddBookTagToBorrowingListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetBorrowingAmountByIndexTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IsBorrowingListContainTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveBookFromBorrowingListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetBorrowingBooksCountTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetBorrowingListTagByIndexTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetBorrowingListBookAmountByTagTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetBorrowingListCountTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddBorrowingToBorrowedTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetBorrowedListTagByIndexTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetBorrowedItemAmountByTagTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetBorrowedListCountTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetBorrowedItemCellsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReturnBookToLibraryTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetReturnBookTextTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddBookAmountByTagTest()
        {
            Assert.Fail();
        }
    }
}