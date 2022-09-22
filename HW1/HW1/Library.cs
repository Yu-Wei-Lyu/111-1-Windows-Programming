using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Library109590004
{
    public class Library
    {
        private List<Book> _books = new List<Book>();
        private BookCategory _category = new BookCategory();
        private BookItem _item = new BookItem();
        public Library()
        {
            const string FILE_NAME = "../../../hw1_books_source.txt";
            StreamReader file = new StreamReader(@FILE_NAME);
            Book book = new Book();
            const string BOOK_WORD = "BOOK";
            while (!file.EndOfStream)
            {
                if (file.ReadLine() == BOOK_WORD)
                {
                    _item.amount.Add(int.Parse(file.ReadLine()));
                    _category.list.Add(file.ReadLine());
                    _books.Add(new Book(file.ReadLine(), file.ReadLine(), file.ReadLine(), file.ReadLine()));
                }
            }
        }
    }
}
