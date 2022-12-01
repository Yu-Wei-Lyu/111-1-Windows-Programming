using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class DrawingForm : Form
    {
        DrawingModel.Model _model;
        Presentation.FormPresentationModel _presentationModel;

        public DrawingForm()
        {
            InitializeComponent();
            this.MinimumSize = new Size(_clearToolButton.Width * 3 + 100, _clearToolButton.Height);

            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;

            _clearToolButton.Click += HandleClearButtonClick;

            _model = new DrawingModel.Model();
            _presentationModel = new Presentation.FormPresentationModel(_model, _canvas);
            _model._modelChanged += HandleModelChanged;
        }

        // HandleClearButtonClick
        public void HandleRectangleButtonClick(object sender, System.EventArgs e)
        {
            _model.SetShapeType("Rectangle");
        }

        // HandleClearButtonClick
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _model.Clear();
        }

        // HandleCanvasPressed
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.PressedPointer(e.X, e.Y);
        }

        // HandleCanvasReleased
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.ReleasedPointer(e.X, e.Y);
        }

        // HandleCanvasMoved
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.MovedPointer(e.X, e.Y);
        }

        // HandleCanvasPaint
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        // HandleModelChanged
        public void HandleModelChanged()
        {
            Invalidate(true);
        }

    }
}
