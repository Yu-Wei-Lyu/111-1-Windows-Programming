using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class BookItem
    {
        public BookItem()
        {
            bookAmountDictionary = new Dictionary<string, int>();
        }
        public Dictionary<string, int> bookAmountDictionary { get; set; }

        public void Add(string bookName, int bookAmount)
        {
            bookAmountDictionary.Add(bookName, bookAmount);
        }
    }
}
