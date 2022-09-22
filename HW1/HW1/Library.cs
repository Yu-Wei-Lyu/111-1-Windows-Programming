using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class Library
    {
        public Library()
        {
            bookTag = 0;
            books = new List<Book>();
            bookCategory = new BookCategory();
        }
        private int bookTag { get; set; }
        public List<Book> books { get; set; }

        public BookCategory bookCategory;
    }

    
}
