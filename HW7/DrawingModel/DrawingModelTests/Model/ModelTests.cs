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
        Mock<IGraphics> _mockGraphicsInterface;
        PrivateObject _privateModel;
        Model _model;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _mockGraphicsInterface = new Mock<IGraphics>();
            _model = new Model();
            _privateModel = new PrivateObject(_model);
        }

        // TestSetShapeType
        [TestMethod()]
        public void TestSetShapeType()
        {
            Assert.AreEqual("SelectBox", _privateModel.GetFieldOrProperty("_currentShapeType"));
            _model.SetState("Triangle");
            Assert.AreEqual("Triangle", _privateModel.GetFieldOrProperty("_currentShapeType"));
        }

        [TestMethod()]
        public void TestSetStateDrawing()
        {
            _model.SetStateDrawing("Rectangle");
            AbstractState state = (AbstractState)_privateModel.GetFieldOrProperty("_stateHandler");
            Assert.AreEqual("Drawing", state.GetStateType());
            Assert.AreEqual("Rectangle", _privateModel.GetFieldOrProperty("_currentShapeType"));
        }

        [TestMethod()]
        public void TestSetStateLine()
        {
            _model.SetStateLine();
            AbstractState state = (AbstractState)_privateModel.GetFieldOrProperty("_stateHandler");
            Assert.AreEqual("Line", state.GetStateType());
            Assert.AreEqual("Line", _privateModel.GetFieldOrProperty("_currentShapeType"));
        }

        [TestMethod()]
        public void TestSetState()
        {
            _model.SetState("Triangle");
            Assert.AreEqual("Triangle", _privateModel.GetFieldOrProperty("_currentShapeType"));
            Assert.AreEqual(false, _privateModel.GetFieldOrProperty("_isSelected"));
            Assert.AreEqual("", _model.GetSelectLabelText());
        }

        [TestMethod()]
        public void TestPressedPointer()
        {
            _model.PressedPointer(-1, -1);
            Assert.IsNull(_privateModel.GetFieldOrProperty("_hint"));
            _model.ResetState();
            _model.PressedPointer(10, 6);
            Assert.AreEqual(false, _privateModel.GetFieldOrProperty("_isPressed"));
            Assert.AreEqual(false, _privateModel.GetFieldOrProperty("_isSelected"));
            _model.SetStateDrawing("Rectangle");
            _model.PressedPointer(10, 6);
            AbstractShape rectangle = new Rectangle();
            rectangle.SetPoints(0, 0, 100, 100);
            _model.DrawShape(rectangle);
            _model.ResetState();
            _model.PressedPointer(10, 6);
            Assert.AreEqual(true, _privateModel.GetFieldOrProperty("_isSelected"));
        }

        //// TestMovedPointer
        [TestMethod()]
        public void TestMovedPointer()
        {
            _model.MovedPointer(1, 1);
            Assert.AreEqual(false, _privateModel.GetFieldOrProperty("_isPressed"));
            _model.SetStateDrawing("Triangle");
            _model.PressedPointer(1, 5);
            _model.MovedPointer(10, 10);
            Assert.AreEqual(true, _privateModel.GetFieldOrProperty("_isPressed"));
            AbstractShape shape = (AbstractShape)_privateModel.GetFieldOrProperty("_hint");
            Assert.AreEqual(10, shape.X2);
            Assert.AreEqual(10, shape.Y2);
        }

        // TestReleasedPointer
        [TestMethod()]
        public void TestReleasedPointer()
        {
            _model.ReleasedPointer(10, 10);
            Assert.AreEqual("SelectBox", _privateModel.GetFieldOrProperty("_currentShapeType"));
            _model.SetStateLine();
            AbstractShape rectangle = new Rectangle();
            rectangle.SetPoints(0, 0, 100, 100);
            _model.DrawShape(rectangle);
            _model.PressedPointer(1, 1);
            _model.ReleasedPointer(10, 10);
            Assert.AreEqual("Line", _privateModel.GetFieldOrProperty("_currentShapeType"));
            _model.SetStateDrawing("Triangle");
            _model.PressedPointer(7, 11);
            _model.MovedPointer(54, 87);
            Assert.AreEqual("Triangle", _privateModel.GetFieldOrProperty("_currentShapeType"));
            _model.ReleasedPointer(115, 48);
            Assert.AreEqual("SelectBox", _privateModel.GetFieldOrProperty("_currentShapeType"));
            _model.PressedPointer(50, 50);
            _model.ReleasedPointer(50, 50);
            Assert.AreEqual("SelectBox", _privateModel.GetFieldOrProperty("_currentShapeType"));
        }

        // TestClear
        [TestMethod()]
        public void TestClear()
        {
            _model.SetState("Rectangle");
            Assert.AreEqual("Rectangle", _privateModel.GetFieldOrProperty("_currentShapeType"));
            _model.Clear();
            Assert.AreEqual(false, _privateModel.GetFieldOrProperty("_isPressed"));
            Assert.AreEqual(false, _privateModel.GetFieldOrProperty("_isSelected"));
            Assert.AreEqual("", _model.GetSelectLabelText());
            Assert.AreEqual("SelectBox", _privateModel.GetFieldOrProperty("_currentShapeType"));
        }

        // TestResetCurrentShape
        [TestMethod()]
        public void TestResetState()
        {
            _model.SetState("Triangle");
            Assert.AreEqual("Triangle", _privateModel.GetFieldOrProperty("_currentShapeType"));
            _model.ResetState();
            Assert.AreEqual("SelectBox", _privateModel.GetFieldOrProperty("_currentShapeType"));
            Assert.AreEqual(false, _privateModel.GetFieldOrProperty("_isPressed"));
        }

        // TestPaintOn
        [TestMethod()]
        public void TestPaintOn()
        {
            _model.SetStateDrawing("Rectangle");
            _model.PressedPointer(7, 11);
            _model.MovedPointer(54, 87);
            _model.PaintOn(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.PreviewRectangle(7, 11, 54, 87));
            _model.ReleasedPointer(115, 48);
            _model.PaintOn(_mockGraphicsInterface.Object);
            _mockGraphicsInterface.Verify(obj => obj.DrawRectangle(7, 11, 115, 48));
        }

        // TestNotifyModelChanged
        [TestMethod()]
        public void TestNotifyModelChanged()
        {
            _model.SetState("Rectangle");
            _model.NotifyModelChanged();
            Assert.AreEqual("Rectangle", _privateModel.GetFieldOrProperty("_currentShapeType"));
            _model._modelChanged += delegate
            {
                _model.ResetState();
            };
            _model.NotifyModelChanged();
            Assert.AreEqual("SelectBox", _privateModel.GetFieldOrProperty("_currentShapeType"));
        }

        [TestMethod()]
        public void TestDrawShape()
        {
            Shapes shapes = (Shapes)_privateModel.GetFieldOrProperty("_shapes");
            PrivateObject privateShapes = new PrivateObject(shapes);
            List<AbstractShape> abstractShapes = (List<AbstractShape>)privateShapes.GetFieldOrProperty("_shapes");
            AbstractShape shape = new Triangle();
            Assert.AreEqual(0, abstractShapes.Count);
            _model.DrawShape(shape);
            Assert.AreEqual(1, abstractShapes.Count);

        }

        [TestMethod()]
        public void TestDeleteShape()
        {
            Shapes shapes = (Shapes)_privateModel.GetFieldOrProperty("_shapes");
            PrivateObject privateShapes = new PrivateObject(shapes);
            List<AbstractShape> abstractShapes = (List<AbstractShape>)privateShapes.GetFieldOrProperty("_shapes");
            AbstractShape shape = new Triangle();
            Assert.AreEqual(0, abstractShapes.Count);
            _model.DrawShape(shape);
            Assert.AreEqual(1, abstractShapes.Count);
            _model.DeleteShape();
            Assert.AreEqual(0, abstractShapes.Count);
        }

        [TestMethod()]
        public void TestUndo()
        {
            _model.SetStateDrawing("Rectangle");
            _model.PressedPointer(1, 1);
            _model.ReleasedPointer(10, 10);
            _model.PressedPointer(6, 6);
            _model.ReleasedPointer(6, 6);
            Assert.AreEqual(true, _privateModel.GetFieldOrProperty("_isSelected"));
            Assert.AreEqual("Select：Rectangle(1, 1, 10, 10)", _model.GetSelectLabelText());
            _model.Undo();
            Assert.AreEqual(false, _privateModel.GetFieldOrProperty("_isSelected"));
            Assert.AreEqual("", _model.GetSelectLabelText());
        }

        [TestMethod()]
        public void TestRedo()
        {
            _model.SetStateDrawing("Rectangle");
            _model.PressedPointer(1, 1);
            _model.ReleasedPointer(10, 10);
            _model.Undo();
            _model.PressedPointer(6, 6);
            _model.ReleasedPointer(6, 6);
            Assert.IsTrue(_model.IsRedoEnabled);
            Assert.AreEqual(false, _privateModel.GetFieldOrProperty("_isSelected"));
            Assert.AreEqual("", _model.GetSelectLabelText());
            _model.Redo();
            Assert.IsTrue(_model.IsUndoEnabled);
            _model.PressedPointer(6, 6);
            _model.ReleasedPointer(6, 6);
            Assert.AreEqual(true, _privateModel.GetFieldOrProperty("_isSelected"));
            Assert.AreEqual("Select：Rectangle(1, 1, 10, 10)", _model.GetSelectLabelText());

        }

        [TestMethod()]
        public void TestGetSelectLabelText()
        {
            AbstractShape rectangle = new Rectangle();
            rectangle.SetPoints(0, 0, 100, 100);
            _model.DrawShape(rectangle);
            Assert.AreEqual("", _model.GetSelectLabelText());
            _model.PressedPointer(50, 50);
            Assert.AreEqual("Select：Rectangle(0, 0, 100, 100)", _model.GetSelectLabelText());
        }

        [TestMethod()]
        public void TestHandleShapeToolButtonClick()
        {
            AbstractShape rectangle = new Rectangle();
            rectangle.SetPoints(0, 0, 100, 100);
            _model.DrawShape(rectangle);
            _model.PressedPointer(50, 50);
            Assert.AreEqual(true, _privateModel.GetFieldOrProperty("_isSelected"));
            _model.HandleShapeToolButtonClick();
            Assert.AreEqual(null, _privateModel.GetFieldOrProperty("_hint"));
            Assert.AreEqual(false, _privateModel.GetFieldOrProperty("_isSelected"));
        }

        [TestMethod()]
        public void TestUpdateHintText()
        {
            AbstractShape rectangle = new Rectangle();
            rectangle.SetPoints(0, 0, 100, 100);
            _model.DrawShape(rectangle);
            Assert.AreEqual("", _model.GetSelectLabelText());
            _model.PressedPointer(50, 50);
            Assert.AreEqual("Select：Rectangle(0, 0, 100, 100)", _model.GetSelectLabelText());
        }

        [TestMethod()]
        public void TestIsStateKeep()
        {
            Assert.IsFalse(_model.IsStateKeep());
            _model.SetStateLine();
            _model.PressedPointer(5, 5);
            Assert.IsTrue(_model.IsStateKeep());
        }











    }
}