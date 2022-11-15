using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class BackPackPresentationModel
    {
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler _modelChanged;
        private const string RETURN_AMOUNT_ERROR_TITLE = "還書錯誤";
        private const string RETURN_AMOUNT_ERROR_TEXT_AT_LEAST_ONE_BOOK = "您至少要歸還1本書";
        private const string RETURN_AMOUNT_ERROR_TEXT_NOT_OVER_BORROWED = "還書數量不能超過已借數量";
        private string _errorMessageTitle;
        private string _errorMessageText;
        private int _editSelectBookTag;
        private int _editingAmount;
        LibraryModel _library;
        
        public BackPackPresentationModel(LibraryModel library)
        {
            _library = library;
            _errorMessageTitle = "";
            _errorMessageText = "";
            _editSelectBookTag = -1;
            _editingAmount = -1;
        }

        // Notify observer
        public void NotifyObserver()
        {
            if (_modelChanged != null)
            {
                _modelChanged();
            }
        }

        // SetEditSelectBookTag
        public void SetEditSelectBookTag(int value)
        {
            _editSelectBookTag = value;
        }

        // GetEditSelectBookTag
        public int GetEditSelectBookTag()
        {
            return _editSelectBookTag;
        }

        // SetEditingAmount
        public void SetEditingAmount(string value)
        {
            _editingAmount = int.Parse(value);
        }

        // GetCurrentAmount
        public string GetCurrentAmount()
        {
            return _editingAmount.ToString();
        }


        // GetBookAmountByTag
        public int GetBorrowedItemAmountByTag(int bookTag)
        {
            return _library.GetBorrowedItemAmountByTag(bookTag);
        }

        // GetErrorMessageBoxTitle
        public string GetErrorMessageBoxTitle()
        {
            return _errorMessageTitle;
        }

        // GetErrorMessageBoxText
        public string GetErrorMessageBoxText()
        {
            return _errorMessageText;
        }

        // SetMessageBosResultAndEditingAmount
        public void SetMessageBoxResultAndEditingAmount(int amount, string title, string text)
        {
            _editingAmount = amount;
            _errorMessageTitle = title;
            _errorMessageText = text;
            NotifyObserver();
        }

        // JudgeEditing
        public void JudgeEditing()
        {
            int selectedBookBorrowedAmount = GetBorrowedItemAmountByTag(_editSelectBookTag);
            if (_editingAmount < 1)
                SetMessageBoxResultAndEditingAmount(1, RETURN_AMOUNT_ERROR_TITLE, RETURN_AMOUNT_ERROR_TEXT_AT_LEAST_ONE_BOOK);
            if (_editingAmount > selectedBookBorrowedAmount)
                SetMessageBoxResultAndEditingAmount(selectedBookBorrowedAmount, RETURN_AMOUNT_ERROR_TITLE, RETURN_AMOUNT_ERROR_TEXT_NOT_OVER_BORROWED);
        }
    }
}
