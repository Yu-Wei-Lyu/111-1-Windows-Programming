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
        private void BookInventorySystemButtonClick(object sender, EventArgs e)
        {
            BookInventoryForm form = new BookInventoryForm(new BookInventoryPresentationModel(_presentationModel.GetLibrary()));
            form.Show();
        }

        // Book borrowing system button click event
        private void BookBorrowingSystemButtonClick(object sender, EventArgs e)
        {
            BookBorrowingForm form = new BookBorrowingForm(new BookBorrowingFormPresentationModel(_presentationModel.GetLibrary()));
            form.Show();
        }
    }
}
