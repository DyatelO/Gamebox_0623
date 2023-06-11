using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Graphs;
using UnityEngine;

public class UIBoardPage : MonoBehaviour
{
    [SerializeField] private UiBoardItem itemPrefab;

    [SerializeField] private RectTransform contentPanel;

    private List<UiBoardItem> listOfItems = new List<UiBoardItem>();

    public void InitializeBoardUI(int itemsAmount)
    {
        for (int i = 0; i < itemsAmount; i++)
        {
            UiBoardItem uiItem = Instantiate(itemPrefab, Vector2.zero, Quaternion.identity);
            uiItem.name = $"{itemPrefab.name}_{i}";
            uiItem.transform.SetParent(contentPanel, false);
            listOfItems.Add(uiItem);

            uiItem.OnBoardItemClicked += HaHandleItemSelection;
            uiItem.OnBoardItemDroppedOn += HaHandleDroppedOn;
            uiItem.OnBoardItemBeginDrag += HaHandleBeginDrag;
            uiItem.OnBoardItemEndDrag += HaHandleEndDrag;
        }
    }

    private void HaHandleEndDrag(UiBoardItem obj)
    {
        throw new NotImplementedException();
    }

    private void HaHandleBeginDrag(UiBoardItem obj)
    {
        throw new NotImplementedException();
    }

    private void HaHandleDroppedOn(UiBoardItem obj)
    {
        throw new NotImplementedException();
    }

    private void HaHandleItemSelection(UiBoardItem obj)
    {
        Debug.Log(obj.name);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
