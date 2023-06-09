using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiSlot : MonoBehaviour, IDropHandler
{
    public bool IsEmpty = true;

    //public GameObject IteminSlot_1;
    //public GameObject IteminSlot_2;
    public List<ScriptableObject> itemsByType;


    //public UiSlot(List<ScriptableObject> itemsByType)
    //{
    //    this.itemsByType = itemsByType;
    //}

    private void Awake()
    {
    }


    private void Update()
    {
        if(GetComponentInChildren<UiItem>() == null)
        {
            IsEmpty = true;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        var droppedItemTransform = eventData.pointerDrag.transform;
        droppedItemTransform.SetParent(transform);
        droppedItemTransform.localPosition = Vector3.zero;

        IsEmpty = false;    

        //IteminSlot_1 = eventData.pointerDrag.gameObject;
        //var item1 = IteminSlot_1.GetComponent<UiItem>().ItemType;

        //if (IsEmpty == false && )
        //{
        //    IteminSlot_2 = eventData.pointerDrag.gameObject;
        //    if(!= )
        //}



    }
}
