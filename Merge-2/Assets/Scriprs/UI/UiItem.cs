using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiItem : MonoBehaviour,IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler
{
    private RectTransform _rectTransform;
    private Canvas _mainCanvas;

    private CanvasGroup _canvasGroup;

    private GridSpawnController _gridSpawnController;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCanvas = GetComponentInParent<Canvas>();

        _canvasGroup = GetComponent<CanvasGroup>();

        //_gridSpawnController = FindObjectOfType<GridSpawnController>();
        //Debug.Log(_gridSpawnController.name);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        Debug.Log(eventData.GetType());
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        var slotTransform = _rectTransform.parent;
        slotTransform.SetAsLastSibling();

        _canvasGroup.blocksRaycasts = false;


        //_gridSpawnController.enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //if()
        transform.localPosition = Vector2.zero;
        _canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerEnter+ " Enter!!!");
    }
}
