
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
            this._exitButton = new Library109590004.BookButton();
            this._bookInventorySystemButton = new Library109590004.BookButton();
            this._bookBorrowingSystemButton = new Library109590004.BookButton();
            this.SuspendLayout();
            // 
            // _exitButton
            // 
            this._exitButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._exitButton.Location = new System.Drawing.Point(247, 152);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(75, 32);
            this._exitButton.TabIndex = 2;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // _bookInventorySystemButton
            // 
            this._bookInventorySystemButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._bookInventorySystemButton.Location = new System.Drawing.Point(52, 83);
            this._bookInventorySystemButton.Name = "_bookInventorySystemButton";
            this._bookInventorySystemButton.Size = new System.Drawing.Size(270, 51);
            this._bookInventorySystemButton.TabIndex = 1;
            this._bookInventorySystemButton.Text = "Book Inventory System";
            this._bookInventorySystemButton.UseVisualStyleBackColor = true;
            this._bookInventorySystemButton.Click += new System.EventHandler(this.BookInventorySystemButtonClick);
            // 
            // _bookBorrowingSystemButton
            // 
            this._bookBorrowingSystemButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._bookBorrowingSystemButton.Location = new System.Drawing.Point(52, 23);
            this._bookBorrowingSystemButton.Name = "_bookBorrowingSystemButton";
            this._bookBorrowingSystemButton.Size = new System.Drawing.Size(270, 54);
            this._bookBorrowingSystemButton.TabIndex = 0;
            this._bookBorrowingSystemButton.Text = "Book Borrowing System";
            this._bookBorrowingSystemButton.UseVisualStyleBackColor = true;
            this._bookBorrowingSystemButton.Click += new System.EventHandler(this.BookBorrowingSystemButtonClick);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 196);
            this.Controls.Add(this._exitButton);
            this.Controls.Add(this._bookInventorySystemButton);
            this.Controls.Add(this._bookBorrowingSystemButton);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.ResumeLayout(false);

        }

        #endregion

        private BookButton _bookBorrowingSystemButton;
        private BookButton _bookInventorySystemButton;
        private BookButton _exitButton;
    }
}