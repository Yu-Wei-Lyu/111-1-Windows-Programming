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
    public partial class TestForm : Form
    {
        private const string ENABLED = "Enabled";
        
        private DrawingModel.Model _model;
        private FormPresentationModel _presentationModel;
        private ToolStripButton _undo;
        private ToolStripButton _redo;
        private TableLayoutPanel _toolButtonPanel;
        private Button _rectangleToolButton;
        private Button _lineToolButton;
        private Button _triangleToolButton;
        private Button _clearToolButton;
        private DoubleBufferedPanel _canvas;

        public TestForm()
        {
            _model = new DrawingModel.Model();
            _presentationModel = new Presentation.FormPresentationModel(_model);
            _model._modelChanged += RefreshForm;

            InitializeComponent();

            _canvas = new DoubleBufferedPanel();
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);

            _rectangleToolButton = this.CreateButton();
            _rectangleToolButton.Dock = DockStyle.Fill;
            _rectangleToolButton.Text = "Rectangle";

            _lineToolButton = this.CreateButton();
            _lineToolButton.Dock = DockStyle.Fill;
            _lineToolButton.Text = "Line";

            _triangleToolButton = this.CreateButton();
            _triangleToolButton.Dock = DockStyle.Fill;
            _triangleToolButton.Text = "Triangle";

            _clearToolButton = this.CreateButton();
            _clearToolButton.Dock = DockStyle.Fill;
            _clearToolButton.Text = "Clear";

            _toolButtonPanel = new TableLayoutPanel();
            _toolButtonPanel.ColumnCount = 9;
            for (int i = 0; i < 9; i++)
            {
                if (i % 2 == 0)
                    _toolButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent, 20F));
                else
                    _toolButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            }
            _toolButtonPanel.Controls.Add(_rectangleToolButton, 1, 0);
            _toolButtonPanel.Controls.Add(_lineToolButton, 3, 0);
            _toolButtonPanel.Controls.Add(_triangleToolButton, 5, 0);
            _toolButtonPanel.Controls.Add(_clearToolButton, 7, 0);
            _toolButtonPanel.Location = new Point(0, 0);
            _toolButtonPanel.Dock = DockStyle.Top;
            _toolButtonPanel.BackColor = SystemColors.Control;
            Controls.Add(_toolButtonPanel);

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

            this.MinimumSize = new Size(_clearToolButton.Width * _toolButtonPanel.ColumnCount / 2 + 15, this.Size.Height);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        // HandleClearButtonClick
        public void HandleRectangleButtonClick(object sender, EventArgs e)
        {
            _model.SetStateDrawing(((Button)sender).Text);
            _presentationModel.HandleRectangleButtonClick();
        }

        // HandleLineButtonClick
        public void HandleLineButtonClick(object sender, EventArgs e)
        {
            _model.SetStateLine();
            _presentationModel.HandleLineButtonClick();
        }

        // HandleClearButtonClick
        public void HandleTriangleButtonClick(object sender, EventArgs e)
        {
            _model.SetStateDrawing(((Button)sender).Text);
            _presentationModel.HandleTriangleButtonClick();
        }

        // HandleClearButtonClick
        public void HandleClearButtonClick(object sender, EventArgs e)
        {
            _model.Clear();
            _presentationModel.HandleClearButtonClick();
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
            _presentationModel.SetToDefaultButtonEnabled();
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
            _hintLabel.Text = _model.GetSelectLabelText();
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

        // ButtonCreate
        public Button CreateButton()
        {
            Button button = new Button();
            button.Dock = DockStyle.Fill;
            button.Font = new Font("新細明體", 16F);
            button.UseVisualStyleBackColor = true;
            return button;
        }
    }
}
