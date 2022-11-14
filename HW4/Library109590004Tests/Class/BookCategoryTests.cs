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
            _book1.ImagePath = "C://test.jpg";
            _book1.Tag = 3;
            _bookCategory = new BookCategory("6月", _book1);
        }

        // TestMethod
        [TestMethod()]
        public void TestBookCategory()
        {
            Assert.AreEqual("6月", _bookCategory.Name);
            Assert.AreEqual(0, _bookCategory.GetIndexOfBook(_book1));
        }

        // TestMethod
        [TestMethod()]
        public void TestGetBooksCount()
        {
            Assert.AreEqual(1, _bookCategory.GetBooksCount());
        }

        // TestMethod
        [TestMethod()]
        public void TestGetBooks()
        {
            Book book2 = new Book("New Bean", "8", "author", "NT");
            book2.ImagePath = "E://test.png";
            book2.Tag = 0;
            _bookCategory.AddBook(book2);
            List<Book> expectedBookList = new List<Book>() { _book1, book2 };
            CollectionAssert.AreEqual(expectedBookList, _bookCategory.GetBooks());
        }

        // TestMethod
        [TestMethod()]
        public void TestAddBook()
        {
            Book book2 = new Book("Book2", "2", "", "NTUT");
            book2.ImagePath = "D://test.jpeg";
            book2.Tag = 4;
            _bookCategory.AddBook(book2);
            Assert.AreEqual(1, _bookCategory.GetIndexOfBook(book2));
        }

        // TestMethod
        [TestMethod()]
        public void TestGetIndexOfBook()
        {
            Assert.AreEqual(0, _bookCategory.GetIndexOfBook(_book1));
        }
        // TestMethod
        [TestMethod()]
        public void TestRemoveContainBook()
        {
            Book book2 = new Book("Book2", "2", "", "NTUT");
            book2.ImagePath = "D://test.jpeg";
            book2.Tag = 0;
            Book book3 = new Book("Book3", "3", "", "NTU");
            book3.ImagePath = "D://testNTU.png";
            book3.Tag = 5;
            _bookCategory.AddBook(book2);
            _bookCategory.AddBook(book3);
            _bookCategory.RemoveContainBook(_book1);
            List<Book> books = new List<Book>() { book2, book3 };
            CollectionAssert.AreEqual(books, _bookCategory.GetBooks());
        }
    }
}