using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Graphs;
using UnityEngine;

public class UIBoardPage : MonoBehaviour
{
    [SerializeField] private UiBoardItem itemPrefab;

    [SerializeField] private RectTransform contentPanel;

    [SerializeField] private MouseFolower mouseFolower;

    private List<UiBoardItem> listOfItems = new List<UiBoardItem>();


    public Sprite image, image2;

    private int currentlyDraggedItemIndex = -1;

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


    private void HaHandleEndDrag(UiBoardItem boardItemUI)
    {
        int index = listOfItems.IndexOf(boardItemUI);
        if (index == -1)
        {
            mouseFolower.Toggle(false);
            currentlyDraggedItemIndex = -1;
            return;
        }

        mouseFolower.Toggle(false);
        currentlyDraggedItemIndex = -1;
    }

    private void HaHandleBeginDrag(UiBoardItem boardItemUI)
    {
        mouseFolower.Toggle(true);

        int index = listOfItems.IndexOf(boardItemUI);
        if (index == -1)
            return;

        currentlyDraggedItemIndex = index;

        mouseFolower.SetData(index == 0 ? image : image2);

        Debug.Log(index);
    }

    private void HaHandleSwap(UiBoardItem boardItemUI)
    {
        int index = listOfItems.IndexOf(boardItemUI);
        if (index == -1)
        {
            mouseFolower.Toggle(false);
            currentlyDraggedItemIndex = -1;
            return;
        }

        listOfItems[currentlyDraggedItemIndex].SetData(
            index == 0 ? image : image2);      
        
        listOfItems[index].SetData(
            currentlyDraggedItemIndex == 0 ? image : image2);

        mouseFolower.Toggle(false);
        currentlyDraggedItemIndex = -1;

        
    }

    private void HaHandleItemSelection(UiBoardItem boardItemUI)
    {
        //listOfItems[currentlyDraggedItemIndex].Select();


        Debug.Log(boardItemUI.name);
    }

    public void Show()
    {
        gameObject.SetActive(true);

        listOfItems[0].SetData(image);
        listOfItems[1].SetData(image2);

    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
