using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform _rectTransform;

    
    public void OnDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        _rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _rectTransform = GetComponent<RectTransform>();
        Debug.Log($"{name} Click in progress!");
    }
}
