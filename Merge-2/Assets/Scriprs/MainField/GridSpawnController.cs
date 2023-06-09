using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof( GridLayoutGroup))]
public class GridSpawnController : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    //[SerializeField] private GameObject parentForPrefab;

    //RectTransform rectTransform;
    public int Amount; // = 18;
    //public int Column = 18;

    private void Awake()
    {
        //GridLayoutGroup gridGroupe = GetComponent<GridLayoutGroup>();
        //Amount = gridGroupe.constraintCount ;


        for (int i = 0; i < Amount ; i++)
        {
            //for (int j = 0; j < Column; j++)
            //{

            //}
            GameObject slot = Instantiate(cellPrefab);
            slot.name = $"{cellPrefab.name}_{i+1}";
            slot.transform.SetParent(this.transform, false);
        }

    }
}
