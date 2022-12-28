﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Moq;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        Mock<IGraphics> _mockGraphicsInterface;
        Triangle _triangle;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _mockGraphicsInterface = new Mock<IGraphics>();
            _triangle = new Triangle();
        }

        // TestDraw
        [TestMethod()]
        public void TestDraw()
        {
            _triangle.X1 = 5;
            _triangle.Y1 = 10;
            _triangle.X2 = 15;
            _triangle.Y2 = 20;
            _triangle.Draw(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.DrawTriangle(5, 10, 15, 20));
        }

        // TestPreviewDraw
        [TestMethod()]
        public void TestPreviewDraw()
        {
            _triangle.X1 = 500;
            _triangle.Y1 = 1000;
            _triangle.X2 = 1100;
            _triangle.Y2 = 1800;
            _triangle.PreviewDraw(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.PreviewTriangle(500, 1000, 1100, 1800));
        }

        // TestGetShapeType
        [TestMethod()]
        public void TestGetShapeType()
        {
            Assert.AreEqual("Triangle", _triangle.GetShapeType());
        }

        [TestMethod()]
        public void TestGetSideLength()
        {
            PointF point1 = new PointF(0, 0);
            PointF point2 = new PointF(10, 10);
            Assert.AreEqual(10 * Math.Sqrt(2), _triangle.GetSideLength(point1, point2));
            point1 = new PointF(10, 10);
            point2 = new PointF(0, 0);
            Assert.AreEqual(10 * Math.Sqrt(2), _triangle.GetSideLength(point1, point2));
        }

        [TestMethod()]
        public void TestGetTriangleArea()
        {
            PointF point1 = new PointF(0, 0);
            PointF point2 = new PointF(0, 5);
            PointF point3 = new PointF(12, 5);
            Assert.AreEqual(30, _triangle.GetTriangleArea(point1, point2, point3), 0.1);
            point1 = new PointF(0, 0);
            point2 = new PointF(0, 10);
            point3 = new PointF(12, 5);
            Assert.AreEqual(60, _triangle.GetTriangleArea(point1, point2, point3), 0.1);
        }

        [TestMethod()]
        public void TestIsContain()
        {
            _triangle.X1 = 5;
            _triangle.Y1 = 10;
            _triangle.X2 = 15;
            _triangle.Y2 = 20;
            Assert.IsTrue(_triangle.IsContain(10, 15));
            Assert.IsFalse(_triangle.IsContain(200, 0));
            Assert.IsTrue(_triangle.IsContain(10, 10));
        }

        [TestMethod()]
        public void TestSetTrianglePoints()
        {
            PrivateObject privateTriangle = new PrivateObject(_triangle);
            _triangle.X1 = 5;
            _triangle.Y1 = 10;
            _triangle.X2 = 15;
            _triangle.Y2 = 20;
            _triangle.SetTrianglePoints();
            PointF point = new PointF(10, 10);
            PointF top = (PointF)privateTriangle.GetFieldOrProperty("_top");
            PointF leftBottom = (PointF)privateTriangle.GetFieldOrProperty("_leftBottom");
            PointF rightBottom = (PointF)privateTriangle.GetFieldOrProperty("_rightBottom");
            Assert.AreEqual(10, top.X);
            Assert.AreEqual(10, top.Y);
            Assert.AreEqual(15, leftBottom.X);
            Assert.AreEqual(20, leftBottom.Y);
            Assert.AreEqual(5, rightBottom.X);
            Assert.AreEqual(20, rightBottom.Y);
        }
    }
}