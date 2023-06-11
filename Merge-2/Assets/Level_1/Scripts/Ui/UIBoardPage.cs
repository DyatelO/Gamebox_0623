using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Graphs;
using UnityEngine;

namespace Board.UI
{
    public class UIBoardPage : MonoBehaviour
    {
        [SerializeField] private UiBoardItem itemPrefab;

        [SerializeField] private RectTransform contentPanel;

        [SerializeField] private MouseFolower mouseFolower;

        //[SerializeField] private UiBoardDescription uiBoardDescription;

        private List<UiBoardItem> listOfItems = new List<UiBoardItem>();

        private int currentlyDraggedItemIndex = -1;

        public event Action<int> OnItemActionRequested;
        public event Action<int> OnStartDragging;

        public event Action<int, int> OnSwapItem;

        public event Action<int> OnDescriptionRequested;

        private void Awake()
        {
            //Hide();
            mouseFolower.Toggle(false);
        }

        public void InitializeBoardUI(int itemsAmount)
        {
            for (int i = 0; i < itemsAmount; i++)
            {
                UiBoardItem uiItem = Instantiate(itemPrefab, Vector2.zero, Quaternion.identity);
                uiItem.name = $"{itemPrefab.name}_{i}";
                uiItem.transform.SetParent(contentPanel, false);
                listOfItems.Add(uiItem);

                uiItem.OnBoardItemClicked += HaHandleItemSelection;
                uiItem.OnBoardItemDroppedOn += HaHandleSwap;
                uiItem.OnBoardItemBeginDrag += HaHandleBeginDrag;
                uiItem.OnBoardItemEndDrag += HaHandleEndDrag;
                //uiItem.OnBoardItemDrag += 
            }
        }

        public void UpdateData(int itemaIndex, Sprite itemIcon)
        {
            if (listOfItems.Count > itemaIndex)
            {
                listOfItems[itemaIndex].SetData(itemIcon);

            }

        }


        private void HaHandleEndDrag(UiBoardItem boardItemUI)
        {
            ResetDraggedItem();
            DeselectAllItems();
        }

        private void ResetDraggedItem()
        {
            mouseFolower.Toggle(false);
            currentlyDraggedItemIndex = -1;
        }

        private void HaHandleBeginDrag(UiBoardItem boardItemUI)
        {
            int index = listOfItems.IndexOf(boardItemUI);
            if (index == -1)
                return;

            currentlyDraggedItemIndex = index;
            HaHandleItemSelection(boardItemUI);
            OnStartDragging?.Invoke(index);

            Debug.Log(currentlyDraggedItemIndex);
        }

        public void CreateDraggetItem(Sprite sprite)
        {
            mouseFolower.Toggle(true);
            mouseFolower.SetData(sprite);
        }

        private void HaHandleSwap(UiBoardItem boardItemUI)
        {
            int index = listOfItems.IndexOf(boardItemUI);
            if (index == -1)
            {
                return;
            }

            OnSwapItem?.Invoke(currentlyDraggedItemIndex, index);
        }

        private void HaHandleItemSelection(UiBoardItem boardItemUI)
        {
            int index = listOfItems.IndexOf(boardItemUI);
            if (index == -1)
            {
                return;
            }
            listOfItems[index].Select();

            Debug.Log(boardItemUI.name);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            ResetSelection();
        }

        private void ResetSelection()
        {
            DeselectAllItems();
        }

        private void DeselectAllItems()
        {
            for (int i = 0; i < listOfItems.Count; i++)
            {
                listOfItems[i].Deselect();
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            ResetDraggedItem();
        }

        public void UpdateDescription(int itemIndex, Sprite itemIcon, string name)
        {
            //UpdateData(itemIndex, itemIcon);
            //uiBoardDescription.SetDescription(itemIcon);
            DeselectAllItems();
            listOfItems[itemIndex].Select();
        }
    }
}