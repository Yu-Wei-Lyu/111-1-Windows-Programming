
namespace Library109590004
{
    partial class BookInventoryForm
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
            this._comingSoonLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _comingSoonLabel
            // 
            this._comingSoonLabel.AutoSize = true;
            this._comingSoonLabel.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._comingSoonLabel.Location = new System.Drawing.Point(384, 246);
            this._comingSoonLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._comingSoonLabel.Name = "_comingSoonLabel";
            this._comingSoonLabel.Size = new System.Drawing.Size(305, 53);
            this._comingSoonLabel.TabIndex = 0;
            this._comingSoonLabel.Text = "Coming Soon";
            // 
            // BookInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this._comingSoonLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BookInventoryForm";
            this.Text = "BookInventoryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _comingSoonLabel;
    }
}