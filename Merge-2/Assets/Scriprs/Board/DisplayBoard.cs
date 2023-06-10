using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBoard : MonoBehaviour
{
    public GameObject boardPrefab;
    public BoardObject board;

    public int XStartPosition;
    public int YStartPosition;
    public int XOffset;
    public int YOffset;
    public int MaxColumn;

    private Dictionary<GameObject, BoardSlot> itemsIcons = new Dictionary<GameObject, BoardSlot>();

    private void Awake()
    {
        CreateSlots();
    }

    private void CreateSlots()
    {
        itemsIcons = new Dictionary<GameObject, BoardSlot>();

        for (int i = 0; i < board.container.Items.Length; i++)
        {
            GameObject tempObject = Instantiate(boardPrefab, Vector2.zero, Quaternion.identity, transform);
            tempObject.GetComponent<RectTransform>().localPosition = GetPosition(i);

            itemsIcons.Add(tempObject, board.container.Items[i]); 
        }
    }

    public Vector2 GetPosition(int i)
    {
        return new Vector2(XStartPosition + (XOffset * (i % MaxColumn)), YStartPosition + (- YOffset * (i / MaxColumn)));
    }
}
