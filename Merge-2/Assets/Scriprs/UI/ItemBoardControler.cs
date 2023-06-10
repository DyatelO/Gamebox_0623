using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBoardControler : MonoBehaviour
{
    public List<UiSlot> boardSlots;
    public GameObject uiItemPrefab;

    public bool AddItem(Item item)
    {
        for (int i = 0; i < boardSlots.Count - 1; i++)
        {
            UiSlot slot = boardSlots[i];
            UiItem itemInSlot = slot.GetComponentInChildren<UiItem>();
            if(itemInSlot == null )
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;

        
    }

    public void SpawnNewItem(Item item, UiSlot slot)
    {
        GameObject newItemGameObject = Instantiate(uiItemPrefab, slot.transform);
        UiItem uiItem = newItemGameObject.GetComponent<UiItem>();
        uiItem.InitializeItem(item );
    }
}
