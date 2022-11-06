﻿using System;
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
        private const int TWO = 2;

        public BookBorrowingForm(BookBorrowingPresentationModel presentationModel, LibraryModel library)
        {
            _library = library;
            _library._modelChanged += UpdateBookDetailGroupBox;
            _presentationModel = presentationModel;
            _presentationModel._modelChanged += EditErrorMessageBox;
            _backPackForm = new BackPackForm(new BackPackPresentationModel(_library), _library);
            _backPackForm.FormClosing += new FormClosingEventHandler(ClosingBackPackForm);
            InitializeComponent();
            InitializeTabControl();
            _addListButton.Enabled = _presentationModel.IsAddListButtonEnable();
            _borrowingButton.Enabled = _presentationModel.IsBorrowingButtonEnable();
            _borrowingCountLabel.Text = _presentationModel.GetBorrowingBooksAmount();
            _presentationModel.SetCategoryPageCountByIndex(0);
            SetLabelTextAndPageUpDownEnable();
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

        // Initialize tabControl
        private void InitializeTabControl()
        {
            for (int categoryIndex = 0; categoryIndex < GetCategoryCount(); categoryIndex++)
            {
                TabPage tabPage = new TabPage(GetCategoryName(categoryIndex));
                for (int bookIndex = 0; bookIndex < GetBookCount(categoryIndex); bookIndex++)
                {
                    Button button = CreateBookButton(categoryIndex, bookIndex);
                    tabPage.Controls.Add(button);
                }
                _bookCategoryTabControl.TabPages.Add(tabPage);
            }
        }

        // Create book button with index
        private Button CreateBookButton(int categoryIndex, int bookIndex)
        {
            int bookTag = _library.GetBookTag(categoryIndex, bookIndex);
            Button button = new Button();
            button.Tag = bookTag;
            button.Size = _presentationModel.GetBookButtonSize();
            button.Location = _presentationModel.GetBookButtonLocation(bookIndex);
            button.BackgroundImage = GetBookImageByTag(bookTag);
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.Click += BookButtonClick;
            return button;
        }

        // Get book image by tag
        private Image GetBookImageByTag(int bookTag)
        {
            return _library.GetBookImageByTag(bookTag);
        }

        // Book button click event
        private void BookButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            _library.SetTag(button.Tag.ToString());
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
            _borrowingDataView.Rows.Add(GetBookCells());
            _presentationModel.AddBookTagToBorrowingList();
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
        private string[] GetBookCells()
        {
            return _library.GetCurrentBookCells();
        }

        // Book category tabPage selected tab change event
        private void BookCategoryPageSelectedIndexChanged(object sender, EventArgs e)
        {
            int tabSelect = _bookCategoryTabControl.SelectedIndex;
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
            for (int i = GetCurrentCategoryFirstPageLastIndex(); i < _library.GetBooksCount(GetCurrentCategoryPageIndex()); i++)
            {
                Button button = (Button)_bookCategoryTabControl.TabPages[_presentationModel.GetCurrentCategoryPageIndex()].Controls[i];
                button.Visible = false;
            }
        }

        // Initialize book button select and perform
        private void InitializeBookDetailGroupBox()
        {
            _library.Tag = -1;
            _bookDetailTextBox.Text = "";
            _bookRemainLabel.Text = _presentationModel.GetBookAmountText();
            _presentationModel.JudgeAddBorrowingListButtonEnable();
            _addListButton.Enabled = _presentationModel.IsAddListButtonEnable();
        }

        // UpdateBookRemainLabel
        public void UpdateBookDetailGroupBox()
        {
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
        private int GetBookCount(int categoryIndex)
        {
            return _library.GetBooksCount(categoryIndex);
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
                Image img = _presentationModel.GetTrashCanImage();
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
