using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IBoard
{
    int Copacity { get; set; }
    bool isFull { get; set; }

    IBoardItem GetItem(Type itemType);
    IBoardItem[] GetAllItems();
    IBoardItem[] GetAllItems(Type itemType);
    IBoardItem[] GetEquippedItems();
    int GetItemsAmount(Type itemType);

    bool TryAdd(object sendler, IBoardItem item);
    bool Remove(object sendler, Type itemType, int amount = 1);
    bool HAsItem(Type itemType, out IBoardItem item);

}

namespace Assets.Scriprs.Abstracts
{
    public interface IBoardSlot
    {
        bool isFull { get; }
        bool isEmpty { get; }
        IBoardItem Item { get; }
        Type ItemType { get; }
        int AmountItems { get; }
        int Copacity { get; }

        void SetItem(IBoardItem item);
        void Clear();
    }
}
