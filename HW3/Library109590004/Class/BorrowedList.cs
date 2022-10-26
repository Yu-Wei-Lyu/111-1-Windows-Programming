using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class BorrowedList
    {
        private List<BorrowedItem> _borrowedItems;
        public BorrowedList()
        {
            _borrowedItems = new List<BorrowedItem>();
        }

        // get borrowed iten by index
        public BorrowedItem GetBorrowedItem(int index)
        {
            return _borrowedItems[index];
        }

        // Borrowed items list add
        public void Add(BorrowedItem borrowedItem)
        {
            bool searched = false;
            for (int i = 0; i < _borrowedItems.Count; i++)
            {
                BorrowedItem item = GetBorrowedItemByIndex(i);
                if (item.IsSameBookAddAmount(borrowedItem))
                {
                    searched = true;
                    return;
                }
            }
            if (!searched)
                _borrowedItems.Add(borrowedItem);
        }

        // ReduceBorrowedAmountByIndex
        public void ReduceBorrowedAmountByIndex(int index, int amount)
        {
            _borrowedItems[index].SetMinusBorrowedAmount(amount);
        }

        // Borrowed items list remove
        public void Remove(int index)
        {
            _borrowedItems.RemoveAt(index);
        }

        // Borrowed items cell
        public string[] GetBorrowedItemCells(int index)
        {
            BorrowedItem borrowedItem = GetBorrowedItemByIndex(index);
            return borrowedItem.GetBorrowedItemCells(index);
        }

        // Get borrowed date
        public string GetBorrowedDate(int index)
        {
            return _borrowedItems[index].GetBorrowedDate();
        }

        // Get last return date
        public string GetLatestReturnDate(int index)
        {
            return _borrowedItems[index].GetLatestReturnDate();
        }

        // Count attribute
        public int Count
        {
            get
            {
                return _borrowedItems.Count;
            }
        }

        // Get borrowed item by index
        private BorrowedItem GetBorrowedItemByIndex(int index)
        {
            return _borrowedItems[index];
        }

        // GetBorrowedItemAmountByTag
        public int GetBorrowedItemAmountByTag(int bookTag)
        {
            foreach (BorrowedItem item in _borrowedItems)
            {
                if (item.BookTag == bookTag)
                {
                    return GetBorrowedItemAmount(item);
                }
            }
            throw new Exception("");
        }

        // GetBorrowedItemAmount
        private int GetBorrowedItemAmount(BorrowedItem borrowedItem)
        {
            return borrowedItem.BorrowedAmount;
        }

        // GetBorrowedListTagByIndex
        public int GetBorrowedListTagByIndex(int index)
        {
            return _borrowedItems.ElementAt(index).BookTag;
        }

        // ReturnBookAmountBy
    }
}
