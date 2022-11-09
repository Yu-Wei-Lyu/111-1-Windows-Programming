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
        public void BorrowingListTest()
        {
            Assert.AreEqual(0, _borrowingList.Count);
        }

        // TestMethod
        [TestMethod()]
        public void AddTest()
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
        public void SetBorrowingAmountByIndexTest()
        {
            _borrowingList.Add(2, 1);
            _borrowingList.Add(0, 5);
            _borrowingList.Add(7, 1);
            _borrowingList.SetBorrowingAmountByIndex(1, 1);
            Assert.AreEqual(1, _borrowingList.GetBorrowingListAmountByIndex(1));
        }

        // TestMethod
        [TestMethod()]
        public void ContainsKeyTest()
        {
            _borrowingList.Add(3, 1);
            _borrowingList.Add(5, 8);
            Assert.IsTrue(_borrowingList.ContainsKey(5));
            Assert.IsFalse(_borrowingList.ContainsKey(1));
        }

        // TestMethod
        [TestMethod()]
        public void RemoveBookTagByIndexTest()
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
        public void GetBorrowingBooksAmountText()
        {
            _borrowingList.Add(8, 1);
            _borrowingList.Add(7, 4);
            _borrowingList.Add(3, 3);
            Assert.AreEqual(8, _borrowingList.GetBorrowingBooksAmount());
        }

        // TestMethod
        [TestMethod()]
        public void ClearTest()
        {
            _borrowingList.Add(4, 8);
            _borrowingList.Add(7, 4);
            Assert.AreEqual(2, _borrowingList.Count);
            _borrowingList.Clear();
            Assert.AreEqual(0, _borrowingList.Count);
        }

        // TestMethod
        [TestMethod()]
        public void GetAmountByTagTest()
        {
            _borrowingList.Add(4, 3);
            _borrowingList.Add(1, 0);
            _borrowingList.Add(2, 8);
            Assert.AreEqual(8, _borrowingList.GetAmountByTag(2));
        }
    }
}