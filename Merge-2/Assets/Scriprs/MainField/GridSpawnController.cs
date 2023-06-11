using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Progress;
//using static UnityEditor.Progress;

[RequireComponent(typeof( FlexibleGridLayout))]
public class GridSpawnController : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private ItemBoardControler boardControler;

    public int Amount; // = 18;
    //public int Column = 18;

    public event Action DisableGrid;

    private FlexibleGridLayout gridGroupe;
    private List<GameObject> slots = new List<GameObject>();
    //private List<Transform> transforms = new List<Transform>(); 
    public List<UiSlot> emptySlots;
    private void Awake()
    {

        CreateGrid();
    }

    private void SpawnItem()
    {
        GameObject item = Instantiate(itemPrefab, slots[0].transform);
    }

    private void CreateGrid()
    {
        gridGroupe = GetComponent<FlexibleGridLayout>();
        gridGroupe.enabled = true;
        Amount = gridGroupe.columns * gridGroupe.rows;
        //slots 

        for (int i = 0; i < gridGroupe.columns; i++)
        {
            for (int j = 0; j < gridGroupe.rows; j++)
            {
                GameObject slot = Instantiate(cellPrefab);
                slot.name = $"{cellPrefab.name}_{i}{j}";
                slot.transform.SetParent(this.transform, false);
                boardControler.boardSlots.Add(slot.GetComponent<UiSlot>());
            }

        }

        List<Transform> transforms = new List<Transform>();
        foreach (var item in slots)
        {
            transforms.Add(item.transform);
        }
    }

    public void OnGridDisable()
    {
        DisableGrid?.Invoke();
    }
}
