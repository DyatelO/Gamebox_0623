using System;

[Serializable]
public class Board
{
    //internal object Items;
    //public List<Item> itemList;
    public BoardSlot[] Items = new BoardSlot[32];

    //public Board() 
    //{
    //    itemList = new List<Item>();

    //    AddItem(new Item() { itemType = ItemType.Attack, amount = 1 });
    //    Debug.Log(itemList.Count);
    //}

    //public void AddItem(Item item)
    //{
    //    itemList.Add(item);
    //}
}

