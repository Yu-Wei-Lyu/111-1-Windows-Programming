using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrawingModel
{
    public interface ICommand
    {
        // Execute
        void Execute();

        // UndoExecute
        void UndoExecute();
    }
}
