using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class BookCategory
    {
        private Dictionary<string, string> _category;
        public BookCategory()
        {
            _category = new Dictionary<string, string>();
        }
        // Set book category information
        public void Set(string bookName, string bookCategory)
        {
            _category.Add(bookName, bookCategory);
        }
        // Get book category information
        public string Get()

    }
}
