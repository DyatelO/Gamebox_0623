using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiSlot : MonoBehaviour, IDropHandler
{
    private void Awake()
    {
        //UIItem item = GetComponentInChildren<UIItem>();
        //string name = this.GetComponentInChildren<UIItem>().name;
        //if(name.Contains("_01"))
        //{
        //    item.enabled = true;
        //}
    }

    public void OnDrop(PointerEventData eventData)
    {
        var droppedItemTransform = eventData.pointerDrag.transform;
        droppedItemTransform.SetParent(transform);
        droppedItemTransform.localPosition = Vector3.zero;


    }
}
