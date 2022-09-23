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
            _library = new Library();
        }

        public Form1(Library library)
        {
            InitializeComponent();
            InitializeTabPageComponent();
            
        }

        // Initialize the tab page of book category
        private void InitializeTabPageComponent()
        {
            List<string> categoryName = new List<string>();
            Dictionary<string, TabPage> tabPages = new Dictionary<string, TabPage>();
            Button newButton = new Button();
            List<string> categorySet = _library.GetCategorySet();
            for(int indexOfLibrary = 0; indexOfLibrary < _library.count; indexOfLibrary++)
            {
                Book book = _library.GetBook(indexOfLibrary);
                int a = _library.GetBookAmount(book.name);
                string bookCategory = _library.GetBookCategory(book.name);
                if (categoryName.Contains(bookCategory))
                {
                    TabPage tabPage = new TabPage();
                }
            }
        }

        // Initialize the data grid view of borrowing list
        private void InitializeDataGridViewComponent()
        {

        }
    }
}
