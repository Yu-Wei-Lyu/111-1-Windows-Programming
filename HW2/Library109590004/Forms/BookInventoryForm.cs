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
    public partial class BookInventoryForm : Form
    {
        BookInventoryPresentationModel _presentationModel;

        public BookInventoryForm(BookInventoryPresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            InitializeComponent();
        }
    }
}
