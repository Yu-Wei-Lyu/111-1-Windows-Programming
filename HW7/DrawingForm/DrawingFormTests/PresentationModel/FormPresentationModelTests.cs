using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingForm.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Moq;

namespace DrawingForm.Presentation.Tests
{
    [TestClass()]
    public class FormPresentationModelTests
    {
        DrawingModel.Model _model;
        PrivateObject _privateModel;
        FormPresentationModel _presentationModel;
        Mock<DrawingModel.IGraphics> _mockGraphics;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new DrawingModel.Model();
            _privateModel = new PrivateObject(_model);
            _mockGraphics = new Mock<DrawingModel.IGraphics>();
            _presentationModel = new FormPresentationModel(_model);
        }

        // TestDraw
        [TestMethod()]
        public void TestDraw()
        {
            _model.SetState("Triangle");
            _model.PressedPointer(1, 1);
            _model.ReleasedPointer(2, 2);
            _presentationModel.Draw(_mockGraphics.Object);
            _mockGraphics.Verify(obj => obj.DrawTriangle(1, 1, 2, 2));
        }
    }
}