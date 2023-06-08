using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrid : MonoBehaviour
{
    private readonly float _slotSideSize = 90f;

    //private BoardItemSlot 
    private RectTransform _rectTransform;
    private Vector2 _positionOnGrid = new Vector2();
    private Vector2Int _tileGridPosition = new Vector2Int();

    public void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public Vector2Int GetTileGridPosition(Vector2 cursorPosition)
    {
        _positionOnGrid.x = cursorPosition.x - _rectTransform.position.x; 
        _positionOnGrid.y = -cursorPosition.y + _rectTransform.position.y;

        _tileGridPosition.x = (int)(_positionOnGrid.x / _slotSideSize);
        _tileGridPosition.y = (int)(_positionOnGrid.y / _slotSideSize);

        return _tileGridPosition;
    }
}
