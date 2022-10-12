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

        // Open book borrowing form
        public void OpenBookBorrowingForm()
        {

        }

        // Open book borrowing form
        public void OpenBookInventoryForm()
        {
            BookInventoryForm inventoryForm = new BookInventoryForm(new BookInventoryPresentationModel(GetLibrary()));
            inventoryForm.Show();
            inventoryForm.FormClosing += (sender, e) => _menuInventoryButtonEnabled = true;
            _menuInventoryButtonEnabled = false;
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
    }
}
