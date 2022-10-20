
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
            this._bigTitleLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._inventoryDataViewBookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._inventoryDataViewBookCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._inventoryDataViewBookAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._inventoryDataViewReplenishment = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // _bigTitleLabel
            // 
            this._bigTitleLabel.AutoSize = true;
            this._bigTitleLabel.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._bigTitleLabel.Location = new System.Drawing.Point(343, 25);
            this._bigTitleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._bigTitleLabel.Name = "_bigTitleLabel";
            this._bigTitleLabel.Size = new System.Drawing.Size(342, 50);
            this._bigTitleLabel.TabIndex = 0;
            this._bigTitleLabel.Text = "書籍庫存管理系統";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._inventoryDataViewBookName,
            this._inventoryDataViewBookCategory,
            this._inventoryDataViewBookAmount,
            this._inventoryDataViewReplenishment});
            this.dataGridView1.Location = new System.Drawing.Point(35, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(413, 435);
            this.dataGridView1.TabIndex = 1;
            // 
            // _inventoryDataViewBookName
            // 
            this._inventoryDataViewBookName.FillWeight = 192.6206F;
            this._inventoryDataViewBookName.HeaderText = "書籍名稱";
            this._inventoryDataViewBookName.MinimumWidth = 6;
            this._inventoryDataViewBookName.Name = "_inventoryDataViewBookName";
            // 
            // _inventoryDataViewBookCategory
            // 
            this._inventoryDataViewBookCategory.HeaderText = "書籍類別";
            this._inventoryDataViewBookCategory.MinimumWidth = 6;
            this._inventoryDataViewBookCategory.Name = "_inventoryDataViewBookCategory";
            // 
            // _inventoryDataViewBookAmount
            // 
            this._inventoryDataViewBookAmount.FillWeight = 40F;
            this._inventoryDataViewBookAmount.HeaderText = "數量";
            this._inventoryDataViewBookAmount.MinimumWidth = 6;
            this._inventoryDataViewBookAmount.Name = "_inventoryDataViewBookAmount";
            // 
            // _inventoryDataViewReplenishment
            // 
            this._inventoryDataViewReplenishment.FillWeight = 40F;
            this._inventoryDataViewReplenishment.HeaderText = "補貨";
            this._inventoryDataViewReplenishment.MinimumWidth = 6;
            this._inventoryDataViewReplenishment.Name = "_inventoryDataViewReplenishment";
            this._inventoryDataViewReplenishment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._inventoryDataViewReplenishment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // BookInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this._bigTitleLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BookInventoryForm";
            this.Text = "BookInventoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _bigTitleLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _inventoryDataViewBookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _inventoryDataViewBookCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn _inventoryDataViewBookAmount;
        private System.Windows.Forms.DataGridViewButtonColumn _inventoryDataViewReplenishment;
    }
}