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


namespace HW1
{

    public partial class Form1 : Form
    {
        private Library library = new Library();
        public Form1()
        {
            InitializeComponent();
            string fileName = "../../../hw1_books_source.txt";
            StreamReader file = new StreamReader(@fileName);
            List<string> readlines = new List<string>();
            Book book = new Book();
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                if (line == "BOOK")
                {
                    for(int readLine = 0; readLine < 6; readLine++)
                    {
                        readlines.Add(file.ReadLine());
                    }
                    book = new Book(ref readlines);
                    library.Add(ref book);
                    readlines.Clear();
                }
            }
            setTabPageConstruct();
        }
        private void setTabPageConstruct()
        {
            TabPage newTabPage = new TabPage();
            Button newButton = new Button();
            int buttonTag = 1;
            foreach (KeyValuePair<string, List<Book>> item in library.bookCategory)
            {
                int btn_x = 8, btn_y = 8, btn_x_spacing = 80;
                newTabPage = new TabPage();
                newTabPage.Text = item.Key;
                for (int tabPageButtonIndex = 0; tabPageButtonIndex < item.Value.Count; tabPageButtonIndex++)
                {
                    Book book = item.Value[tabPageButtonIndex];
                    newButton = new Button();
                    newButton.Tag = buttonTag++;
                    newButton.Text = "Book " + newButton.Tag;
                    newButton.Parent = this;
                    newButton.Location = new Point(newTabPage.Location.X + btn_x + (btn_x_spacing * tabPageButtonIndex), newTabPage.Location.X + btn_y);
                    newButton.Size = new Size(81, 78);
                    newButton.Click += (sender, e) => AddBookButton_Click(sender, e, book);
                    newTabPage.Controls.Add(newButton);
                }
                bookCategoryPage.Controls.AddRange(new Control[] { newTabPage });
            }
        }
        private void AddBookButton_Click(object sender, EventArgs e, Book book)
        {
            richTextBoxBookDesc.Text = string.Format("{0}\n編號：{1}\n作者：{2}\n{3}", book.name, book.ISBN, book.author, book.publication);
            //bookRemainLabel.Text = "剩餘數量：" + book.amount;
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
