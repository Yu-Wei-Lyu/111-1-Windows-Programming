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
    public class BookCategoryTests
    {
        BookCategory _bookCategory;
        Book _book1;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _book1 = new Book("book1", "1", "", "");
            _book1.SetImagePath("C://test.jpg");
            _bookCategory = new BookCategory("6月", _book1);
        }

        // TestMethod
        [TestMethod()]
        public void BookCategoryTest()
        {
            Assert.AreEqual("6月", _bookCategory.Name);
            Assert.AreEqual(0, _bookCategory.GetIndexOfBook(_book1));
        }

        // TestMethod
        [TestMethod()]
        public void GetBooksCountTest()
        {
            Assert.AreEqual(1, _bookCategory.GetBooksCount());
        }

        // TestMethod
        [TestMethod()]
        public void AddBookTest()
        {
            Book book2 = new Book("Book2", "2", "", "NTUT");
            book2.SetImagePath("D://test.jpeg");
            _bookCategory.AddBook(book2);
            Assert.AreEqual(1, _bookCategory.GetIndexOfBook(book2));
        }

        // TestMethod
        [TestMethod()]
        public void RemoveContainBookTest()
        {
            Book book2 = new Book("Book2", "2", "", "NTUT");
            book2.SetImagePath("D://test.jpeg");
            Book book3 = new Book("Book3", "3", "", "NTU");
            book3.SetImagePath("D://testNTU.png");
            _bookCategory.AddBook(book2);
            _bookCategory.AddBook(book3);
            _bookCategory.RemoveContainBook(_book1);
            List<Book> books = new List<Book>() { book2, book3 };
            CollectionAssert.AreEqual(books, _bookCategory.GetBooks());
        }
    }
}