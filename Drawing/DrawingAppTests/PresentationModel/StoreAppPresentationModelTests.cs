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
        Mock<DrawingModel.IGraphics> _mockGraphics;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new DrawingModel.Model();
            _mockGraphics = new Mock<DrawingModel.IGraphics>();
            _presentationModel = new StoreAppPresentationModel(_model);
        }

        // TestDraw
        [TestMethod()]
        public void TestDraw()
        {
            _model.SetShapeType("Triangle");
            _model.PressedPointer(1, 1);
            _model.ReleasedPointer(2, 2);
            _presentationModel.Draw(_mockGraphics.Object);
            _mockGraphics.Verify(obj => obj.DrawTriangle(1, 1, 2, 2));
        }
    }
}
