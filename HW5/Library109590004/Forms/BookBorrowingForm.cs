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
        BackPackForm _backPackForm;
        private BookBorrowingPresentationModel _presentationModel;
        private LibraryModel _library;

        public BookBorrowingForm(BookBorrowingPresentationModel presentationModel, LibraryModel library)
        {
            _library = library;
            _library._modelChanged += UpdateBookDetailGroupBox;
            _library._modelChangedManagement += InitializeFormStatus;
            _library._modelChangedManagement += UpdateBorrowingDataView;
            _presentationModel = presentationModel;
            _presentationModel._modelChanged += EditErrorMessageBox;
            _backPackForm = new BackPackForm(new BackPackPresentationModel(_library), _library);
            _backPackForm.FormClosing += new FormClosingEventHandler(ClosingBackPackForm);
            InitializeComponent();
            InitializeFormStatus();
        }

        // BackPack form closing event
        private void ClosingBackPackForm(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            _openBackPackButton.Enabled = true;
            _backPackForm.Hide();
        }

        // Set page up and page down enable state
        private void SetLabelTextAndPageUpDownEnable()
        {
            _pageLabel.Text = _presentationModel.GetCurrentPageLabel();
            _pageUpButton.Enabled = _presentationModel.IsUpButtonEnable();
            _pageDownButton.Enabled = _presentationModel.IsDownButtonEnable();
        }

        // UpdateBorrowingDataView
        private void UpdateBorrowingDataView()
        {
            _borrowingDataView.Rows.Clear();
            for (int i = 0; i < GetBorrowingListCount(); i++)
            {
                int bookTag = GetBorrowingListTagByIndex(i);
                _borrowingDataView.Rows.Add(GetBookCellsByTag(bookTag));
            }
        }

        // GetBorrowingListCount
        private int GetBorrowingListCount()
        {
            return _library.GetBorrowingListCount();
        }

        // GetBorrowingListTagByIndex
        private int GetBorrowingListTagByIndex(int index)
        {
            return _library.GetBorrowingListTagByIndex(index);
        }

        // Initialize tabControl
        private void InitializeFormStatus()
        {
            _bookCategoryTabControl.SelectedIndexChanged -= BookCategoryPageSelectedIndexChanged;
            _bookCategoryTabControl.TabPages.Clear();
            for (int categoryIndex = 0; categoryIndex < GetCategoryCount(); categoryIndex++)
            {
                TabPage tabPage = new TabPage(GetCategoryName(categoryIndex));
                for (int bookIndex = 0; bookIndex < GetCategoryBooksCountByIndex(categoryIndex); bookIndex++)
                {
                    Button button = CreateBookButton(categoryIndex, bookIndex);
                    tabPage.Controls.Add(button);
                }
                _bookCategoryTabControl.TabPages.Add(tabPage);
            }
            InitializeBookDetailGroupBox();
            InitializePageLabel();
            SetLabelTextAndPageUpDownEnable();
            _bookCategoryTabControl.SelectedIndexChanged += BookCategoryPageSelectedIndexChanged;
        }

        // Initialize PageLabel
        private void InitializePageLabel()
        {
            _presentationModel.SetCategoryPageCountByIndex(0);
            _addListButton.Enabled = _presentationModel.IsAddListButtonEnable();
            _borrowingButton.Enabled = _presentationModel.IsBorrowingButtonEnable();
            _borrowingCountLabel.Text = _presentationModel.GetBorrowingBooksAmount();
        }

        // Create book button with index
        private Button CreateBookButton(int categoryIndex, int bookIndex)
        {
            int bookTag = _library.GetBookTag(categoryIndex, bookIndex);
            Button button = new Button();
            button.Tag = bookTag;
            button.Name = "Book " + bookTag;
            button.Size = _presentationModel.GetBookButtonSize();
            button.Location = _presentationModel.GetBookButtonLocation(bookIndex);
            button.BackgroundImage = Image.FromFile(GetBookImagePathByTag(bookTag));
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.Click += BookButtonClick;
            return button;
        }

        // Get book image by tag
        private string GetBookImagePathByTag(int bookTag)
        {
            return _library.GetBookImagePathByTag(bookTag);
        }

        // Book button click event
        private void BookButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            _library.SetLibraryTag(button.Tag.ToString());
            _addListButton.Enabled = _presentationModel.IsAddListButtonEnable();
            _bookDetailTextBox.Text = _presentationModel.GetBookDetail();
            UpdateBookDetailGroupBox();
        }

        // Add book button click event
        private void AddBorrowingListButtonClick(object sender, EventArgs e)
        {
            if (IsBorrowingListFull())
            {
                MessageBox.Show(_presentationModel.GetBorrowingListFullText());
                return;
            }
            _borrowingDataView.Rows.Add(GetCurrentBookCells());
            _presentationModel.AddCurrentBookTagToBorrowingList();
            _borrowingCountLabel.Text = _presentationModel.GetBorrowingBooksAmount();
            _borrowingButton.Enabled = _presentationModel.IsBorrowingButtonEnable();
            UpdateBookDetailGroupBox();
        }

        // Is borrowing list full, return bool
        private bool IsBorrowingListFull()
        {
            return _presentationModel.IsBorrowingListFull();
        }

        // Get book cells
        private string[] GetCurrentBookCells()
        {
            return _library.GetBookCells(GetLibraryCurrentTag());
        }

        // GetLibraryTag
        private int GetLibraryCurrentTag()
        {
            return _library.LibraryTag;
        }

        // GetCurrentBookCells
        private string[] GetBookCellsByTag(int bookTag)
        {
            return _library.GetBookCells(bookTag);
        }

        // Book category tabPage selected tab change event
        private void BookCategoryPageSelectedIndexChanged(object sender, EventArgs e)
        {
            int tabSelect = _bookCategoryTabControl.SelectedIndex;
            if (tabSelect == -1)
                return;
            _presentationModel.SetCategoryPageCountByIndex(tabSelect);
            _presentationModel.JudgeAddBorrowingListButtonEnable();
            SetLabelTextAndPageUpDownEnable();
            InitializeBookButtonByTabIndex();
            InitializeBookDetailGroupBox();
        }

        // Initialize category buttons visible
        private void InitializeBookButtonByTabIndex()
        {
            for (int i = 0; i < GetCurrentCategoryFirstPageLastIndex(); i++)
            {
                Button button = (Button)_bookCategoryTabControl.TabPages[_presentationModel.GetCurrentCategoryPageIndex()].Controls[i];
                button.Visible = true;
            }
            for (int i = GetCurrentCategoryFirstPageLastIndex(); i < _library.GetCategoryBooksCountByIndex(GetCurrentCategoryPageIndex()); i++)
            {
                Button button = (Button)_bookCategoryTabControl.TabPages[_presentationModel.GetCurrentCategoryPageIndex()].Controls[i];
                button.Visible = false;
            }
        }

        // Initialize book button select and perform
        private void InitializeBookDetailGroupBox()
        {
            _bookDetailTextBox.Text = _presentationModel.GetBookDetail();
            _bookRemainLabel.Text = _presentationModel.GetBookAmountText();
            _presentationModel.JudgeAddBorrowingListButtonEnable();
            _addListButton.Enabled = _presentationModel.IsAddListButtonEnable();
        }

        // UpdateBookRemainLabel
        public void UpdateBookDetailGroupBox()
        {
            _bookDetailTextBox.Text = _presentationModel.GetBookDetail();
            _bookRemainLabel.Text = _presentationModel.GetBookAmountText();
            _addListButton.Enabled = _presentationModel.IsAddListButtonEnable();
        }

        // Get category count
        private int GetCategoryCount()
        {
            return _library.GetCategoryCount();
        }

        // Get category name by index
        private string GetCategoryName(int categoryIndex)
        {
            return _library.GetCategoryNameByIndex(categoryIndex);
        }

        // Get books count by category index
        private int GetCategoryBooksCountByIndex(int categoryIndex)
        {
            return _library.GetCategoryBooksCountByIndex(categoryIndex);
        }

        // Page up button click
        private void PageUpButtonClick(object sender, EventArgs e)
        {
            _presentationModel.JudgeAddBorrowingListButtonEnable();
            SetCurrentBookButtonsVisible(false);
            _presentationModel.SetPageUp();
            SetCurrentBookButtonsVisible(true);
            SetLabelTextAndPageUpDownEnable();
            InitializeBookDetailGroupBox();
            _addListButton.Enabled = _presentationModel.IsAddListButtonEnable();
        }

        // Page down button click
        private void PageDownButtonClick(object sender, EventArgs e)
        {
            _presentationModel.JudgeAddBorrowingListButtonEnable();
            SetCurrentBookButtonsVisible(false);
            _presentationModel.SetPageDown();
            SetCurrentBookButtonsVisible(true);
            SetLabelTextAndPageUpDownEnable();
            InitializeBookDetailGroupBox();
            _addListButton.Enabled = _presentationModel.IsAddListButtonEnable();
        }

        // Set book buttons visible
        private void SetCurrentBookButtonsVisible(bool visible)
        {
            for (int i = GetCurrentPageFirstIndex(); i < GetCurrentPageLastIndex(); i++)
            {
                Button button = (Button)_bookCategoryTabControl.TabPages[_presentationModel.GetCurrentCategoryPageIndex()].Controls[i];
                button.Visible = visible;
            }
        }

        // Get current page first index
        public int GetCurrentPageFirstIndex()
        {
            return _presentationModel.GetCurrentPageFirstIndex();
        }

        // Get current page last index
        public int GetCurrentPageLastIndex()
        {
            return _presentationModel.GetCurrentPageLastIndex();
        }

        // Get current page last index
        public int GetCurrentCategoryFirstPageLastIndex()
        {
            return _presentationModel.GetCurrentCategoryFirstPageLastIndex();
        }

        // Get current page index
        public int GetCurrentCategoryPageIndex()
        {
            return _presentationModel.GetCurrentCategoryPageIndex();
        }

        // Borrowing data grid view cell painting event
        private void BorrowingDataViewCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) 
                return;
            if (e.ColumnIndex == 0)
            {
                const int two = 2;
                Image img = Image.FromFile(_presentationModel.GetTrashCanImage());
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = img.Width;
                var h = img.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / two;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / two;
                e.Graphics.DrawImage(img, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        // Borrowing data view cell click event
        private void BorrowingDataViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                dataGridView.Rows.RemoveAt(e.RowIndex);
                _presentationModel.RemoveBookFromBorrowingList(e.RowIndex);
                _borrowingCountLabel.Text = _presentationModel.GetBorrowingBooksAmount();
                _addListButton.Enabled = _presentationModel.IsAddListButtonEnable();
                _borrowingButton.Enabled = _presentationModel.IsBorrowingButtonEnable();
            }
        }

        // Borrow button click event
        private void BorrowingButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show(_presentationModel.GetBorrowedSuccessText());
            _library.AddBorrowingToBorrowedByTime(DateTime.Now);
            _borrowingButton.Enabled = _presentationModel.IsBorrowingButtonEnable();
            _borrowingDataView.Rows.Clear();
            InitializeBookDetailGroupBox();
            _borrowingCountLabel.Text = _presentationModel.GetBorrowingBooksAmount();
            _backPackForm.UpdateBackPackDataView();
        }

        // Open BackPack form button click
        private void OpenBackPackButtonClick(object sender, EventArgs e)
        {
            _backPackForm.UpdateBackPackDataView();
            _backPackForm.Show();
            _openBackPackButton.Enabled = false;
        }

        // Show error edit message box
        private void EditErrorMessageBox()
        {
            _borrowingDataView.EndEdit();
            _borrowingDataView.CellValueChanged -= BorrowingDataViewCellValueChanged;
            _borrowingDataView.CurrentCell.Value = _presentationModel.GetCurrentAmount();
            _borrowingDataView.CellValueChanged += BorrowingDataViewCellValueChanged;
            int borrowingListIndex = _borrowingDataView.CurrentCell.RowIndex;
            _library.SetBorrowingAmountByIndex(borrowingListIndex, int.Parse(_presentationModel.GetCurrentAmount()));
            _borrowingCountLabel.Text = _presentationModel.GetBorrowingBooksAmount();
            string message = _presentationModel.GetErrorMessageBoxText();
            string title = _presentationModel.GetErrorMessageBoxTitle();
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, title, buttons);
        }

        // BorrowingDataViewEditingControlShowing event
        private void BorrowingDataViewEditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.TextChanged += new EventHandler(ChangeCellValue);
        }

        // CellValueChanged
        private void ChangeCellValue(object sender, EventArgs e)
        {
            _borrowingDataView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // BorrowingDataViewCellValueChanged event
        private void BorrowingDataViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (e.RowIndex < 0)
                return;
            string nowText = dataGridView.CurrentCell.Value.ToString();
            int bookTag = _library.GetBorrowingListTagByIndex(e.RowIndex);
            _presentationModel.SetEditSelectBookTag(bookTag);
            _presentationModel.SetEditingAmount(nowText);
            _library.SetBorrowingAmountByIndex(e.RowIndex, int.Parse(_presentationModel.GetCurrentAmount()));
            _presentationModel.JudgeEditing();
            _borrowingCountLabel.Text = _presentationModel.GetBorrowingBooksAmount();
        }
    }
}
