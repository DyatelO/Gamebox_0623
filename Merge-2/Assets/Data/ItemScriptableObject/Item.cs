using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu (menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    [Header("Gameplay")]
    public string Title;
    public ItemType Type;

    public bool Stackable;

    public Sprite ImageSprite;
}

public enum ItemType
{
    Axe,
    Shield,
    Sword,
    LowHeal,
    MidHeal,
    FireBall
}
