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
        private const string ENABLED = "Enabled";
        private DoubleBufferedPanel _canvas;
        private DrawingModel.Model _model;
        private Presentation.FormPresentationModel _presentationModel;
        private ToolStripButton _undo;
        private ToolStripButton _redo;

        public DrawingForm()
        {
            _model = new DrawingModel.Model();
            _presentationModel = new Presentation.FormPresentationModel(_model);
            _model._modelChanged += RefreshForm;
            InitializeComponent();
            _selectHintLabel.Text = "";
            this.MinimumSize = new Size(_clearToolButton.Width * _toolBarPanel.Controls.Count + 100, _clearToolButton.Height);
            _canvas = new DoubleBufferedPanel();
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = Color.LightYellow;
            Controls.Add(_canvas);
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;

            _rectangleToolButton.Click += HandleRectangleButtonClick;
            _rectangleToolButton.DataBindings.Add(ENABLED, _presentationModel, "IsRectangleButtonEnabled");
            _lineToolButton.Click += HandleLineButtonClick;
            _lineToolButton.DataBindings.Add(ENABLED, _presentationModel, "IsLineButtonEnabled");
            _triangleToolButton.Click += HandleTriangleButtonClick;
            _triangleToolButton.DataBindings.Add(ENABLED, _presentationModel, "IsTriangleButtonEnabled");
            _clearToolButton.Click += HandleClearButtonClick;

            ToolStrip toolStrip = new ToolStrip();
            toolStrip.Parent = this;
            _undo = new ToolStripButton("Undo", null, UndoHandler);
            _undo.Enabled = false;
            toolStrip.Items.Add(_undo);
            _redo = new ToolStripButton("Redo", null, RedoHandler);
            _redo.Enabled = false;
            toolStrip.Items.Add(_redo);

            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        // HandleClearButtonClick
        public void HandleRectangleButtonClick(object sender, EventArgs e)
        {
            _model.SetState(((Button)sender).Text);
            _presentationModel.HandleRectangleButtonClick();
        }

        // HandleLineButtonClick
        public void HandleLineButtonClick(object sender, EventArgs e)
        {
            _model.SetState(((Button)sender).Text);
            _presentationModel.HandleLineButtonClick();
        }

        // HandleClearButtonClick
        public void HandleTriangleButtonClick(object sender, EventArgs e)
        {
            _model.SetState(((Button)sender).Text);
            _presentationModel.HandleTriangleButtonClick();
        }

        // HandleClearButtonClick
        public void HandleClearButtonClick(object sender, EventArgs e)
        {
            _model.Clear();
            _presentationModel.ClearButtonClick();
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
        public void RefreshForm()
        {
            _redo.Enabled = _model.IsRedoEnabled;
            _undo.Enabled = _model.IsUndoEnabled;
            _selectHintLabel.Text = _model.GetSelectLabelText();
            Invalidate(true);
        }

        // UndoHandler
        public void UndoHandler(object sender, EventArgs e)
        {
            _model.Undo();
        }

        // RedoHandler
        public void RedoHandler(object sender, EventArgs e)
        {
            _model.Redo();
        }
    }
}
