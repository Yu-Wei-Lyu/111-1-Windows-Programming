using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library109590004
{
    public partial class BookInventoryForm : Form
    {
        BookInventoryPresentationModel _presentationModel;
        LibraryModel _library;

        public BookInventoryForm(BookInventoryPresentationModel presentationModel, LibraryModel library)
        {
            _presentationModel = presentationModel;
            _library = library;
            InitializeComponent();
            for(int i = 0; i < _library.GetBookCount(); i++)
            {
                _inventoryDataView.Rows.Add(_library.GetInventoryDataCells(i));
            }
        }

        // Get category count
        private int GetCategoryCount()
        {
            return _library.GetCategoryCount();
        }

        // Get category name by index
        private string GetCategoryName(int categoryIndex)
        {
            return _library.GetCategoryName(categoryIndex);
        }

        // Get books count by category index
        private int GetBookCount(int categoryIndex)
        {
            return _library.GetBookCount(categoryIndex);
        }

        // Inventory data grid view cell painting event
        private void SetInventoryDataViewCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 3)
            {
                const int two = 2;
                Image img = _presentationModel.GetSupplyImage();
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = img.Width;
                var h = img.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / two;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / two;
                e.Graphics.DrawImage(img, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        // Inventory data view cell content click event
        private void InventoryDataViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int a = 0;
            }
            else
            {
                _bookPictureBox.Image = _library.GetBookImageByTag(e.RowIndex);
                _bookDetailTextBox.Text = _library.GetBookDetail(e.RowIndex);
            }
        }

        private void BookInventoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
