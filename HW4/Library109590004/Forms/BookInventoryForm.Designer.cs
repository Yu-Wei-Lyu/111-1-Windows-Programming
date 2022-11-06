
namespace Library109590004
{
    partial class BookInventoryForm
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
            this._inventoryBigTitleLabel = new System.Windows.Forms.Label();
            this._inventoryDataView = new System.Windows.Forms.DataGridView();
            this._inventoryDataViewBookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._inventoryDataViewBookCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._inventoryDataViewBookAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._inventoryDataViewSupply = new System.Windows.Forms.DataGridViewButtonColumn();
            this._bookImageLabel = new System.Windows.Forms.Label();
            this._bookPictureBox = new System.Windows.Forms.PictureBox();
            this._bookInformationLabel = new System.Windows.Forms.Label();
            this._bookDetailTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this._inventoryDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bookPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _inventoryBigTitleLabel
            // 
            this._inventoryBigTitleLabel.AutoSize = true;
            this._inventoryBigTitleLabel.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._inventoryBigTitleLabel.Location = new System.Drawing.Point(257, 20);
            this._inventoryBigTitleLabel.Name = "_inventoryBigTitleLabel";
            this._inventoryBigTitleLabel.Size = new System.Drawing.Size(273, 40);
            this._inventoryBigTitleLabel.TabIndex = 0;
            this._inventoryBigTitleLabel.Text = "書籍庫存管理系統";
            // 
            // _inventoryDataView
            // 
            this._inventoryDataView.AllowUserToAddRows = false;
            this._inventoryDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._inventoryDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this._inventoryDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._inventoryDataViewBookName,
            this._inventoryDataViewBookCategory,
            this._inventoryDataViewBookAmount,
            this._inventoryDataViewSupply});
            this._inventoryDataView.Location = new System.Drawing.Point(70, 72);
            this._inventoryDataView.Margin = new System.Windows.Forms.Padding(2);
            this._inventoryDataView.Name = "_inventoryDataView";
            this._inventoryDataView.ReadOnly = true;
            this._inventoryDataView.RowHeadersVisible = false;
            this._inventoryDataView.RowHeadersWidth = 51;
            this._inventoryDataView.RowTemplate.Height = 27;
            this._inventoryDataView.Size = new System.Drawing.Size(356, 348);
            this._inventoryDataView.TabIndex = 1;
            this._inventoryDataView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DoingInventoryDataViewCellClick);
            this._inventoryDataView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.SetInventoryDataViewCellPainting);
            // 
            // _inventoryDataViewBookName
            // 
            this._inventoryDataViewBookName.FillWeight = 192.6206F;
            this._inventoryDataViewBookName.HeaderText = "書籍名稱";
            this._inventoryDataViewBookName.MinimumWidth = 6;
            this._inventoryDataViewBookName.Name = "_inventoryDataViewBookName";
            this._inventoryDataViewBookName.ReadOnly = true;
            this._inventoryDataViewBookName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _inventoryDataViewBookCategory
            // 
            this._inventoryDataViewBookCategory.HeaderText = "書籍類別";
            this._inventoryDataViewBookCategory.MinimumWidth = 6;
            this._inventoryDataViewBookCategory.Name = "_inventoryDataViewBookCategory";
            this._inventoryDataViewBookCategory.ReadOnly = true;
            this._inventoryDataViewBookCategory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _inventoryDataViewBookAmount
            // 
            this._inventoryDataViewBookAmount.FillWeight = 55F;
            this._inventoryDataViewBookAmount.HeaderText = "數量";
            this._inventoryDataViewBookAmount.MinimumWidth = 6;
            this._inventoryDataViewBookAmount.Name = "_inventoryDataViewBookAmount";
            this._inventoryDataViewBookAmount.ReadOnly = true;
            this._inventoryDataViewBookAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _inventoryDataViewSupply
            // 
            this._inventoryDataViewSupply.FillWeight = 55F;
            this._inventoryDataViewSupply.HeaderText = "補貨";
            this._inventoryDataViewSupply.Name = "_inventoryDataViewSupply";
            this._inventoryDataViewSupply.ReadOnly = true;
            // 
            // _bookImageLabel
            // 
            this._bookImageLabel.AutoSize = true;
            this._bookImageLabel.Location = new System.Drawing.Point(469, 72);
            this._bookImageLabel.Name = "_bookImageLabel";
            this._bookImageLabel.Size = new System.Drawing.Size(53, 12);
            this._bookImageLabel.TabIndex = 2;
            this._bookImageLabel.Text = "書籍圖片";
            // 
            // _bookPictureBox
            // 
            this._bookPictureBox.Location = new System.Drawing.Point(471, 87);
            this._bookPictureBox.Name = "_bookPictureBox";
            this._bookPictureBox.Size = new System.Drawing.Size(110, 138);
            this._bookPictureBox.TabIndex = 3;
            this._bookPictureBox.TabStop = false;
            // 
            // _bookInformationLabel
            // 
            this._bookInformationLabel.AutoSize = true;
            this._bookInformationLabel.Location = new System.Drawing.Point(469, 238);
            this._bookInformationLabel.Name = "_bookInformationLabel";
            this._bookInformationLabel.Size = new System.Drawing.Size(53, 12);
            this._bookInformationLabel.TabIndex = 4;
            this._bookInformationLabel.Text = "書籍資訊";
            // 
            // _bookDetailTextBox
            // 
            this._bookDetailTextBox.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._bookDetailTextBox.Location = new System.Drawing.Point(471, 253);
            this._bookDetailTextBox.Name = "_bookDetailTextBox";
            this._bookDetailTextBox.ReadOnly = true;
            this._bookDetailTextBox.Size = new System.Drawing.Size(258, 167);
            this._bookDetailTextBox.TabIndex = 5;
            this._bookDetailTextBox.Text = "";
            // 
            // BookInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._bookDetailTextBox);
            this.Controls.Add(this._bookInformationLabel);
            this.Controls.Add(this._bookPictureBox);
            this.Controls.Add(this._bookImageLabel);
            this.Controls.Add(this._inventoryDataView);
            this.Controls.Add(this._inventoryBigTitleLabel);
            this.Name = "BookInventoryForm";
            this.Text = "BookInventoryForm";
            ((System.ComponentModel.ISupportInitialize)(this._inventoryDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bookPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _inventoryBigTitleLabel;
        private System.Windows.Forms.DataGridView _inventoryDataView;
        private System.Windows.Forms.Label _bookImageLabel;
        private System.Windows.Forms.PictureBox _bookPictureBox;
        private System.Windows.Forms.Label _bookInformationLabel;
        private System.Windows.Forms.RichTextBox _bookDetailTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _inventoryDataViewBookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _inventoryDataViewBookCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn _inventoryDataViewBookAmount;
        private System.Windows.Forms.DataGridViewButtonColumn _inventoryDataViewSupply;
    }
}