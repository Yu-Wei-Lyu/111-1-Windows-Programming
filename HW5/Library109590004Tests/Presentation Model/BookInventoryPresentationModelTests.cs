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
    public class BookInventoryPresentationModelTests
    {
        private const string TEST_FILE_PATH = "hw4_books_source.txt";
        LibraryModel _libraryModel;
        BookInventoryPresentationModel _presentationModel;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _libraryModel = new LibraryModel(TEST_FILE_PATH);
            _presentationModel = new BookInventoryPresentationModel(_libraryModel);
        }

        // TestMethod
        [TestMethod()]
        public void TestSetLastSelect()
        {
            _presentationModel.SetLastSelect(5);
            Assert.AreEqual(5, _presentationModel.GetLastSelect());
        }

        // TestMethod
        [TestMethod()]
        public void TestGetLastSelect()
        {
            Assert.AreEqual(-1, _presentationModel.GetLastSelect());
            _presentationModel.SetLastSelect(10);
            Assert.AreEqual(10, _presentationModel.GetLastSelect());
        }

        // TestMethod
        [TestMethod()]
        public void TestGetSupplyImage()
        {
            Assert.AreEqual("../../../image/replenishment.png", _presentationModel.GetSupplyImage());
        }
    }
}