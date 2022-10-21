
namespace Library109590004
{
    partial class SupplyForm
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
            this._supplyBigTitleLabel = new System.Windows.Forms.Label();
            this._supplyBookDetailTextBox = new System.Windows.Forms.RichTextBox();
            this._supplyAmountLabel = new System.Windows.Forms.Label();
            this._supplyBookAmountTextBox = new System.Windows.Forms.TextBox();
            this._supplyConfirmButton = new System.Windows.Forms.Button();
            this._supplyCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _supplyBigTitleLabel
            // 
            this._supplyBigTitleLabel.AutoSize = true;
            this._supplyBigTitleLabel.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._supplyBigTitleLabel.Location = new System.Drawing.Point(134, 26);
            this._supplyBigTitleLabel.Name = "_supplyBigTitleLabel";
            this._supplyBigTitleLabel.Size = new System.Drawing.Size(113, 40);
            this._supplyBigTitleLabel.TabIndex = 1;
            this._supplyBigTitleLabel.Text = "補貨單";
            // 
            // _supplyBookDetailTextBox
            // 
            this._supplyBookDetailTextBox.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this._supplyBookDetailTextBox.Location = new System.Drawing.Point(30, 86);
            this._supplyBookDetailTextBox.Name = "_supplyBookDetailTextBox";
            this._supplyBookDetailTextBox.ReadOnly = true;
            this._supplyBookDetailTextBox.Size = new System.Drawing.Size(316, 112);
            this._supplyBookDetailTextBox.TabIndex = 6;
            this._supplyBookDetailTextBox.Text = "";
            // 
            // _supplyAmountLabel
            // 
            this._supplyAmountLabel.AutoSize = true;
            this._supplyAmountLabel.Font = new System.Drawing.Font("新細明體", 11F);
            this._supplyAmountLabel.Location = new System.Drawing.Point(27, 211);
            this._supplyAmountLabel.Name = "_supplyAmountLabel";
            this._supplyAmountLabel.Size = new System.Drawing.Size(82, 15);
            this._supplyAmountLabel.TabIndex = 7;
            this._supplyAmountLabel.Text = "補貨數量：";
            // 
            // _supplyBookAmountTextBox
            // 
            this._supplyBookAmountTextBox.Font = new System.Drawing.Font("新細明體", 12F);
            this._supplyBookAmountTextBox.Location = new System.Drawing.Point(107, 204);
            this._supplyBookAmountTextBox.Name = "_supplyBookAmountTextBox";
            this._supplyBookAmountTextBox.Size = new System.Drawing.Size(74, 27);
            this._supplyBookAmountTextBox.TabIndex = 8;
            this._supplyBookAmountTextBox.TextChanged += new System.EventHandler(this.SupplyBookAmountTextBoxTextChanged);
            this._supplyBookAmountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SupplyBookAmountKeyPress);
            // 
            // _supplyConfirmButton
            // 
            this._supplyConfirmButton.BackColor = System.Drawing.Color.MediumAquamarine;
            this._supplyConfirmButton.Font = new System.Drawing.Font("新細明體", 11F);
            this._supplyConfirmButton.Location = new System.Drawing.Point(30, 239);
            this._supplyConfirmButton.Name = "_supplyConfirmButton";
            this._supplyConfirmButton.Size = new System.Drawing.Size(155, 31);
            this._supplyConfirmButton.TabIndex = 9;
            this._supplyConfirmButton.Text = "確認";
            this._supplyConfirmButton.UseVisualStyleBackColor = false;
            this._supplyConfirmButton.Click += new System.EventHandler(this.SupplyConfirmButtonClick);
            // 
            // _supplyCancelButton
            // 
            this._supplyCancelButton.BackColor = System.Drawing.Color.LightCoral;
            this._supplyCancelButton.Font = new System.Drawing.Font("新細明體", 11F);
            this._supplyCancelButton.Location = new System.Drawing.Point(191, 239);
            this._supplyCancelButton.Name = "_supplyCancelButton";
            this._supplyCancelButton.Size = new System.Drawing.Size(155, 31);
            this._supplyCancelButton.TabIndex = 10;
            this._supplyCancelButton.Text = "取消";
            this._supplyCancelButton.UseVisualStyleBackColor = false;
            this._supplyCancelButton.Click += new System.EventHandler(this.SupplyCancelButtonClick);
            // 
            // SupplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 308);
            this.Controls.Add(this._supplyCancelButton);
            this.Controls.Add(this._supplyConfirmButton);
            this.Controls.Add(this._supplyBookAmountTextBox);
            this.Controls.Add(this._supplyAmountLabel);
            this.Controls.Add(this._supplyBookDetailTextBox);
            this.Controls.Add(this._supplyBigTitleLabel);
            this.Name = "SupplyForm";
            this.Text = "SupplyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _supplyBigTitleLabel;
        private System.Windows.Forms.RichTextBox _supplyBookDetailTextBox;
        private System.Windows.Forms.Label _supplyAmountLabel;
        private System.Windows.Forms.TextBox _supplyBookAmountTextBox;
        private System.Windows.Forms.Button _supplyConfirmButton;
        private System.Windows.Forms.Button _supplyCancelButton;
    }
}