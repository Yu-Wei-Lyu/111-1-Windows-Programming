using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm109590004
{
    public partial class DrawingForm : Form
    {
        DrawingModel109590004.Model _model;
        Presentation.FormPresentationModel _presentationModel;
        Panel _canvas = new DoubleBufferedPanel();
        private const int BUTTON_FONT_SIZE = 18;
        private Button _clear;
        private Button _rectangle;
        private Button _triangle;

        public DrawingForm()
        {
            InitializeComponent();
            //
            // prepare canvas
            //
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = System.Drawing.Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);
            //
            // prepare clear button
            //
            _clear = new Button();
            _clear.Text = "Clear";
            _clear.Font = new Font(_clear.Font.FontFamily, BUTTON_FONT_SIZE);
            _clear.AutoSize = true;
            _clear.UseVisualStyleBackColor = true;
            _clear.Click += HandleClearButtonClick;
            //
            // prepare rectangle button
            //
            _rectangle = new Button();
            _rectangle.Text = "Rectangle";
            _rectangle.Font = new Font(_rectangle.Font.FontFamily, BUTTON_FONT_SIZE);
            _rectangle.AutoSize = true;
            _rectangle.UseVisualStyleBackColor = true;
            _rectangle.Click += HandleClearButtonClick;
            //
            // prepare rectangle button
            //
            _triangle = new Button();
            _triangle.Text = "Triangle";
            _triangle.Font = new Font(_triangle.Font.FontFamily, BUTTON_FONT_SIZE);
            _triangle.AutoSize = true;
            _triangle.Dock = DockStyle.Top;
            int x = _triangle.Size.Width; 
            int y = _triangle.Size.Height;
            _triangle.AutoSize = false;
            _triangle.Size = new Size(x, y);
            _triangle.UseVisualStyleBackColor = true;
            _triangle.LocationChanged += ButtonLocationChanged;
            _triangle.Click += HandleClearButtonClick;
            //
            // prepare table layout panel
            //
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Top;
            //flowLayoutPanel.AutoSize = true;
            int formWidth = this.Width;
            int padding = formWidth / 8;
            flowLayoutPanel.Padding = new Padding(padding, 0, padding, 0);
            //flowLayoutPanel.BackColor = _canvas.BackColor;
            flowLayoutPanel.Controls.Add(_rectangle);
            //flowLayoutPanel.Controls.Add(_triangle);
            flowLayoutPanel.Controls.Add(_clear);
            Controls.Add(flowLayoutPanel);
            

            _model = new DrawingModel109590004.Model();
            _presentationModel = new Presentation.FormPresentationModel(_model, _canvas);
            _model._modelChanged += HandleModelChanged;
        }

        void ButtonLocationChanged(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            //btn.Location = new Point(btn.Location.X, btn.Location.Y + 5);
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

        private void DrawingForm_Resize(object sender, EventArgs e)
        {
            if (_clear != null)
                _clear.Size = new Size(this.Width / 8, _clear.Size.Height);
            if (_triangle != null)
                _triangle.Size = new Size(this.Width / 16, _triangle.Size.Height);
            if (_rectangle != null)
                _rectangle.Size = new Size(this.Width / 16, _rectangle.Size.Height);
        }
    }
}
