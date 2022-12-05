using DrawingApp.PresentationModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DrawAppTests.PresentationModel
{
    [TestClass()]
    public class StoreAppPresentationModelTests
    {
        DrawingModel.Model _model;
        StoreAppPresentationModel _presentationModel;
        Canvas _canvas;

       [TestInitialize()]
        public void Initialize()
        {
            _model = new DrawingModel.Model();
            _canvas = new Canvas();
            _presentationModel = new StoreAppPresentationModel(_model, _canvas);
        }

        [TestMethod()]
        public void TestDraw()
        {
            _presentationModel.Draw();
        }
    }
}
