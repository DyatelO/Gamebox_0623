using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private bool IsActive = false;
    public void OnDrop(PointerEventData eventData)
    {
        //eventData =  this.gameObject.transform.position;
        IsActive = true;
        Debug.Log("Dropping end!!");
    }
}
