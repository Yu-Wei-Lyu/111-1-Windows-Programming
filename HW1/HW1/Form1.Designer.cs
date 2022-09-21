
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
            this.addToBorrowingListBtn = new System.Windows.Forms.Button();
            this.groupBoxBookIntroduction = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxBookDesc = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageJune = new System.Windows.Forms.TabPage();
            this.bookBtn3 = new System.Windows.Forms.Button();
            this.bookBtn2 = new System.Windows.Forms.Button();
            this.bookBtn1 = new System.Windows.Forms.Button();
            this.tabPageApril = new System.Windows.Forms.TabPage();
            this.bookBtn6 = new System.Windows.Forms.Button();
            this.bookBtn5 = new System.Windows.Forms.Button();
            this.bookBtn4 = new System.Windows.Forms.Button();
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
            this.tabControl1.SuspendLayout();
            this.tabPageJune.SuspendLayout();
            this.tabPageApril.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxBooks
            // 
            this.groupBoxBooks.Controls.Add(this.addToBorrowingListBtn);
            this.groupBoxBooks.Controls.Add(this.groupBoxBookIntroduction);
            this.groupBoxBooks.Controls.Add(this.tabControl1);
            this.groupBoxBooks.Location = new System.Drawing.Point(74, 76);
            this.groupBoxBooks.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxBooks.Name = "groupBoxBooks";
            this.groupBoxBooks.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxBooks.Size = new System.Drawing.Size(297, 401);
            this.groupBoxBooks.TabIndex = 0;
            this.groupBoxBooks.TabStop = false;
            this.groupBoxBooks.Text = "書籍";
            // 
            // addToBorrowingListBtn
            // 
            this.addToBorrowingListBtn.Location = new System.Drawing.Point(180, 364);
            this.addToBorrowingListBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addToBorrowingListBtn.Name = "addToBorrowingListBtn";
            this.addToBorrowingListBtn.Size = new System.Drawing.Size(100, 29);
            this.addToBorrowingListBtn.TabIndex = 2;
            this.addToBorrowingListBtn.Text = "加入借書單";
            this.addToBorrowingListBtn.UseVisualStyleBackColor = true;
            // 
            // groupBoxBookIntroduction
            // 
            this.groupBoxBookIntroduction.Controls.Add(this.label1);
            this.groupBoxBookIntroduction.Controls.Add(this.richTextBoxBookDesc);
            this.groupBoxBookIntroduction.Location = new System.Drawing.Point(23, 175);
            this.groupBoxBookIntroduction.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxBookIntroduction.Name = "groupBoxBookIntroduction";
            this.groupBoxBookIntroduction.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxBookIntroduction.Size = new System.Drawing.Size(257, 181);
            this.groupBoxBookIntroduction.TabIndex = 1;
            this.groupBoxBookIntroduction.TabStop = false;
            this.groupBoxBookIntroduction.Text = "書籍介紹";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(8, 158);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "剩餘數量：";
            // 
            // richTextBoxBookDesc
            // 
            this.richTextBoxBookDesc.Location = new System.Drawing.Point(8, 26);
            this.richTextBoxBookDesc.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxBookDesc.Name = "richTextBoxBookDesc";
            this.richTextBoxBookDesc.Size = new System.Drawing.Size(240, 122);
            this.richTextBoxBookDesc.TabIndex = 0;
            this.richTextBoxBookDesc.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageJune);
            this.tabControl1.Controls.Add(this.tabPageApril);
            this.tabControl1.Location = new System.Drawing.Point(23, 26);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(267, 125);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageJune
            // 
            this.tabPageJune.Controls.Add(this.bookBtn3);
            this.tabPageJune.Controls.Add(this.bookBtn2);
            this.tabPageJune.Controls.Add(this.bookBtn1);
            this.tabPageJune.Location = new System.Drawing.Point(4, 25);
            this.tabPageJune.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageJune.Name = "tabPageJune";
            this.tabPageJune.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageJune.Size = new System.Drawing.Size(259, 96);
            this.tabPageJune.TabIndex = 0;
            this.tabPageJune.Text = "6月暢銷書";
            this.tabPageJune.UseVisualStyleBackColor = true;
            // 
            // bookBtn3
            // 
            this.bookBtn3.Location = new System.Drawing.Point(171, 8);
            this.bookBtn3.Margin = new System.Windows.Forms.Padding(4);
            this.bookBtn3.Name = "bookBtn3";
            this.bookBtn3.Size = new System.Drawing.Size(81, 78);
            this.bookBtn3.TabIndex = 2;
            this.bookBtn3.Text = "Book 3";
            this.bookBtn3.UseVisualStyleBackColor = true;
            // 
            // bookBtn2
            // 
            this.bookBtn2.Location = new System.Drawing.Point(89, 8);
            this.bookBtn2.Margin = new System.Windows.Forms.Padding(4);
            this.bookBtn2.Name = "bookBtn2";
            this.bookBtn2.Size = new System.Drawing.Size(81, 78);
            this.bookBtn2.TabIndex = 1;
            this.bookBtn2.Text = "Book 2";
            this.bookBtn2.UseVisualStyleBackColor = true;
            // 
            // bookBtn1
            // 
            this.bookBtn1.Location = new System.Drawing.Point(8, 8);
            this.bookBtn1.Margin = new System.Windows.Forms.Padding(4);
            this.bookBtn1.Name = "bookBtn1";
            this.bookBtn1.Size = new System.Drawing.Size(81, 78);
            this.bookBtn1.TabIndex = 0;
            this.bookBtn1.Text = "Book 1";
            this.bookBtn1.UseVisualStyleBackColor = true;
            // 
            // tabPageApril
            // 
            this.tabPageApril.Controls.Add(this.bookBtn6);
            this.tabPageApril.Controls.Add(this.bookBtn5);
            this.tabPageApril.Controls.Add(this.bookBtn4);
            this.tabPageApril.Location = new System.Drawing.Point(4, 25);
            this.tabPageApril.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageApril.Name = "tabPageApril";
            this.tabPageApril.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageApril.Size = new System.Drawing.Size(259, 96);
            this.tabPageApril.TabIndex = 1;
            this.tabPageApril.Text = "4月暢銷書";
            this.tabPageApril.UseVisualStyleBackColor = true;
            // 
            // bookBtn6
            // 
            this.bookBtn6.Location = new System.Drawing.Point(171, 8);
            this.bookBtn6.Margin = new System.Windows.Forms.Padding(4);
            this.bookBtn6.Name = "bookBtn6";
            this.bookBtn6.Size = new System.Drawing.Size(81, 78);
            this.bookBtn6.TabIndex = 2;
            this.bookBtn6.Text = "Book 6";
            this.bookBtn6.UseVisualStyleBackColor = true;
            // 
            // bookBtn5
            // 
            this.bookBtn5.Location = new System.Drawing.Point(89, 8);
            this.bookBtn5.Margin = new System.Windows.Forms.Padding(4);
            this.bookBtn5.Name = "bookBtn5";
            this.bookBtn5.Size = new System.Drawing.Size(81, 78);
            this.bookBtn5.TabIndex = 2;
            this.bookBtn5.Text = "Book 5";
            this.bookBtn5.UseVisualStyleBackColor = true;
            // 
            // bookBtn4
            // 
            this.bookBtn4.Location = new System.Drawing.Point(8, 8);
            this.bookBtn4.Margin = new System.Windows.Forms.Padding(4);
            this.bookBtn4.Name = "bookBtn4";
            this.bookBtn4.Size = new System.Drawing.Size(81, 78);
            this.bookBtn4.TabIndex = 1;
            this.bookBtn4.Text = "Book 4";
            this.bookBtn4.UseVisualStyleBackColor = true;
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
            this.dataGridView1.Location = new System.Drawing.Point(435, 127);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(446, 285);
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
            this.label2.Location = new System.Drawing.Point(615, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "借書單";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(433, 439);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "借書數量：";
            // 
            // confirmBorrowBtn
            // 
            this.confirmBorrowBtn.Location = new System.Drawing.Point(768, 430);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPageJune.ResumeLayout(false);
            this.tabPageApril.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBooks;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageJune;
        private System.Windows.Forms.Button bookBtn3;
        private System.Windows.Forms.Button bookBtn2;
        private System.Windows.Forms.Button bookBtn1;
        private System.Windows.Forms.TabPage tabPageApril;
        private System.Windows.Forms.GroupBox groupBoxBookIntroduction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxBookDesc;
        private System.Windows.Forms.Button bookBtn6;
        private System.Windows.Forms.Button bookBtn5;
        private System.Windows.Forms.Button bookBtn4;
        private System.Windows.Forms.Button addToBorrowingListBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button confirmBorrowBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPublication;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnBookID;
    }
}

