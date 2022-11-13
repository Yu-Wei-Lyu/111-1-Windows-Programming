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
        private const string DEFAULT_RETURN_AMOUNT = "1";
        private const string RETURN_BOOK = "歸還";
        private const string DATE_FORMAT = "{0:yyyy/MM/dd}";
        private const int THIRTY_DAYS = 30;
        BorrowedItem _borrowedItem;
        Book _book;
        DateTime _borrowedDateTime;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _book = new Book("book1", "1", "", "NTUT");
            _book.ImagePath = "C://test.jpg";
            _borrowedItem = new BorrowedItem(_book, 1, 3, DateTime.Now);
            _borrowedDateTime = DateTime.Now;
        }

        // TestMethod
        [TestMethod()]
        public void BorrowedItemTest()
        {
            Assert.AreEqual(_book.Name, _borrowedItem.GetBookName());
            Assert.AreEqual(_book.Id, _borrowedItem.GetBookId());
            Assert.AreEqual(_book.Author, _borrowedItem.GetBookAuthor());
            Assert.AreEqual(_book.Publication, _borrowedItem.GetBookPublication());
            Assert.AreEqual(1, _borrowedItem.BookTag);
            Assert.AreEqual(3, _borrowedItem.BorrowedAmount);
            string borrowedDateTimeText = string.Format(DATE_FORMAT, _borrowedDateTime);
            Assert.AreEqual(borrowedDateTimeText, _borrowedItem.GetBorrowedDate());
            DateTime returnDateTime = _borrowedDateTime.AddDays(THIRTY_DAYS);
            string returnDateTimeText = string.Format(DATE_FORMAT, returnDateTime);
            Assert.AreEqual(returnDateTimeText, _borrowedItem.GetLatestReturnDate());
        }

        // TestMethod
        [TestMethod()]
        public void IsSameBookAddAmountTest()
        {
            Book book = new Book("book1", "1", "", "NTUT");
            book.ImagePath = "C://test.jpg";
            BorrowedItem borrowedItem = new BorrowedItem(_book, 1, 2, DateTime.Now);
            Assert.IsTrue(_borrowedItem.IsSameBook(borrowedItem));
            Book book2 = new Book("book2", "2", "", "NTU");
            book2.ImagePath = "C://test.png";
            BorrowedItem borrowedItem2 = new BorrowedItem(_book, 2, 2, DateTime.Now);
            Assert.IsFalse(_borrowedItem.IsSameBook(borrowedItem2));
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
            string borrowedDateTime = string.Format(DATE_FORMAT, _borrowedDateTime);
            string returnDateTime = string.Format(DATE_FORMAT, _borrowedDateTime.AddDays(THIRTY_DAYS));
            string[] expectedStringArray = new string[] { RETURN_BOOK, DEFAULT_RETURN_AMOUNT, "book1", 3.ToString(), borrowedDateTime, returnDateTime, "1", "", "NTUT" };
            CollectionAssert.AreEqual(expectedStringArray, _borrowedItem.GetBorrowedItemCells());
        }

        // TestMethod
        [TestMethod()]
        public void AddBorrowedBookAmountTest()
        {
            Assert.AreEqual(3, _borrowedItem.BorrowedAmount);
            _borrowedItem.SetIncreaseBorrowedBookAmount(2);
            Assert.AreEqual(5, _borrowedItem.BorrowedAmount);
        }
    }
}