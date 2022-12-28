using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrawingModel
{
    public class CommandManager
    {
        private Stack<ICommand> _undo = new Stack<ICommand>();
        private Stack<ICommand> _redo = new Stack<ICommand>();

        // Execute
        public void Execute(ICommand command)
        {
            command.Execute();
            _undo.Push(command);
            _redo.Clear();
        }

        // ClearAll
        public void ClearAll()
        {
            _undo.Clear();
            _redo.Clear();
        }

        // Undo
        public void Undo()
        {
            ICommand command = _undo.Pop();
            _redo.Push(command);
            command.UndoExecute();
        }

        // Redo
        public void Redo()
        {
            ICommand command = _redo.Pop();
            _undo.Push(command);
            command.Execute();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _redo.Count != 0;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _undo.Count != 0;
            }
        }
    }
}
