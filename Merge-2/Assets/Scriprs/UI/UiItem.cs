using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiItem : MonoBehaviour,IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IDropHandler
{
    public Item item;

    public Image Image;
    //-------------------

    private RectTransform _rectTransform;
    private Canvas _mainCanvas;

    private CanvasGroup _canvasGroup;

    private GridSpawnController _gridSpawnController;

    public GameObject ObjectBelow;

    public ItemType ItemType;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCanvas = GetComponentInParent<Canvas>();

        _canvasGroup = GetComponent<CanvasGroup>();
        //Image = GetComponentInChildren<Image>();


        //InitializeItem(item);
    }

    public void InitializeItem(Item newItem)
    {
        item = newItem;
        Image.sprite = newItem.ImageSprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        //ObjectBelow = eventData.pointerDrag.gameObject;
        //Debug.Log(eventData.GetType());
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        var slotTransform = _rectTransform.parent;
        slotTransform.SetAsLastSibling();

        _canvasGroup.blocksRaycasts = false;
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
        //ObjectBelow = eventData.pointerDrag.gameObject;
        //Debug.Log(ObjectBelow.name + " Enter!!!");
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.gameObject.GetComponent<UiItem>().ItemType != ItemType)
        {
            transform.localPosition = Vector2.zero;
            _canvasGroup.blocksRaycasts = true; 
        }

    }
}
