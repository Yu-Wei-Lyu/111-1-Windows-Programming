using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class Library
    {
        public Library()
        {
            bookTag = 0;
        }
        private int bookTag { get; set; }
        public Dictionary<Book, int> books { get; set; }
        public void Add(ref Book book)
        {
            books.Add(book, bookTag++);
        }
    }

    
}
