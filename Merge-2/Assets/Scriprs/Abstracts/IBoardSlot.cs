using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
