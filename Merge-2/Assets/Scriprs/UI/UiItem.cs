using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiItem : MonoBehaviour,IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IDropHandler, IPointerClickHandler
{
    public Item item;

    public Image Image;

    public ItemMergeControler mergeControler;
    //-------------------

    private RectTransform _rectTransform;
    private Canvas _mainCanvas;

    private CanvasGroup _canvasGroup;

    private GridSpawnController _gridSpawnController;

    //public GameObject ObjectBelow;

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
        ItemType = newItem.Type;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //if (mergeControler.mergeList.Count > 2 )
        //    mergeControler.mergeList.Clear();

        //if (!mergeControler.mergeList.Contains(this.item))
        //    mergeControler.mergeList.Add(item);

        //throw new System.NotImplementedException();
        //ObjectBelow = eventData.pointerDrag.gameObject;
        //Debug.Log(eventData.GetType());
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        var slotTransform = _rectTransform.parent;
        slotTransform.SetAsLastSibling();

        _canvasGroup.blocksRaycasts = false;

        //mergeControler.slot_1 = item;
        //mergeControler.mergeList.Add(item);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //MergeCheck();
        transform.localPosition = Vector2.zero;

        _canvasGroup.blocksRaycasts = true;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        //mergeControler.slot_2 = eventData.pointerEnter.GetComponent<UiItem>().item;
        //ObjectBelow = eventData.pointerDrag.gameObject;
        //Debug.Log(ObjectBelow.name + " Enter!!!");
    }

    public void OnDrop(PointerEventData eventData)
    {
        //mergeControler.slot_2 = eventData.pointerDrag.GetComponent<UiItem>().item;
        //if (eventData.pointerDrag.gameObject.GetComponent<UiItem>().ItemType != ItemType)
        //{
        //    transform.localPosition = Vector2.zero;
        //    _canvasGroup.blocksRaycasts = true; 
        //}

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //mergeControler.mergeList.Add(eventData.pointerPressRaycast.gameObject);

    }
}
