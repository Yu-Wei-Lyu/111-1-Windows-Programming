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
            this._canvas = new DoubleBufferedPanel();
            this._toolBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _toolBarPanel
            // 
            this._toolBarPanel.BackColor = System.Drawing.Color.LightYellow;
            this._toolBarPanel.ColumnCount = 7;
            this._toolBarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._toolBarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this._toolBarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._toolBarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this._toolBarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._toolBarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this._toolBarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._toolBarPanel.Controls.Add(this._rectangleToolButton, 1, 0);
            this._toolBarPanel.Controls.Add(this._triangleToolButton, 3, 0);
            this._toolBarPanel.Controls.Add(this._clearToolButton, 5, 0);
            this._toolBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._toolBarPanel.Location = new System.Drawing.Point(0, 0);
            this._toolBarPanel.Margin = new System.Windows.Forms.Padding(4);
            this._toolBarPanel.Name = "_toolBarPanel";
            this._toolBarPanel.RowCount = 1;
            this._toolBarPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._toolBarPanel.Size = new System.Drawing.Size(1007, 125);
            this._toolBarPanel.TabIndex = 1;
            // 
            // _rectangleToolButton
            // 
            this._rectangleToolButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rectangleToolButton.Font = new System.Drawing.Font("新細明體", 16F);
            this._rectangleToolButton.Location = new System.Drawing.Point(105, 19);
            this._rectangleToolButton.Margin = new System.Windows.Forms.Padding(4, 19, 4, 4);
            this._rectangleToolButton.Name = "_rectangleToolButton";
            this._rectangleToolButton.Size = new System.Drawing.Size(192, 102);
            this._rectangleToolButton.TabIndex = 0;
            this._rectangleToolButton.Text = "Rectangle";
            this._rectangleToolButton.UseVisualStyleBackColor = true;
            // 
            // _triangleToolButton
            // 
            this._triangleToolButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._triangleToolButton.Font = new System.Drawing.Font("新細明體", 16F);
            this._triangleToolButton.Location = new System.Drawing.Point(406, 19);
            this._triangleToolButton.Margin = new System.Windows.Forms.Padding(4, 19, 4, 4);
            this._triangleToolButton.Name = "_triangleToolButton";
            this._triangleToolButton.Size = new System.Drawing.Size(192, 102);
            this._triangleToolButton.TabIndex = 1;
            this._triangleToolButton.Text = "Triangle";
            this._triangleToolButton.UseVisualStyleBackColor = true;
            // 
            // _clearToolButton
            // 
            this._clearToolButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._clearToolButton.Font = new System.Drawing.Font("新細明體", 16F);
            this._clearToolButton.Location = new System.Drawing.Point(707, 19);
            this._clearToolButton.Margin = new System.Windows.Forms.Padding(4, 19, 4, 4);
            this._clearToolButton.Name = "_clearToolButton";
            this._clearToolButton.Size = new System.Drawing.Size(192, 102);
            this._clearToolButton.TabIndex = 2;
            this._clearToolButton.Text = "Clear";
            this._clearToolButton.UseVisualStyleBackColor = true;
            // 
            // _canvas
            // 
            this._canvas.BackColor = System.Drawing.Color.LightYellow;
            this._canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._canvas.Location = new System.Drawing.Point(0, 125);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(1007, 495);
            this._canvas.TabIndex = 2;
            // 
            // DrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 620);
            this.Controls.Add(this._canvas);
            this.Controls.Add(this._toolBarPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DrawingForm";
            this.Text = "Draw";
            this._toolBarPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel _toolBarPanel;
        private System.Windows.Forms.Button _rectangleToolButton;
        private System.Windows.Forms.Button _triangleToolButton;
        private System.Windows.Forms.Button _clearToolButton;
        private DoubleBufferedPanel _canvas;
    }
}

