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
            IShape triangle = _shapeFactory.CreateShape("Triangle", new double[] { 1, 2, 3, 4 });
            Assert.AreEqual("Triangle", triangle.GetShapeType());
            Assert.AreEqual(1, triangle.X1);
            Assert.AreEqual(2, triangle.Y1);
            Assert.AreEqual(3, triangle.X2);
            Assert.AreEqual(4, triangle.Y2);
            IShape rectangle = _shapeFactory.CreateShape("Rectangle", new double[] { 5, 4, 8.7, 78 });
            Assert.AreEqual("Rectangle", rectangle.GetShapeType());
            Assert.AreEqual(5, rectangle.X1);
            Assert.AreEqual(4, rectangle.Y1);
            Assert.AreEqual(8.7, rectangle.X2);
            Assert.AreEqual(78, rectangle.Y2);
        }
    }
}