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

        public BookInventoryForm(BookInventoryPresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            InitializeComponent();
        }

        // Inventory data grid view cell painting event
        private void InventoryDataViewCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 3 && e.ColumnIndex < dataGridView.ColumnCount - 1)
            {
                const int two = 2;
                Image img = _presentationModel.GetReplenishmentImage();
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = img.Width;
                var h = img.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / two;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / two;
                e.Graphics.DrawImage(img, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }
    }
}
