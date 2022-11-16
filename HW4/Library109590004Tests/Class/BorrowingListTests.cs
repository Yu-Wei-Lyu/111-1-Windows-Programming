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
    public class BorrowingListTests
    {
        BorrowingList _borrowingList;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _borrowingList = new BorrowingList();
        }

        // TestMethod
        [TestMethod()]
        public void TestBorrowingList()
        {
            Assert.AreEqual(0, _borrowingList.Count);
        }

        // TestMethod
        [TestMethod()]
        public void TestAdd()
        {
            _borrowingList.Add(1, 1);
            Assert.IsFalse(_borrowingList.ContainsKey(5));
            _borrowingList.Add(5, 3);
            Assert.IsTrue(_borrowingList.ContainsKey(5));
            Assert.AreEqual(2, _borrowingList.Count);
            Assert.AreEqual(1, _borrowingList.GetBorrowingListTagByIndex(0));
            Assert.AreEqual(3, _borrowingList.GetBorrowingListAmountByIndex(1));
        }

        // TestMethod
        [TestMethod()]
        public void TestSetBorrowingAmountByIndex()
        {
            _borrowingList.Add(2, 1);
            _borrowingList.Add(0, 5);
            _borrowingList.Add(7, 1);
            _borrowingList.SetBorrowingAmountByIndex(1, 1);
            Assert.AreEqual(1, _borrowingList.GetBorrowingListAmountByIndex(1));
        }

        // TestMethod
        [TestMethod()]
        public void TestContainsKey()
        {
            _borrowingList.Add(3, 1);
            _borrowingList.Add(5, 8);
            Assert.IsTrue(_borrowingList.ContainsKey(5));
            Assert.IsFalse(_borrowingList.ContainsKey(1));
        }

        // TestMethod
        [TestMethod()]
        public void TestRemoveBookTagByIndex()
        {
            _borrowingList.Add(3, 1);
            _borrowingList.Add(2, 1);
            _borrowingList.Add(0, 5);
            _borrowingList.Add(5, 8);
            Assert.AreEqual(4, _borrowingList.Count);
            Assert.IsTrue(_borrowingList.ContainsKey(2));
            _borrowingList.RemoveBookTagByIndex(1);
            Assert.AreEqual(3, _borrowingList.Count);
            Assert.IsFalse(_borrowingList.ContainsKey(2));
        }

        // TestMethod
        [TestMethod()]
        public void TextGetBorrowingBooksAmount()
        {
            _borrowingList.Add(8, 1);
            _borrowingList.Add(7, 4);
            _borrowingList.Add(3, 3);
            Assert.AreEqual(8, _borrowingList.GetBorrowingBooksAmount());
        }

        // TestMethod
        [TestMethod()]
        public void TestGetBorrowingListTagByIndex()
        {
            _borrowingList.Add(1, 10);
            _borrowingList.Add(9, 2);
            Assert.AreEqual(9, _borrowingList.GetBorrowingListTagByIndex(1));
        }

        // TestMethod
        [TestMethod()]
        public void TestGetBorrowingListAmountByIndex()
        {
            _borrowingList.Add(18, 3);
            _borrowingList.Add(14, 0);
            _borrowingList.Add(0, 5);
            Assert.AreEqual(5, _borrowingList.GetBorrowingListAmountByIndex(2));
        }

        // TestMethod
        [TestMethod()]
        public void TestClear()
        {
            _borrowingList.Add(4, 8);
            _borrowingList.Add(7, 4);
            Assert.AreEqual(2, _borrowingList.Count);
            _borrowingList.Clear();
            Assert.AreEqual(0, _borrowingList.Count);
        }

        // TestMethod
        [TestMethod()]
        public void TestGetAmountByTag()
        {
            _borrowingList.Add(4, 3);
            _borrowingList.Add(1, 0);
            _borrowingList.Add(2, 8);
            Assert.AreEqual(8, _borrowingList.GetAmountByTag(2));
        }
    }
}