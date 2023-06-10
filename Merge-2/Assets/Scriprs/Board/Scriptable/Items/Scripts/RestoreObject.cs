using UnityEngine;

[CreateAssetMenu(fileName = "New Restore as Object", menuName = "Board System/Items/Restore")]
public class RestoreObject : ItemObject
{
    public int restorekValue;
    private ItemType itemType = ItemType.Restore;
    public override ItemType ItemType { get => itemType; set => itemType = value; }
}
