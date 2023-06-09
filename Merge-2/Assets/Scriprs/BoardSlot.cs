using Assets.Scriprs.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scriprs
{
    public class BoardSlot : IBoardSlot
    {
        public bool isFull => AmountItems == Copacity;

        public bool isEmpty => Item == null;

        public IBoardItem Item {get; private set;}

        public Type ItemType => Item.ItemType;

        public int AmountItems => isEmpty ? 0 : Item.AmountItems;

        public int Copacity { get; private set; }

        public void Clear()
        {
            if (isEmpty)
                return;

            Item.AmountItems = 0;
            Item = null;
        }

        public void SetItem(IBoardItem item)
        {
            if(!isEmpty)
            {
                return;
            }

            this.Item = Item;
            this.Copacity = Item.MaxItemsInBoardSlot;            
        }
    }
}
