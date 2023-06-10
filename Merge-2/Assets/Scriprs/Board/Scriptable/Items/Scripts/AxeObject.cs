using UnityEngine;

[CreateAssetMenu(fileName ="New Attack as Object", menuName = "Board System/Items/Axe")]
public class AxeObject : ItemObject
{
    public int attackValue;
    private ItemType itemType = ItemType.Attack;
    public override ItemType ItemType { get => itemType; set => itemType = value; }
}
