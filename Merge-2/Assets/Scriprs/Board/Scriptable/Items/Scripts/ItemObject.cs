using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Default,
    Attack,
    Defense,
    MagicAttack,
    Restore
    
    
}
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public abstract ItemType ItemType { get; set; }
    [TextArea(15, 25)]
    public string description;
}
