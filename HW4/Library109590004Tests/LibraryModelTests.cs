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

        // TestMethod
        [TestMethod()]
        public void SetTagTest()
        {
            _libraryModel.LibraryTag = 2;
            Assert.AreEqual(2, _libraryModel.LibraryTag);
            _libraryModel.SetLibraryTag("10");
            Assert.AreEqual(10, _libraryModel.LibraryTag);
        }

        // TestMethod
        [TestMethod()]
        public void GetBookImagePathByTagTest()
        {
            Assert.AreEqual("../../../image/4.jpg", _libraryModel.GetBookImagePathByTag(3));
        }

        // TestMethod
        [TestMethod()]
        public void GetBookByTagTest()
        {
            Book book = _libraryModel.GetBookByTag(0);
            Assert.AreEqual("964 8394:2-5 2021", book.Id);
        }

        // TestMethod
        [TestMethod()]
        public void RemoveCategoryBookTest()
        {
            Book book = new Book("零零落落", "851.486 8345:2 2022", "黃春明", "聯合文學, 2022[民111]");
            book.ImagePath = "../../../image/4.jpg";
            Assert.AreEqual(4, _libraryModel.GetCategoryBooksCountByIndex(0));
            _libraryModel.RemoveCategoryBook(book);
            Assert.AreEqual(3, _libraryModel.GetCategoryBooksCountByIndex(0));
        }

        // TestMethod
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

        // TestMethod
        [TestMethod()]
        public void GetBookTagTest()
        {
            Assert.AreEqual(2, _libraryModel.GetBookTag(0, 2));
            Assert.AreEqual(4, _libraryModel.GetBookTag(1, 0));
        }

        // TestMethod
        [TestMethod()]
        public void GetCurrentBookAmountTest()
        {
            Assert.AreEqual(0, _libraryModel.GetCurrentBookAmount());
            _libraryModel.LibraryTag = 18;
            Assert.AreEqual(6, _libraryModel.GetCurrentBookAmount());

        }

        // TestMethod
        [TestMethod()]
        public void GetBookAmountByTagTest()
        {
            Assert.AreEqual(1, _libraryModel.GetBookAmountByTag(1));
        }

        // TestMethod
        [TestMethod()]
        public void GetBookCellsTest()
        {
            string[] expectedStringArray = new string[] { "", "關於工作的9大謊言", "1", "494.01 8566 2019 c.2", "巴金漢 (Buckingham, Marcus)", "星出版, 2019[民108]" };
            CollectionAssert.AreEqual(expectedStringArray, _libraryModel.GetBookCells(17));
            _libraryModel.AddBookTagToBorrowingList(17);
            _libraryModel.SetBorrowingAmountByIndex(0, 5);
            expectedStringArray[2] = "5";
            CollectionAssert.AreEqual(expectedStringArray, _libraryModel.GetBookCells(17));
        }

        // TestMethod
        [TestMethod()]
        public void GetCategoryNameByIndexTest()
        {
            Assert.AreEqual("英文學習", _libraryModel.GetCategoryNameByIndex(2));
        }

        // TestMethod
        [TestMethod()]
        public void IsBorrowingListContainTest()
        {
            Assert.IsFalse(_libraryModel.IsBorrowingListContain(3));
            _libraryModel.AddBookTagToBorrowingList(3);
            Assert.IsTrue(_libraryModel.IsBorrowingListContain(3));
        }

        // TestMethod
        [TestMethod()]
        public void RemoveBookFromBorrowingListTest()
        {
            _libraryModel.AddBookTagToBorrowingList(2);
            _libraryModel.AddBookTagToBorrowingList(5);
            _libraryModel.AddBookTagToBorrowingList(10);
            _libraryModel.RemoveBookFromBorrowingList(1);
            Assert.IsFalse(_libraryModel.IsBorrowingListContain(5));
        }

        // TestMethod
        [TestMethod()]
        public void AddBorrowingToBorrowedTest()
        {
            Assert.AreEqual(0, _libraryModel.GetBorrowedListCount());
            _libraryModel.AddBookTagToBorrowingList(0);
            _libraryModel.AddBookTagToBorrowingList(2);
            _libraryModel.AddBookTagToBorrowingList(1);
            _libraryModel.AddBookTagToBorrowingList(3);
            _libraryModel.AddBorrowingToBorrowedByTime(DateTime.Now);
            Assert.AreEqual(4, _libraryModel.GetBorrowedListCount());
            Assert.AreEqual(2, _libraryModel.GetBorrowedListTagByIndex(1));
        }

        // TestMethod
        [TestMethod()]
        public void GetBorrowedItemAmountByTagTest()
        {
            _libraryModel.AddBookTagToBorrowingList(5);
            _libraryModel.SetBorrowingAmountByIndex(0, 2);
            _libraryModel.AddBookTagToBorrowingList(1);
            _libraryModel.AddBookTagToBorrowingList(6);
            _libraryModel.SetBorrowingAmountByIndex(2, 1);
            _libraryModel.AddBorrowingToBorrowedByTime(DateTime.Now);
            Assert.AreEqual(1, _libraryModel.GetBorrowedItemAmountByTag(1));
        }

        // TestMethod
        [TestMethod()]
        public void GetBorrowedItemCellsTest()
        {
            _libraryModel.AddBookTagToBorrowingList(4);
            _libraryModel.SetBorrowingAmountByIndex(0, 3);
            _libraryModel.AddBookTagToBorrowingList(1);
            _libraryModel.AddBorrowingToBorrowedByTime(DateTime.Parse("2022/11/12"));
            string[] expectedStringArray = new string[] { "歸還", "1", "煤氣燈操縱 : 辨識人際中最暗黑的操控術, 走出精神控制與內疚, 重建自信與自尊", "3", "2022/11/12", "2022/12/12", "177.3 8333:3 2022", "艾米.馬洛-麥柯", "麥田出版 : 家庭傳媒城邦分公司發行, 2022[民111]" };
            CollectionAssert.AreEqual(expectedStringArray, _libraryModel.GetBorrowedItemCells(0));
        }

        // TestMethod
        [TestMethod()]
        public void ReturnBookToLibraryTest()
        {
            _libraryModel.AddBookTagToBorrowingList(17);
            _libraryModel.SetBorrowingAmountByIndex(0, 2);
            _libraryModel.AddBookTagToBorrowingList(11);
            _libraryModel.SetBorrowingAmountByIndex(1, 1);
            _libraryModel.AddBorrowingToBorrowedByTime(DateTime.Now);
            Assert.AreEqual(1, _libraryModel.GetBookAmountByTag(17));
            _libraryModel.ReturnBookToLibrary(0, 1);
            Assert.AreEqual(2, _libraryModel.GetBookAmountByTag(17));
            Assert.AreEqual(4, _libraryModel.GetBookAmountByTag(11));
            _libraryModel.ReturnBookToLibrary(1, 1);
            Assert.AreEqual(5, _libraryModel.GetBookAmountByTag(11));
        }

        // TestMethod
        [TestMethod()]
        public void GetReturnBookTextTest()
        {
            _libraryModel.AddBookTagToBorrowingList(14);
            _libraryModel.SetBorrowingAmountByIndex(0, 1);
            _libraryModel.AddBookTagToBorrowingList(1);
            _libraryModel.SetBorrowingAmountByIndex(1, 3);
            _libraryModel.AddBorrowingToBorrowedByTime(DateTime.Now);
            _libraryModel.ReturnBookToLibrary(1, 2);
            Assert.AreEqual("【創造快樂大腦 : 重塑大腦快樂習慣-提升血清素, 多巴胺, 催產素, 腦內啡】已成功歸還2本", _libraryModel.GetReturnBookText());
        }

        // TestMethod
        [TestMethod()]
        public void AddBookAmountByTagTest()
        {
            Assert.AreEqual(5, _libraryModel.GetBookAmountByTag(0));
            _libraryModel.AddBookAmountByTag(0, "4");
            Assert.AreEqual(9, _libraryModel.GetBookAmountByTag(0));
        }

        // TestMethod
        [TestMethod()]
        public void NotifyModelChangedTest()
        {
            _libraryModel._modelChanged += delegate () 
            { 
                _libraryModel.LibraryTag = 1;
            };
            _libraryModel.AddBookAmountByTag(1, "5");
            Assert.AreEqual(1, _libraryModel.LibraryTag);
        }

        // TestMethod
        [TestMethod()]
        public void NotifyModelChangedManagementTest()
        {
            _libraryModel._modelChangedManagement += delegate ()
            {
                _libraryModel.LibraryTag = 18;
            };
            _libraryModel.UpdateBookDetailByTag(3, new Book("Hello", "0", "Adele", "Rock"), "Music");
            Assert.AreEqual(18, _libraryModel.LibraryTag);
        }

        // TestMethod
        [TestMethod()]
        public void NotifyModelChangedDeleteRowTest()
        {
            _libraryModel._modelChangedDeleteRow += delegate ()
            {
                _libraryModel.LibraryTag = 0;
            };
            _libraryModel.AddBookTagToBorrowingList(2);
            _libraryModel.AddBorrowingToBorrowedByTime(DateTime.Now);
            _libraryModel.ReturnBookToLibrary(0, 1);
            Assert.AreEqual(0, _libraryModel.LibraryTag);
        }
    }
}