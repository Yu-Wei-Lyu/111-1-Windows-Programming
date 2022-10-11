
namespace Library109590004
{
    partial class MenuForm
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
            this._borrowingSystemButton = new System.Windows.Forms.Button();
            this._inventorySystemButton = new System.Windows.Forms.Button();
            this._exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _borrowingSystemButton
            // 
            this._borrowingSystemButton.Font = new System.Drawing.Font("Arial", 14.25F);
            this._borrowingSystemButton.Location = new System.Drawing.Point(69, 29);
            this._borrowingSystemButton.Name = "_borrowingSystemButton";
            this._borrowingSystemButton.Size = new System.Drawing.Size(360, 68);
            this._borrowingSystemButton.TabIndex = 3;
            this._borrowingSystemButton.Text = "Book Borrowing System";
            this._borrowingSystemButton.UseVisualStyleBackColor = true;
            this._borrowingSystemButton.Click += new System.EventHandler(this.HandleBorrowingSystemButtonClick);
            // 
            // _inventorySystemButton
            // 
            this._inventorySystemButton.Font = new System.Drawing.Font("Arial", 14.25F);
            this._inventorySystemButton.Location = new System.Drawing.Point(69, 103);
            this._inventorySystemButton.Name = "_inventorySystemButton";
            this._inventorySystemButton.Size = new System.Drawing.Size(360, 64);
            this._inventorySystemButton.TabIndex = 4;
            this._inventorySystemButton.Text = "Book Inventory System";
            this._inventorySystemButton.UseVisualStyleBackColor = true;
            this._inventorySystemButton.Click += new System.EventHandler(this.HandleInventorySystemButtonClick);
            // 
            // _exitButton
            // 
            this._exitButton.Font = new System.Drawing.Font("Arial", 14.25F);
            this._exitButton.Location = new System.Drawing.Point(329, 193);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(100, 40);
            this._exitButton.TabIndex = 5;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 245);
            this.Controls.Add(this._exitButton);
            this.Controls.Add(this._inventorySystemButton);
            this.Controls.Add(this._borrowingSystemButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Activated += new System.EventHandler(this.HandleMenuFormActivated);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _borrowingSystemButton;
        private System.Windows.Forms.Button _inventorySystemButton;
        private System.Windows.Forms.Button _exitButton;
    }
}