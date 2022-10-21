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
        public SupplyForm(SupplyPresentationModel presentationModel, LibraryModel library)
        {
            _library = library;
            _presentationModel = presentationModel;
            InitializeComponent();
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
        public void UpdateSupplyForm()
        {

        }
    }
}
