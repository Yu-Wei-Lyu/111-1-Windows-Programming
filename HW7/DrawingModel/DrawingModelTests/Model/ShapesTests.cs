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
        Mock<IGraphics> _mockGraphicsInterface;
        Shapes _shapes;
        PrivateObject _privateShapes;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _mockGraphicsInterface = new Mock<IGraphics>();
            _shapes = new Shapes();
            _privateShapes = new PrivateObject(_shapes);
        }

        [TestMethod()]
        public void TestDrawShapes()
        {
            AbstractShape shape1 = new Triangle();
            shape1.SetPoints(0, 0, 1, 1);
            AbstractShape shape2 = new Line();
            shape2.SetPoints(0, 0, 10, 10);
            AbstractShape shape3 = new Rectangle();
            shape3.SetPoints(10, 10, 15, 15);
            AbstractShape shape4 = new Line();
            shape4.SetPoints(100, 50, 120, 190);
            _shapes.Add(shape1);
            _shapes.Add(shape2);
            _shapes.Add(shape3);
            _shapes.Add(shape4);
            _shapes.DrawShapes(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.DrawTriangle(0, 0, 1, 1));
            _mockGraphicsInterface.Verify(obj => obj.DrawRectangle(10, 10, 15, 15));

        }

        [TestMethod()]
        public void TestDrawLines()
        {
            AbstractShape shape1 = new Triangle();
            shape1.SetPoints(0, 0, 1, 1);
            AbstractShape shape2 = new Line();
            shape2.SetPoints(0, 0, 10, 10);
            AbstractShape shape3 = new Rectangle();
            shape3.SetPoints(10, 10, 15, 15);
            AbstractShape shape4 = new Line();
            shape4.SetPoints(100, 50, 120, 190);
            _shapes.Add(shape1);
            _shapes.Add(shape2);
            _shapes.Add(shape3);
            _shapes.Add(shape4);
            _shapes.DrawLines(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.DrawLine(0, 0, 10, 10));
            _mockGraphicsInterface.Verify(obj => obj.DrawLine(100, 50, 120, 190));
        }

        [TestMethod()]
        public void TestClear()
        {
            List<AbstractShape> shapes = (List<AbstractShape>)_privateShapes.GetFieldOrProperty("_shapes");
            Assert.AreEqual(0, shapes.Count);
            AbstractShape shape = new Line();
            shape.SetPoints(100, 50, 120, 190);
            _shapes.Add(shape);
            Assert.AreEqual(1, shapes.Count);
            _shapes.Clear();
            Assert.AreEqual(0, shapes.Count);
        }

        [TestMethod()]
        public void TestAdd()
        {
            List<AbstractShape> shapes = (List<AbstractShape>)_privateShapes.GetFieldOrProperty("_shapes");
            Assert.AreEqual(0, shapes.Count);
            AbstractShape shape = new Rectangle();
            shape.SetPoints(100, 50, 120, 190);
            _shapes.Add(shape);
            Assert.AreEqual(shape, _shapes.GetSelectedPointShape(110, 60));
        }

        [TestMethod()]
        public void TestRemoveLast()
        {
            List<AbstractShape> shapes = (List<AbstractShape>)_privateShapes.GetFieldOrProperty("_shapes");
            AbstractShape shape1 = new Rectangle();
            shape1.SetPoints(100, 50, 120, 190);
            AbstractShape shape2 = new Line();
            shape2.SetPoints(10, 550, 210, 1090);
            _shapes.Add(shape1);
            _shapes.Add(shape2);
            Assert.AreEqual(shape2, shapes.ElementAt(shapes.Count - 1));
            _shapes.RemoveLast();
            Assert.AreEqual(shape1, shapes.ElementAt(shapes.Count - 1));
        }

        [TestMethod()]
        public void TestGetSelectedPointShape()
        {
            AbstractShape shape1 = new Rectangle();
            shape1.SetPoints(0, 0, 10, 10);
            AbstractShape shape2 = new Triangle();
            shape2.SetPoints(0, 0, 10, 10);
            AbstractShape shape3 = new Rectangle();
            shape3.SetPoints(9, 9, 15, 15);
            AbstractShape shape4 = new Line();
            shape4.SetPoints(100, 50, 120, 190);
            _shapes.Add(shape1);
            _shapes.Add(shape2);
            _shapes.Add(shape3);
            _shapes.Add(shape4);
            Assert.AreEqual(shape1, _shapes.GetSelectedPointShape(1, 1));
            Assert.AreEqual(shape2, _shapes.GetSelectedPointShape(5, 5));
            Assert.AreEqual(shape3, _shapes.GetSelectedPointShape(9, 9));
            Assert.AreEqual(null, _shapes.GetSelectedPointShape(100, 50));
        }

        [TestMethod()]
        public void TestIsLine()
        {
            AbstractShape line = new Line();
            AbstractShape rectangle = new Rectangle();
            Assert.IsTrue(_shapes.IsLine(line));
            Assert.IsFalse(_shapes.IsLine(rectangle));
        }
    }
}