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
        SupplyForm _supplyForm;
        BookInventoryPresentationModel _presentationModel;
        LibraryModel _library;
        LibraryMessages _messages;

        public BookInventoryForm(BookInventoryPresentationModel presentationModel, LibraryModel library)
        {
            _presentationModel = presentationModel;
            _library = library;
            _library._modelChanged += InitializeDataGridView;
            _messages = new LibraryMessages(library);
            InitializeComponent();
            InitializeDataGridView();
            _supplyForm = new SupplyForm(new SupplyPresentationModel(library), library);
            _supplyForm.FormClosing += new FormClosingEventHandler(ClosingSupplyForm);
        }

        // Initialize DataGridView
        private void InitializeDataGridView()
        {
            _inventoryDataView.Rows.Clear();
            for (int bookTag = 0; bookTag < _library.GetBooksCount(); bookTag++)
            {
                _inventoryDataView.Rows.Add(GetInventoryDataCellsByTag(bookTag));
            }
        }

        // Get inventory data cells
        public string[] GetInventoryDataCellsByTag(int bookTag)
        {
            Book book = _library.GetBookByTag(bookTag);
            return new string[] { book.Name, GetCategoryNameByBookTag(bookTag), GetBookAmountByTag(bookTag).ToString() };
        }

        // GetBookAmountByTag
        private object GetBookAmountByTag(int bookTag)
        {
            return _library.GetBookAmountByTag(bookTag);
        }

        // GetCategoryNameByBookTag
        private string GetCategoryNameByBookTag(int bookTag)
        {
            return _library.GetCategoryNameByBookTag(bookTag);
        }

        // Closing supply form event
        private void ClosingSupplyForm(object sender, FormClosingEventArgs e)
        {
            InitializeDataGridView();
            e.Cancel = true;
            _supplyForm.Hide();
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

        // Inventory data view cell click event
        private void DoingInventoryDataViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (e.RowIndex == -1)
                return;
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                _supplyForm.OpenSupplyForm(e.RowIndex);
            }
            else
            {
                _bookPictureBox.Image = _library.GetBookImageByTag(e.RowIndex);
                _bookDetailTextBox.Text = _messages.GetBookDetail(e.RowIndex);
            }
        }
    }
}
