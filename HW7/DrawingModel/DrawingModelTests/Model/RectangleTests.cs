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

        // TestGetCenter
        [TestMethod()]
        public void TestGetCenter()
        {
            _rectangle.X1 = -100;
            _rectangle.Y1 = 250;
            _rectangle.X2 = 200;
            _rectangle.Y2 = 350;
            CollectionAssert.AreEqual(new double[] { 50.0, 300.0 }, _rectangle.GetCenter());
        }


        [TestMethod()]
        public void TestIsArea()
        {
            _rectangle.X1 = -100;
            _rectangle.Y1 = 250;
            _rectangle.X2 = 200;
            _rectangle.Y2 = 350;
            Assert.IsTrue(_rectangle.IsArea(50, 300));
        }
    }
}