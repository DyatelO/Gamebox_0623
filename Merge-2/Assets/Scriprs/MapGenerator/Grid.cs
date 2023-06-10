using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public struct Grid 
{
    private int[,] gridArray;
    //private TextMesh[,] textArray;
    private TextMeshProUGUI[,] textArray;
    private  float cellSize;
    //private  RectTransform parentTransform;
    private  Transform parentTransform;
    
    public Grid(int width, int height, float cellSize, Transform parentTransform) //, RectTransform parentTransform)
    {
        Width = width;
        Height = height;
        this.cellSize = cellSize;
        //this.parentTransform = parentTransform;
        this.parentTransform = parentTransform;

        gridArray = new int[width, height];
        //textArray = new TextMesh[width, height];
        textArray = new TextMeshProUGUI[width, height];



        for (int i = 0; i < gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < gridArray.GetLength(1); j++)
            {
                textArray[i,j] = CreaTextMeshObject(gridArray[i, j].ToString(), parentTransform,  GetWorldPosition(i, j) + new Vector2(cellSize, cellSize) * .5f, 10);
                Debug.DrawLine(GetWorldPosition(i,j), GetWorldPosition(i, j + 1), Color.white, 100);
                Debug.DrawLine(GetWorldPosition(i,j), GetWorldPosition(i + 1, j), Color.white, 100);
            }
        }

        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100);

        //SetValue(2, 1, 18);

    }

    private void GetXY(Vector2 worldPosition, out int x, out int y )
    {
        x = Mathf.FloorToInt(worldPosition.x / cellSize);
        y = Mathf.FloorToInt(worldPosition.y / cellSize);
    }
    public void SetValue(Vector2 worldPosition, int value)
    {
        int x; 
        int y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public void SetValue(int x, int y, int value)
    {
        if(x >= 0 && y >= 0 && x < Width && y < Height)
        {
            gridArray[x, y] = value;
            textArray[x, y].text = gridArray[x, y].ToString();
        }
    }
    private Vector2 GetWorldPosition(int x, int y) 
    {
        return new Vector2(x, y ) * cellSize;
    }
    private TextMeshProUGUI CreaTextMeshObject(string text, Transform parent = null, Vector2 localPosition = default(Vector2), int fontSize = 20)
    {
        GameObject textOnject = new GameObject("GridText", typeof(TextMeshProUGUI));
        Transform transform = textOnject.transform;
        transform.SetParent(parent, false);
        transform.transform.localPosition = localPosition;
        //textOnject.gameObject.AddComponent<MeshRenderer>();
        TextMeshProUGUI textMesh = textOnject.GetComponent<TextMeshProUGUI>();
        //textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.alignment = TextAlignmentOptions.Center;// TextAlignmentOptions.Center;

        //textMesh.alignment = alignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        //textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }


    //private TextMesh CreaTextMeshObject( string text, Transform parent = null, Vector2 localPosition = default(Vector2), int fontSize = 20)
    //{
    //    GameObject textOnject = new GameObject("GridText",typeof(TextMesh));
    //    Transform transform = textOnject.transform;
    //    transform.SetParent(parent, false);
    //    transform.transform.localPosition = localPosition;
    //    //textOnject.gameObject.AddComponent<MeshRenderer>();
    //    TextMesh textMesh = textOnject.GetComponent<TextMesh>();
    //    textMesh.anchor = TextAnchor.MiddleCenter;
    //    textMesh.alignment = TextAlignment.Center ;// TextAlignmentOptions.Center;

    //    //textMesh.alignment = alignment;
    //    textMesh.text = text;
    //    textMesh.fontSize = fontSize;
    //    //textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
    //    return textMesh;
    //}

    public int Width { get; }
    public int Height { get; }



}
