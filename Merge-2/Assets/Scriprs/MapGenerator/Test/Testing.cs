using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    //public RectTransform parentGridTransform;
    public Transform parentGridTransform;

    private void Awake()
    {
        Grid grid = new Grid(4, 2, 10, parentGridTransform);  // , parentGridTransform);
    }
}
