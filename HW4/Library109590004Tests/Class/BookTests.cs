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
            _book = new Book("Laplus", "SA-552", "Lala-Plus", "Hololive");
            _book.ImagePath = "C://user//Laplus.jpg";
            _book.Tag = 0;
        }

        // TestMethod
        [TestMethod()]
        public void TestBook()
        {
            Assert.AreEqual("Laplus", _book.Name);
            Assert.AreEqual("SA-552", _book.Id);
            Assert.AreEqual("Lala-Plus", _book.Author);
            Assert.AreEqual("Hololive", _book.Publication);
            Assert.AreEqual("C://user//Laplus.jpg", _book.ImagePath);
            Assert.AreEqual(0, _book.Tag);
        }

        // TestMethod
        [TestMethod()]
        public void TestIsSameBook()
        {
            Book book = new Book("Laplus", "SA-552", "Lala-Plus", "Hololive");
            book.ImagePath = "C://user//Laplus.jpg";
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
            book2.ImagePath = "D://test.jpg";
            _book.UpdateBookDetail(book2);
            Assert.IsTrue(_book.IsSameBook(book2));
        }
    }
}