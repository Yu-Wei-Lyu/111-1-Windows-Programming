using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library109590004;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Library109590004.Tests
{
    [TestClass()]
    public class SupplyPresentationModelTests
    {
        private const string TEST_FILE_PATH = "hw4_books_source.txt";
        LibraryModel _libraryModel;
        SupplyPresentationModel _presentationModel;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _libraryModel = new LibraryModel(TEST_FILE_PATH);
            _presentationModel = new SupplyPresentationModel(_libraryModel);
        }

        // TestMethod
        [TestMethod()]
        public void TestSupplyPresentationModel()
        {
            Assert.IsFalse(_presentationModel.IsConfirmEnabled);
            Assert.AreEqual("", _presentationModel.SupplyBookAmountText);
        }

        // TestMethod
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            _presentationModel.NotifyPropertyChanged("test");
            Assert.AreEqual(-1, _libraryModel.LibraryTag);
            _presentationModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                _libraryModel.LibraryTag = 2;
            };
            _presentationModel.NotifyPropertyChanged("test");
            Assert.AreEqual(2, _libraryModel.LibraryTag);
        }

        // TestMethod
        [TestMethod()]
        public void TestSupplyBookAmountTextBoxTextChanged()
        {
            _presentationModel.SupplyBookAmountTextBoxTextChanged("");
            Assert.IsFalse(_presentationModel.IsConfirmEnabled);
            Assert.AreEqual("", _presentationModel.SupplyBookAmountText);
            _presentationModel.SupplyBookAmountTextBoxTextChanged("there is something");
            Assert.IsTrue(_presentationModel.IsConfirmEnabled);
            Assert.AreEqual("there is something", _presentationModel.SupplyBookAmountText);
        }

        // TestMethod
        [TestMethod()]
        public void TestGetSupplyBookText()
        {
            string exceptedString = "書籍名稱：走路 : 獨處的實踐\n\n書籍類別：4月暢銷書\n庫存數量：3";
            Assert.AreEqual(exceptedString, _presentationModel.GetSupplyBookText(7));
        }
    }
}