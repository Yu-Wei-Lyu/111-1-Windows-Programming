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
    public class ModelTests
    {
        Mock<IGraphics> _mockGraphicsInterface;
        PrivateObject _privateObject;
        Model _model;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _mockGraphicsInterface = new Mock<IGraphics>();
            _model = new Model();
            _privateObject = new PrivateObject(_model);
        }

        [TestMethod()]
        public void TestSetShapeType()
        {
            Assert.AreEqual("", _privateObject.GetFieldOrProperty("_currentShape"));
            _model.SetShapeType("Triangle");
            Assert.AreEqual("Triangle", _privateObject.GetFieldOrProperty("_currentShape"));
        }

        [TestMethod()]
        public void TestPressedPointer()
        {
            _model.PressedPointer(-1, -1);
            Assert.AreEqual(false, _privateObject.GetFieldOrProperty("_isPressed"));
            _model.SetShapeType("Rectangle");
            _model.PressedPointer(10, 6);
            Assert.AreEqual(true, _privateObject.GetFieldOrProperty("_isPressed"));
        }

        [TestMethod()]
        public void TestMovedPointer()
        {
            _model.MovedPointer(1, 1);
            Assert.AreEqual(false, _privateObject.GetFieldOrProperty("_isMoving"));
            _model.SetShapeType("Triangle");
            _model.PressedPointer(1, 5);
            _model.MovedPointer(10, 10);
            Assert.AreEqual(true, _privateObject.GetFieldOrProperty("_isMoving"));
        }

        [TestMethod()]
        public void TestReleasedPointer()
        {
            _model.ReleasedPointer(10, 10);
            Assert.AreEqual("", _privateObject.GetFieldOrProperty("_currentShape"));
            _model.SetShapeType("Triangle");
            _model.PressedPointer(7, 11);
            _model.MovedPointer(54, 87);
            Assert.AreEqual("Triangle", _privateObject.GetFieldOrProperty("_currentShape"));
            _model.ReleasedPointer(115, 48);
            Assert.AreEqual("", _privateObject.GetFieldOrProperty("_currentShape"));
        }

        [TestMethod()]
        public void TestClear()
        {
            _model.SetShapeType("Rectangle");
            Assert.AreEqual("Rectangle", _privateObject.GetFieldOrProperty("_currentShape"));
            _model.Clear();
            Assert.AreEqual("", _privateObject.GetFieldOrProperty("_currentShape"));
        }

        [TestMethod()]
        public void TestResetCurrentShape()
        {
            _model.SetShapeType("Triangle");
            Assert.AreEqual("Triangle", _privateObject.GetFieldOrProperty("_currentShape"));
            _model.ResetCurrentShape();
            Assert.AreEqual("", _privateObject.GetFieldOrProperty("_currentShape"));
        }

        [TestMethod()]
        public void TestPaintOn()
        {
            _model.SetShapeType("Rectangle");
            _model.PressedPointer(7, 11);
            _model.MovedPointer(54, 87);
            _model.PaintOn(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.PreviewRectangle(7, 11, 54, 87));
            _model.ReleasedPointer(115, 48);
            _model.PaintOn(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.DrawRectangle(7, 11, 115, 48));
        }

        // TestNotifyModelChanged
        [TestMethod()]
        public void TestNotifyModelChanged()
        {
            _model.SetShapeType("Rectangle");
            _model.NotifyModelChanged();
            Assert.AreEqual("Rectangle", _privateObject.GetFieldOrProperty("_currentShape"));
            _model._modelChanged += delegate
            {
                _model.SetShapeType("");
            };
            _model.NotifyModelChanged();
            Assert.AreEqual("", _privateObject.GetFieldOrProperty("_currentShape"));
        }
    }
}