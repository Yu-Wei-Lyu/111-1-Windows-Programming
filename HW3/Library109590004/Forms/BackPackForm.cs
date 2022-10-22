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
    public partial class BackPackForm : Form
    {
        BackPackPresentationModel _presentationModel;
        LibraryModel _library;
        public BackPackForm(BackPackPresentationModel presentationModel, LibraryModel library)
        {
            _library = library;
            _presentationModel = presentationModel;
            InitializeComponent();
            UpdateBackPackDataView();
        }

        // Initialize BackPack data view
        public void UpdateBackPackDataView()
        {
            _backPackDataView.Rows.Clear();
            for (int i = 0; i < _library.GetBorrowedListCount(); i++)
            {
                _backPackDataView.Rows.Add(GetBorrowedListRow(i));
            }
        }

        // Get borrowed list row
        public string[] GetBorrowedListRow(int index)
        {
            return _library.GetBorrowedItemCells(index);
        }

        // Borrowing data view cell content click event
        private void BackPackDataViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                dataGridView.Rows.RemoveAt(e.RowIndex);
                _library.ReturnBookToLibrary(e.RowIndex);
                MessageBox.Show(_library.GetReturnBookText());
            }
        }
    }
}
