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
    public class StatePointerTests
    {
        StatePointer _statePointer;
        Shapes _shapes;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _statePointer = new StatePointer();
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

        // TestGetStateType
        [TestMethod()]
        public void TestGetStateType()
        {
            Assert.AreEqual("Pointer", _statePointer.GetStateType());
        }

        // TestPressed
        [TestMethod()]
        public void TestPressed()
        {
            AbstractShape shape = _statePointer.Pressed(_shapes, "SelectBox", 1, 2);
            Assert.AreEqual("SelectBox", shape.GetShapeType());
            Assert.AreEqual(0, shape.X1);
            Assert.AreEqual(0, shape.Y1);
            Assert.AreEqual(10, shape.X2);
            Assert.AreEqual(10, shape.Y2);
            Assert.AreEqual("Select：Rectangle(0, 0, 10, 10)", _statePointer.HintText);
        }

        // TestMoved
        [TestMethod()]
        public void TestMoved()
        {
            AbstractShape shape = new Rectangle();
            AbstractShape movedShape = _statePointer.Moved(shape, 1, 2);
            Assert.AreEqual(shape, movedShape);
        }

        // TestReleased
        [TestMethod()]
        public void TestReleased()
        {
            AbstractShape shape1 = _statePointer.Released(_shapes, new Triangle(), 100, 15);
            Assert.IsNull(shape1);
            AbstractShape shape2 = _statePointer.Pressed(_shapes, "SelectBox", 20, 18);
            AbstractShape shape3 = _statePointer.Released(_shapes, shape2, 15.01, 15.02);
            Assert.AreEqual(10, shape3.X1);
            Assert.AreEqual(10, shape3.Y1);
            Assert.AreEqual(20, shape3.X2);
            Assert.AreEqual(20, shape3.Y2);
        }

        // TestHandleSelect
        [TestMethod()]
        public void TestHandleSelect()
        {
            _statePointer.Pressed(_shapes, "SelectBox", 0, 0);
            AbstractShape shape = _statePointer.HandleSelect(_shapes, 235, 200);
            Assert.AreEqual("SelectBox", shape.GetShapeType());
            Assert.AreEqual(200, shape.X1);
            Assert.AreEqual(100, shape.Y1);
            Assert.AreEqual(250, shape.X2);
            Assert.AreEqual(250, shape.Y2);
        }
    }
}