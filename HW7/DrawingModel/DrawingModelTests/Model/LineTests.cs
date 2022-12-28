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
        AbstractShape _line;

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
            AbstractShape rectangle = new Rectangle();
            rectangle.SetPoints(10, 20, 100, 30);
            _line.ReferenceShape1 = rectangle;
            _line.Draw(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.DrawLine(55, 25, 10, 10));
            AbstractShape triangle = new Triangle();
            triangle.SetPoints(55, 25, 105, 125);
            _line.ReferenceShape2 = triangle;
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
        public void TestSetReference1()
        {
            _line.ReferenceShape1 = null;
            Assert.IsNull(_line.ReferenceShape1);
            AbstractShape triangle = new Triangle();
            triangle.SetPoints(0, 0, 10, 10);
            _line.ReferenceShape1 = triangle;
            Assert.AreEqual(triangle, _line.ReferenceShape1);
            Assert.AreEqual(5, _line.X1);
            Assert.AreEqual(5, _line.Y1);
        }

        [TestMethod()]
        public void TestSetReference2()
        {
            _line.ReferenceShape2 = null;
            Assert.IsNull(_line.ReferenceShape2);
            AbstractShape triangle = new Triangle();
            triangle.SetPoints(100, 150, 200, 300);
            _line.ReferenceShape2 = triangle;
            Assert.AreEqual(triangle, _line.ReferenceShape2);
            Assert.AreEqual(150, _line.X2);
            Assert.AreEqual(225, _line.Y2);
        }
    }
}