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
        List<Book> Library = new List<Book>();
        public Form1()
        {
            InitializeComponent();
            
            string fileName = "../../../hw1_books_source.txt";
            StreamReader file = new StreamReader(@fileName);
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                if (line == "BOOK")
                {
                    Book book = new Book();
                    book.amount = int.Parse(file.ReadLine());
                    book.category = file.ReadLine();
                    book.name = file.ReadLine();
                    book.ISBN = file.ReadLine();
                    book.author = file.ReadLine();
                    book.publication = file.ReadLine();
                    Library.Add(book);
                }
            }
            Console.ReadLine();
        }

    }

    public class Book
    {
        // 數量
        // 分類
        // 名稱
        // ISBN
        // 作者
        // 出版項
        public int amount { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public string ISBN { get; set; }
        public string author { get; set; }
        public string publication { get; set; }
        public Book() { }
    }
}
