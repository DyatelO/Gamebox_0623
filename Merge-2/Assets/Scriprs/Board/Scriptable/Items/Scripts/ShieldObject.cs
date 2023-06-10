using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Defense as Object", menuName = "Board System/Items/Defense")]
public class ShieldObject : ItemObject
{
    public int defenseValue;
    private ItemType itemType = ItemType.Defense;
    public override ItemType ItemType { get => itemType; set => itemType = value; }
}
