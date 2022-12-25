
namespace DrawingForm
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._hintLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _hintLabel
            // 
            this._hintLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._hintLabel.AutoSize = true;
            this._hintLabel.Location = new System.Drawing.Point(404, 339);
            this._hintLabel.Name = "_hintLabel";
            this._hintLabel.Size = new System.Drawing.Size(0, 12);
            this._hintLabel.TabIndex = 0;
            this._hintLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this._hintLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _hintLabel;
    }
}