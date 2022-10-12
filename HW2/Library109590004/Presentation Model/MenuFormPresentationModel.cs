using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class MenuFormPresentationModel
    {
        private LibraryModel _library;
        private bool _menuInventoryButtonEnabled;
        private bool _menuBorrowingButtonEnabled;

        public MenuFormPresentationModel(LibraryModel library)
        {
            _library = library;
            _menuBorrowingButtonEnabled = true;
            _menuInventoryButtonEnabled = true;
        }

        // Get library
        public LibraryModel GetLibrary()
        {
            return _library;
        }

        // Get menu borrowing system button enabled
        public bool IsMenuBorrowingButtonEnabled()
        {
            return _menuBorrowingButtonEnabled;
        }

        // Get menu inventory system button enabled
        public bool IsMenuInventoryButtonEnabled()
        {
            return _menuInventoryButtonEnabled;
        }

        // Set inventory button enabled
        public void SetInventoryButtonEnable(bool flag)
        {
            _menuInventoryButtonEnabled = flag;
        }

        // Set borrowing button enabled
        public void SetBorrowingButtonEnable(bool flag)
        {
            _menuBorrowingButtonEnabled = flag;
        }
    }
}
