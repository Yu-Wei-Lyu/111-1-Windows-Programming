using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingForm.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Moq;
using DrawingModel;

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
            _model.SetStateDrawing("Triangle");
            _model.PressedPointer(1, 1);
            _model.ReleasedPointer(2, 2);
            _presentationModel.Draw(_mockGraphics.Object);
            _mockGraphics.Verify(obj => obj.DrawTriangle(1, 1, 2, 2));
        }

        // TestFormPresentationModel
        [TestMethod()]
        public void TestFormPresentationModel()
        {
            Assert.IsTrue(_presentationModel.IsLineButtonEnabled);
            Assert.IsTrue(_presentationModel.IsTriangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsRectangleButtonEnabled);
        }

        // TestNotifyPropertyChanged
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            int count = 0;
            _presentationModel.NotifyPropertyChanged("Nothing");
            Assert.AreEqual(0, count);
            _presentationModel.PropertyChanged += delegate
            {
                count += 1;
            };
            _presentationModel.NotifyPropertyChanged("Nothing");
            Assert.AreEqual(1, count);
        }

        // TestHandleRectangleButtonClick
        [TestMethod()]
        public void TestHandleRectangleButtonClick()
        {
            _presentationModel.HandleRectangleButtonClick();
            Assert.IsTrue(_presentationModel.IsLineButtonEnabled);
            Assert.IsTrue(_presentationModel.IsTriangleButtonEnabled);
            Assert.IsFalse(_presentationModel.IsRectangleButtonEnabled);
        }

        // TestHandleLineButtonClick
        [TestMethod()]
        public void TestHandleLineButtonClick()
        {
            _presentationModel.HandleLineButtonClick();
            Assert.IsFalse(_presentationModel.IsLineButtonEnabled);
            Assert.IsTrue(_presentationModel.IsTriangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsRectangleButtonEnabled);
        }

        // TestHandleTriangleButtonClick
        [TestMethod()]
        public void TestHandleTriangleButtonClick()
        {
            _presentationModel.HandleTriangleButtonClick();
            Assert.IsTrue(_presentationModel.IsLineButtonEnabled);
            Assert.IsFalse(_presentationModel.IsTriangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsRectangleButtonEnabled);
        }

        // TestHandleClearButtonClick
        [TestMethod()]
        public void TestHandleClearButtonClick()
        {
            Assert.IsTrue(_presentationModel.IsLineButtonEnabled);
            Assert.IsTrue(_presentationModel.IsTriangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsRectangleButtonEnabled);
        }

        // TestSetToDefaultButtonEnabled
        [TestMethod()]
        public void TestSetToDefaultButtonEnabled()
        {
            _presentationModel.SetToDefaultButtonEnabled();
            Assert.IsTrue(_presentationModel.IsLineButtonEnabled);
            Assert.IsTrue(_presentationModel.IsTriangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsRectangleButtonEnabled);
            _model.SetStateLine();
            AbstractShape shape = new DrawingModel.Rectangle();
            shape.SetPoints(0, 0, 10, 10);
            _model.DrawShape(shape);
            _model.PressedPointer(5, 5);
            _presentationModel.SetToDefaultButtonEnabled();
            Assert.IsFalse(_presentationModel.IsLineButtonEnabled);
            Assert.IsTrue(_presentationModel.IsTriangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsRectangleButtonEnabled);
        }
    }
}