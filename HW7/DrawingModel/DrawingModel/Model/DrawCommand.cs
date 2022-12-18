using System;
using System.Drawing;

namespace DrawingModel
{
    class DrawCommand : ICommand
    {
        IShape _shape;
        Model _model;
        public DrawCommand(Model model, IShape shape)
        {
            _shape = shape;
            _model = model;
        }

        public void Execute()
        {
            _model.DrawShape(_shape);
        }

        public void UnExecute()
        {
            _model.DeleteShape();
        }
    }
}
