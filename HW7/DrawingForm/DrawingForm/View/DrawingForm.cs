using DrawingForm.Presentation;
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
        DoubleBufferedPanel _canvas;
        DrawingModel.Model _model;
        Presentation.FormPresentationModel _presentationModel;
        ToolStripButton undo;
        ToolStripButton redo;

        public DrawingForm()
        {
            _canvas = new DoubleBufferedPanel();
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = Color.LightYellow;
            Controls.Add(_canvas);
            InitializeComponent();
            this.MinimumSize = new Size(_clearToolButton.Width * 3 + 100, _clearToolButton.Height);

            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;

            _clearToolButton.Click += HandleClearButtonClick;
            _rectangleToolButton.Click += HandleRectangleButtonClick;
            _triangleToolButton.Click += HandleTriangleButtonClick;

            _model = new DrawingModel.Model();
            _presentationModel = new Presentation.FormPresentationModel(_model);
            _model._modelChanged += RefreshUI;

            ToolStrip ts = new ToolStrip();
            ts.Parent = this;
            undo = new ToolStripButton("Undo", null, UndoHandler);
            undo.Enabled = false;
            ts.Items.Add(undo);
            redo = new ToolStripButton("Redo", null, RedoHandler);
            redo.Enabled = false;
            ts.Items.Add(redo);

            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        // HandleClearButtonClick
        public void HandleRectangleButtonClick(object sender, EventArgs e)
        {
            _model.SetShapeType("Rectangle");
            _rectangleToolButton.Enabled = false;
            _triangleToolButton.Enabled = true;
        }

        // HandleClearButtonClick
        public void HandleTriangleButtonClick(object sender, EventArgs e)
        {
            _model.SetShapeType("Triangle");
            _rectangleToolButton.Enabled = true;
            _triangleToolButton.Enabled = false;
        }

        // HandleClearButtonClick
        public void HandleClearButtonClick(object sender, EventArgs e)
        {
            _model.Clear();
            _rectangleToolButton.Enabled = true;
            _triangleToolButton.Enabled = true;
        }

        // HandleCanvasPressed
        public void HandleCanvasPressed(object sender, MouseEventArgs e)
        {
            _model.PressedPointer(e.X, e.Y);
        }

        // HandleCanvasReleased
        public void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            _model.ReleasedPointer(e.X, e.Y);
            _rectangleToolButton.Enabled = true;
            _triangleToolButton.Enabled = true;
        }

        // HandleCanvasMoved
        public void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            _model.MovedPointer(e.X, e.Y);
        }

        // HandleCanvasPaint
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(new WindowsFormsGraphicsAdaptor(e.Graphics));
        }

        // HandleModelChanged
        public void RefreshUI()
        {
            redo.Enabled = _model.IsRedoEnabled;
            undo.Enabled = _model.IsUndoEnabled;
            Invalidate(true);
        }

        public void UndoHandler(Object sender, EventArgs e)
        {
            _model.Undo();
        }
        public void RedoHandler(Object sender, EventArgs e)
        {
            _model.Redo();
        }
    }
}
