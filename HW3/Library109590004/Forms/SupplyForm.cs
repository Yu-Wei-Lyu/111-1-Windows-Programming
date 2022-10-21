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
    public partial class SupplyForm : Form
    {
        LibraryModel _library;
        SupplyPresentationModel _presentationModel;
        private int _tag;
        public SupplyForm(SupplyPresentationModel presentationModel, LibraryModel library)
        {
            _library = library;
            _presentationModel = presentationModel;
            InitializeComponent();
            _supplyBookDetailTextBox.Text = "";
            _supplyConfirmButton.DataBindings.Add("Enabled", _presentationModel, "IsConfirmEnabled");
            _supplyConfirmButton.Enabled = false;
            _tag = -1;
        }

        // Supply book amount textbox key press event
        private void SupplyBookAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Update supply form
        public void OpenSupplyForm(int bookTag)
        {
            _tag = bookTag;
            _supplyBookAmountTextBox.Text = "";
            _supplyBookDetailTextBox.Text = _library.GetSupplyBookText(bookTag);
            ShowDialog();
        }

        // Supply cancel button click
        private void SupplyCancelButtonClick(object sender, EventArgs e)
        {
            Hide();
        }

        // Supply book amount textbox text changed
        private void SupplyBookAmountTextBoxTextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            _presentationModel.SupplyBookAmountTextBoxTextChanged(textBox.Text);
        }

        // Supply confirm button click
        private void SupplyConfirmButtonClick(object sender, EventArgs e)
        {
            _library.AddBookAmountByTag(_tag, _presentationModel.SupplyBookAmountText);
        }
    }
}
