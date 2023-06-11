using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickController : MonoBehaviour //, IDropHandler
{
    public List<GameObject > clickedObjects;

    public void CompareClickedObjects()
    {
        if (clickedObjects[0].GetComponent<Merge2test>().itemType != clickedObjects[1].GetComponent<Merge2test>().itemType)
        {
            //clickedObjects[1].transform.position
            Debug.Log("BORODA! NeSOVPADAUT");
        }
    }
}
