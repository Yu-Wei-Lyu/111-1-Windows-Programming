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
        private BookBorrowingForm _borrowingForm;
        private BookInventoryForm _inventoryForm;
        MenuFormPresentationModel _presentationModel;
        public MenuForm(MenuFormPresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            InitializeComponent();
            _borrowingForm = new BookBorrowingForm(new BookBorrowingPresentationModel(_presentationModel.GetLibrary()));
            _borrowingForm.FormClosing += new FormClosingEventHandler(ClosingBorrowingForm);
            _inventoryForm = new BookInventoryForm(new BookInventoryPresentationModel(_presentationModel.GetLibrary()));
            _inventoryForm.FormClosing += new FormClosingEventHandler(ClosingInventoryForm);
        }

        // Exit button click event
        private void ExitButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        // Book inventory system button click event
        private void HandleInventorySystemButtonClick(object sender, EventArgs e)
        {
            ShowInventoryForm();
            SetSystemButtonsEnable();
        }

        // Book borrowing system button click event
        private void HandleBorrowingSystemButtonClick(object sender, EventArgs e)
        {
            ShowBorrowingForm();
            SetSystemButtonsEnable();
        }

        // Menu form activated event
        private void HandleMenuFormActivated(object sender, EventArgs e)
        {
            SetSystemButtonsEnable();
        }

        // Show inventory form
        private void ShowInventoryForm()
        {
            _inventoryForm.Show();
            _presentationModel.SetInventoryButtonEnable(false);
        }

        // Show borrowing form
        private void ShowBorrowingForm()
        {
            _borrowingForm.Show();
            _presentationModel.SetBorrowingButtonEnable(false);
        }

        // Set system buttons enable
        private void SetSystemButtonsEnable()
        {
            _borrowingSystemButton.Enabled = _presentationModel.IsMenuBorrowingButtonEnabled();
            _inventorySystemButton.Enabled = _presentationModel.IsMenuInventoryButtonEnabled();
        }

        // Closing borrow form event
        private void ClosingBorrowingForm(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            _presentationModel.SetBorrowingButtonEnable(true);
            _borrowingForm.Hide();
        }

        // Closing inventory form event
        private void ClosingInventoryForm(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            _presentationModel.SetInventoryButtonEnable(true);
            _inventoryForm.Hide();
        }
    }
}
