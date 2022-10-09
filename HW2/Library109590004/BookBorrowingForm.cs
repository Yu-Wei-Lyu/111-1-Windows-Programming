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
            InitializeComponent();
            _presentationModel = presentationModel;
            for (int categoryIndex = 0; categoryIndex < _presentationModel.GetCategoryCount(); categoryIndex++)
            {
                TabPage tabPage = new TabPage(presentationModel.GetCategoryName(categoryIndex));
                for (int bookIndex = 0; bookIndex < _presentationModel.GetBookCount(categoryIndex); bookIndex++)
                {
                    Button button = new Button();
                    button.Location = presentationModel.GetBookButtonLocation(_bookCategoryTabControl.Location, bookIndex);
                    button.Text = "Book " + bookIndex;
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
            /*int bookTextNumber = 0;
            foreach (BookCategory category in _library.GetCategories())
            {
                List<Book> books = category.GetBooks();
                TabPage tabPage = new TabPage(category.Name);
                for (int bookIndex = 0; bookIndex < books.Count(); bookIndex++)
                {
                    int buttonTag = _library.GetBookTag(books[bookIndex]);
                    string buttonText = BOOK_TEXT + bookTextNumber++;
                    Point buttonPoint = new Point(tabPage.Location.X + bookIndex * BOOK_BUTTON_SIZE_X, tabPage.Location.Y);
                    BookButton bookButton = new BookButton(buttonTag, buttonText, buttonPoint, new Size(BOOK_BUTTON_SIZE_X, BOOK_BUTTON_SIZE_Y));
                    bookButton.Click += new EventHandler(BookButtonClick);
                    bookButton.Parent = tabPage;
                    tabPage.Controls.Add(bookButton);
                }
                _bookCategoryTabControl.TabPages.Add(tabPage);
            }
        }

        // Book button click event
        private void BookButtonClick(object sender, EventArgs e)
        {
            /*Button button = (Button)sender;
            int buttonTag = int.Parse(button.Tag.ToString());
            _library.Tag = buttonTag;
            BookItem bookItem = _library.GetCurrentBookTagItem();
            string bookDetail = _library.GetBookDetail(buttonTag);
            _bookDetailTextBox.Text = bookDetail;
            RefreshBookAmountLabel(bookItem);
            AddBorrowingListButtonEnable(bookItem);*/
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

        // Add borrowing list button enable control
        private void AddBorrowingListButtonEnable(BookItem bookItem)
        {
            _addToBorrowingListButton.Enabled = (bookItem.Amount == 0) ? false : true;
        }

        // Refresh book amount label
        private void RefreshBookAmountLabel(BookItem bookItem)
        {
            //_bookRemainLabel.Text = BOOK_REMAIN_COUNT + bookItem.Amount;
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
