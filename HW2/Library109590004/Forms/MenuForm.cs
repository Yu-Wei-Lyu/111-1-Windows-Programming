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
        MenuFormPresentationModel _presentationModel;
        public MenuForm(MenuFormPresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            InitializeComponent();
        }

        // Exit button click event
        private void ExitButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        // Book inventory system button click event
        private void HandleInventorySystemButtonClick(object sender, EventArgs e)
        {
            _presentationModel.OpenBookInventoryForm();
            _inventorySystemButton.Enabled = _presentationModel.IsMenuInventoryButtonEnabled();
        }

        // Book borrowing system button click event
        private void HandleBorrowingSystemButtonClick(object sender, EventArgs e)
        {
            _presentationModel.OpenBookBorrowingForm();
            _borrowingSystemButton.Enabled = _presentationModel.IsMenuBorrowingButtonEnabled();
        }

        // Menu form activated event
        private void HandleMenuFormActivated(object sender, EventArgs e)
        {
            _borrowingSystemButton.Enabled = _presentationModel.IsMenuBorrowingButtonEnabled();
            _inventorySystemButton.Enabled = _presentationModel.IsMenuInventoryButtonEnabled();
        }
    }
}
