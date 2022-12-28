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
    public class StateDrawingTests
    {
        AbstractState _stateDrawing;

        [TestInitialize()]
        public void Initialize()
        {
            _stateDrawing = new StateDrawing();
        }

        [TestMethod()]
        public void TestGetStateType()
        {
            Assert.AreEqual("Drawing", _stateDrawing.GetStateType());
        }

        [TestMethod()]
        public void TestPressed()
        {
            AbstractShape shape = _stateDrawing.Pressed(new Shapes(), "Triangle", 10, 12);
            Assert.AreEqual("Triangle", shape.GetShapeType());
            Assert.AreEqual(10, shape.X1);
            Assert.AreEqual(12, shape.Y1);
            Assert.AreEqual(10, shape.X2);
            Assert.AreEqual(12, shape.Y2);
        }

        [TestMethod()]
        public void TestMoved()
        {
            AbstractShape shape = new Triangle();
            AbstractShape movedShape = _stateDrawing.Moved(shape, 15, 20);
            Assert.AreEqual(15, movedShape.X2);
            Assert.AreEqual(20, movedShape.Y2);
        }

        [TestMethod()]
        public void TestReleased()
        {
            AbstractShape shape1 = _stateDrawing.Released(new Shapes(), null, 0, 0);
            Assert.IsNull(shape1);
            AbstractShape line =  _stateDrawing.Pressed(new Shapes(), "Line", 0, 0);
            AbstractShape shape2 = _stateDrawing.Released(new Shapes(), line, 17, 19);
            Assert.AreEqual(0, shape2.X1);
            Assert.AreEqual(0, shape2.Y1);
            Assert.AreEqual(17, shape2.X2);
            Assert.AreEqual(19, shape2.Y2);
        }
    }
}