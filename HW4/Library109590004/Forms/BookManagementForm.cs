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
    public partial class BookManagementForm : Form
    {
        private BookManagementPresentationModel _presentationModel;
        private LibraryModel _library;
        public BookManagementForm(BookManagementPresentationModel presentationModel, LibraryModel library)
        {
            _library = library;
            _presentationModel = presentationModel;
            InitializeComponent();
            InitializeListBox();
        }

        // InitializeListBox
        private void InitializeListBox()
        {
            _presentationModel.UpdateLibraryBooks();
            _bookListBox.Items.Clear();
            for (int i = 0; i < _presentationModel.GetBooksCount(); i++)
            {
                _bookListBox.Items.Add(GetBookNameByTag(i));
            }
        }

        // GetBookNameByTag
        private string GetBookNameByTag(int tag)
        {
            return _presentationModel.GetBookNameByTag(tag);
        }

        // BookListBoxClick
        private void BookListBoxClick(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            int bookTag = listBox.SelectedIndex;
            _bookNameTextBox.Text = _presentationModel.GetBookNameByTag(bookTag);
            _bookIdTextBox.Text = _presentationModel.GetBookNameByTag(bookTag);
            _bookAuthorTextBox.Text = _presentationModel.GetBookNameByTag(bookTag);
            _bookCategoryComboBox.Text = _presentationModel.GetBookNameByTag(bookTag);
            _bookNameTextBox.Text = _presentationModel.GetBookNameByTag(bookTag);
            _bookNameTextBox.Text = _presentationModel.GetBookNameByTag(bookTag);
        }
    }
}
