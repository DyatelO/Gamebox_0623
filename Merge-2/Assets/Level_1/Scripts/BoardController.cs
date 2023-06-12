using Board.Model;
using Board.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Board
{
    public class BoardController : MonoBehaviour
    {
        [SerializeField] private UIBoardPage boardPageUI;
        [SerializeField] private BoardSO boardData;

        [SerializeField] private List<BoardItem> boardItems; // = new List<BoardItem>();
        //public List<BoardItem> initialItems = new List<BoardItem>();
        [field: SerializeField] public int Size => boardData.Size;

        public event Action<Dictionary<int, BoardItem>> OnInventoryUpdated;

        private void Awake()
        {
            PrepareUI();
            PrepareBoardData();
            boardPageUI.Show();

        }
        private void PrepareBoardData()
        {
            Initialize();
            OnInventoryUpdated += UpdateBoardUI;

            foreach (BoardItem item in boardData.boardItems)
            {
                if (item.IsEmpty)
                    continue;

                AddItem(item);
            }
        }

        private void UpdateBoardUI(Dictionary<int, BoardItem> boardState)
        {
            boardPageUI.ResetAllItems();
            foreach (var item in boardState)
            {
                boardPageUI.UpdateData(item.Key, item.Value.item.ItemIcon);
            }
        }

        public void AddItem(BoardItem item)
        {
            AddItem(item.item);
        }

        private void PrepareUI()
        {
            boardPageUI.InitializeBoardUI(Size);
            boardPageUI.OnMergeItem += HandleMergeItem;
            boardPageUI.OnStartDragging += HandleStartDragging;
            boardPageUI.OnItemActionRequested += HandleActionRequested;
            boardPageUI.OnDescriptionRequested += HandleDescriptionRequested;
        }

        private void HandleDescriptionRequested(int itemIndex)
        {
            BoardItem boardItem = GetItemAt(itemIndex);

            if (boardItem.IsEmpty)
            {
                boardPageUI.ResetSelection();
                return;
            }

            ItemSO item = boardItem.item;
            boardPageUI.UpdateDescription(itemIndex, item.ItemIcon, item.Name);

        }

        private void HandleActionRequested(int itemIndex)
        {
            throw new NotImplementedException();
        }

        private void HandleStartDragging(int itemIndex)
        {
            BoardItem boardItem = GetItemAt(itemIndex);
            if (boardItem.IsEmpty)
            {
                boardPageUI.ResetSelection();
                return;
            }
            boardPageUI.CreateDraggetItem(boardItem.item.ItemIcon);
        }

        private void HandleMergeItem(int itemIndex1, int itemIndex2)
        {
            if (boardItems[itemIndex1].item.ID == boardItems[itemIndex2].item.ID)
            {
                MergeItems(itemIndex1, itemIndex2);
            }
            //SwapItems(itemIndex1, itemIndex2);
        }

        //private void SwapItems(int itemIndex1, int itemIndex2)
        //{
        //    BoardItem boardItem1 = boardItems[itemIndex1];
        //    boardItems[itemIndex1] = boardItems[itemIndex2];
        //    boardItems[itemIndex2] = boardItem1;
        //    InformAboutChange();

        //}
        private void MergeItems(int itemIndex1, int itemIndex2)
        {
            boardItems[itemIndex2] = BoardItem.GetEmptyItem();
            boardItems[itemIndex1] = BoardItem.GetEmptyItem();
            InformAboutChange();

        }

        private void InformAboutChange()
        {
            OnInventoryUpdated?.Invoke(GetCurrentBoardState());
        }

        public BoardItem GetItemAt(int itemIndex)
        {
            return boardItems[itemIndex];
        }

        private void Update()
        {
            //Придумать как пришить таймер к спавну объектоа.
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
                {
                    boardItems[i] = new BoardItem
                    {
                        item = item
                    };
                    return;
                }
                //boardItems.Add(BoardItem.GetEmptyItem());
            }
        }

    }
}