using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class BackPackPresentationModel
    {
        LibraryModel _library;
        public BackPackPresentationModel(LibraryModel library)
        {
            _library = library;
        }

        // Return book back to library
        public void ReturnBookToLibrary(int index)
        {
            _library.ReturnBookToLibrary(index);
        }
    }
}
