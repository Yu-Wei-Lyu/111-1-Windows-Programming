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

        public MenuFormPresentationModel(LibraryModel library)
        {
            _library = library;
        }

        // Get library
        public LibraryModel GetLibrary()
        {
            return _library;
        }
    }
}
