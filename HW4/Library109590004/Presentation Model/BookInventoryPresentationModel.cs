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
        private const string SUPPLY_IMAGE = "../../../image/replenishment.png";
        private Image _supplyImage;

        public BookInventoryPresentationModel(LibraryModel library)
        {
            _library = library;
            _supplyImage = Image.FromFile(SUPPLY_IMAGE);
        }

        // Get replenishment image
        public Image GetSupplyImage()
        {
            return _supplyImage;
        }
    }
}
