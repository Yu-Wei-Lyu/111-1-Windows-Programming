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
        public event Action _updateBorrowingForm;
        BookBorrowingForm _bookBorrowingForm;
        BackPackPresentationModel _presentationModel;
        public BackPackForm(BackPackPresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            InitializeComponent();
            InitializeBackPackDataView();
        }

        // Initialize BackPack data view
        public void InitializeBackPackDataView()
        {
            _presentationModel.InitializeViewRows();
            _backPackDataView.Rows.Clear();
            for (int i = 0; i < _presentationModel.GetBorrowedListCount(); i++)
            {
                _backPackDataView.Rows.Add(GetBorrowedListRow());
            }
        }

        // Get borrowed list row
        public string[] GetBorrowedListRow()
        {
            return _presentationModel.GetBorrowedListRow();
        }

        // Borrowing data view cell content click event
        private void BackPackDataViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                dataGridView.Rows.RemoveAt(e.RowIndex);
                _presentationModel.ReturnBookToLibrary(e.RowIndex);
                MessageBox.Show(_presentationModel.GetReturnBookText());
                UpdateBorrowingForm();
            }
        }

        // Update borrowing form
        public void UpdateBorrowingForm()
        {
            if (_updateBorrowingForm != null)
            {
                _updateBorrowingForm.Invoke();
            }
        }
    }
}
