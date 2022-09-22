using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class Book
    {
        public Book() 
        { 
        }
        public Book(string name, string id, string author, string publication)
        {
            this.name = name; // 名稱
            this.id = id; // ISBN
            this.author = author; // 作者
            this.publication = publication; // 出版項
        }
        public string name 
        { 
            get; 
            set; 
        }
        public string id 
        { 
            get; 
            set; 
        }
        public string author 
        { 
            get; 
            set; 
        }
        public string publication 
        { 
            get; 
            set; 
        }
    }
}
