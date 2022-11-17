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
            _library._modelChangedManagement += UpdateBackPackDataView;
            _presentationModel = presentationModel;
            InitializeComponent();
            UpdateBackPackDataView();
            _presentationModel._modelChanged += EditErrorMessageBox;
            _library._modelChangedDeleteRow += DeleteRow;
            _library._modelChanged += UpdateBackPackDataView;
        }

        // DeleteRow
        private void DeleteRow()
        {
            int row = _backPackDataView.CurrentCell.RowIndex;
            _backPackDataView.Rows.RemoveAt(row);
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
                int returnAmount = int.Parse(dataGridView[1, e.RowIndex].Value.ToString());
                _library.ReturnBookToLibrary(e.RowIndex, returnAmount);
                MessageBox.Show(_library.GetReturnBookText(), "歸還結果");
            }
        }

        // BackPackDataViewEditingControlShowing event
        private void BackPackDataViewEditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.TextChanged += new EventHandler(ChangeCellValue);
        }

        // CellValueChanged
        private void ChangeCellValue(object sender, EventArgs e)
        {
            _backPackDataView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // BackPackDataViewCellValueChanged event
        private void BackPackDataViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (e.RowIndex < 0)
                return;
            string nowText = dataGridView.CurrentCell.Value.ToString();
            int bookTag = _library.GetBorrowedListTagByIndex(e.RowIndex);
            _presentationModel.SetEditSelectBookTag(bookTag);
            _presentationModel.SetEditingAmount(nowText);
            _presentationModel.JudgeEditing();
        }

        // EditErrorMessageBox
        private void EditErrorMessageBox()
        {
            _backPackDataView.EndEdit();
            _backPackDataView.CellValueChanged -= BackPackDataViewCellValueChanged;
            _backPackDataView.CurrentCell.Value = _presentationModel.GetCurrentAmount();
            _backPackDataView.CellValueChanged += BackPackDataViewCellValueChanged;
            int borrowedListIndex = _backPackDataView.CurrentCell.RowIndex;
            string message = _presentationModel.GetErrorMessageBoxText();
            string title = _presentationModel.GetErrorMessageBoxTitle();
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, title, buttons);
        }
    }
}
