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
    public class LineTests
    {
        Mock<IGraphics> _mockGraphicsInterface;
        Line _line;

        [TestInitialize()]
        public void Initialize()
        {
            _mockGraphicsInterface = new Mock<IGraphics>();
            _line = new Line();
        }

        [TestMethod()]
        public void TestDraw()
        {
            _line.SetPoints(0, 0, 10, 10);
            _line.Draw(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.DrawLine(0, 0, 10, 10));
            Rectangle rectangle = new Rectangle();
            rectangle.SetPoints()
        }

        [TestMethod()]
        public void TestPreviewDraw()
        {
            _line.SetPoints(0, 0, 9, 9);
            _line.Draw(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.DrawLine(0, 0, 9, 9));
        }

        [TestMethod()]
        public void TestIsContain()
        {
            _line.SetPoints(100, 122, 80, 44);
            Assert.IsFalse(_line.IsContain(5, 5));
            Assert.IsFalse(_line.IsContain(100, 120));
        }

        [TestMethod()]
        public void TestGetShapeType()
        {
            Assert.AreEqual("Line", _line.GetShapeType());
        }

        [TestMethod()]
        public void TestSetPointsByReference()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestSetPointsByReference1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestSetReferencePoints()
        {
            Assert.Fail();
        }
    }
}