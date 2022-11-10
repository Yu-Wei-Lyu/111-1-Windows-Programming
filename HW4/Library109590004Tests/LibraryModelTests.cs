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
            Assert.AreEqual(4, _libraryModel.GetCategoryBooksCountByIndex(0));
            _libraryModel.RemoveCategoryBook(book);
            Assert.AreEqual(3, _libraryModel.GetCategoryBooksCountByIndex(0));
        }

        [TestMethod()]
        public void UpdateBookDetailByTagTest()
        {
            int bookTag = 19;
            _libraryModel.UpdateBookDetailByTag(bookTag, new Book("New Book", "109590004", "Lyu Yu Wei", "NTUT"), "6月暢銷書");
            Assert.AreEqual("New Book", _libraryModel.GetBookByTag(bookTag).Name);
            Assert.AreEqual("6月暢銷書", _libraryModel.GetCategoryNameByBookTag(bookTag));
            bookTag = 0;
            _libraryModel.UpdateBookDetailByTag(bookTag, new Book("New Book", "109590004", "Lyu Yu Wei", "NTUT"), "6月暢銷書");
            Assert.AreEqual("6月暢銷書", _libraryModel.GetCategoryNameByBookTag(bookTag));
        }

        [TestMethod()]
        public void GetBookTagTest()
        {
            Assert.AreEqual(2, _libraryModel.GetBookTag(0, 2));
            Assert.AreEqual(4, _libraryModel.GetBookTag(1, 0));
        }

        [TestMethod()]
        public void GetCurrentBookAmountTest()
        {
            Assert.AreEqual(0, _libraryModel.GetCurrentBookAmount());
            _libraryModel.Tag = 18;
            Assert.AreEqual(6, _libraryModel.GetCurrentBookAmount());
        
        }

        [TestMethod()]
        public void GetBookAmountByTagTest()
        {
            Assert.AreEqual(1, _libraryModel.GetBookAmountByTag(1));
        }

        [TestMethod()]
        public void GetBookCellsTest()
        {
            string[] expectedStringArray = new string[] { "", "關於工作的9大謊言", "1" , "494.01 8566 2019 c.2", "巴金漢 (Buckingham, Marcus)", "星出版, 2019[民108]" };
            CollectionAssert.AreEqual(expectedStringArray, _libraryModel.GetBookCells(17));
            _libraryModel.AddBookTagToBorrowingList(17);
            _libraryModel.SetBorrowingAmountByIndex(0, 5);
            expectedStringArray[2] = "5";
            CollectionAssert.AreEqual(expectedStringArray, _libraryModel.GetBookCells(17));
        }

        [TestMethod()]
        public void GetCategoryNameByIndexTest()
        {
            Assert.AreEqual("英文學習", _libraryModel.GetCategoryNameByIndex(2));
        }

        [TestMethod()]
        public void GetCategoryNameByBookTagTest()
        {
            Assert.AreEqual("", _libraryModel.GetCategoryNameByBookTag(-1));
            Assert.AreEqual("", _libraryModel.GetCategoryNameByBookTag(20));
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