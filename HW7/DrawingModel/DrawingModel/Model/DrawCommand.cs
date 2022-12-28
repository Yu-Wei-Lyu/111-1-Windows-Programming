using System;
using System.Drawing;

namespace DrawingModel
{
    public class DrawCommand : ICommand
    {
        AbstractShape _shape;
        Model _model;

        public DrawCommand(Model model, AbstractShape shape)
        {
            _shape = shape;
            _model = model;
        }

        // Execute
        public void Execute()
        {
            _model.DrawShape(_shape);
        }

        // UndoExecute
        public void UndoExecute()
        {
            _model.DeleteShape();
        }
    }
}
