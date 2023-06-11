using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu]
public class BoardSO : ScriptableObject
{
    [SerializeField] private List<BoardItem> boardItems;

    [field: SerializeField] public int Size { get; private set; } = 10;

    //Этого метода тут быть не должно Вынести метод инициализации в отдельный класс.
    public void Initialize()
    {
        boardItems = new List<BoardItem>();
        for (int i = 0; i < Size; i++)
        {
            boardItems.Add(BoardItem.GetEmptyItem());
        }
    }

    public Dictionary<int, BoardItem> GetCurrentBoardState()
    {
        Dictionary<int, BoardItem> returnValue = new Dictionary<int, BoardItem>();

        for (int i = 0; i < boardItems.Count; i++)
        {
            if (boardItems[i].IsEmpty)
                continue;
            returnValue[i] = boardItems[i];
        }
        return returnValue;
    }

    /// <summary>
    /// Метод добавляет предмет к уже сузествующему. 
    /// Есть смысл использовать после слияния предметов.
    /// Пока не понятно что с ним делать дальше.
    /// Его тут быть не должно. Вынести в жругой класс.
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(ItemSO item)
    {
        for (int i = 0; i < boardItems.Count; i++)
        {
            if (boardItems[i].IsEmpty)
                boardItems[i] = new BoardItem 
                {
                    item = item
                };
            boardItems.Add(BoardItem.GetEmptyItem());
        }
    }
}

[Serializable]
public struct BoardItem
{
    public ItemSO item;
    public bool IsEmpty => item != null;

    public BoardItem ChangeItem()
    {
        return new BoardItem
        {
            item = this.item
        };
    }

    public static BoardItem GetEmptyItem() => new BoardItem {item = null};
}
