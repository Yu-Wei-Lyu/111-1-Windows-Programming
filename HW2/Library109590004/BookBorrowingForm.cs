using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Library109590004
{
    public partial class BookBorrowingForm : Form
    {
        private BookBorrowingFormPresentationModel _presentationModel;

        public BookBorrowingForm(BookBorrowingFormPresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            InitializeComponent();
            for (int categoryIndex = 0; categoryIndex < _presentationModel.GetCategoryCount(); categoryIndex++)
            {
                TabPage tabPage = new TabPage(_presentationModel.GetCategoryName(categoryIndex));
                for (int bookIndex = 0; bookIndex < _presentationModel.GetBookCount(categoryIndex); bookIndex++)
                {
                    Button button = new Button();
                    button.Location = _presentationModel.GetBookButtonLocation(bookIndex);
                    button.Text = "Book " + _presentationModel.GetBookNumber();
                    button.Size = _presentationModel.GetBookButtonSize();
                    button.Tag = _presentationModel.GetBookTag(categoryIndex, bookIndex);
                    button.Parent = tabPage;
                    button.Click += BookButtonClick;
                    tabPage.Controls.Add(button);
                }
                _bookCategoryTabControl.TabPages.Add(tabPage);
            }
            _addToBorrowingListButton.Enabled = false;
            _borrowButton.Enabled = false;
        }

        // TabControl initialize with resource
        private void InitializeTabControl()
        {

        }

        // Book button click event
        private void BookButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            _bookDetailTextBox.Text = _presentationModel.GetBookDetail(button.Tag.ToString());
            _bookRemainLabel.Text = _presentationModel.GetCurrentBookAmount();
            button.Enabled = _presentationModel.IsBookButtonEnable();
        }

        // Add book button click event
        private void AddBorrowingListButtonClick(object sender, EventArgs e)
        {
            /*Button button = (Button)sender;
            BookItem bookItem = _library.GetCurrentBookTagItem();
            if (bookItem.Amount > 0)
            {
                _library.BookAmountMinusOne();
                _borrowingDataView.Rows.Add(_library.GetCurrentBookName(), _library.GetCurrentBookId(), _library.GetCurrentBookAuthor(), _library.GetCurrentBookPublication());
                RefreshBookAmountLabel(bookItem);
            }
            AddBorrowingListButtonEnable(bookItem);*/
        }

        // Book detail richTextbox text changed event
        private void BookDetailTextChanged(object sender, EventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)sender;
            _addToBorrowingListButton.Enabled = (richTextBox.Text == "") ? false : true;
        }

        // Book category tabPage selected tab change event
        private void BookCategoryPageSelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            int indexOfPage = tabControl.SelectedIndex;
            Button button = (Button)tabControl.TabPages[indexOfPage].Controls[0];
            button.Select();
            button.PerformClick();
        }

        // Borrowing dataGridView rows added event
        private void BorrowingDataViewRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //_borrowingCountLabel.Text = BOOK_BORROWING_COUNT + (_borrowingDataView.Rows.Count - 1);
            _borrowButton.Enabled = true;
        }

        // Borrowing dataGridView rows removed event
        private void BorrowingDataViewRowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //_borrowingCountLabel.Text = BOOK_BORROWING_COUNT + (_borrowingDataView.Rows.Count - 1);
            if (_borrowingDataView.Rows.Count - 1 == 0)
            {
                _borrowButton.Enabled = false;
            }
        }
    }
}
