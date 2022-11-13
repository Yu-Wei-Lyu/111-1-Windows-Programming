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
    public class BookItemTests
    {
        BookItem _bookItem;
        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _bookItem = new BookItem(5);
        }

        // TestMethod
        [TestMethod()]
        public void TestBookItemAmount()
        {
            Assert.AreEqual(5, _bookItem.Amount);
            _bookItem.Amount = 2;
            Assert.AreEqual(2, _bookItem.Amount);
        }
    }
}