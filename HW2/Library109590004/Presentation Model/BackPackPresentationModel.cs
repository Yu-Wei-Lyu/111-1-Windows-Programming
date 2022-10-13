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
        private int _row;
        public BackPackPresentationModel(LibraryModel library)
        {
            _library = library;
            _row = 0;
        }

        // Get borrowed list count
        public int GetBorrowedListCount()
        {
            return _library.GetBorrowedListCount();
        }

        // Initialize row
        public void InitializeViewRows()
        {
            _row = 0;
        }

        // Get borrowed list row
        public string[] GetBorrowedListRow()
        {
            return _library.GetBorrowedItemCells(_row++);
        }

        // Return book back to library
        public void ReturnBookToLibrary(int index)
        {
            _library.ReturnBookToLibrary(index);
        }

        // GetReturnBookText
        public string GetReturnBookText()
        {
            return _library.GetReturnBookText();
        }
    }
}
