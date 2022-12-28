using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class StateLineTests
    {
        AbstractState _stateLine;
        Shapes _shapes;

        [TestInitialize()]
        public void Initialize()
        {
            _stateLine = new StateLine();
            _shapes = new Shapes();
            AbstractShape shape1 = new Rectangle();
            AbstractShape shape2 = new Triangle();
            AbstractShape shape3 = new Rectangle();
            AbstractShape shape4 = new Triangle();
            shape1.SetPoints(0, 0, 10, 10);
            shape2.SetPoints(10, 10, 20, 20);
            shape3.SetPoints(100, 0, 110, 10);
            shape4.SetPoints(200, 100, 250, 250);
            _shapes.Add(shape1);
            _shapes.Add(shape2);
            _shapes.Add(shape3);
            _shapes.Add(shape4);
        }

        [TestMethod()]
        public void TestGetStateType()
        {
            Assert.AreEqual("Line", _stateLine.GetStateType());
        }

        [TestMethod()]
        public void TestPressed()
        {
            AbstractShape shape = _stateLine.Pressed(_shapes, "Line", 1, 2);
            Assert.AreEqual("Line", shape.GetShapeType());
            Assert.AreEqual(5, shape.X1);
            Assert.AreEqual(5, shape.Y1);
            Assert.AreEqual(1, shape.X2);
            Assert.AreEqual(2, shape.Y2);
            Assert.IsTrue(_stateLine.KeepAlive);
        }

        [TestMethod()]
        public void TestMoved()
        {
            AbstractShape shape = new Line();
            AbstractShape movedShape = _stateLine.Moved(shape, 15, 20);
            Assert.AreEqual(15, movedShape.X2);
            Assert.AreEqual(20, movedShape.Y2);
            AbstractShape movedShape2 = _stateLine.Moved(null, 15, 20);
            Assert.IsNull(movedShape2);
        }

        [TestMethod()]
        public void TestReleased()
        {
            AbstractShape shape1 = _stateLine.Released(_shapes, null, 0, 0);
            Assert.IsNull(shape1);
            AbstractShape line = _stateLine.Pressed(_shapes, "Line", 20, 18);
            AbstractShape shape2 = _stateLine.Released(_shapes, line, 15, 15);
            Assert.IsNull(shape2);
            Assert.IsTrue(_stateLine.KeepAlive);
            AbstractShape line2 = _stateLine.Pressed(_shapes, "Line", 15.11, 15.04);
            AbstractShape shape3 = _stateLine.Released(_shapes, line2, 225.02, 175.44);
            Assert.AreEqual(15, shape3.X1);
            Assert.AreEqual(15, shape3.Y1);
            Assert.AreEqual(225, shape3.X2);
            Assert.AreEqual(175, shape3.Y2);
            Assert.IsFalse(_stateLine.KeepAlive);
        }
    }
}