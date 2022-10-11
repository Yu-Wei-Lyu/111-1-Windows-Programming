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
        private BookBorrowingPresentationModel _presentationModel;

        public BookBorrowingForm(BookBorrowingPresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            InitializeComponent();
            InitializeTabControl();
            _addListButton.Enabled = _presentationModel.IsAddListButtonEnable();
            _borrowButton.Enabled = false;
            _pageUpButton.Enabled = _presentationModel.IsUpButtonEnable();
            _pageLabel.Text = $"Page：1 / {GetFirstCategoryPageCount()}";
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

        // Get first category page count
        private int GetFirstCategoryPageCount()
        {
            return _presentationModel.GetCategoryPageCountByIndex(0);
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
            TabControl tabControl = (TabControl)sender;
            int tabSelect = tabControl.SelectedIndex;
            Button button = (Button)tabControl.TabPages[tabSelect].Controls[0];
            button.Select();
            button.PerformClick();
            _pageLabel.Text = $"Page：1 / {_presentationModel.GetCategoryPageCountByIndex(tabSelect)}";
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
            _presentationModel.SetPageUp();
            _pageLabel.Text = $"Page：{GetCurrentPage()} / {GetCurrentCategoryPageCount()}";
            _pageUpButton.Enabled = _presentationModel.IsUpButtonEnable();
            _pageDownButton.Enabled = _presentationModel.IsDownButtonEnable();
        }

        // Get current page
        private int GetCurrentPage()
        {
            return _presentationModel.GetCurrentPage();
        }

        // Get current category page count
        private int GetCurrentCategoryPageCount()
        {
            return _presentationModel.GetCurrentCategoryPageCount();
        }

        // Page down button click
        private void PageDownButtonClick(object sender, EventArgs e)
        {
            _presentationModel.SetPageDown();
            for(int i = 0; i < _bookCategoryTabControl.TabPages[_presentationModel.GetCategoryPageIndex()].Controls.Count; i++)
            {
                
            }
            _pageLabel.Text = $"Page：{GetCurrentPage()} / {GetCurrentCategoryPageCount()}";
            _pageUpButton.Enabled = _presentationModel.IsUpButtonEnable();
            _pageDownButton.Enabled = _presentationModel.IsDownButtonEnable();
        }
    }
}
