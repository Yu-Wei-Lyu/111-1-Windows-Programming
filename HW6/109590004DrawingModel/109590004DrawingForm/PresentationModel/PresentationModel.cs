﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel109590004;
using System.Windows.Forms;

namespace DrawingForm109590004.Presentation
{
    class FormPresentationModel
    {
        Model _model;
        public FormPresentationModel(Model model, Control canvas)
        {
            this._model = model;
        }

        // Draw
        public void Draw(System.Drawing.Graphics graphics)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
            // 因此，Adaptor不能重複使用，每次都要重新new
            _model.Draw(new WindowsFormsGraphicsAdaptor(graphics));
        }

    }
}
