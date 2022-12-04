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
    public class ShapesTests
    {
        Mock<GraphicsInterface> _mockGraphicsInterface;
        Shapes _shapes;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _mockGraphicsInterface = new Mock<GraphicsInterface>();
            _shapes = new Shapes();
        }

        [TestMethod()]
        public void TestCreateShape()
        {
            _shapes.CreateShape("Triangle", new double[] { 1.1, 1.2, 1.3, 1.4 });
            Shape shape = _shapes.GetShape(0);
            Assert.AreEqual("Triangle", shape.GetShapeType());
            Assert.AreEqual(1.1, shape.X1);
            Assert.AreEqual(1.2, shape.Y1);
            Assert.AreEqual(1.3, shape.X2);
            Assert.AreEqual(1.4, shape.Y2);
        }

        [TestMethod()]
        public void TestGetShape()
        {
            _shapes.CreateShape("Rectangle", new double[] { 0.1, 2, 0.3, 4 });
            Shape shape = _shapes.GetShape(0);
            Assert.AreEqual("Rectangle", shape.GetShapeType());
            Assert.AreEqual(0.1, shape.X1);
            Assert.AreEqual(2, shape.Y1);
            Assert.AreEqual(0.3, shape.X2);
            Assert.AreEqual(4, shape.Y2);
        }

        [TestMethod()]
        public void TestGetShapesQuantity()
        {
            Assert.AreEqual(0, _shapes.GetShapesQuantity());
            _shapes.CreateShape("Rectangle", new double[] { 41, 22, 42, 28 });
            Assert.AreEqual(1, _shapes.GetShapesQuantity());
            _shapes.CreateShape("Triangle", new double[] { 41, 22, 42, 28 });
            Assert.AreEqual(2, _shapes.GetShapesQuantity());
        }

        [TestMethod()]
        public void TestDrawAllShapes()
        {
            _shapes.CreateShape("Triangle", new double[] { 1.1, 1.2, 1.3, 1.4 });
            _shapes.CreateShape("Rectangle", new double[] { 0.1, 2, 0.3, 4 });
            _shapes.CreateShape("Triangle", new double[] { 41, 22, 42, 28 });
            _shapes.DrawAllShapes(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.DrawTriangle(1.1, 1.2, 1.3, 1.4));
            _mockGraphicsInterface.Verify(obj => obj.DrawRectangle(0.1, 2, 0.3, 4));
            _mockGraphicsInterface.Verify(obj => obj.DrawTriangle(41, 22, 42, 28));
        }

        [TestMethod()]
        public void TestClear()
        {
            _shapes.CreateShape("Triangle", new double[] { 1.1, 1.2, 1.3, 1.4 });
            _shapes.CreateShape("Rectangle", new double[] { 0.1, 2, 0.3, 4 });
            Assert.AreEqual(2, _shapes.GetShapesQuantity());
            _shapes.Clear();
            Assert.AreEqual(0, _shapes.GetShapesQuantity());
        }
    }
}