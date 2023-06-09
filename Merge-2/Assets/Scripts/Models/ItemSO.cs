using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Board.Model
{
    [CreateAssetMenu]
    public class ItemSO : ScriptableObject
    {
        [field: SerializeField] public string Name { get; set; }
        [field: SerializeField] public bool IsStackable { get; set; }
        [field: SerializeField] public Sprite ItemIcon { get; set; }
        public ItemType ItemType;

        public int ID => GetInstanceID();

    }

    public enum ItemType
    {
        Axe,
        Knife,
        Shield,
        FireSpell,
        Restore
    }

    [CreateAssetMenu(fileName ="Obstacle", menuName ="ItemsSO/Obstacle")]
    public class ItemObstacleSO : ItemSO
    {
        public bool IsObstacle;
    }
}

