using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public class Book
    {
        public Book() { }
        public Book(ref List<string> bookDetail)
        {
            this.name = bookDetail[0];               // 名稱
            this.ISBN = bookDetail[1];               // ISBN
            this.author = bookDetail[2];             // 作者
            this.publication = bookDetail[3];        // 出版項
        }
        public string name { get; set; }
        public string ISBN { get; set; }
        public string author { get; set; }
        public string publication { get; set; }
    }
}
