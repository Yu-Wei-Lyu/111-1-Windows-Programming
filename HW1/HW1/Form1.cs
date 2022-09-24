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
using System.Diagnostics;

namespace Library109590004
{

    public partial class Form1 : Form
    {
        private Library _library;
        
        public Form1()
        {
            InitializeComponent();
            const int BOOK_BUTTON_SIZE_X = 86;
            const int BOOK_BUTTON_SIZE_Y = 94;
            const string FILE_NAME = "../../../hw1_books_source.txt";
            _library = new Library(FILE_NAME);
            Size buttonSize = new Size(BOOK_BUTTON_SIZE_X, BOOK_BUTTON_SIZE_Y);
            InitializeTabControl(buttonSize);
            InitializeDataGridView();
            _addBookButton.Enabled = false;
        }

        // DataGridView initialize with resource
        private void InitializeDataGridView()
        {
            string[] columnsName = { "書籍名稱", "書籍編號", "作者", "出版項" };
            _borrowingDataView.ColumnCount = columnsName.Length;
            for (int column = 0; column < columnsName.Length; column++)
            {
                _borrowingDataView.Columns[column].Name = columnsName[column];
            }
        }

        // TabControl initialize with resource
        private void InitializeTabControl(Size buttonSize)
        {
            int buttonTag = 0;
            List<BookCategory> categories = _library.GetCategories();
            foreach (BookCategory category in categories)
            {
                List<Book> books = category.GetBooks();
                TabPage tabPage = new TabPage();
                tabPage.Text = category.Name;
                for (int bookIndex = 0; bookIndex < books.Count(); bookIndex++)
                {
                    Point buttonPoint = new Point(tabPage.Location.X + bookIndex * buttonSize.Width, tabPage.Location.Y);
                    BookButton bookButton = new BookButton(this, buttonTag, buttonPoint, buttonSize);
                    bookButton.Click += (sender, e) => BookButtonClick(sender, e);
                    tabPage.Controls.Add(bookButton);
                    buttonTag++;
                }
                _bookCategoryTabPage.TabPages.Add(tabPage);
            }
        }

        // Book button click event
        private void BookButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ChangeBookDetail(button);
        }

        // Add book button click event
        private void AddBookButtonClick(object sender, EventArgs e)
        {
            int tag = _library.GetTag();
            BookItem bookItem = _library.GetCurrentBookItem();
            _borrowingDataView.Rows.Add(bookItem.Book.Name, bookItem.Book.Id, bookItem.Book.Author, bookItem.Book.Publication);
        }

        // Borrowing dataGridView rows added event
        private void BorrowingDataViewRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            const string BORROWING_TEXT = "借書數量：";
            _borrowingCountLabel.Text = BORROWING_TEXT + (_borrowingDataView.Rows.Count - 1);
        }

        // Book detail richTextbox text changed event
        private void BookDetailTextChanged(object sender, EventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)sender;
            _addBookButton.Enabled = (richTextBox.Text == "") ? false : true;
        }

        // Book category tabPage selected tab change event
        private void BookCategoryPageSelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            int indexOfPage = tabControl.SelectedIndex;
            Button button = (Button)tabControl.TabPages[indexOfPage].Controls[0];
            ChangeBookDetail(button);
        }

        // Show book detail and set library tag
        public void ChangeBookDetail(Button button)
        {
            int buttonTag = int.Parse(button.Tag.ToString());
            _library.SetTag(buttonTag);
            BookItem bookItem = _library.GetCurrentBookItem();
            string bookDetail = _library.GetBookDetail(buttonTag);
            const string BOOK_REMAIN = "剩餘數量：";
            _bookDetailTextBox.Text = bookDetail;
            _bookRemainLabel.Text = BOOK_REMAIN + bookItem.Amount;
        }
    }
}
