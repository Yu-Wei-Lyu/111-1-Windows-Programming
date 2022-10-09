﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Library109590004
{
    public class Library
    {
        private const string FILE_NAME = "../../../hw1_books_source.txt";
        private const string BOOK_WORD = "BOOK";
        private List<Book> _books;
        private List<BookItem> _bookItems;
        private List<BookCategory> _bookCategories;
        private int _tag;

        public Library()
        {
            _tag = -1;
            _books = new List<Book>();
            _bookItems = new List<BookItem>();
            _bookCategories = new List<BookCategory>();

            StreamReader file = new StreamReader(@FILE_NAME);
            while (!file.EndOfStream)
            {
                if (file.ReadLine() == BOOK_WORD)
                {
                    int bookAmount = int.Parse(file.ReadLine());
                    string bookCategory = file.ReadLine();
                    Book book = new Book(file.ReadLine(), file.ReadLine(), file.ReadLine(), file.ReadLine());

                    int categoryIndex = _bookCategories.FindIndex(category => bookCategory.Equals(category.Name));
                    if (categoryIndex >= 0)
                    {
                        _bookCategories[categoryIndex].AddBook(book);
                    }
                    else
                    {
                        _bookCategories.Add(new BookCategory(bookCategory, book));
                    }
                    _bookItems.Add(new BookItem(book, bookAmount));
                    _books.Add(book);
                }
            }
        }

        // Book getter
        public Book GetBook(int tag)
        {
            return _books[tag];
        }

        // Book list getter
        public List<Book> GetBooks()
        {
            return _books;
        }

        // Book tag getter
        public int GetBookTag(Book book)
        {
            return _books.FindIndex(book.IsSameBook);
        }

        // Book item list getter
        public BookItem GetCurrentBookTagItem()
        {
            return _bookItems[_tag];
        }

        // Book category getter
        public BookCategory GetCategory(int index)
        {
            return _bookCategories[index];
        }

        // Book category list getter
        public List<BookCategory> GetCategories()
        {
            return _bookCategories;
        }

        // Book detail string getter
        public string GetBookDetail(int tag)
        {
            Book book = _books[tag];
            const string BOOK_DETAIL_FORMAT = "{0}\n編號：{1}\n作者：{2}\n{3}";
            string bookDetail = string.Format(BOOK_DETAIL_FORMAT, book.Name, book.Id, book.Author, book.Publication);
            return bookDetail;
        }

        // Library tag getter and setter
        public int Tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
            }
        }
    }
}
