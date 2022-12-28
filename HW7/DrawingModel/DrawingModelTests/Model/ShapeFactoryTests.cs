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
    public class ShapeFactoryTests
    {
        ShapeFactory _shapeFactory;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _shapeFactory = new ShapeFactory();
        }

        // TestCreateShape
        [TestMethod()]
        public void TestCreateShape()
        {
            Shape shape = _shapeFactory.CreateShape("Rectangle");
            Assert.AreEqual("Rectangle", shape.GetShapeType());
            shape = _shapeFactory.CreateShape("Triangle");
            Assert.AreEqual("Triangle", shape.GetShapeType());
            shape = _shapeFactory.CreateShape("Line");
            Assert.AreEqual("Line", shape.GetShapeType());
            shape = _shapeFactory.CreateShape("SelectBox");
            Assert.AreEqual("SelectBox", shape.GetShapeType());
        }
    }
}