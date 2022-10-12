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
        private BookBorrowingPresentationModel _presentationModel;

        public BookBorrowingForm(BookBorrowingPresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            InitializeComponent();
            InitializeTabControl();
            _addListButton.Enabled = _presentationModel.IsAddListButtonEnable();
            _presentationModel.SetCategoryPageCountByIndex(0);
            SetLabelTextAndPageUpDownEnable();
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
                    button.Parent = tabPage;
                    tabPage.Controls.Add(button);
                }
                _bookCategoryTabControl.TabPages.Add(tabPage);
            }
        }

        // Create book button with index
        private Button CreateBookButton(int categoryIndex, int bookIndex)
        {
            int bookTag = _presentationModel.GetBookTag(categoryIndex, bookIndex);
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
            return _presentationModel.GetBookImageByTag(bookTag);
        }

        // Book button click event
        private void BookButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            _bookDetailTextBox.Text = _presentationModel.GetBookDetail(button.Tag.ToString());
            UpdateBookDetailGroupBoxState();
        }

        // Add book button click event
        private void AddBorrowingListButtonClick(object sender, EventArgs e)
        {
            _borrowingDataView.Rows.Add(_presentationModel.GetCurrentBookCells());
            UpdateBookDetailGroupBoxState();
        }

        // Update book remain label and addList button
        private void UpdateBookDetailGroupBoxState()
        {
            _bookRemainLabel.Text = "剩餘數量：" + _presentationModel.GetCurrentBookAmount();
            _addListButton.Enabled = _presentationModel.IsAddListButtonEnable();
        }

        // Book category tabPage selected tab change event
        private void BookCategoryPageSelectedIndexChanged(object sender, EventArgs e)
        {
            int tabSelect = _bookCategoryTabControl.SelectedIndex;
            _presentationModel.SetCategoryPageCountByIndex(tabSelect);
            SetLabelTextAndPageUpDownEnable();
            InitializeBookButtonByTabIndex();
            InitializeBookButtonSelectPerform();
        }

        // Initialize category buttons visible
        private void InitializeBookButtonByTabIndex()
        {
            for (int i = 0; i < GetCurrentCategoryFirstPageLastIndex(); i++)
            {
                Button button = (Button)_bookCategoryTabControl.TabPages[_presentationModel.GetCurrentCategoryPageIndex()].Controls[i];
                button.Visible = true;
            }
            for (int i = GetCurrentCategoryFirstPageLastIndex(); i < _presentationModel.GetBookCount(GetCurrentCategoryPageIndex()); i++)
            {
                Button button = (Button)_bookCategoryTabControl.TabPages[_presentationModel.GetCurrentCategoryPageIndex()].Controls[i];
                button.Visible = false;
            }
        }

        // Initialize book button selevt and perform
        private void InitializeBookButtonSelectPerform()
        {
            Button button = (Button)_bookCategoryTabControl.TabPages[GetCurrentCategoryPageIndex()].Controls[GetCurrentPageFirstIndex()];
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

        // Get category count
        private int GetCategoryCount()
        {
            return _presentationModel.GetCategoryCount();
        }

        // Get category name by index
        private string GetCategoryName(int categoryIndex)
        {
            return _presentationModel.GetCategoryName(categoryIndex);
        }

        // Get books count by category index
        private int GetBookCount(int categoryIndex)
        {
            return _presentationModel.GetBookCount(categoryIndex);
        }

        // Page up button click
        private void PageUpButtonClick(object sender, EventArgs e)
        {
            SetCurrentBookButtonsVisible(false);
            _presentationModel.SetPageUp();
            SetCurrentBookButtonsVisible(true);
            SetLabelTextAndPageUpDownEnable();
            InitializeBookButtonSelectPerform();
        }

        // Page down button click
        private void PageDownButtonClick(object sender, EventArgs e)
        {
            SetCurrentBookButtonsVisible(false);
            _presentationModel.SetPageDown();
            SetCurrentBookButtonsVisible(true);
            SetLabelTextAndPageUpDownEnable();
            InitializeBookButtonSelectPerform();
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
    }
}
