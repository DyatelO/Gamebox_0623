using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
//using static UnityEditor.Progress;

//[RequireComponent(typeof( GridLayoutGroup))]
public class GridSpawnController : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private GameObject itemPrefab;

    //[SerializeField] private GameObject parentForPrefab;

    //RectTransform rectTransform;
    public int Amount; // = 18;
    //public int Column = 18;

    public event Action DisableGrid;

    private GridLayoutGroup gridGroupe;
    private List<GameObject> slots = new List<GameObject>();
    //private List<Transform> transforms = new List<Transform>(); 

    private void Awake()
    {
        //GridLayoutGroup 

        CreateGrid();
    }

    private void Start()
    {
 
       //gridGroupe.enabled = false;     
    }

    private void SpawnItem()
    {
        GameObject item = Instantiate(itemPrefab, slots[0].transform);
    }

    private void CreateGrid()
    {
        gridGroupe = GetComponent<GridLayoutGroup>();
        gridGroupe.enabled = true;
        Amount = gridGroupe.constraintCount;
        //slots 

        for (int i = 0; i < Amount; i++)
        {
            for (int j = 0; j < Amount; j++)
            {
                GameObject slot = Instantiate(cellPrefab);
                slot.name = $"{cellPrefab.name}_{i}{j}";
                slot.transform.SetParent(this.transform, false);
                slots.Add(slot);
            }

        }

        List<Transform> transforms = new List<Transform>();
        foreach (var item in slots)
        {
            transforms.Add(item.transform);
        }
        //gridGroupe.enabled = false;

        //for (int i = 0; i < slots.Count; i++)
        //{
        //    slots[i].transform.position = transforms[i].position;
        //}
    }

    public void OnGridDisable()
    {
        DisableGrid?.Invoke();
    }
}
