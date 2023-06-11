using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] private UIBoardPage boardPageUI;
    //[SerializeField] private BoardSO boardData;

    //public int boardSize = 8;

    [field: SerializeField] public List<BoardItem> boardItems;

    [field: SerializeField] public int Size { get; private set; } = 10;


    private void Awake()
    {
        PrepareUI();

        boardPageUI.Show();

    }

    private void Start()
    {
        //boardItems = boardData.boardItems;
    }

    private void PrepareUI()
    {
        boardPageUI.InitializeBoardUI(Size);
        this.boardPageUI.OnSwapItem += HandleSpawnItem;
        this.boardPageUI.OnStartDragging += HandleStartDragging;
        this.boardPageUI.OnItemActionRequested += HandleActionRequested;
        this.boardPageUI.OnDescriptionRequested += HandleDescriptionRequested;
    }

    private void HandleDescriptionRequested(int itemIndex)
    {
        BoardItem boardItem = GetItemAt(itemIndex);

        if (boardItem.IsEmpty)
            return;

        ItemSO item = boardItem.item;
        boardPageUI.UpdateDescription(itemIndex, item.ItemIcon, item.Name);

    }

    private void HandleActionRequested(int itemIndex)
    {
        throw new NotImplementedException();
    }

    private void HandleStartDragging(int itemIndex)
    {
        throw new NotImplementedException();
    }

    private void HandleSpawnItem(int itemIndex1, int itemIndex2)
    {
        throw new NotImplementedException();
    }

    public BoardItem GetItemAt(int itemIndex)
    {
        return boardItems[itemIndex];
    }

    private void Update()
    {
        //��������� ��� ������� ������ � ������ ��������.
        foreach (var item in GetCurrentBoardState())
        {
            boardPageUI.UpdateData(item.Key, item.Value.item.ItemIcon);
        }
    }

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
