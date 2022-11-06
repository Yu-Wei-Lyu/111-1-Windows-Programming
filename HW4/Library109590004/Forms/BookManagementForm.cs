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
    public partial class BookManagementForm : Form
    {
        private BookManagementPresentationModel _presentationModel;
        private LibraryModel _library;
        public BookManagementForm(BookManagementPresentationModel presentationModel, LibraryModel library)
        {
            _library = library;
            _presentationModel = presentationModel;
            InitializeComponent();
        }
    }
}
