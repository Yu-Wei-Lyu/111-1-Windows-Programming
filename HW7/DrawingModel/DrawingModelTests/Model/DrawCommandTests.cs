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
    public class DrawCommandTests
    {
        DrawCommand _drawCommand;
        Model _model;
        AbstractShape _shape;
        PrivateObject _privateShapes;
        PrivateObject _privateModel;

        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _privateModel = new PrivateObject(_model);
            _shape = new Triangle();
            _drawCommand = new DrawCommand(_model, _shape);
        }

        [TestMethod()]
        public void TestExecute()
        {
            Shapes shapes = (Shapes)_privateModel.GetFieldOrProperty("_shapes");
            _shape.SetPoints(50, 100, 150, 200);
            _drawCommand.Execute();
            Assert.AreEqual(_shape, shapes.GetSelectedPointShape(100, 150));
        }

        [TestMethod()]
        public void TestUndoExecute()
        {
            Shapes shapes = (Shapes)_privateModel.GetFieldOrProperty("_shapes");
            _shape.SetPoints(50, 100, 150, 200);
            AbstractShape triangle = new Triangle();
            triangle.SetPoints(0, 0, 10, 10);
            shapes.Add(triangle);
            Assert.AreEqual(triangle, shapes.GetSelectedPointShape(5, 5));
            _drawCommand.UndoExecute();
            Assert.IsNull(shapes.GetSelectedPointShape(5, 5));
        }
    }
}