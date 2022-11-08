using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library109590004
{
    public class BorrowingList
    {
        private Dictionary<int, int> _borrowingList; // bookTag, bookBorrowingAmount
        public BorrowingList()
        {
            _borrowingList = new Dictionary<int, int>();
        }

        public int Count
        {
            get
            {
                return _borrowingList.Count;
            }
        }

        // Add
        public void Add(int bookTag, int amount)
        {
            _borrowingList.Add(bookTag, amount);
        }

        // SetBorrowingAmountByIndex
        public void SetBorrowingAmountByIndex(int index, int amount)
        {
            int key = _borrowingList.ElementAt(index).Key;
            _borrowingList[key] = amount;
        }

        // ContainsKey
        public bool ContainsKey(int key)
        {
            return _borrowingList.ContainsKey(key);
        }

        // RemoveBookTagByIndex
        public void RemoveBookTagByIndex(int index)
        {
            _borrowingList.Remove(_borrowingList.ElementAt(index).Key);
        }

        // GetBorrowingBooksAmount
        public int GetBorrowingBooksAmount()
        {
            int borrowingBooksAmount = 0;
            foreach (KeyValuePair<int, int> item in _borrowingList)
                borrowingBooksAmount += item.Value;
            return borrowingBooksAmount;
        }

        // GetBorrowingListTagByIndex
        public int GetBorrowingListTagByIndex(int index)
        {
            return _borrowingList.ElementAt(index).Key;
        }

        // Clear
        public void Clear()
        {
            _borrowingList.Clear();
        }

        // GetAmountByTag
        public int GetAmountByTag(int bookTag)
        {
            return _borrowingList[bookTag];
        }
    }
}
