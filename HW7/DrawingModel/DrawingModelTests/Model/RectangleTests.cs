using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class RectangleTests
    {
        Mock<IGraphics> _mockGraphicsInterface;
        Rectangle _rectangle;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _mockGraphicsInterface = new Mock<IGraphics>();
            _rectangle = new Rectangle();
        }

        // TestDraw
        [TestMethod()]
        public void TestDraw()
        {
            _rectangle.X1 = 1172;
            _rectangle.Y1 = 52;
            _rectangle.X2 = 105;
            _rectangle.Y2 = 20;
            _rectangle.Draw(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.DrawRectangle(1172, 52, 105, 20));
        }

        // TestPreviewDraw
        [TestMethod()]
        public void TestPreviewDraw()
        {
            _rectangle.X1 = 101;
            _rectangle.Y1 = 277;
            _rectangle.X2 = 142;
            _rectangle.Y2 = 381;
            _rectangle.PreviewDraw(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.PreviewRectangle(101, 277, 142, 381));
        }

        // TestGetShapeType
        [TestMethod()]
        public void TestGetShapeType()
        {
            Assert.AreEqual("Rectangle", _rectangle.GetShapeType());
        }

        [TestMethod()]
        public void TestIsContain()
        {
            _rectangle.SetPoints(100, 100, 200, 200);
            Assert.IsTrue(_rectangle.IsContain(150, 150));
            Assert.IsFalse(_rectangle.IsContain(201, 201));
            _rectangle.SetPoints(200, 200, 100, 100);
            Assert.IsTrue(_rectangle.IsContain(160, 110));
            Assert.IsFalse(_rectangle.IsContain(90, 90));
        }

        [TestMethod()]
        public void TestGetHalfPointX()
        {
            _rectangle.SetPoints(100, 100, 200, 200);
            Assert.AreEqual(150, _rectangle.GetHalfPointX());
        }

        [TestMethod()]
        public void TestGetLargeX()
        {
            _rectangle.SetPoints(100, 100, 200, 200);
            Assert.AreEqual(200, _rectangle.GetLargeX());
            _rectangle.SetPoints(200, 200, 100, 100);
            Assert.AreEqual(200, _rectangle.GetLargeX());
        }

        [TestMethod()]
        public void TestGetLargeY()
        {
            _rectangle.SetPoints(100, 100, 200, 200);
            Assert.AreEqual(200, _rectangle.GetLargeY());
            _rectangle.SetPoints(200, 200, 100, 100);
            Assert.AreEqual(200, _rectangle.GetLargeY());
        }

        [TestMethod()]
        public void TestGetSmallX()
        {
            _rectangle.SetPoints(100, 100, 200, 200);
            Assert.AreEqual(100, _rectangle.GetSmallX());
            _rectangle.SetPoints(200, 200, 100, 100);
            Assert.AreEqual(100, _rectangle.GetSmallX());
        }

        [TestMethod()]
        public void TestGetSmallY()
        {
            _rectangle.SetPoints(100, 100, 200, 200);
            Assert.AreEqual(100, _rectangle.GetSmallY());
            _rectangle.SetPoints(200, 200, 100, 100);
            Assert.AreEqual(100, _rectangle.GetSmallY());
        }

        [TestMethod()]
        public void TestSetPoints()
        {
            _rectangle.SetPoints(0, 0, 1, 1);
            Assert.AreEqual(0, _rectangle.X1);
            Assert.AreEqual(0, _rectangle.Y1);
            Assert.AreEqual(1, _rectangle.X2);
            Assert.AreEqual(1, _rectangle.Y2);
        }
    }
}