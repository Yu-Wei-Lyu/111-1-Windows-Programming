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
        private const string DATA_BINDING_CONFIRM_ENABLED = "IsConfirmEnabled";
        private const string DATA_BINDING_AMOUNT_TEXT = "SupplyBookAmountText";
        private LibraryModel _library;
        private bool _isConfirmEnabled;
        private string _supplyBookAmount;

        public SupplyPresentationModel(LibraryModel library)
        {
            _library = library;
            _isConfirmEnabled = false;
            _supplyBookAmount = "";
        }

        // Supply book amount textbox text changed
        public void SupplyBookAmountTextBoxTextChanged(string text)
        {
            _isConfirmEnabled = text != "";
            _supplyBookAmount = text;
            NotifyPropertyChanged(DATA_BINDING_CONFIRM_ENABLED);
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
                NotifyPropertyChanged(DATA_BINDING_CONFIRM_ENABLED);
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

        // Notify
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
