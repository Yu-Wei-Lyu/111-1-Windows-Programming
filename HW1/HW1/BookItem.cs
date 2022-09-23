using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class BookItem
    {
        private Dictionary<string, int> _list;

        public BookItem()
        {
            _list = new Dictionary<string, int>();
        }

        // Add a pair of book name and book amount to list
        public void Add(string bookName, int bookAmount)
        {
            _list.Add(bookName, bookAmount);
        }

        // Get book amount by the book name
        public int GetAmountByBookName(string bookName)
        {
            return _list[bookName];
        }
    }
}
