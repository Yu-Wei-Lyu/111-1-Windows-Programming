using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using DrawingModel;

namespace DrawingApp.PresentationModel
{
    public class StoreAppPresentationModel
    {
        Model _model;

        public StoreAppPresentationModel(Model model)
        {
            this._model = model;
        }

        // Draw
        public void Draw(IGraphics graphics)
        {
            // 重複使用igraphics物件
            _model.PaintOn(graphics);
        }
    }
}
