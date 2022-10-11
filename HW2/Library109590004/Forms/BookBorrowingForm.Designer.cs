
namespace Library109590004
{
    partial class BookBorrowingForm
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
            this._pageDownButton = new System.Windows.Forms.Button();
            this._bookDetailGroupBox = new System.Windows.Forms.GroupBox();
            this._bookRemainLabel = new System.Windows.Forms.Label();
            this._bookDetailTextBox = new System.Windows.Forms.RichTextBox();
            this._bookCategoryTabControl = new System.Windows.Forms.TabControl();
            this._pageLabel = new System.Windows.Forms.Label();
            this._pageUpButton = new System.Windows.Forms.Button();
            this._addListButton = new System.Windows.Forms.Button();
            this._borrowingDataView = new System.Windows.Forms.DataGridView();
            this._borrowingDataViewBookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._borrowingDataViewBookId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._borrowingDataViewBookAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._borrowingDataViewBookPublication = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._borrowLabel = new System.Windows.Forms.Label();
            this._borrowingCountLabel = new System.Windows.Forms.Label();
            this._borrowButton = new System.Windows.Forms.Button();
            this._libraryGroupBox.SuspendLayout();
            this._bookDetailGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._borrowingDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // _libraryGroupBox
            // 
            this._libraryGroupBox.Controls.Add(this._pageDownButton);
            this._libraryGroupBox.Controls.Add(this._bookDetailGroupBox);
            this._libraryGroupBox.Controls.Add(this._bookCategoryTabControl);
            this._libraryGroupBox.Controls.Add(this._pageLabel);
            this._libraryGroupBox.Controls.Add(this._pageUpButton);
            this._libraryGroupBox.Controls.Add(this._addListButton);
            this._libraryGroupBox.Location = new System.Drawing.Point(12, 57);
            this._libraryGroupBox.Name = "_libraryGroupBox";
            this._libraryGroupBox.Size = new System.Drawing.Size(298, 331);
            this._libraryGroupBox.TabIndex = 0;
            this._libraryGroupBox.TabStop = false;
            this._libraryGroupBox.Text = "書籍";
            // 
            // _pageDownButton
            // 
            this._pageDownButton.Location = new System.Drawing.Point(155, 296);
            this._pageDownButton.Name = "_pageDownButton";
            this._pageDownButton.Size = new System.Drawing.Size(49, 23);
            this._pageDownButton.TabIndex = 5;
            this._pageDownButton.Text = "下一頁";
            this._pageDownButton.UseVisualStyleBackColor = true;
            this._pageDownButton.Click += new System.EventHandler(this.PageDownButtonClick);
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
            // _bookDetailTextBox
            // 
            this._bookDetailTextBox.Font = new System.Drawing.Font("新細明體", 10F);
            this._bookDetailTextBox.Location = new System.Drawing.Point(6, 21);
            this._bookDetailTextBox.Name = "_bookDetailTextBox";
            this._bookDetailTextBox.ReadOnly = true;
            this._bookDetailTextBox.Size = new System.Drawing.Size(256, 98);
            this._bookDetailTextBox.TabIndex = 0;
            this._bookDetailTextBox.Text = "";
            // 
            // _bookCategoryTabControl
            // 
            this._bookCategoryTabControl.Location = new System.Drawing.Point(17, 21);
            this._bookCategoryTabControl.Name = "_bookCategoryTabControl";
            this._bookCategoryTabControl.SelectedIndex = 0;
            this._bookCategoryTabControl.Size = new System.Drawing.Size(267, 120);
            this._bookCategoryTabControl.TabIndex = 0;
            this._bookCategoryTabControl.SelectedIndexChanged += new System.EventHandler(this.BookCategoryPageSelectedIndexChanged);
            // 
            // _pageLabel
            // 
            this._pageLabel.AutoSize = true;
            this._pageLabel.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._pageLabel.Location = new System.Drawing.Point(9, 299);
            this._pageLabel.Name = "_pageLabel";
            this._pageLabel.Size = new System.Drawing.Size(85, 15);
            this._pageLabel.TabIndex = 4;
            this._pageLabel.Text = "Page：0 / 1";
            // 
            // _pageUpButton
            // 
            this._pageUpButton.Location = new System.Drawing.Point(100, 296);
            this._pageUpButton.Name = "_pageUpButton";
            this._pageUpButton.Size = new System.Drawing.Size(49, 23);
            this._pageUpButton.TabIndex = 3;
            this._pageUpButton.Text = "上一頁";
            this._pageUpButton.UseVisualStyleBackColor = true;
            this._pageUpButton.Click += new System.EventHandler(this.PageUpButtonClick);
            // 
            // _addListButton
            // 
            this._addListButton.Location = new System.Drawing.Point(210, 296);
            this._addListButton.Name = "_addListButton";
            this._addListButton.Size = new System.Drawing.Size(75, 23);
            this._addListButton.TabIndex = 2;
            this._addListButton.Text = "加入借書單";
            this._addListButton.UseVisualStyleBackColor = true;
            this._addListButton.Click += new System.EventHandler(this.AddBorrowingListButtonClick);
            // 
            // _borrowingDataView
            // 
            this._borrowingDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._borrowingDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._borrowingDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._borrowingDataViewBookName,
            this._borrowingDataViewBookId,
            this._borrowingDataViewBookAuthor,
            this._borrowingDataViewBookPublication});
            this._borrowingDataView.Location = new System.Drawing.Point(336, 88);
            this._borrowingDataView.Margin = new System.Windows.Forms.Padding(2);
            this._borrowingDataView.Name = "_borrowingDataView";
            this._borrowingDataView.ReadOnly = true;
            this._borrowingDataView.RowHeadersWidth = 51;
            this._borrowingDataView.RowTemplate.Height = 27;
            this._borrowingDataView.Size = new System.Drawing.Size(551, 251);
            this._borrowingDataView.TabIndex = 1;
            this._borrowingDataView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.BorrowingDataViewRowsAdded);
            this._borrowingDataView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.BorrowingDataViewRowsRemoved);
            // 
            // _borrowingDataViewBookName
            // 
            this._borrowingDataViewBookName.HeaderText = "書籍名稱";
            this._borrowingDataViewBookName.MinimumWidth = 6;
            this._borrowingDataViewBookName.Name = "_borrowingDataViewBookName";
            this._borrowingDataViewBookName.ReadOnly = true;
            // 
            // _borrowingDataViewBookId
            // 
            this._borrowingDataViewBookId.HeaderText = "書籍編號";
            this._borrowingDataViewBookId.MinimumWidth = 6;
            this._borrowingDataViewBookId.Name = "_borrowingDataViewBookId";
            this._borrowingDataViewBookId.ReadOnly = true;
            // 
            // _borrowingDataViewBookAuthor
            // 
            this._borrowingDataViewBookAuthor.HeaderText = "作者";
            this._borrowingDataViewBookAuthor.MinimumWidth = 6;
            this._borrowingDataViewBookAuthor.Name = "_borrowingDataViewBookAuthor";
            this._borrowingDataViewBookAuthor.ReadOnly = true;
            // 
            // _borrowingDataViewBookPublication
            // 
            this._borrowingDataViewBookPublication.HeaderText = "出版項";
            this._borrowingDataViewBookPublication.MinimumWidth = 6;
            this._borrowingDataViewBookPublication.Name = "_borrowingDataViewBookPublication";
            this._borrowingDataViewBookPublication.ReadOnly = true;
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
            // _borrowButton
            // 
            this._borrowButton.Location = new System.Drawing.Point(802, 351);
            this._borrowButton.Margin = new System.Windows.Forms.Padding(2);
            this._borrowButton.Name = "_borrowButton";
            this._borrowButton.Size = new System.Drawing.Size(85, 31);
            this._borrowButton.TabIndex = 4;
            this._borrowButton.Text = "確認借書";
            this._borrowButton.UseVisualStyleBackColor = true;
            // 
            // BookBorrowingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 450);
            this.Controls.Add(this._borrowButton);
            this.Controls.Add(this._borrowingCountLabel);
            this.Controls.Add(this._borrowLabel);
            this.Controls.Add(this._borrowingDataView);
            this.Controls.Add(this._libraryGroupBox);
            this.Name = "BookBorrowingForm";
            this.Text = "HW1";
            this._libraryGroupBox.ResumeLayout(false);
            this._libraryGroupBox.PerformLayout();
            this._bookDetailGroupBox.ResumeLayout(false);
            this._bookDetailGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._borrowingDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _bookRemainLabel;
        private System.Windows.Forms.Label _borrowLabel;
        private System.Windows.Forms.Label _borrowingCountLabel;
        private System.Windows.Forms.Button _addListButton;
        private System.Windows.Forms.Button _borrowButton;
        private System.Windows.Forms.GroupBox _libraryGroupBox;
        private System.Windows.Forms.GroupBox _bookDetailGroupBox;
        private System.Windows.Forms.TabControl _bookCategoryTabControl;
        private System.Windows.Forms.RichTextBox _bookDetailTextBox;
        private System.Windows.Forms.DataGridView _borrowingDataView;
        private System.Windows.Forms.DataGridViewTextBoxColumn _borrowingDataViewBookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _borrowingDataViewBookId;
        private System.Windows.Forms.DataGridViewTextBoxColumn _borrowingDataViewBookAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn _borrowingDataViewBookPublication;
        private System.Windows.Forms.Button _pageUpButton;
        private System.Windows.Forms.Button _pageDownButton;
        private System.Windows.Forms.Label _pageLabel;
    }
}

