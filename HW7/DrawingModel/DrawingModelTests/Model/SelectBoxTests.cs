﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class SelectBoxTests
    {
        Mock<IGraphics> _mockGraphicsInterface;
        Shape _selectBox;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _mockGraphicsInterface = new Mock<IGraphics>();
            _selectBox = new SelectBox();
        }

        [TestMethod()]
        public void TestDraw()
        {
            Shape triangle = new Triangle();
            triangle.SetPoints(10, 10, 100, 100);
            _selectBox.ReferenceShape1 = triangle;
            _selectBox.Draw(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.DrawSelectBox(10, 10, 100, 100));
        }

        [TestMethod()]
        public void TestPreviewDraw()
        {
            Shape rectangle = new Rectangle();
            rectangle.SetPoints(80, 110, 125, 190);
            _selectBox.ReferenceShape1 = rectangle;
            _selectBox.PreviewDraw(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.DrawSelectBox(80, 110, 125, 190));
        }

        [TestMethod()]
        public void TestGetShapeType()
        {
            Assert.AreEqual("SelectBox", _selectBox.GetShapeType());
        }

        [TestMethod()]
        public void TestReferenceShape()
        {
            Assert.AreEqual(null, _selectBox.ReferenceShape1);
            Shape rectangle = new Rectangle();
            rectangle.SetPoints(0, 0, 200, 200);
            _selectBox.ReferenceShape1 = rectangle;
            Assert.AreEqual(rectangle, _selectBox.ReferenceShape1);
            Assert.AreEqual(0, _selectBox.X1);
            Assert.AreEqual(0, _selectBox.Y1);
            Assert.AreEqual(200, _selectBox.X2);
            Assert.AreEqual(200, _selectBox.Y2);
        }
    }
}