using Assets.Scriprs.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scriprs
{
    public class BoardWithSlots // : IBoard
    {
        public int Capacity { get; set; }
        //public bool isFull => _slots.All( slot => slot.isFull);

        bool IsFull { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        private List<IBoardSlot> _slots;

        public BoardWithSlots(int capacity )
        {
            this.Capacity = capacity;

            _slots = new List<IBoardSlot>();
            for (int i = 0; i < Capacity; i++)
            {
                _slots.Add(new BoardSlot());
            }
        }

        public IBoardItem[] GetAllItems()
        {
            throw new NotImplementedException();
        }

        public IBoardItem[] GetAllItems(Type itemType)
        {
            throw new NotImplementedException();
        }

        public IBoardItem[] GetEquippedItems()
        {
            throw new NotImplementedException();
        }

        public IBoardItem GetItem(Type itemType)
        {
            return _slots.Find(slot => slot.ItemType == itemType).Item;
        }

        public int GetItemsAmount(Type itemType)
        {
            throw new NotImplementedException();
        }

        public bool HasItem(Type itemType, out IBoardItem item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(object sendler, Type itemType, int amount = 1)
        {
            throw new NotImplementedException();
        }

        public bool TryAdd(object sendler, IBoardItem item)
        {
            //var slotWithSameItem = _slots.
            //    Find(slot => !slot.isEmpty 
            //                && slot.ItemType == item.ItemType && !slot.isFull);

            //if(slotWithSameItem != null)
            //{
            //    return AddToSlot(sendler, slotWithSameItem, item);
            //}

            throw new NotImplementedException();
        }
    }
}
