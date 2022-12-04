using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        Triangle _triangle;

        // TestInitialize
        [TestInitialize()]
        public void Initialize()
        {
            _triangle = new Triangle();
        }

        [TestMethod()]
        public void TestDraw()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestPreviewDraw()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetShapeType()
        {
            Assert.AreEqual("Triangle", _triangle.GetShapeType());
        }
    }
}