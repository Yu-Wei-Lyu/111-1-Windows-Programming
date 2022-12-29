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
    public class CommandManagerTests
    {
        CommandManager _commandManager;
        PrivateObject _privateCommandManager;
        Mock<ICommand> _mockCommand;
        Stack<ICommand> _undoStack;
        Stack<ICommand> _redoStack;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _commandManager = new CommandManager();
            _privateCommandManager = new PrivateObject(_commandManager);
            _mockCommand = new Mock<ICommand>();
            _undoStack = (Stack<ICommand>)_privateCommandManager.GetFieldOrProperty("_undo");
            _redoStack = (Stack<ICommand>)_privateCommandManager.GetFieldOrProperty("_redo");
        }

        // TestMethod
        [TestMethod()]
        public void TestExecute()
        {
            _commandManager.Execute(_mockCommand.Object);
            _mockCommand.Verify(obj => obj.Execute());
            Assert.AreEqual(0, _redoStack.Count);
            Assert.AreEqual(1, _undoStack.Count);
            Assert.IsTrue(_commandManager.IsUndoEnabled);
        }

        // TestMethod
        [TestMethod()]
        public void TestClearAll()
        {
            _commandManager.Execute(_mockCommand.Object);
            Assert.AreEqual(1, _undoStack.Count);
            Assert.IsTrue(_commandManager.IsUndoEnabled);
            _commandManager.ClearAll();
            Assert.AreEqual(0, _redoStack.Count);
            Assert.AreEqual(0, _undoStack.Count);
            Assert.IsFalse(_commandManager.IsRedoEnabled);
            Assert.IsFalse(_commandManager.IsUndoEnabled);
        }

        // TestMethod
        [TestMethod()]
        public void TestUndo()
        {
            _commandManager.Execute(_mockCommand.Object);
            _commandManager.Execute(_mockCommand.Object);
            Assert.AreEqual(2, _undoStack.Count);
            Assert.AreEqual(0, _redoStack.Count);
            _commandManager.Undo();
            Assert.AreEqual(1, _undoStack.Count);
            Assert.AreEqual(1, _redoStack.Count);
        }

        // TestMethod
        [TestMethod()]
        public void TestRedo()
        {
            _commandManager.Execute(_mockCommand.Object);
            _commandManager.Execute(_mockCommand.Object);
            _commandManager.Undo();
            Assert.AreEqual(1, _undoStack.Count);
            Assert.AreEqual(1, _redoStack.Count);
            _commandManager.Redo();
            Assert.AreEqual(2, _undoStack.Count);
            Assert.AreEqual(0, _redoStack.Count);
        }
    }
}