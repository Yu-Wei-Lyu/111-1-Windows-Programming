
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
            this._groupBoxBooks = new System.Windows.Forms.GroupBox();
            this._addBookButton = new System.Windows.Forms.Button();
            this._groupBoxBookIntroduction = new System.Windows.Forms.GroupBox();
            this._bookRemainLabel = new System.Windows.Forms.Label();
            this._bookDetail = new System.Windows.Forms.RichTextBox();
            this._bookCategoryPage = new System.Windows.Forms.TabControl();
            this._dataGridView1 = new System.Windows.Forms.DataGridView();
            this._borrowLabel = new System.Windows.Forms.Label();
            this._borrowBooksAmountLabel = new System.Windows.Forms.Label();
            this._borrowOut = new System.Windows.Forms.Button();
            this._columnBookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnPublication = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnBookID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._groupBoxBooks.SuspendLayout();
            this._groupBoxBookIntroduction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // _groupBoxBooks
            // 
            this._groupBoxBooks.Controls.Add(this._addBookButton);
            this._groupBoxBooks.Controls.Add(this._groupBoxBookIntroduction);
            this._groupBoxBooks.Controls.Add(this._bookCategoryPage);
            this._groupBoxBooks.Location = new System.Drawing.Point(26, 57);
            this._groupBoxBooks.Name = "_groupBoxBooks";
            this._groupBoxBooks.Size = new System.Drawing.Size(296, 331);
            this._groupBoxBooks.TabIndex = 0;
            this._groupBoxBooks.TabStop = false;
            this._groupBoxBooks.Text = "書籍";
            // 
            // _addBookButton
            // 
            this._addBookButton.Location = new System.Drawing.Point(209, 298);
            this._addBookButton.Name = "_addBookButton";
            this._addBookButton.Size = new System.Drawing.Size(75, 23);
            this._addBookButton.TabIndex = 2;
            this._addBookButton.Text = "加入借書單";
            this._addBookButton.UseVisualStyleBackColor = true;
            // 
            // _groupBoxBookIntroduction
            // 
            this._groupBoxBookIntroduction.Controls.Add(this._bookRemainLabel);
            this._groupBoxBookIntroduction.Controls.Add(this._bookDetail);
            this._groupBoxBookIntroduction.Location = new System.Drawing.Point(17, 147);
            this._groupBoxBookIntroduction.Name = "_groupBoxBookIntroduction";
            this._groupBoxBookIntroduction.Size = new System.Drawing.Size(267, 144);
            this._groupBoxBookIntroduction.TabIndex = 1;
            this._groupBoxBookIntroduction.TabStop = false;
            this._groupBoxBookIntroduction.Text = "書籍介紹";
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
            // _bookDetail
            // 
            this._bookDetail.Location = new System.Drawing.Point(6, 21);
            this._bookDetail.Name = "_bookDetail";
            this._bookDetail.Size = new System.Drawing.Size(256, 98);
            this._bookDetail.TabIndex = 0;
            this._bookDetail.Text = "";
            // 
            // _bookCategoryPage
            // 
            this._bookCategoryPage.Location = new System.Drawing.Point(17, 21);
            this._bookCategoryPage.Name = "_bookCategoryPage";
            this._bookCategoryPage.SelectedIndex = 0;
            this._bookCategoryPage.Size = new System.Drawing.Size(267, 120);
            this._bookCategoryPage.TabIndex = 0;
            // 
            // _dataGridView1
            // 
            this._dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._columnBookName,
            this._columnAuthor,
            this._columnPublication,
            this._columnBookID});
            this._dataGridView1.Location = new System.Drawing.Point(336, 88);
            this._dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this._dataGridView1.Name = "_dataGridView1";
            this._dataGridView1.RowHeadersWidth = 51;
            this._dataGridView1.RowTemplate.Height = 27;
            this._dataGridView1.Size = new System.Drawing.Size(425, 251);
            this._dataGridView1.TabIndex = 1;
            // 
            // _borrowLabel
            // 
            this._borrowLabel.AutoSize = true;
            this._borrowLabel.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._borrowLabel.Location = new System.Drawing.Point(532, 57);
            this._borrowLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._borrowLabel.Name = "_borrowLabel";
            this._borrowLabel.Size = new System.Drawing.Size(78, 28);
            this._borrowLabel.TabIndex = 2;
            this._borrowLabel.Text = "借書單";
            // 
            // _borrowBooksAmountLabel
            // 
            this._borrowBooksAmountLabel.AutoSize = true;
            this._borrowBooksAmountLabel.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Bold);
            this._borrowBooksAmountLabel.Location = new System.Drawing.Point(334, 358);
            this._borrowBooksAmountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._borrowBooksAmountLabel.Name = "_borrowBooksAmountLabel";
            this._borrowBooksAmountLabel.Size = new System.Drawing.Size(82, 14);
            this._borrowBooksAmountLabel.TabIndex = 3;
            this._borrowBooksAmountLabel.Text = "借書數量：";
            // 
            // _borrowOut
            // 
            this._borrowOut.Location = new System.Drawing.Point(676, 350);
            this._borrowOut.Margin = new System.Windows.Forms.Padding(2);
            this._borrowOut.Name = "_borrowOut";
            this._borrowOut.Size = new System.Drawing.Size(85, 31);
            this._borrowOut.TabIndex = 4;
            this._borrowOut.Text = "確認借書";
            this._borrowOut.UseVisualStyleBackColor = true;
            // 
            // _columnBookName
            // 
            this._columnBookName.HeaderText = "書籍名稱";
            this._columnBookName.MinimumWidth = 6;
            this._columnBookName.Name = "_columnBookName";
            // 
            // _columnAuthor
            // 
            this._columnAuthor.HeaderText = "作者";
            this._columnAuthor.MinimumWidth = 6;
            this._columnAuthor.Name = "_columnAuthor";
            // 
            // _columnPublication
            // 
            this._columnPublication.HeaderText = "出版項";
            this._columnPublication.MinimumWidth = 6;
            this._columnPublication.Name = "_columnPublication";
            // 
            // _columnBookID
            // 
            this._columnBookID.HeaderText = "書籍編號";
            this._columnBookID.MinimumWidth = 6;
            this._columnBookID.Name = "_columnBookID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._borrowOut);
            this.Controls.Add(this._borrowBooksAmountLabel);
            this.Controls.Add(this._borrowLabel);
            this.Controls.Add(this._dataGridView1);
            this.Controls.Add(this._groupBoxBooks);
            this.Name = "Form1";
            this.Text = "HW1";
            this._groupBoxBooks.ResumeLayout(false);
            this._groupBoxBookIntroduction.ResumeLayout(false);
            this._groupBoxBookIntroduction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupBoxBooks;
        private System.Windows.Forms.GroupBox _groupBoxBookIntroduction;
        private System.Windows.Forms.Label _bookRemainLabel;
        private System.Windows.Forms.RichTextBox _bookDetail;
        private System.Windows.Forms.Button _addBookButton;
        private System.Windows.Forms.DataGridView _dataGridView1;
        private System.Windows.Forms.Label _borrowLabel;
        private System.Windows.Forms.Label _borrowBooksAmountLabel;
        private System.Windows.Forms.Button _borrowOut;
        private System.Windows.Forms.TabControl _bookCategoryPage;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnBookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnPublication;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnBookID;
    }
}

