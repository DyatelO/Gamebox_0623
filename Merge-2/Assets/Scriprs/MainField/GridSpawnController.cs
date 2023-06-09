using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
//using static UnityEditor.Progress;

[RequireComponent(typeof( GridLayoutGroup))]
public class GridSpawnController : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private GameObject itemPrefab;

    //[SerializeField] private GameObject parentForPrefab;

    //RectTransform rectTransform;
    public int Amount; // = 18;
    //public int Column = 18;


    private GridLayoutGroup gridGroupe;
    public List<GameObject> slots = new List<GameObject>();


    private void Awake()
    {
        //GridLayoutGroup 
            gridGroupe = GetComponent<GridLayoutGroup>();
        Amount = gridGroupe.constraintCount ;
        //slots 

        for (int i = 0; i < Amount ; i++)
        {
            for (int j = 0; j < gridGroupe.constraintCount; j++)
            {
                GameObject slot = Instantiate(cellPrefab);
                slot.name = $"{cellPrefab.name}_{i}{j}";
                slot.transform.SetParent(this.transform, false);

                slots.Add(slot);
            }

        }
        //var parent = FindObjectOfType<UiSlot>().transform;
        itemPrefab.SetActive(true);
        GameObject item = Instantiate(itemPrefab);
        Debug.Log(item.transform);
        //item.SetActive(true);

        //var parent = slots[0].transform.parent;
        //itemPrefab.transform.SetParent(parent);

        //GridLayoutGroup gridGroupe = GetComponent<GridLayoutGroup>();
        ///gridGroupe.enabled = false;
    }

    private void Start()
    {
        //gridGroupe = GetComponent<GridLayoutGroup>();
        //gridGroupe.enabled = false;

        //UIItem item = GetComponentInChildren<>
    }
}
