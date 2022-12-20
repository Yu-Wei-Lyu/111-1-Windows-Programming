using System;
using System.Drawing;

namespace DrawingModel
{
    class DrawCommand : ICommand
    {
        Shape _shape;
        Model _model;
        public DrawCommand(Model model, Shape shape)
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
