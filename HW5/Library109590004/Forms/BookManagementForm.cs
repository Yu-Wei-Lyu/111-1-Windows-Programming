using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library109590004
{
    public partial class BookManagementForm : Form
    {
        private const string ENABLED = "Enabled";
        private const string TEXT = "Text";
        private BookManagementPresentationModel _presentationModel;
        private LibraryModel _library;
        public BookManagementForm(BookManagementPresentationModel presentationModel, LibraryModel library)
        {
            _library = library;
            _library._modelChangedManagement += InitializeListBox;
            _presentationModel = presentationModel;
            InitializeComponent();
            InitializeListBox();
            SetDataBindingComponent();
            _addBookButton.Enabled = false;
            _updateBookGroupBox.DataBindings.Add(ENABLED, _presentationModel, "IsGroupBoxEnabled");
            _applyChangedButton.DataBindings.Add(ENABLED, _presentationModel, "IsApplyChanged");
            _browseButton.DataBindings.Add(ENABLED, _presentationModel, "IsBrowse");
            string[] categoriesName = _presentationModel.GetCategoriesNameList();
            _bookCategoryComboBox.Items.AddRange(categoriesName);
        }

        // SetDataBindingComponent
        private void SetDataBindingComponent()
        {
            _bookNameTextBox.DataBindings.Add(TEXT, _presentationModel, "NameText", true, DataSourceUpdateMode.OnPropertyChanged);
            _bookIdTextBox.DataBindings.Add(TEXT, _presentationModel, "IdText", true, DataSourceUpdateMode.OnPropertyChanged);
            _bookAuthorTextBox.DataBindings.Add(TEXT, _presentationModel, "AuthorText", true, DataSourceUpdateMode.OnPropertyChanged);
            _bookCategoryComboBox.DataBindings.Add(TEXT, _presentationModel, "CategoryText", true, DataSourceUpdateMode.OnPropertyChanged);
            _bookPublicationTextBox.DataBindings.Add(TEXT, _presentationModel, "PublicationText", true, DataSourceUpdateMode.OnPropertyChanged);
            _bookImagePathTextBox.DataBindings.Add(TEXT, _presentationModel, "ImagePathText", true, DataSourceUpdateMode.OnPropertyChanged);
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

        // BookListBoxClick event
        private void BookListBoxClick(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            int bookTag = listBox.SelectedIndex;
            _presentationModel.SetSelectedTag(bookTag);
        }

        // ApplyChangesButtonClick event
        private void ApplyChangedButtonClick(object sender, EventArgs e)
        {
            _presentationModel.UpdateBookDetail();
        }

        // BrowseButtonClick event
        private void BrowseButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files|*.jpg;*.jpeg;*.png;";
            dialog.InitialDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\Image\\"));
            dialog.Title = "請選擇書籍圖片";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _bookImagePathTextBox.Text = dialog.FileName;
            }
        }
    }
}
