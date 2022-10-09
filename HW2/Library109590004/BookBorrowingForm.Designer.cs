
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
            this._addToBorrowingListButton = new System.Windows.Forms.Button();
            this._bookDetailGroupBox = new System.Windows.Forms.GroupBox();
            this._bookRemainLabel = new System.Windows.Forms.Label();
            this._bookDetailTextBox = new System.Windows.Forms.RichTextBox();
            this._bookCategoryTabControl = new System.Windows.Forms.TabControl();
            this._borrowingDataView = new System.Windows.Forms.DataGridView();
            this._borrowLabel = new System.Windows.Forms.Label();
            this._borrowingCountLabel = new System.Windows.Forms.Label();
            this._borrowButton = new System.Windows.Forms.Button();
            this._borrowingDataViewBookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._borrowingDataViewBookId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._borrowingDataViewBookAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._borrowingDataViewBookPublication = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._libraryGroupBox.SuspendLayout();
            this._bookDetailGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._borrowingDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // _libraryGroupBox
            // 
            this._libraryGroupBox.Controls.Add(this._addToBorrowingListButton);
            this._libraryGroupBox.Controls.Add(this._bookDetailGroupBox);
            this._libraryGroupBox.Controls.Add(this._bookCategoryTabControl);
            this._libraryGroupBox.Location = new System.Drawing.Point(35, 71);
            this._libraryGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this._libraryGroupBox.Name = "_libraryGroupBox";
            this._libraryGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this._libraryGroupBox.Size = new System.Drawing.Size(395, 414);
            this._libraryGroupBox.TabIndex = 0;
            this._libraryGroupBox.TabStop = false;
            this._libraryGroupBox.Text = "書籍";
            // 
            // _addToBorrowingListButton
            // 
            this._addToBorrowingListButton.Location = new System.Drawing.Point(279, 372);
            this._addToBorrowingListButton.Margin = new System.Windows.Forms.Padding(4);
            this._addToBorrowingListButton.Name = "_addToBorrowingListButton";
            this._addToBorrowingListButton.Size = new System.Drawing.Size(100, 29);
            this._addToBorrowingListButton.TabIndex = 2;
            this._addToBorrowingListButton.Text = "加入借書單";
            this._addToBorrowingListButton.UseVisualStyleBackColor = true;
            this._addToBorrowingListButton.Click += new System.EventHandler(this.AddBorrowingListButtonClick);
            // 
            // _bookDetailGroupBox
            // 
            this._bookDetailGroupBox.Controls.Add(this._bookRemainLabel);
            this._bookDetailGroupBox.Controls.Add(this._bookDetailTextBox);
            this._bookDetailGroupBox.Location = new System.Drawing.Point(23, 184);
            this._bookDetailGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this._bookDetailGroupBox.Name = "_bookDetailGroupBox";
            this._bookDetailGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this._bookDetailGroupBox.Size = new System.Drawing.Size(356, 180);
            this._bookDetailGroupBox.TabIndex = 1;
            this._bookDetailGroupBox.TabStop = false;
            this._bookDetailGroupBox.Text = "書籍介紹";
            // 
            // _bookRemainLabel
            // 
            this._bookRemainLabel.AutoSize = true;
            this._bookRemainLabel.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Bold);
            this._bookRemainLabel.Location = new System.Drawing.Point(8, 152);
            this._bookRemainLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._bookRemainLabel.Name = "_bookRemainLabel";
            this._bookRemainLabel.Size = new System.Drawing.Size(98, 17);
            this._bookRemainLabel.TabIndex = 1;
            this._bookRemainLabel.Text = "剩餘數量：";
            // 
            // _bookDetailTextBox
            // 
            this._bookDetailTextBox.Font = new System.Drawing.Font("新細明體", 10F);
            this._bookDetailTextBox.Location = new System.Drawing.Point(8, 26);
            this._bookDetailTextBox.Margin = new System.Windows.Forms.Padding(4);
            this._bookDetailTextBox.Name = "_bookDetailTextBox";
            this._bookDetailTextBox.ReadOnly = true;
            this._bookDetailTextBox.Size = new System.Drawing.Size(340, 122);
            this._bookDetailTextBox.TabIndex = 0;
            this._bookDetailTextBox.Text = "";
            this._bookDetailTextBox.TextChanged += new System.EventHandler(this.BookDetailTextChanged);
            // 
            // _bookCategoryTabControl
            // 
            this._bookCategoryTabControl.Location = new System.Drawing.Point(23, 26);
            this._bookCategoryTabControl.Margin = new System.Windows.Forms.Padding(4);
            this._bookCategoryTabControl.Name = "_bookCategoryTabControl";
            this._bookCategoryTabControl.SelectedIndex = 0;
            this._bookCategoryTabControl.Size = new System.Drawing.Size(356, 150);
            this._bookCategoryTabControl.TabIndex = 0;
            this._bookCategoryTabControl.SelectedIndexChanged += new System.EventHandler(this.BookCategoryPageSelectedIndexChanged);
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
            this._borrowingDataView.Location = new System.Drawing.Point(448, 110);
            this._borrowingDataView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._borrowingDataView.Name = "_borrowingDataView";
            this._borrowingDataView.ReadOnly = true;
            this._borrowingDataView.RowHeadersWidth = 51;
            this._borrowingDataView.RowTemplate.Height = 27;
            this._borrowingDataView.Size = new System.Drawing.Size(735, 314);
            this._borrowingDataView.TabIndex = 1;
            this._borrowingDataView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.BorrowingDataViewRowsAdded);
            this._borrowingDataView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.BorrowingDataViewRowsRemoved);
            // 
            // _borrowLabel
            // 
            this._borrowLabel.AutoSize = true;
            this._borrowLabel.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._borrowLabel.Location = new System.Drawing.Point(772, 71);
            this._borrowLabel.Name = "_borrowLabel";
            this._borrowLabel.Size = new System.Drawing.Size(99, 36);
            this._borrowLabel.TabIndex = 2;
            this._borrowLabel.Text = "借書單";
            // 
            // _borrowingCountLabel
            // 
            this._borrowingCountLabel.AutoSize = true;
            this._borrowingCountLabel.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Bold);
            this._borrowingCountLabel.Location = new System.Drawing.Point(445, 448);
            this._borrowingCountLabel.Name = "_borrowingCountLabel";
            this._borrowingCountLabel.Size = new System.Drawing.Size(98, 17);
            this._borrowingCountLabel.TabIndex = 3;
            this._borrowingCountLabel.Text = "借書數量：";
            // 
            // _borrowButton
            // 
            this._borrowButton.Location = new System.Drawing.Point(1069, 439);
            this._borrowButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._borrowButton.Name = "_borrowButton";
            this._borrowButton.Size = new System.Drawing.Size(113, 39);
            this._borrowButton.TabIndex = 4;
            this._borrowButton.Text = "確認借書";
            this._borrowButton.UseVisualStyleBackColor = true;
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
            // BookBorrowingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 562);
            this.Controls.Add(this._borrowButton);
            this.Controls.Add(this._borrowingCountLabel);
            this.Controls.Add(this._borrowLabel);
            this.Controls.Add(this._borrowingDataView);
            this.Controls.Add(this._libraryGroupBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BookBorrowingForm";
            this.Text = "HW1";
            this._libraryGroupBox.ResumeLayout(false);
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
        private System.Windows.Forms.Button _addToBorrowingListButton;
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
    }
}

