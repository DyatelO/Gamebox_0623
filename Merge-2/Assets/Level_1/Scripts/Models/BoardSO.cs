using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

namespace Board.Model
{
    [CreateAssetMenu]
    public class BoardSO : ScriptableObject
    {
        [field: SerializeField] public List<BoardItem> boardItems;
        [field: SerializeField] public int Size { get; private set; } = 10;
    }

    [Serializable]
    public struct BoardItem
    {
        public ItemSO item;
        public bool IsEmpty => item == null;

        public BoardItem ChangeItem()
        {
            return new BoardItem
            {
                item = this.item
            };
        }

        public static BoardItem GetEmptyItem() => new BoardItem { item = null };
    }
}

        //����� ������ ��� ���� �� ������ ������� ����� ������������� � ��������� �����.
        //public void Initialize()
        //{
        //    boardItems = new List<BoardItem>();
        //    for (int i = 0; i < Size; i++)
        //    {
        //        boardItems.Add(BoardItem.GetEmptyItem());
        //    }
        //}

        /// <summary>
        /// �������� � �����-�� ���� ����� �������� ������� �����.
        /// </summary>
        /// <returns></returns>
        //public Dictionary<int, BoardItem> GetCurrentBoardState()
        //{
        //    Dictionary<int, BoardItem> returnValue = new Dictionary<int, BoardItem>();

        //    for (int i = 0; i < boardItems.Count; i++)
        //    {
        //        if (boardItems[i].IsEmpty)
        //            continue;
        //        returnValue[i] = boardItems[i];
        //    }
        //    return returnValue;
        //}

        /// <summary>
        /// ����� ��������� ������� � ��� �������������. 
        /// ���� ����� ������������ ����� ������� ���������.
        /// ���� �� ������� ��� � ��� ������ ������.
        /// ��� ��� ���� �� ������. ������� � ������ �����.
        /// </summary>
        /// <param name="item"></param>
        //public void AddItem(ItemSO item)
        //{
        //    for (int i = 0; i < boardItems.Count; i++)
        //    {
        //        if (boardItems[i].IsEmpty)
        //            boardItems[i] = new BoardItem 
        //            {
        //                item = item
        //            };
        //        boardItems.Add(BoardItem.GetEmptyItem());
        //    }
        //}