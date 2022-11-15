using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library109590004
{
    public partial class MenuForm : Form
    {
        private const string SOURCE_FILE_NAME = "../../../hw4_books_source.txt";
        private const string TRASH_CAN_IMAGE = "../../../image/trash_can.png";
        private BookBorrowingForm _borrowingForm;
        private BookInventoryForm _inventoryForm;
        private BookManagementForm _managementForm;
        MenuFormPresentationModel _presentationModel;
        public MenuForm(MenuFormPresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            InitializeComponent();
            LibraryModel libraryModel = new LibraryModel(SOURCE_FILE_NAME);
            _borrowingForm = new BookBorrowingForm(new BookBorrowingPresentationModel(libraryModel, TRASH_CAN_IMAGE), libraryModel);
            _borrowingForm.FormClosing += new FormClosingEventHandler(ClosingBorrowingForm);
            _inventoryForm = new BookInventoryForm(new BookInventoryPresentationModel(libraryModel), libraryModel);
            _inventoryForm.FormClosing += new FormClosingEventHandler(ClosingInventoryForm);
            _managementForm = new BookManagementForm(new BookManagementPresentationModel(libraryModel), libraryModel);
            _managementForm.FormClosing += new FormClosingEventHandler(ClosingManagementForm);
        }

        // Exit button click event
        private void ExitButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        // Book inventory system button click event
        private void HandleInventorySystemButtonClick(object sender, EventArgs e)
        {
            _inventoryForm.Show();
            _inventorySystemButton.Enabled = false;
        }

        // Book borrowing system button click event
        private void HandleBorrowingSystemButtonClick(object sender, EventArgs e)
        {
            _borrowingForm.Show();
            _borrowingSystemButton.Enabled = false;
        }

        // Book management system button click event
        private void HandleManagementSystemButtonClick(object sender, EventArgs e)
        {
            _managementForm.Show();
            _managementSystemButton.Enabled = false;
        }

        // Closing borrow form event
        private void ClosingBorrowingForm(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            _borrowingSystemButton.Enabled = true;
            _borrowingForm.Hide();
        }

        // Closing inventory form event
        private void ClosingInventoryForm(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            _inventorySystemButton.Enabled = true;
            _inventoryForm.Hide();
        }

        // Closing inventory form event
        private void ClosingManagementForm(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            _managementSystemButton.Enabled = true;
            _managementForm.Hide();
        }
    }
}
