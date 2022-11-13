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
    public class BookTests
    {
        Book _book;
        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _book = new Book("", "", "", "");
            _book.ImagePath = "C://test.jpg";
            _book.Tag = 0;
        }

        // TestMethod
        [TestMethod()]
        public void TestIsSameBook()
        {
            Book book = new Book("", "", "", "");
            book.ImagePath = "C://test.jpg";
            book.Tag = 0;
            Book book2 = new Book("Book2", "", "", "");
            book2.ImagePath = "D://test.jpg";
            book2.Tag = 2;
            Assert.IsTrue(_book.IsSameBook(book));
            Assert.IsFalse(_book.IsSameBook(book2));
        }

        // TestMethod
        [TestMethod()]
        public void TestUpdateBookDetail()
        {
            Book book2 = new Book("Book2", "", "", "");
            book2.ImagePath  = "D://test.jpg";
            _book.UpdateBookDetail(book2);
            Assert.IsTrue(_book.IsSameBook(book2));
        }
    }
}