﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void IsBorrowingListContainTest()
        {
            Assert.IsFalse(_libraryModel.IsBorrowingListContain(3));
            _libraryModel.AddBookTagToBorrowingList(3);
            Assert.IsTrue(_libraryModel.IsBorrowingListContain(3));
        }

        [TestMethod()]
        public void RemoveBookFromBorrowingListTest()
        {
            _libraryModel.AddBookTagToBorrowingList(2);
            _libraryModel.AddBookTagToBorrowingList(5);
            _libraryModel.AddBookTagToBorrowingList(10);
            _libraryModel.RemoveBookFromBorrowingList(1);
            Assert.IsFalse(_libraryModel.IsBorrowingListContain(5));
        }

        [TestMethod()]
        public void AddBorrowingToBorrowedTest()
        {
            Assert.AreEqual(0, _libraryModel.GetBorrowedListCount());
            _libraryModel.AddBookTagToBorrowingList(0);
            _libraryModel.AddBookTagToBorrowingList(2);
            _libraryModel.AddBookTagToBorrowingList(1);
            _libraryModel.AddBookTagToBorrowingList(3);
            _libraryModel.AddBorrowingToBorrowed();
            Assert.AreEqual(4, _libraryModel.GetBorrowedListCount());
            Assert.AreEqual(2, _libraryModel.GetBorrowedListTagByIndex(1));
        }

        [TestMethod()]
        public void GetBorrowedItemAmountByTagTest()
        {
            _libraryModel.AddBookTagToBorrowingList(5);
            _libraryModel.SetBorrowingAmountByIndex(0, 2);
            _libraryModel.AddBookTagToBorrowingList(1);
            _libraryModel.AddBookTagToBorrowingList(6);
            _libraryModel.SetBorrowingAmountByIndex(2, 1);
            _libraryModel.AddBorrowingToBorrowed();
            Assert.AreEqual(1, _libraryModel.GetBorrowedItemAmountByTag(1));
        }

        [TestMethod()]
        public void GetBorrowedItemCellsTest()
        {
            _libraryModel.AddBookTagToBorrowingList(4);
            _libraryModel.SetBorrowingAmountByIndex(0, 6);
            _libraryModel.AddBookTagToBorrowingList(1);
            _libraryModel.AddBorrowingToBorrowed();
            string[] expectedStringArray = new string[] { "歸還", "1", "煤氣燈操縱 : 辨識人際中最暗黑的操控術, 走出精神控制與內疚, 重建自信與自尊", "6"};
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