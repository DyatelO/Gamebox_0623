using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiSlot : MonoBehaviour, IDropHandler
{
    public bool IsEmpty = true;

    //public GameObject IteminSlot_1;
    //public GameObject IteminSlot_2;
    public List<Item> itemsByType;

    public ItemMergeControler mergeControler;


    private void Update()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        //if(!itemsByType.Contains(eventData.pointerDrag.GetComponent<UiItem>().item))
        //    itemsByType.Add((eventData.pointerDrag.GetComponent<UiItem>().item));

        var droppedItemTransform = eventData.pointerDrag.transform;
        droppedItemTransform.SetParent(transform);
        droppedItemTransform.localPosition = Vector2.zero;

        IsEmpty = false;

        

        //mergeControler.slot_2 = eventData.pointerDrag.GetComponent<UiItem>().item;
        
        //mergeControler.mergeList.Add(eventData.pointerDrag.GetComponent<UiItem>().item);

    }
}
