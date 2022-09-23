using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class BookCategory
    {
        private Dictionary<string, string> _list;
        private List<string> _onlyList;

        public BookCategory()
        {
            _list = new Dictionary<string, string>();
            _onlyList = new List<string>();
        }

        // Add a pair of the book name and book category to list
        public void Add(string bookName, string bookCategory)
        {
            _list.Add(bookName, bookCategory);
            if (!_onlyList.Contains(bookCategory))
            {
                _onlyList.Add(bookCategory);
            }
        }

        // Get book's category by the book name
        public string GetCategoryByBookName(string bookName)
        {
            return _list[bookName];
        }

        // Get set of category
        public List<string> GetCategorySet()
        {
            return _onlyList;
        }
    }
}
