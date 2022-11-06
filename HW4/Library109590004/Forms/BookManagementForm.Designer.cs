
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
            this._saveChangesButton = new System.Windows.Forms.Button();
            this._updateBookGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _managementBigTitleLabel
            // 
            this._managementBigTitleLabel.AutoSize = true;
            this._managementBigTitleLabel.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._managementBigTitleLabel.Location = new System.Drawing.Point(399, 11);
            this._managementBigTitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._managementBigTitleLabel.Name = "_managementBigTitleLabel";
            this._managementBigTitleLabel.Size = new System.Drawing.Size(262, 50);
            this._managementBigTitleLabel.TabIndex = 2;
            this._managementBigTitleLabel.Text = "館藏管理系統";
            // 
            // _bookListBox
            // 
            this._bookListBox.Font = new System.Drawing.Font("新細明體", 12F);
            this._bookListBox.FormattingEnabled = true;
            this._bookListBox.ItemHeight = 20;
            this._bookListBox.Location = new System.Drawing.Point(37, 85);
            this._bookListBox.Margin = new System.Windows.Forms.Padding(4);
            this._bookListBox.Name = "_bookListBox";
            this._bookListBox.Size = new System.Drawing.Size(265, 364);
            this._bookListBox.TabIndex = 3;
            this._bookListBox.Click += new System.EventHandler(this.BookListBoxClick);
            // 
            // _addBookButton
            // 
            this._addBookButton.Location = new System.Drawing.Point(37, 477);
            this._addBookButton.Margin = new System.Windows.Forms.Padding(4);
            this._addBookButton.Name = "_addBookButton";
            this._addBookButton.Size = new System.Drawing.Size(267, 38);
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
            this._updateBookGroupBox.Location = new System.Drawing.Point(341, 85);
            this._updateBookGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this._updateBookGroupBox.Name = "_updateBookGroupBox";
            this._updateBookGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this._updateBookGroupBox.Size = new System.Drawing.Size(655, 384);
            this._updateBookGroupBox.TabIndex = 5;
            this._updateBookGroupBox.TabStop = false;
            this._updateBookGroupBox.Text = "編輯書籍";
            // 
            // _browseButton
            // 
            this._browseButton.Font = new System.Drawing.Font("新細明體", 9F);
            this._browseButton.Location = new System.Drawing.Point(512, 325);
            this._browseButton.Margin = new System.Windows.Forms.Padding(4);
            this._browseButton.Name = "_browseButton";
            this._browseButton.Size = new System.Drawing.Size(103, 34);
            this._browseButton.TabIndex = 6;
            this._browseButton.Text = "瀏覽";
            this._browseButton.UseVisualStyleBackColor = true;
            // 
            // _bookCategoryComboBox
            // 
            this._bookCategoryComboBox.FormattingEnabled = true;
            this._bookCategoryComboBox.Location = new System.Drawing.Point(155, 215);
            this._bookCategoryComboBox.Margin = new System.Windows.Forms.Padding(4);
            this._bookCategoryComboBox.Name = "_bookCategoryComboBox";
            this._bookCategoryComboBox.Size = new System.Drawing.Size(181, 26);
            this._bookCategoryComboBox.TabIndex = 7;
            // 
            // _bookImagePathTextBox
            // 
            this._bookImagePathTextBox.Location = new System.Drawing.Point(155, 325);
            this._bookImagePathTextBox.Margin = new System.Windows.Forms.Padding(4);
            this._bookImagePathTextBox.Name = "_bookImagePathTextBox";
            this._bookImagePathTextBox.Size = new System.Drawing.Size(327, 29);
            this._bookImagePathTextBox.TabIndex = 6;
            // 
            // _bookPublicationTextBox
            // 
            this._bookPublicationTextBox.Location = new System.Drawing.Point(155, 269);
            this._bookPublicationTextBox.Margin = new System.Windows.Forms.Padding(4);
            this._bookPublicationTextBox.Name = "_bookPublicationTextBox";
            this._bookPublicationTextBox.Size = new System.Drawing.Size(459, 29);
            this._bookPublicationTextBox.TabIndex = 5;
            // 
            // _bookAuthorTextBox
            // 
            this._bookAuthorTextBox.Location = new System.Drawing.Point(155, 159);
            this._bookAuthorTextBox.Margin = new System.Windows.Forms.Padding(4);
            this._bookAuthorTextBox.Name = "_bookAuthorTextBox";
            this._bookAuthorTextBox.Size = new System.Drawing.Size(181, 29);
            this._bookAuthorTextBox.TabIndex = 3;
            // 
            // _bookIdTextBox
            // 
            this._bookIdTextBox.Location = new System.Drawing.Point(155, 102);
            this._bookIdTextBox.Margin = new System.Windows.Forms.Padding(4);
            this._bookIdTextBox.Name = "_bookIdTextBox";
            this._bookIdTextBox.Size = new System.Drawing.Size(181, 29);
            this._bookIdTextBox.TabIndex = 2;
            // 
            // _bookNameTextBox
            // 
            this._bookNameTextBox.Location = new System.Drawing.Point(155, 46);
            this._bookNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this._bookNameTextBox.Name = "_bookNameTextBox";
            this._bookNameTextBox.Size = new System.Drawing.Size(459, 29);
            this._bookNameTextBox.TabIndex = 1;
            this._bookNameTextBox.Text = "範例字體";
            // 
            // _textBoxDescriptionLabel
            // 
            this._textBoxDescriptionLabel.AutoSize = true;
            this._textBoxDescriptionLabel.Font = new System.Drawing.Font("新細明體", 11F);
            this._textBoxDescriptionLabel.Location = new System.Drawing.Point(27, 50);
            this._textBoxDescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._textBoxDescriptionLabel.Name = "_textBoxDescriptionLabel";
            this._textBoxDescriptionLabel.Size = new System.Drawing.Size(106, 304);
            this._textBoxDescriptionLabel.TabIndex = 0;
            this._textBoxDescriptionLabel.Text = "書籍名稱(*)\r\n\r\n\r\n書籍編號(*)\r\n\r\n\r\n書籍作者(*)\r\n\r\n\r\n書籍類別(*)\r\n\r\n\r\n出版項(*)\r\n\r\n\r\n圖片路徑(*)";
            this._textBoxDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _saveChangesButton
            // 
            this._saveChangesButton.Location = new System.Drawing.Point(729, 476);
            this._saveChangesButton.Margin = new System.Windows.Forms.Padding(4);
            this._saveChangesButton.Name = "_saveChangesButton";
            this._saveChangesButton.Size = new System.Drawing.Size(267, 38);
            this._saveChangesButton.TabIndex = 6;
            this._saveChangesButton.Text = "儲存";
            this._saveChangesButton.UseVisualStyleBackColor = true;
            // 
            // BookManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this._saveChangesButton);
            this.Controls.Add(this._updateBookGroupBox);
            this.Controls.Add(this._addBookButton);
            this.Controls.Add(this._bookListBox);
            this.Controls.Add(this._managementBigTitleLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button _saveChangesButton;
    }
}