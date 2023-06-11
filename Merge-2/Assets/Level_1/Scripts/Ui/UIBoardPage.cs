using System.Collections;
using System.Collections.Generic;
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
            uiItem.transform.SetParent(contentPanel, false);
            listOfItems.Add(uiItem);
        }
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
