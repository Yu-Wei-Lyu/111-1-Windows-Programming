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
using System.Diagnostics;

namespace Library109590004
{

    public partial class Form1 : Form
    {
        private Library _library;
        
        public Form1()
        {
            InitializeComponent();
            const string FILE_NAME = "../../../hw1_books_source.txt";
            _library = new Library(FILE_NAME);
            InitializeTabPageComponent();
        }

        // Initialize the tab page of book category
        private void InitializeTabPageComponent()
        {
            const int BUTTON_WIDTH = 86;
            const int BUTTON_LENGTH = 87;
            List<BookCategory> categories = _library.GetCategories();
            int buttonTag = 0;
            foreach (BookCategory category in categories)
            {
                List<Book> books = category.GetBooks();
                TabPage tabPage = new TabPage();
                tabPage.Text = category.Name;
                for (int bookIndex = 0; bookIndex < books.Count(); bookIndex++)
                {
                    BookButton bookButton = new BookButton(this, buttonTag, tabPage.Location.X + bookIndex * BUTTON_WIDTH, tabPage.Location.Y, BUTTON_WIDTH, BUTTON_LENGTH);
                    tabPage.Controls.Add(bookButton);
                    buttonTag++;
                }
                _bookCategoryPage.TabPages.Add(tabPage);
            }
        }

        // Book button click event handle
        private void BookButtonClick(object sender, EventArgs e)
        {

        }
    }
}
