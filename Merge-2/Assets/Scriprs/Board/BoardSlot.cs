using System;

[Serializable]
public class BoardSlot
{
    public int ID { get; set; }
    public Item Item { get; set; }
    public int Amount { get; set; }

    public BoardSlot()
    {
        ID = -1;
        Item = null;
        Amount = 0;
    }    
    public BoardSlot(int id, Item item, int amount)
    {
        ID = id;
        Item = item;
        Amount = amount;
    }

    public void AddAmount(int value)
    {
        //_amount += value;
        Amount += value;
    }
}