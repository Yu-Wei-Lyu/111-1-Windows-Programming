using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class BookItem
    {
        public BookItem()
        {
            amount = new List<int>();
        }
        public List<int> amount
        {
            get;
            set;
        }
        public List<string> name
        {
            get;
            set;
        }
    }
}
