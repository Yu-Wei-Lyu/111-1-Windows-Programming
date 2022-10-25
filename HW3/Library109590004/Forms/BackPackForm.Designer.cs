
namespace Library109590004
{
    partial class BackPackForm
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
            this._backPackDataView = new System.Windows.Forms.DataGridView();
            this._backPackDataViewReturnButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this._backPackDataViewReturnAmount = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this._backPackDataViewBookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._backPackDataViewAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._backPackDataViewBorrowedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._backPackDataViewLatestReturnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._backPackDataViewBookId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._backPackDataViewBookAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._backPackDataViewBookPublication = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._backPackDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // _backPackDataView
            // 
            this._backPackDataView.AllowUserToAddRows = false;
            this._backPackDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._backPackDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._backPackDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._backPackDataViewReturnButton,
            this._backPackDataViewReturnAmount,
            this._backPackDataViewBookName,
            this._backPackDataViewAmount,
            this._backPackDataViewBorrowedDate,
            this._backPackDataViewLatestReturnDate,
            this._backPackDataViewBookId,
            this._backPackDataViewBookAuthor,
            this._backPackDataViewBookPublication});
            this._backPackDataView.Location = new System.Drawing.Point(16, 15);
            this._backPackDataView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._backPackDataView.Name = "_backPackDataView";
            this._backPackDataView.RowHeadersVisible = false;
            this._backPackDataView.RowHeadersWidth = 51;
            this._backPackDataView.RowTemplate.Height = 24;
            this._backPackDataView.Size = new System.Drawing.Size(1035, 469);
            this._backPackDataView.TabIndex = 0;
            this._backPackDataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BackPackDataViewCellContentClick);
            // 
            // _backPackDataViewReturnButton
            // 
            this._backPackDataViewReturnButton.FillWeight = 43.40272F;
            this._backPackDataViewReturnButton.HeaderText = "還書";
            this._backPackDataViewReturnButton.MinimumWidth = 6;
            this._backPackDataViewReturnButton.Name = "_backPackDataViewReturnButton";
            this._backPackDataViewReturnButton.Text = "";
            // 
            // _backPackDataViewReturnAmount
            // 
            this._backPackDataViewReturnAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this._backPackDataViewReturnAmount.HeaderText = "歸還數量";
            this._backPackDataViewReturnAmount.MinimumWidth = 6;
            this._backPackDataViewReturnAmount.Name = "_backPackDataViewReturnAmount";
            this._backPackDataViewReturnAmount.Width = 73;
            // 
            // _backPackDataViewBookName
            // 
            this._backPackDataViewBookName.FillWeight = 115.9473F;
            this._backPackDataViewBookName.HeaderText = "書籍名稱";
            this._backPackDataViewBookName.MinimumWidth = 6;
            this._backPackDataViewBookName.Name = "_backPackDataViewBookName";
            // 
            // _backPackDataViewAmount
            // 
            this._backPackDataViewAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this._backPackDataViewAmount.HeaderText = "已借數量";
            this._backPackDataViewAmount.MinimumWidth = 6;
            this._backPackDataViewAmount.Name = "_backPackDataViewAmount";
            this._backPackDataViewAmount.Width = 96;
            // 
            // _backPackDataViewBorrowedDate
            // 
            this._backPackDataViewBorrowedDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this._backPackDataViewBorrowedDate.FillWeight = 115.9473F;
            this._backPackDataViewBorrowedDate.HeaderText = "借書日期";
            this._backPackDataViewBorrowedDate.MinimumWidth = 6;
            this._backPackDataViewBorrowedDate.Name = "_backPackDataViewBorrowedDate";
            this._backPackDataViewBorrowedDate.Width = 96;
            // 
            // _backPackDataViewLatestReturnDate
            // 
            this._backPackDataViewLatestReturnDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this._backPackDataViewLatestReturnDate.FillWeight = 115.9473F;
            this._backPackDataViewLatestReturnDate.HeaderText = "還書期限";
            this._backPackDataViewLatestReturnDate.MinimumWidth = 6;
            this._backPackDataViewLatestReturnDate.Name = "_backPackDataViewLatestReturnDate";
            this._backPackDataViewLatestReturnDate.Width = 96;
            // 
            // _backPackDataViewBookId
            // 
            this._backPackDataViewBookId.FillWeight = 115.9473F;
            this._backPackDataViewBookId.HeaderText = "書籍編號";
            this._backPackDataViewBookId.MinimumWidth = 6;
            this._backPackDataViewBookId.Name = "_backPackDataViewBookId";
            // 
            // _backPackDataViewBookAuthor
            // 
            this._backPackDataViewBookAuthor.FillWeight = 115.9473F;
            this._backPackDataViewBookAuthor.HeaderText = "作者";
            this._backPackDataViewBookAuthor.MinimumWidth = 6;
            this._backPackDataViewBookAuthor.Name = "_backPackDataViewBookAuthor";
            // 
            // _backPackDataViewBookPublication
            // 
            this._backPackDataViewBookPublication.FillWeight = 115.9473F;
            this._backPackDataViewBookPublication.HeaderText = "出版項";
            this._backPackDataViewBookPublication.MinimumWidth = 6;
            this._backPackDataViewBookPublication.Name = "_backPackDataViewBookPublication";
            // 
            // BackPackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this._backPackDataView);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BackPackForm";
            this.Text = "BackPackForm";
            ((System.ComponentModel.ISupportInitialize)(this._backPackDataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _backPackDataView;
        private System.Windows.Forms.DataGridViewButtonColumn _backPackDataViewReturnButton;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn _backPackDataViewReturnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn _backPackDataViewBookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _backPackDataViewAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn _backPackDataViewBorrowedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn _backPackDataViewLatestReturnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn _backPackDataViewBookId;
        private System.Windows.Forms.DataGridViewTextBoxColumn _backPackDataViewBookAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn _backPackDataViewBookPublication;
    }
}