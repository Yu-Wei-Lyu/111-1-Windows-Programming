using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Library109590004
{
    public class BookInventoryPresentationModel
    {
        private LibraryModel _library;

        public BookInventoryPresentationModel(LibraryModel library)
        {
            _library = library;
        }

        // Get library
        public LibraryModel GetLibrary()
        {
            return _library;
        }

        // Get replenishment image
        public Image GetSupplyImage()
        {
            return _library.GetSupplyImage();
        }
    }
}
