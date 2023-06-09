using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Chest : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private List<GameObject> items ;
    [SerializeField] private GameObject gridTransform;
    public GridSpawnController SpawnController;

    private void Awake()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        List<UiSlot> emptySlots = SpawnController.emptySlots;

        SpawnSingleItem();
    }

    private void SpawnSingleItem()
    {
        System.Random randomize = new System.Random();
        int number = randomize.Next(0, items.Count);

        Instantiate(items[number]);



    }
}
