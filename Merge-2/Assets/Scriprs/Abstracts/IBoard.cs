using System;

public interface IBoard
{
    int Capacity { get; set; }
    bool IsFull { get; set; }

    IBoardItem GetItem(Type itemType);
    IBoardItem[] GetAllItems();
    IBoardItem[] GetAllItems(Type itemType);
    IBoardItem[] GetEquippedItems();
    int GetItemsAmount(Type itemType);

    bool TryAdd(object sendler, IBoardItem item);
    bool Remove(object sendler, Type itemType, int amount = 1);
    bool HasItem(Type itemType, out IBoardItem item);

}
