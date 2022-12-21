﻿
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
            this._toolBarPanel = new System.Windows.Forms.TableLayoutPanel();
            this._rectangleToolButton = new System.Windows.Forms.Button();
            this._triangleToolButton = new System.Windows.Forms.Button();
            this._clearToolButton = new System.Windows.Forms.Button();
            this._lineToolButton = new System.Windows.Forms.Button();
            this._selectHintLabel = new System.Windows.Forms.Label();
            this._toolBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _toolBarPanel
            // 
            this._toolBarPanel.BackColor = System.Drawing.SystemColors.Control;
            this._toolBarPanel.ColumnCount = 9;
            this._toolBarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._toolBarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this._toolBarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._toolBarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this._toolBarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._toolBarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this._toolBarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._toolBarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this._toolBarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._toolBarPanel.Controls.Add(this._rectangleToolButton, 1, 0);
            this._toolBarPanel.Controls.Add(this._triangleToolButton, 5, 0);
            this._toolBarPanel.Controls.Add(this._clearToolButton, 7, 0);
            this._toolBarPanel.Controls.Add(this._lineToolButton, 3, 0);
            this._toolBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._toolBarPanel.Location = new System.Drawing.Point(0, 0);
            this._toolBarPanel.Name = "_toolBarPanel";
            this._toolBarPanel.RowCount = 1;
            this._toolBarPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._toolBarPanel.Size = new System.Drawing.Size(755, 100);
            this._toolBarPanel.TabIndex = 1;
            // 
            // _rectangleToolButton
            // 
            this._rectangleToolButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rectangleToolButton.Font = new System.Drawing.Font("新細明體", 16F);
            this._rectangleToolButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._rectangleToolButton.Location = new System.Drawing.Point(34, 15);
            this._rectangleToolButton.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this._rectangleToolButton.Name = "_rectangleToolButton";
            this._rectangleToolButton.Size = new System.Drawing.Size(144, 82);
            this._rectangleToolButton.TabIndex = 0;
            this._rectangleToolButton.Text = "Rectangle";
            this._rectangleToolButton.UseVisualStyleBackColor = true;
            // 
            // _triangleToolButton
            // 
            this._triangleToolButton.BackColor = System.Drawing.Color.LightYellow;
            this._triangleToolButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._triangleToolButton.Font = new System.Drawing.Font("新細明體", 16F);
            this._triangleToolButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._triangleToolButton.Location = new System.Drawing.Point(396, 15);
            this._triangleToolButton.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this._triangleToolButton.Name = "_triangleToolButton";
            this._triangleToolButton.Size = new System.Drawing.Size(144, 82);
            this._triangleToolButton.TabIndex = 1;
            this._triangleToolButton.Text = "Triangle";
            this._triangleToolButton.UseVisualStyleBackColor = true;
            // 
            // _clearToolButton
            // 
            this._clearToolButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._clearToolButton.Font = new System.Drawing.Font("新細明體", 16F);
            this._clearToolButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._clearToolButton.Location = new System.Drawing.Point(577, 15);
            this._clearToolButton.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this._clearToolButton.Name = "_clearToolButton";
            this._clearToolButton.Size = new System.Drawing.Size(144, 82);
            this._clearToolButton.TabIndex = 2;
            this._clearToolButton.Text = "Clear";
            this._clearToolButton.UseVisualStyleBackColor = true;
            // 
            // _lineToolButton
            // 
            this._lineToolButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lineToolButton.Font = new System.Drawing.Font("新細明體", 16F);
            this._lineToolButton.Location = new System.Drawing.Point(215, 15);
            this._lineToolButton.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this._lineToolButton.Name = "_lineToolButton";
            this._lineToolButton.Size = new System.Drawing.Size(144, 82);
            this._lineToolButton.TabIndex = 3;
            this._lineToolButton.Text = "Line";
            this._lineToolButton.UseVisualStyleBackColor = true;
            // 
            // _selectHintLabel
            // 
            this._selectHintLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._selectHintLabel.AutoSize = true;
            this._selectHintLabel.Location = new System.Drawing.Point(552, 475);
            this._selectHintLabel.Name = "_selectHintLabel";
            this._selectHintLabel.Size = new System.Drawing.Size(44, 12);
            this._selectHintLabel.TabIndex = 2;
            this._selectHintLabel.Text = "Select：";
            // 
            // DrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(755, 496);
            this.Controls.Add(this._selectHintLabel);
            this.Controls.Add(this._toolBarPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DrawingForm";
            this.Text = "Draw";
            this._toolBarPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel _toolBarPanel;
        private System.Windows.Forms.Button _rectangleToolButton;
        private System.Windows.Forms.Button _triangleToolButton;
        private System.Windows.Forms.Button _clearToolButton;
        private System.Windows.Forms.Button _lineToolButton;
        private System.Windows.Forms.Label _selectHintLabel;
    }
}

