
namespace DrawingForm
{
    partial class DrawingForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
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
            this._hintLabel.Font = new System.Drawing.Font("新細明體", 12F);
            this._hintLabel.Location = new System.Drawing.Point(490, 461);
            this._hintLabel.Name = "_hintLabel";
            this._hintLabel.Size = new System.Drawing.Size(0, 16);
            this._hintLabel.TabIndex = 1;
            this._hintLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(755, 486);
            this.Controls.Add(this._hintLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DrawingForm";
            this.Text = "Draw";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _hintLabel;
    }
}

