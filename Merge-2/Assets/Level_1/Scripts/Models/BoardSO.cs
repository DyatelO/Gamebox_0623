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