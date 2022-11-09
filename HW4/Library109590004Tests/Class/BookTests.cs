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
            _book.SetImagePath("C://test.jpg");
        }
        // TestMethod
        [TestMethod()]
        public void BookTest()
        {
            Assert.AreEqual("", _book.Name);
            Assert.AreEqual("", _book.Id);
            Assert.AreEqual("", _book.Author);
            Assert.AreEqual("", _book.Publication);
            Assert.AreEqual("C://test.jpg", _book.GetImagePath());
        }

        // TestMethod
        [TestMethod()]
        public void IsSameBookTest()
        {
            Book book = new Book("", "", "", "");
            book.SetImagePath("C://test.jpg");
            Book book2 = new Book("Book2", "", "", "");
            book2.SetImagePath("D://test.jpg");
            Assert.IsTrue(_book.IsSameBook(book));
            Assert.IsFalse(_book.IsSameBook(book2));
        }

        // TestMethod
        [TestMethod()]
        public void UpdateBookDetailTest()
        {
            Book book2 = new Book("Book2", "", "", "");
            book2.SetImagePath("D://test.jpg");
            _book.UpdateBookDetail(book2);
            Assert.IsTrue(_book.IsSameBook(book2));
        }
    }
}