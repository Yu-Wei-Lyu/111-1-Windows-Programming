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
        PrivateObject _privateLine;
        Line _line;

        [TestInitialize()]
        public void Initialize()
        {
            _mockGraphicsInterface = new Mock<IGraphics>();
            _line = new Line();
            _privateLine = new PrivateObject(_line);
        }

        [TestMethod()]
        public void TestDraw()
        {
            _line.SetPoints(0, 0, 10, 10);
            _line.Draw(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.DrawLine(0, 0, 10, 10));
            Shape rectangle = new Rectangle();
            rectangle.SetPoints(10, 20, 100, 30);
            _line.SetReference(rectangle);
            _line.Draw(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.DrawLine(55, 25, 10, 10));
            Shape triangle = new Triangle();
            triangle.SetPoints(55, 25, 105, 125);
            _line.SetReference(rectangle, triangle);
            _line.Draw(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.DrawLine(55, 25, 80, 75));
        }

        [TestMethod()]
        public void TestPreviewDraw()
        {
            _line.SetPoints(0, 0, 9, 9);
            _line.PreviewDraw(_mockGraphicsInterface.Object);
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
            Shape triangle = new Triangle();
            _line.SetReference(triangle);
            Assert.AreEqual(triangle, _privateLine.GetFieldOrProperty("_referenceShapeFirst"));
        }

        [TestMethod()]
        public void TestSetPointsByTwoReference()
        {
            Shape rectangle = new Rectangle();
            Shape triangle = new Triangle();
            _line.SetReference(rectangle, triangle);
            Assert.AreEqual(rectangle, _privateLine.GetFieldOrProperty("_referenceShapeFirst"));
            Assert.AreEqual(triangle, _privateLine.GetFieldOrProperty("_referenceShapeSecond"));
        }
    }
}