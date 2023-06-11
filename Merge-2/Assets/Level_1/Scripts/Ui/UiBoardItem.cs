using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiBoardItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler, IDropHandler
{
    [SerializeField] private Image itemImage;
    [SerializeField] private Image borderImage;

    //private CanvasGroup _canvasGroup;

    public event Action<UiBoardItem> OnBoardItemClicked;
    public event Action<UiBoardItem> OnBoardItemDroppedOn;
    public event Action<UiBoardItem> OnBoardItemBeginDrag;
    public event Action<UiBoardItem> OnBoardItemEndDrag;
    public event Action<UiBoardItem> OnBoardItemDrag;

    private bool isEmpty = true;


    private void Awake()
    {
        ResetData();
        Deselect();
    }

    public void Deselect()
    {
        borderImage.enabled = false;
    }

    public void ResetData()
    {
        this.itemImage.gameObject.SetActive(false);
        isEmpty = false;
    }

    public void SetData(Sprite sprite) //, int quantity)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        //this.quantity.text = quantity + ;
        isEmpty = false;
    }

    public void Select()
    {
        borderImage.enabled = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isEmpty)
            return;
        OnBoardItemBeginDrag?.Invoke(this);

    }

    public void OnDrop(PointerEventData eventData)
    {
        OnBoardItemDroppedOn?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnBoardItemEndDrag?.Invoke(this);

        //_canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnBoardItemDrag?.Invoke(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnBoardItemClicked?.Invoke(this);   
    }
}
