using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardGenerator : MonoBehaviour
{
    public int ColumnCount = 11;
    public int RowCount = 9;
    public bool IsFullRow { get { return _gridRowLayout.enabled; } set { _gridRowLayout.enabled = value; } }

    [Header("Cell in pixels")]
    public int Size = 90; 
    public int Spacing = 10;

    [SerializeField] private GameObject _slotProp;
    [SerializeField] private GameObject _gridColumnObject;
    [SerializeField] private GameObject _gridRowObject;

    private RectTransform _gridRowTransform;
    private GridLayoutGroup _gridRowLayout;

    //[SerializeField] private 

    private void Awake()
    {
        _gridRowTransform = _gridRowObject.GetComponent<RectTransform>();

        CreatePopSlotForRow("Prop");


        //CreateRow newRow = new CreateRow(ColumnCount, Size, Spacing);
        SetRowGroupeLayout(ColumnCount, Size, Spacing);



        CreateRow();
    }

    private void CreateRow()
    {
        List<RectTransform> tileList = new List<RectTransform>();
        GameObject tile;
        for (int i = 0; i < _gridRowLayout.constraintCount; i++)
        {
            tile = Instantiate(_slotProp);
            tile.name = $"{_slotProp.name}_{i}";
            tile.transform.SetParent(_gridRowTransform.transform, false);

            tileList.Add(tile.transform as RectTransform);
        }

        foreach (var item in tileList)
        {
            item.transform.position = new Vector2(item.transform.position.x, _gridRowTransform.transform.position.y);
            item.transform.SetParent(_gridColumnObject.transform);
        }
        _gridRowTransform.gameObject.SetActive(false);
        //CreateRow newRow = new CreateRow(tileList);
    }

    private void CreatePopSlotForRow(string name )
    {
        _slotProp = new GameObject(name);
        _slotProp.transform.localPosition = Vector3.zero;
        //_slotProp.transform.localRotation = Quaternion.identity;

        Image slotView = _slotProp.AddComponent<Image>();
        slotView.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    }

    private void SetRowGroupeLayout(int rouObjectCount, int cellSize, int spacing)
    {
        _gridRowLayout = _gridRowObject.AddComponent<GridLayoutGroup>();
        _gridRowLayout.childAlignment = TextAnchor.MiddleCenter;
        _gridRowLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _gridRowLayout.constraintCount = rouObjectCount;
        _gridRowLayout.cellSize = new Vector2(cellSize, cellSize) ;
        _gridRowLayout.spacing = new Vector2(spacing, spacing);
    }
}

public struct Row
{
    private List<GameObject> tileList;

    public Row(List<GameObject> tileList)
    {
        this.tileList = tileList;
    }

    public void GetRowWidth()
    {
        RectTransform rectTransform = tileList[0].GetComponent<RectTransform>();
        //rectTransform.
    }

   // public float GetRowSize
}