using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfig", menuName = "Item")]
public class ItemConfig : ScriptableObject
{
    [Tooltip("Sprite of the item which will be displayed in inventory or ground")]
    public Sprite sprite;

    [Tooltip("Name of the item")]
    public new string name;

    [Tooltip("Description of the item for more detail")]
    public string description;

    [Tooltip("Type of Item")]
    public ItemType type;
}

[Serializable]
public enum ItemType
{
    SIDEARM,
    LONGARM,
    MELEE,
    THROWABLE,
    HEALING,
    CONSUMABLE,
    CRAFTABLE,
    ITEM,
    HAT,
    CHESTWEAR,
    PANTS,
    BOOT,
    BAG
}