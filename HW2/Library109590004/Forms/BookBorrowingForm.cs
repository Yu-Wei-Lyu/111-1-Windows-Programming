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

        public BookBorrowingForm(BookBorrowingPresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            _backPackForm = new BackPackForm(new BackPackPresentationModel(_presentationModel.GetLibrary()));
            _backPackForm.FormClosing += new FormClosingEventHandler(ClosingBackPackForm);
            _backPackForm._updateBorrowingForm += this.UpdateBookDetailGroupBox;
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
            _presentationModel.SetOpenBackPackButtonEnable(true);
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
            _presentationModel.SetTag(int.Parse(button.Tag.ToString()));
            _addListButton.Enabled = _presentationModel.IsAddListButtonEnable();
            _bookDetailTextBox.Text = _presentationModel.GetBookDetail();
            UpdateBookDetailGroupBoxState();
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
            UpdateBookDetailGroupBoxState();
        }

        // Is borrowing list full, return bool
        private bool IsBorrowingListFull()
        {
            return _presentationModel.IsBorrowingListFull();
        }

        // Get book cells
        private string[] GetBookCells()
        {
            return _presentationModel.GetCurrentBookCells();
        }

        // Update book remain label and addList button
        public void UpdateBookDetailGroupBoxState()
        {
            _bookRemainLabel.Text = _presentationModel.GetBookAmountText();
            _addListButton.Enabled = _presentationModel.IsAddListButtonEnable();
        }

        // Book category tabPage selected tab change event
        private void BookCategoryPageSelectedIndexChanged(object sender, EventArgs e)
        {
            int tabSelect = _bookCategoryTabControl.SelectedIndex;
            _presentationModel.SetCategoryPageCountByIndex(tabSelect);
            _presentationModel.ResetBookSelect();
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
            for (int i = GetCurrentCategoryFirstPageLastIndex(); i < _presentationModel.GetBookCount(GetCurrentCategoryPageIndex()); i++)
            {
                Button button = (Button)_bookCategoryTabControl.TabPages[_presentationModel.GetCurrentCategoryPageIndex()].Controls[i];
                button.Visible = false;
            }
        }

        // Initialize book button select and perform
        private void InitializeBookDetailGroupBox()
        {
            _presentationModel.ResetBookSelect();
            _bookDetailTextBox.Text = _presentationModel.GetBookDetail();
            _bookRemainLabel.Text = _presentationModel.GetBookInitializeText();
            _addListButton.Enabled = _presentationModel.IsAddListButtonEnable();
        }

        // UpdateBookRemainLabel
        public void UpdateBookDetailGroupBox()
        {
            _openBackPackButton.Enabled = _presentationModel.IsOpenBackPackButtonEnable();
            _bookRemainLabel.Text = _presentationModel.GetBookAmountText();
            _addListButton.Enabled = _presentationModel.IsAddListButtonEnable();
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
            _presentationModel.ResetBookSelect();
            SetCurrentBookButtonsVisible(false);
            _presentationModel.SetPageUp();
            SetCurrentBookButtonsVisible(true);
            SetLabelTextAndPageUpDownEnable();
            InitializeBookDetailGroupBox();
        }

        // Page down button click
        private void PageDownButtonClick(object sender, EventArgs e)
        {
            _presentationModel.ResetBookSelect();
            SetCurrentBookButtonsVisible(false);
            _presentationModel.SetPageDown();
            SetCurrentBookButtonsVisible(true);
            SetLabelTextAndPageUpDownEnable();
            InitializeBookDetailGroupBox();
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
            DataGridView dataGridView = (DataGridView)sender;
            if (e.RowIndex < 0) 
                return;
            if (e.ColumnIndex == 0 && e.ColumnIndex < dataGridView.ColumnCount - 1)
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

        // Borrowing data view cell content click event
        private void BorrowingDataViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
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
            _backPackForm.InitializeBackPackDataView();
        }

        // Open BackPack form button click
        private void OpenBackPackButtonClick(object sender, EventArgs e)
        {
            OpenBackPackForm();
            _openBackPackButton.Enabled = _presentationModel.IsOpenBackPackButtonEnable();
        }

        // Open BackPack form
        private void OpenBackPackForm()
        {
            _backPackForm.InitializeBackPackDataView();
            _backPackForm.Show();
            _presentationModel.SetOpenBackPackButtonEnable(false);
        }
    }
}
