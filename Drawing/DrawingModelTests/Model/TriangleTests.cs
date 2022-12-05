using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        Mock <IGraphics> _mockGraphicsInterface;
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
    }
}