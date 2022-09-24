
namespace Library109590004
{
    partial class Form1
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
            this._libraryGroupBox = new System.Windows.Forms.GroupBox();
            this._addBookButton = new System.Windows.Forms.Button();
            this._bookDetailGroupBox = new System.Windows.Forms.GroupBox();
            this._bookRemainLabel = new System.Windows.Forms.Label();
            this._bookDetailTextBox = new System.Windows.Forms.RichTextBox();
            this._bookCategoryTabPage = new System.Windows.Forms.TabControl();
            this._borrowingDataView = new System.Windows.Forms.DataGridView();
            this._borrowLabel = new System.Windows.Forms.Label();
            this._borrowingCountLabel = new System.Windows.Forms.Label();
            this._borrowOut = new System.Windows.Forms.Button();
            this._libraryGroupBox.SuspendLayout();
            this._bookDetailGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._borrowingDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // _libraryGroupBox
            // 
            this._libraryGroupBox.Controls.Add(this._addBookButton);
            this._libraryGroupBox.Controls.Add(this._bookDetailGroupBox);
            this._libraryGroupBox.Controls.Add(this._bookCategoryTabPage);
            this._libraryGroupBox.Location = new System.Drawing.Point(26, 57);
            this._libraryGroupBox.Name = "_libraryGroupBox";
            this._libraryGroupBox.Size = new System.Drawing.Size(296, 331);
            this._libraryGroupBox.TabIndex = 0;
            this._libraryGroupBox.TabStop = false;
            this._libraryGroupBox.Text = "書籍";
            // 
            // _addBookButton
            // 
            this._addBookButton.Location = new System.Drawing.Point(209, 298);
            this._addBookButton.Name = "_addBookButton";
            this._addBookButton.Size = new System.Drawing.Size(75, 23);
            this._addBookButton.TabIndex = 2;
            this._addBookButton.Text = "加入借書單";
            this._addBookButton.UseVisualStyleBackColor = true;
            this._addBookButton.Click += new System.EventHandler(this.AddBookButtonClick);
            // 
            // _bookDetailGroupBox
            // 
            this._bookDetailGroupBox.Controls.Add(this._bookRemainLabel);
            this._bookDetailGroupBox.Controls.Add(this._bookDetailTextBox);
            this._bookDetailGroupBox.Location = new System.Drawing.Point(17, 147);
            this._bookDetailGroupBox.Name = "_bookDetailGroupBox";
            this._bookDetailGroupBox.Size = new System.Drawing.Size(267, 144);
            this._bookDetailGroupBox.TabIndex = 1;
            this._bookDetailGroupBox.TabStop = false;
            this._bookDetailGroupBox.Text = "書籍介紹";
            // 
            // _bookRemainLabel
            // 
            this._bookRemainLabel.AutoSize = true;
            this._bookRemainLabel.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Bold);
            this._bookRemainLabel.Location = new System.Drawing.Point(6, 122);
            this._bookRemainLabel.Name = "_bookRemainLabel";
            this._bookRemainLabel.Size = new System.Drawing.Size(82, 14);
            this._bookRemainLabel.TabIndex = 1;
            this._bookRemainLabel.Text = "剩餘數量：";
            // 
            // _bookDetailRichTextbox
            // 
            this._bookDetailTextBox.Font = new System.Drawing.Font("新細明體", 10F);
            this._bookDetailTextBox.Location = new System.Drawing.Point(6, 21);
            this._bookDetailTextBox.Name = "_bookDetailRichTextbox";
            this._bookDetailTextBox.ReadOnly = true;
            this._bookDetailTextBox.Size = new System.Drawing.Size(256, 98);
            this._bookDetailTextBox.TabIndex = 0;
            this._bookDetailTextBox.Text = "";
            this._bookDetailTextBox.TextChanged += new System.EventHandler(this.BookDetailTextChanged);
            // 
            // _bookCategoryTabPage
            // 
            this._bookCategoryTabPage.Location = new System.Drawing.Point(17, 21);
            this._bookCategoryTabPage.Name = "_bookCategoryTabPage";
            this._bookCategoryTabPage.SelectedIndex = 0;
            this._bookCategoryTabPage.Size = new System.Drawing.Size(267, 120);
            this._bookCategoryTabPage.TabIndex = 0;
            this._bookCategoryTabPage.SelectedIndexChanged += new System.EventHandler(this.BookCategoryPageSelectedIndexChanged);
            // 
            // _borrowingDataView
            // 
            this._borrowingDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._borrowingDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._borrowingDataView.Location = new System.Drawing.Point(336, 88);
            this._borrowingDataView.Margin = new System.Windows.Forms.Padding(2);
            this._borrowingDataView.Name = "_borrowingDataView";
            this._borrowingDataView.RowHeadersWidth = 51;
            this._borrowingDataView.RowTemplate.Height = 27;
            this._borrowingDataView.Size = new System.Drawing.Size(551, 251);
            this._borrowingDataView.TabIndex = 1;
            this._borrowingDataView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.BorrowingDataViewRowsAdded);
            // 
            // _borrowLabel
            // 
            this._borrowLabel.AutoSize = true;
            this._borrowLabel.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._borrowLabel.Location = new System.Drawing.Point(579, 57);
            this._borrowLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._borrowLabel.Name = "_borrowLabel";
            this._borrowLabel.Size = new System.Drawing.Size(78, 28);
            this._borrowLabel.TabIndex = 2;
            this._borrowLabel.Text = "借書單";
            // 
            // _borrowingCountLabel
            // 
            this._borrowingCountLabel.AutoSize = true;
            this._borrowingCountLabel.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Bold);
            this._borrowingCountLabel.Location = new System.Drawing.Point(334, 358);
            this._borrowingCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._borrowingCountLabel.Name = "_borrowingCountLabel";
            this._borrowingCountLabel.Size = new System.Drawing.Size(82, 14);
            this._borrowingCountLabel.TabIndex = 3;
            this._borrowingCountLabel.Text = "借書數量：";
            // 
            // _borrowOut
            // 
            this._borrowOut.Location = new System.Drawing.Point(802, 351);
            this._borrowOut.Margin = new System.Windows.Forms.Padding(2);
            this._borrowOut.Name = "_borrowOut";
            this._borrowOut.Size = new System.Drawing.Size(85, 31);
            this._borrowOut.TabIndex = 4;
            this._borrowOut.Text = "確認借書";
            this._borrowOut.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 450);
            this.Controls.Add(this._borrowOut);
            this.Controls.Add(this._borrowingCountLabel);
            this.Controls.Add(this._borrowLabel);
            this.Controls.Add(this._borrowingDataView);
            this.Controls.Add(this._libraryGroupBox);
            this.Name = "Form1";
            this.Text = "HW1";
            this._libraryGroupBox.ResumeLayout(false);
            this._bookDetailGroupBox.ResumeLayout(false);
            this._bookDetailGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._borrowingDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _libraryGroupBox;
        private System.Windows.Forms.GroupBox _bookDetailGroupBox;
        private System.Windows.Forms.Label _bookRemainLabel;
        private System.Windows.Forms.RichTextBox _bookDetailTextBox;
        private System.Windows.Forms.Button _addBookButton;
        private System.Windows.Forms.DataGridView _borrowingDataView;
        private System.Windows.Forms.Label _borrowLabel;
        private System.Windows.Forms.Label _borrowingCountLabel;
        private System.Windows.Forms.Button _borrowOut;
        private System.Windows.Forms.TabControl _bookCategoryTabPage;
    }
}

