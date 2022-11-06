
namespace Library109590004
{
    partial class BookManagementForm
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
            this._managementBigTitleLabel = new System.Windows.Forms.Label();
            this._bookListBox = new System.Windows.Forms.ListBox();
            this._addBookButton = new System.Windows.Forms.Button();
            this._updateBookGroupBox = new System.Windows.Forms.GroupBox();
            this._browseButton = new System.Windows.Forms.Button();
            this._bookCategoryComboBox = new System.Windows.Forms.ComboBox();
            this._bookImagePathTextBox = new System.Windows.Forms.TextBox();
            this._bookPublicationTextBox = new System.Windows.Forms.TextBox();
            this._bookAuthorTextBox = new System.Windows.Forms.TextBox();
            this._bookIdTextBox = new System.Windows.Forms.TextBox();
            this._bookNameTextBox = new System.Windows.Forms.TextBox();
            this._textBoxDescriptionLabel = new System.Windows.Forms.Label();
            this._applyChangedButton = new System.Windows.Forms.Button();
            this._updateBookGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _managementBigTitleLabel
            // 
            this._managementBigTitleLabel.AutoSize = true;
            this._managementBigTitleLabel.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._managementBigTitleLabel.Location = new System.Drawing.Point(299, 9);
            this._managementBigTitleLabel.Name = "_managementBigTitleLabel";
            this._managementBigTitleLabel.Size = new System.Drawing.Size(209, 40);
            this._managementBigTitleLabel.TabIndex = 2;
            this._managementBigTitleLabel.Text = "館藏管理系統";
            // 
            // _bookListBox
            // 
            this._bookListBox.Font = new System.Drawing.Font("新細明體", 12F);
            this._bookListBox.FormattingEnabled = true;
            this._bookListBox.ItemHeight = 16;
            this._bookListBox.Location = new System.Drawing.Point(28, 68);
            this._bookListBox.Name = "_bookListBox";
            this._bookListBox.Size = new System.Drawing.Size(200, 292);
            this._bookListBox.TabIndex = 3;
            this._bookListBox.Click += new System.EventHandler(this.BookListBoxClick);
            // 
            // _addBookButton
            // 
            this._addBookButton.Location = new System.Drawing.Point(28, 382);
            this._addBookButton.Name = "_addBookButton";
            this._addBookButton.Size = new System.Drawing.Size(200, 30);
            this._addBookButton.TabIndex = 4;
            this._addBookButton.Text = "新增書籍";
            this._addBookButton.UseVisualStyleBackColor = true;
            // 
            // _updateBookGroupBox
            // 
            this._updateBookGroupBox.Controls.Add(this._browseButton);
            this._updateBookGroupBox.Controls.Add(this._bookCategoryComboBox);
            this._updateBookGroupBox.Controls.Add(this._bookImagePathTextBox);
            this._updateBookGroupBox.Controls.Add(this._bookPublicationTextBox);
            this._updateBookGroupBox.Controls.Add(this._bookAuthorTextBox);
            this._updateBookGroupBox.Controls.Add(this._bookIdTextBox);
            this._updateBookGroupBox.Controls.Add(this._bookNameTextBox);
            this._updateBookGroupBox.Controls.Add(this._textBoxDescriptionLabel);
            this._updateBookGroupBox.Font = new System.Drawing.Font("新細明體", 11F);
            this._updateBookGroupBox.Location = new System.Drawing.Point(256, 68);
            this._updateBookGroupBox.Name = "_updateBookGroupBox";
            this._updateBookGroupBox.Size = new System.Drawing.Size(491, 307);
            this._updateBookGroupBox.TabIndex = 5;
            this._updateBookGroupBox.TabStop = false;
            this._updateBookGroupBox.Text = "編輯書籍";
            // 
            // _browseButton
            // 
            this._browseButton.Font = new System.Drawing.Font("新細明體", 9F);
            this._browseButton.Location = new System.Drawing.Point(384, 260);
            this._browseButton.Name = "_browseButton";
            this._browseButton.Size = new System.Drawing.Size(77, 27);
            this._browseButton.TabIndex = 6;
            this._browseButton.Text = "瀏覽";
            this._browseButton.UseVisualStyleBackColor = true;
            this._browseButton.Click += new System.EventHandler(this.BrowseButtonClick);
            // 
            // _bookCategoryComboBox
            // 
            this._bookCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._bookCategoryComboBox.FormattingEnabled = true;
            this._bookCategoryComboBox.Location = new System.Drawing.Point(116, 172);
            this._bookCategoryComboBox.Name = "_bookCategoryComboBox";
            this._bookCategoryComboBox.Size = new System.Drawing.Size(137, 23);
            this._bookCategoryComboBox.TabIndex = 7;
            // 
            // _bookImagePathTextBox
            // 
            this._bookImagePathTextBox.Location = new System.Drawing.Point(116, 260);
            this._bookImagePathTextBox.Name = "_bookImagePathTextBox";
            this._bookImagePathTextBox.Size = new System.Drawing.Size(246, 25);
            this._bookImagePathTextBox.TabIndex = 6;
            // 
            // _bookPublicationTextBox
            // 
            this._bookPublicationTextBox.Location = new System.Drawing.Point(116, 215);
            this._bookPublicationTextBox.Name = "_bookPublicationTextBox";
            this._bookPublicationTextBox.Size = new System.Drawing.Size(345, 25);
            this._bookPublicationTextBox.TabIndex = 5;
            // 
            // _bookAuthorTextBox
            // 
            this._bookAuthorTextBox.Location = new System.Drawing.Point(116, 127);
            this._bookAuthorTextBox.Name = "_bookAuthorTextBox";
            this._bookAuthorTextBox.Size = new System.Drawing.Size(137, 25);
            this._bookAuthorTextBox.TabIndex = 3;
            // 
            // _bookIdTextBox
            // 
            this._bookIdTextBox.Location = new System.Drawing.Point(116, 82);
            this._bookIdTextBox.Name = "_bookIdTextBox";
            this._bookIdTextBox.Size = new System.Drawing.Size(137, 25);
            this._bookIdTextBox.TabIndex = 2;
            // 
            // _bookNameTextBox
            // 
            this._bookNameTextBox.Location = new System.Drawing.Point(116, 37);
            this._bookNameTextBox.Name = "_bookNameTextBox";
            this._bookNameTextBox.Size = new System.Drawing.Size(345, 25);
            this._bookNameTextBox.TabIndex = 1;
            // 
            // _textBoxDescriptionLabel
            // 
            this._textBoxDescriptionLabel.AutoSize = true;
            this._textBoxDescriptionLabel.Font = new System.Drawing.Font("新細明體", 11F);
            this._textBoxDescriptionLabel.Location = new System.Drawing.Point(20, 40);
            this._textBoxDescriptionLabel.Name = "_textBoxDescriptionLabel";
            this._textBoxDescriptionLabel.Size = new System.Drawing.Size(84, 240);
            this._textBoxDescriptionLabel.TabIndex = 0;
            this._textBoxDescriptionLabel.Text = "書籍名稱(*)\r\n\r\n\r\n書籍編號(*)\r\n\r\n\r\n書籍作者(*)\r\n\r\n\r\n書籍類別(*)\r\n\r\n\r\n出版項(*)\r\n\r\n\r\n圖片路徑(*)";
            this._textBoxDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _applyChangedButton
            // 
            this._applyChangedButton.Location = new System.Drawing.Point(547, 381);
            this._applyChangedButton.Name = "_applyChangedButton";
            this._applyChangedButton.Size = new System.Drawing.Size(200, 30);
            this._applyChangedButton.TabIndex = 6;
            this._applyChangedButton.Text = "儲存";
            this._applyChangedButton.UseVisualStyleBackColor = true;
            this._applyChangedButton.Click += new System.EventHandler(this.ApplyChangedButtonClick);
            // 
            // BookManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._applyChangedButton);
            this.Controls.Add(this._updateBookGroupBox);
            this.Controls.Add(this._addBookButton);
            this.Controls.Add(this._bookListBox);
            this.Controls.Add(this._managementBigTitleLabel);
            this.Name = "BookManagementForm";
            this.Text = "館藏管理";
            this._updateBookGroupBox.ResumeLayout(false);
            this._updateBookGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _managementBigTitleLabel;
        private System.Windows.Forms.ListBox _bookListBox;
        private System.Windows.Forms.Button _addBookButton;
        private System.Windows.Forms.GroupBox _updateBookGroupBox;
        private System.Windows.Forms.Label _textBoxDescriptionLabel;
        private System.Windows.Forms.Button _browseButton;
        private System.Windows.Forms.ComboBox _bookCategoryComboBox;
        private System.Windows.Forms.TextBox _bookImagePathTextBox;
        private System.Windows.Forms.TextBox _bookPublicationTextBox;
        private System.Windows.Forms.TextBox _bookAuthorTextBox;
        private System.Windows.Forms.TextBox _bookIdTextBox;
        private System.Windows.Forms.TextBox _bookNameTextBox;
        private System.Windows.Forms.Button _applyChangedButton;
    }
}