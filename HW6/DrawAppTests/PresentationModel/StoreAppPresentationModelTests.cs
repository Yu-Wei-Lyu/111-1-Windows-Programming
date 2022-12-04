using DrawingApp.PresentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.UI.Xaml.Controls;

namespace DrawAppTests.PresentationModel
{
    [TestClass()]
    public class StoreAppPresentationModelTests
    {
        DrawingModel.Model _model;
        StoreAppPresentationModel _presentationModel;

        [TestInitialize()]
        public void Initialize()
        {
            _model = new DrawingModel.Model();
            _presentationModel = new StoreAppPresentationModel(_model, new Canvas());
        }

        [TestMethod]
        public void TestMethod1()
        {
            
        }
    }
}
