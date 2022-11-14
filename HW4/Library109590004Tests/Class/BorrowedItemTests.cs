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
    public class BorrowedItemTests
    {
        BorrowedItem _borrowedItem;
        Book _book;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _book = new Book("book1", "1", "", "NTUT");
            _book.ImagePath = "C://test.jpg";
            _book.Tag = 1;
            _borrowedItem = new BorrowedItem(_book, 3, DateTime.Parse("2022/11/13"));
        }

        // TestMethod
        [TestMethod()]
        public void BorrowedItemTest()
        {
            Assert.AreEqual(1, _borrowedItem.BookTag);
            Assert.AreEqual(3, _borrowedItem.BorrowedAmount);
        }

        // TestMethod
        [TestMethod()]
        public void TestGetBookName()
        {
            Assert.AreEqual("book1", _borrowedItem.GetBookName());
        }

        // TestMethod
        [TestMethod()]
        public void TestGetBookId()
        {
            Assert.AreEqual("1", _borrowedItem.GetBookId());
        }

        // TestMethod
        [TestMethod()]
        public void TestGetBookAuthor()
        {
            Assert.AreEqual("", _borrowedItem.GetBookAuthor());
        }

        // TestMethod
        [TestMethod()]
        public void TestGetBookPublication()
        {
            Assert.AreEqual("NTUT", _borrowedItem.GetBookPublication());
        }

        // TestMethod
        [TestMethod()]
        public void TestGetBorrowedDate()
        {
            Assert.AreEqual("2022/11/13", _borrowedItem.GetBorrowedDate());
        }

        // TestMethod
        [TestMethod()]
        public void TestGetLatestReturnDate()
        {
            Assert.AreEqual("2022/12/13", _borrowedItem.GetLatestReturnDate());
        }

        // TestMethod
        [TestMethod()]
        public void TestIsSameBook()
        {
            Book book = new Book("book1", "1", "", "NTUT");
            book.ImagePath = "C://test.jpg";
            book.Tag = 1;
            BorrowedItem borrowedItem = new BorrowedItem(book, 2, DateTime.Now);
            Assert.IsTrue(_borrowedItem.IsSameBook(borrowedItem));
            Book book2 = new Book("book2", "2", "", "NTU");
            book2.ImagePath = "C://test.png";
            book2.Tag = 2;
            BorrowedItem borrowedItem2 = new BorrowedItem(book2, 4, DateTime.Now);
            Assert.IsFalse(_borrowedItem.IsSameBook(borrowedItem2));
        }

        // TestMethod
        [TestMethod()]
        public void TestSetIncreaseBorrowedBookAmount()
        {
            Assert.AreEqual(3, _borrowedItem.BorrowedAmount);
            _borrowedItem.SetIncreaseBorrowedBookAmount(2);
            Assert.AreEqual(5, _borrowedItem.BorrowedAmount);
        }

        // TestMethod
        [TestMethod()]
        public void SetMinusBorrowedAmountTest()
        {
            _borrowedItem.SetMinusBorrowedAmount(2);
            Assert.AreEqual(1, _borrowedItem.BorrowedAmount);
        }

        // TestMethod
        [TestMethod()]
        public void GetBorrowedItemCellsTest()
        {
            string[] expectedStringArray = new string[] { "歸還", "1", "book1", 3.ToString(), "2022/11/13", "2022/12/13", "1", "", "NTUT" };
            CollectionAssert.AreEqual(expectedStringArray, _borrowedItem.GetBorrowedItemCells());
        }
    }
}