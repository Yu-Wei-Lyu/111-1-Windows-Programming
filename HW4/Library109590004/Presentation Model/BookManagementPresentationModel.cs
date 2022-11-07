﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class BookManagementPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        LibraryModel _library;
        List<Book> _books;
        List<string> _notifyGroup;
        string _nameText;
        string _idText;
        string _authorText;
        string _categoryText;
        string _publicationText;
        string _imagePathText;
        bool _isApplyChanged;
        bool _isBrowse;
        int _managementTag;

        public BookManagementPresentationModel(LibraryModel library)
        {
            _library = library;
            _books = new List<Book>();
            IsApplyChanged = false;
            IsBrowse = false;
            _managementTag = -1;
        }

        // Notify
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        public bool IsBrowse
        {
            get
            {
                return _isBrowse;
            }
            set
            {
                _isBrowse = value;
                NotifyPropertyChanged("IsBrowse");
            }
        }

        public bool IsApplyChanged
        {
            get
            {
                return _isApplyChanged;
            }
            set
            {
                _isApplyChanged = value;
                NotifyPropertyChanged("IsApplyChanged");
            }
        }

        public string NameText
        {
            get
            {
                return _nameText;
            }
            set
            {
                _nameText = value;
                JudgeIsApplyChanged();
                NotifyPropertyChanged("NameText");
            }
        }

        public string IdText
        {
            get
            {
                return _idText;
            }
            set
            {
                _idText = value;
                JudgeIsApplyChanged();
                NotifyPropertyChanged("IdText");
            }
        }

        public string AuthorText
        {
            get
            {
                return _authorText;
            }
            set
            {
                _authorText = value;
                JudgeIsApplyChanged();
                NotifyPropertyChanged("AuthorText");
            }
        }

        public string CategoryText
        {
            get
            {
                return _categoryText;
            }
            set
            {
                _categoryText = value;
                JudgeIsApplyChanged();
                NotifyPropertyChanged("CategoryText");
            }
        }

        public string PublicationText
        {
            get
            {
                return _publicationText;
            }
            set
            {
                _publicationText = value;
                JudgeIsApplyChanged();
                NotifyPropertyChanged("PublicationText");
            }
        }

        public string ImagePathText
        {
            get
            {
                return _imagePathText;
            }
            set
            {
                _imagePathText = value;
                JudgeIsApplyChanged();
                NotifyPropertyChanged("ImagePathText");
            }
        }

        // UpdateLibraryBooks
        public void UpdateLibraryBooks()
        {
            _books.Clear();
            for (int i = 0; i < GetBooksCount(); i++)
            {
                _books.Add(GetBookByTag(i));
            }
        }

        // GetBooksCount
        public int GetBooksCount()
        {
            return _library.GetBooksCount();
        }

        // GetBookNameByTag
        public string GetBookNameByTag(int tag)
        {
            return _books[tag].Name;
        }

        // GetBookIdByTag
        public string GetBookIdByTag(int tag)
        {
            return _books[tag].Id;
        }

        // GetBookAuthorByTag
        public string GetBookAuthorByTag(int tag)
        {
            return _books[tag].Author;
        }

        // GetBookCategoryByTag
        public string GetBookCategoryByTag(int tag)
        {
            return _library.GetCategoryNameByBookTag(tag);
        }

        // GetBookPublicationByTag
        public string GetBookPublicationByTag(int tag)
        {
            return _books[tag].Publication;
        }

        // GetBookImagePathByTag
        public string GetBookImagePathByTag(int tag)
        {
            return _books[tag].GetImagePath();
        }

        // GetBookByTag
        private Book GetBookByTag(int tag)
        {
            return _library.GetBookByTag(tag);
        }

        // SetSelectedTag
        public void SetSelectedTag(int tag)
        {
            _managementTag = tag;
            NameText = GetBookNameByTag(tag);
            IdText = GetBookIdByTag(tag);
            AuthorText = GetBookAuthorByTag(tag);
            CategoryText = GetBookCategoryByTag(tag);
            PublicationText = GetBookPublicationByTag(tag);
            ImagePathText = GetBookImagePathByTag(tag);
            IsBrowse = true;
        }

        // JudgeIsApplyChanged
        public void JudgeIsApplyChanged()
        {
            bool oneTextIsEmpty = string.IsNullOrEmpty(_nameText) || string.IsNullOrEmpty(_idText) || string.IsNullOrEmpty(_authorText) || string.IsNullOrEmpty(_categoryText) || string.IsNullOrEmpty(_publicationText) || string.IsNullOrEmpty(_imagePathText);
            bool sameAsLibraryBookDetail = _nameText == GetBookNameByTag(_managementTag) && _idText == GetBookIdByTag(_managementTag) && _authorText == GetBookAuthorByTag(_managementTag) && _categoryText == GetBookCategoryByTag(_managementTag) && _publicationText == GetBookPublicationByTag(_managementTag) && _imagePathText == GetBookImagePathByTag(_managementTag);
            IsApplyChanged = !(oneTextIsEmpty || sameAsLibraryBookDetail);
        }

        // GetCategoriesNameList
        public string[] GetCategoriesNameList()
        {
            int categoryCount = _library.GetCategoryCount();
            string[] categoriesName = new string[categoryCount];
            for (int i = 0; i < categoriesName.Length; i++)
            {
                categoriesName[i] = GetCategoryNameByIndex(i);
            }
            return categoriesName;
        }

        // GetCategoryNameByIndex
        private string GetCategoryNameByIndex(int index)
        {
            return _library.GetCategoryNameByIndex(index);
        }

        // UpdateBookDetail
        public void UpdateBookDetail()
        {
            IsApplyChanged = false;
            Book book = new Book(NameText, IdText, AuthorText, PublicationText);
            book.SetImagePath(ImagePathText);
            _library.UpdateBookDetailByTag(_managementTag, book, CategoryText);
        }
    }
}
