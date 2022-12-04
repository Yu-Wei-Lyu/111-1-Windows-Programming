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
    public class ModelTests
    {
        Mock<GraphicsInterface> _mockGraphicsInterface;
        Model _model;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _mockGraphicsInterface = new Mock<GraphicsInterface>();
            _model = new Model();
        }

        [TestMethod()]
        public void TestModel()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestSetShapeType()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestPressedPointer()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestMovedPointer()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestReleasedPointer()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestClear()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestResetCurrentShape()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestPaintOn()
        {
            Assert.Fail();
        }
    }
}