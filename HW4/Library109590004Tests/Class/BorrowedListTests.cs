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
    public class BorrowedListTests
    {
        BorrowedList _borrowedList;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _borrowedList = new BorrowedList();
        }

        [TestMethod()]
        public void TestAdd()
        {
            Book book = new Book("a", "b", "c", "d");
            book.ImagePath = "E://ABC.jpg";
            book.Tag = 0;
            BorrowedItem borrowedItem = new BorrowedItem(book, 2, DateTime.Parse("2022/11/14"));
            _borrowedList.Add(borrowedItem);
            Assert.AreEqual(2, _borrowedList.GetBorrowedItemAmountByTag(0));
            BorrowedItem borrowedItem2 = new BorrowedItem(book, 1, DateTime.Parse("2022/11/14"));
            _borrowedList.Add(borrowedItem2);
            Assert.AreEqual(3, _borrowedList.GetBorrowedItemAmountByTag(0));
        }

        [TestMethod()]
        public void TestGetBorrowedItem()
        {
            Book book = new Book("a", "b", "c", "d");
            book.ImagePath = "E://ABC.jpg";
            book.Tag = 0;
            BorrowedItem borrowedItem = new BorrowedItem(book, 2, DateTime.Parse("2022/11/14"));
            _borrowedList.Add(borrowedItem);
            BorrowedItem borrowedItem2 = _borrowedList.GetBorrowedItem(0);
            Assert.IsTrue(_borrowedList.IsSameBookTag(borrowedItem, borrowedItem2));
        }

        [TestMethod()]
        public void TestIsSameBookTag()
        {
            Book book = new Book("Same As Before", "YFG-52 2011", "Mark", "NoWhere");
            book.ImagePath = "Desktop//SAB.jpg";
            book.Tag = 2;
            BorrowedItem borrowedItem = new BorrowedItem(book, 2, DateTime.Parse("2022/11/14"));
            _borrowedList.Add(borrowedItem);
            BorrowedItem borrowedItem2 = _borrowedList.GetBorrowedItem(0);
            Assert.IsTrue(_borrowedList.IsSameBookTag(borrowedItem, borrowedItem2));
        }

        [TestMethod()]
        public void TestGetBorrowedAmount()
        {
            Book book = new Book("Saore", "YFG-53 2012", "Mark", "NoWhere");
            book.ImagePath = "C://temp.jpg";
            book.Tag = 5;
            BorrowedItem borrowedItem = new BorrowedItem(book, 4, DateTime.Parse("2022/11/15"));
            _borrowedList.Add(borrowedItem);
            Assert.AreEqual(4, _borrowedList.GetBorrowedAmount(borrowedItem));
        }

        [TestMethod()]
        public void TestReduceBorrowedAmountByIndex()
        {
            Book book = new Book("qds", "Y8-22", "Alan", "Rock");
            book.ImagePath = "C://QDS.png";
            book.Tag = 2;
            BorrowedItem borrowedItem = new BorrowedItem(book, 10, DateTime.Parse("2021/1/15"));
            _borrowedList.Add(borrowedItem);
            _borrowedList.ReduceBorrowedAmountByIndex(0, 2);
            Assert.AreEqual(8, _borrowedList.GetBorrowedAmount(borrowedItem));
        }

        [TestMethod()]
        public void TestRemove()
        {
            Book book = new Book("qds", "Y8-22", "Alan", "Rock");
            book.ImagePath = "C://QDS.png";
            book.Tag = 5;
            Book book2 = new Book("qds2", "Y8-23", "Alan", "Rock");
            book2.ImagePath = "C://QDSv2.png";
            book2.Tag = 6;
            BorrowedItem borrowedItem = new BorrowedItem(book, 10, DateTime.Parse("2021/1/15"));
            BorrowedItem borrowedItem2 = new BorrowedItem(book2, 7, DateTime.Parse("2021/1/16"));
            _borrowedList.Add(borrowedItem);
            _borrowedList.Add(borrowedItem2);
            Assert.IsTrue(_borrowedList.IsSameBookTag(borrowedItem, _borrowedList.GetBorrowedItem(0)));
            _borrowedList.Remove(0);
            Assert.IsFalse(_borrowedList.IsSameBookTag(borrowedItem, _borrowedList.GetBorrowedItem(0)));
        }

        [TestMethod()]
        public void TestGetBorrowedItemCells()
        {
            string[] expectedStringArray = new string[] { "歸還", "1", "book1", 3.ToString(), "2022/11/13", "2022/12/13", "1", "", "NTUT" };
            Book book = new Book("book1", "1", "", "NTUT");
            book.ImagePath = "C://test.jpg";
            book.Tag = 1;
            BorrowedItem borrowedItem = new BorrowedItem(book, 3, DateTime.Parse("2022/11/13"));
            _borrowedList.Add(borrowedItem);
            CollectionAssert.AreEqual(expectedStringArray, _borrowedList.GetBorrowedItemCells(0));
        }

        [TestMethod()]
        public void TestGetBorrowedDate()
        {
            Book book = new Book("Same As Before", "YFG-52 2011", "Mark", "NoWhere");
            book.ImagePath = "Desktop//SAB.jpg";
            book.Tag = 1;
            BorrowedItem borrowedItem = new BorrowedItem(book, 2, DateTime.Parse("2022/11/01"));
            _borrowedList.Add(borrowedItem);
            Assert.AreEqual("2022/11/01", _borrowedList.GetBorrowedDate(0));
        }

        [TestMethod()]
        public void TestGetLatestReturnDate()
        {
            Book book = new Book("長作一康方年", "adw22", "女無到", "財自人我狀票必媽可女大個");
            book.ImagePath = "C://Users//User//Documents//長作一康方年.jpg";
            book.Tag = 5;
            BorrowedItem borrowedItem = new BorrowedItem(book, 2, DateTime.Parse("2022/11/14"));
            _borrowedList.Add(borrowedItem);
            Assert.AreEqual("2022/12/14", _borrowedList.GetLatestReturnDate(0));
        }

        [TestMethod()]
        public void TestGetBorrowedItemAmountByTag()
        {
            Book book = new Book("book1", "1", "", "NTUT");
            book.ImagePath = "C://test.jpg";
            book.Tag = 1;
            BorrowedItem borrowedItem = new BorrowedItem(book, 3, DateTime.Parse("2022/1/13"));
            _borrowedList.Add(borrowedItem);
            Assert.AreEqual(3, _borrowedList.GetBorrowedItemAmountByTag(1));
        }

        [TestMethod()]
        public void TestGetBorrowedListTagByIndex()
        {
            Book book = new Book("book1", "1", "", "NTUT");
            book.ImagePath = "C://test.jpg";
            book.Tag = 18;
            BorrowedItem borrowedItem = new BorrowedItem(book, 1, DateTime.Parse("2022/5/23"));
            _borrowedList.Add(borrowedItem);
            Assert.AreEqual(18, _borrowedList.GetBorrowedListTagByIndex(0));
        }
    }
}