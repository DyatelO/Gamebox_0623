using Board.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseFolower : MonoBehaviour, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private Camera uiCamera;

    [SerializeField] private UiBoardItem boardItem;
    [Header("DEMO")]
    [SerializeField] Sprite imageTMP;


    private RectTransform _rectTransform;

    private void Awake()
    {
        canvas = transform.GetComponentInParent<Canvas>();
        uiCamera = Camera.main;
        boardItem = GetComponentInChildren<UiBoardItem>();

        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            Input.mousePosition,
            canvas.worldCamera,
            out position);

        _rectTransform.anchoredPosition = position / canvas.scaleFactor;
        //transform.position = canvas.transform.TransformPoint(position) / canvas.scaleFactor;
    }

    public void Toggle(bool value)
    {
        Debug.Log($"Item toggled {value}");
        gameObject.SetActive(value);
    }

    public void SetData(Sprite sprite)
    {

        boardItem.SetData(sprite);
        imageTMP = sprite;
        Debug.Log(sprite.name);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
