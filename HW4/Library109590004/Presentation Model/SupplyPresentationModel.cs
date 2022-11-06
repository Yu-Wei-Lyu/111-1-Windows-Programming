using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Library109590004
{
    public class SupplyPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private const string SUPPLY_BOOK_TEXT_FORMAT = "書籍名稱：{0}\n\n書籍類別：{1}\n庫存數量：{2}";
        private const string DATA_BINDING_CONFIRM_ENABLED = "IsConfirmEnabled";
        private const string DATA_BINDING_AMOUNT_TEXT = "SupplyBookAmountText";
        private LibraryModel _library;
        private bool _isConfirmEnabled;
        private string _supplyBookAmount;

        // Notify
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public SupplyPresentationModel(LibraryModel library)
        {
            _library = library;
            _isConfirmEnabled = false;
            _supplyBookAmount = "";
        }

        // Supply book amount textbox text changed
        public void SupplyBookAmountTextBoxTextChanged(string text)
        {
            IsConfirmEnabled = text != "";
            _supplyBookAmount = text;
        }

        // _isConfirmEnabled property
        public bool IsConfirmEnabled
        {
            get
            {
                return _isConfirmEnabled;
            }
            set
            {
                _isConfirmEnabled = value;
                NotifyPropertyChanged("IsConfirmEnabled");
            }
        }

        // _supplyBookAmountText property
        public string SupplyBookAmountText
        {
            get
            {
                return _supplyBookAmount;
            }
        }

        // Get supply book text
        public string GetSupplyBookText(int bookTag)
        {
            Book book = _library.GetBookByTag(bookTag);
            return string.Format(SUPPLY_BOOK_TEXT_FORMAT, book.Name, _library.GetCategoryNameByBookTag(bookTag), _library.GetBookAmountByTag(bookTag));
        }
    }
}
