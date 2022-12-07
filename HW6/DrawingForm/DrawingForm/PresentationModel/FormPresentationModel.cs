using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel;
using System.Windows.Forms;
using System.Drawing;

namespace DrawingForm.Presentation
{
    public class FormPresentationModel
    {
        Model _model;
        public FormPresentationModel(Model model)
        {
            this._model = model;
        }

        // Draw
        public void Draw(IGraphics graphics)
        {
            _model.PaintOn(graphics);
        }

    }
}
