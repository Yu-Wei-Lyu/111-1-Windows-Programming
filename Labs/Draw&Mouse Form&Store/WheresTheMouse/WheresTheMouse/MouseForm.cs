using System.Windows.Forms;
using System.Drawing;
using System;

namespace WheresTheMouse
{
	class MouseForm : Form
	{
		protected int WINDOW_WIDTH = 400;
		protected int WINDOW_HEIGHT = 400;
		protected int BALL_SIZE = 50;
		protected int _clickX = -1;
		protected int _clickY = -1;
		protected int _movement = 0;
		protected bool _clicked = false;
		protected String _message = "Where is the mouse?";

		public MouseForm()
		{
			Text = _message;
			SetClientSizeCore(640, 480);
			// Listen to mouse clicked and moved events
			MouseClick += new MouseEventHandler(MouseClicked);
			MouseMove += new MouseEventHandler(MouseMoved);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics g = e.Graphics;
			Font font = new Font("Times New Roman", 12.0f, FontStyle.Bold);
			using (font)
			{
				// Show the location if the mouse clicked on somewhere
				if (_clicked)
				{
					g.DrawEllipse(Pens.Blue, _clickX - 2, _clickY - 2, 4, 4);
					g.DrawEllipse(Pens.Blue, _clickX - 5, _clickY - 5, 10, 10);
					g.DrawEllipse(Pens.Blue, _clickX - 8, _clickY - 8, 16, 16);
					g.DrawString(_message, font, Brushes.Blue, _clickX, _clickY);
				}
				// Oops! The mouse disappeared!
				else
				{
					SizeF size = g.MeasureString(_message, font);
					int x = (int)(ClientSize.Width - size.Width) / 2;
					int y = (int)(ClientSize.Height - size.Height) / 2;
					g.DrawString(_message, font, Brushes.Red, x, y);
				}
			}

		}

		private void MouseClicked(object sender, MouseEventArgs e)
		{
			_clickX = e.X;
			_clickY = e.Y;
			_message = "(" + _clickX + ", " + _clickY + ")!";
			_clicked = true;
			Invalidate();
		}

		private void MouseMoved(object sender, MouseEventArgs e)
		{
			_movement = Math.Abs(e.X - _clickX) + Math.Abs(e.Y - _clickY);
			if (_movement > 75)
			{
				_clicked = false;
				_message = "Where is the mouse?";
				Invalidate();
			}
		}


	}
}

