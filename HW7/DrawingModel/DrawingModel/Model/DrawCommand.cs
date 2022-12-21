﻿using System;
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
