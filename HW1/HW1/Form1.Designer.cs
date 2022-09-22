
namespace HW1
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
            this.groupBoxBooks = new System.Windows.Forms.GroupBox();
            this.addBookButton = new System.Windows.Forms.Button();
            this.groupBoxBookIntroduction = new System.Windows.Forms.GroupBox();
            this.bookRemainLabel = new System.Windows.Forms.Label();
            this.richTextBoxBookDesc = new System.Windows.Forms.RichTextBox();
            this.bookCategoryPage = new System.Windows.Forms.TabControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnBookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPublication = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnBookID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.confirmBorrowBtn = new System.Windows.Forms.Button();
            this.groupBoxBooks.SuspendLayout();
            this.groupBoxBookIntroduction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxBooks
            // 
            this.groupBoxBooks.Controls.Add(this.addBookButton);
            this.groupBoxBooks.Controls.Add(this.groupBoxBookIntroduction);
            this.groupBoxBooks.Controls.Add(this.bookCategoryPage);
            this.groupBoxBooks.Location = new System.Drawing.Point(34, 71);
            this.groupBoxBooks.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxBooks.Name = "groupBoxBooks";
            this.groupBoxBooks.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxBooks.Size = new System.Drawing.Size(394, 414);
            this.groupBoxBooks.TabIndex = 0;
            this.groupBoxBooks.TabStop = false;
            this.groupBoxBooks.Text = "書籍";
            // 
            // addBookButton
            // 
            this.addBookButton.Location = new System.Drawing.Point(279, 372);
            this.addBookButton.Margin = new System.Windows.Forms.Padding(4);
            this.addBookButton.Name = "addBookButton";
            this.addBookButton.Size = new System.Drawing.Size(100, 29);
            this.addBookButton.TabIndex = 2;
            this.addBookButton.Text = "加入借書單";
            this.addBookButton.UseVisualStyleBackColor = true;
            this.addBookButton.Click += new System.EventHandler(this.addBookButton_Click);
            // 
            // groupBoxBookIntroduction
            // 
            this.groupBoxBookIntroduction.Controls.Add(this.bookRemainLabel);
            this.groupBoxBookIntroduction.Controls.Add(this.richTextBoxBookDesc);
            this.groupBoxBookIntroduction.Location = new System.Drawing.Point(23, 184);
            this.groupBoxBookIntroduction.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxBookIntroduction.Name = "groupBoxBookIntroduction";
            this.groupBoxBookIntroduction.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxBookIntroduction.Size = new System.Drawing.Size(356, 180);
            this.groupBoxBookIntroduction.TabIndex = 1;
            this.groupBoxBookIntroduction.TabStop = false;
            this.groupBoxBookIntroduction.Text = "書籍介紹";
            // 
            // bookRemainLabel
            // 
            this.bookRemainLabel.AutoSize = true;
            this.bookRemainLabel.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Bold);
            this.bookRemainLabel.Location = new System.Drawing.Point(8, 152);
            this.bookRemainLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bookRemainLabel.Name = "bookRemainLabel";
            this.bookRemainLabel.Size = new System.Drawing.Size(98, 17);
            this.bookRemainLabel.TabIndex = 1;
            this.bookRemainLabel.Text = "剩餘數量：";
            // 
            // richTextBoxBookDesc
            // 
            this.richTextBoxBookDesc.Location = new System.Drawing.Point(8, 26);
            this.richTextBoxBookDesc.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxBookDesc.Name = "richTextBoxBookDesc";
            this.richTextBoxBookDesc.Size = new System.Drawing.Size(340, 122);
            this.richTextBoxBookDesc.TabIndex = 0;
            this.richTextBoxBookDesc.Text = "";
            // 
            // bookCategoryPage
            // 
            this.bookCategoryPage.Location = new System.Drawing.Point(23, 26);
            this.bookCategoryPage.Margin = new System.Windows.Forms.Padding(4);
            this.bookCategoryPage.Name = "bookCategoryPage";
            this.bookCategoryPage.SelectedIndex = 0;
            this.bookCategoryPage.Size = new System.Drawing.Size(356, 150);
            this.bookCategoryPage.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnBookName,
            this.columnAuthor,
            this.columnPublication,
            this.columnBookID});
            this.dataGridView1.Location = new System.Drawing.Point(448, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(567, 314);
            this.dataGridView1.TabIndex = 1;
            // 
            // ColumnBookName
            // 
            this.ColumnBookName.HeaderText = "書籍名稱";
            this.ColumnBookName.MinimumWidth = 6;
            this.ColumnBookName.Name = "ColumnBookName";
            // 
            // columnAuthor
            // 
            this.columnAuthor.HeaderText = "作者";
            this.columnAuthor.MinimumWidth = 6;
            this.columnAuthor.Name = "columnAuthor";
            // 
            // columnPublication
            // 
            this.columnPublication.HeaderText = "出版項";
            this.columnPublication.MinimumWidth = 6;
            this.columnPublication.Name = "columnPublication";
            // 
            // columnBookID
            // 
            this.columnBookID.HeaderText = "書籍編號";
            this.columnBookID.MinimumWidth = 6;
            this.columnBookID.Name = "columnBookID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(709, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "借書單";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(445, 448);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "借書數量：";
            // 
            // confirmBorrowBtn
            // 
            this.confirmBorrowBtn.Location = new System.Drawing.Point(902, 438);
            this.confirmBorrowBtn.Name = "confirmBorrowBtn";
            this.confirmBorrowBtn.Size = new System.Drawing.Size(113, 39);
            this.confirmBorrowBtn.TabIndex = 4;
            this.confirmBorrowBtn.Text = "確認借書";
            this.confirmBorrowBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.confirmBorrowBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBoxBooks);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "HW1";
            this.groupBoxBooks.ResumeLayout(false);
            this.groupBoxBookIntroduction.ResumeLayout(false);
            this.groupBoxBookIntroduction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBooks;
        private System.Windows.Forms.GroupBox groupBoxBookIntroduction;
        private System.Windows.Forms.Label bookRemainLabel;
        private System.Windows.Forms.RichTextBox richTextBoxBookDesc;
        private System.Windows.Forms.Button addBookButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button confirmBorrowBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPublication;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnBookID;
        private System.Windows.Forms.TabControl bookCategoryPage;
    }
}

