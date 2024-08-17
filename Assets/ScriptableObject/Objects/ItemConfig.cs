using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "ItemConfig", menuName = "Item/Item")]
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

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        ItemConfig other = (ItemConfig)obj;

        return name == other.name &&
               sprite == other.sprite &&
               description == other.description &&
               type == other.type;
    }

    public override int GetHashCode()
    {
        return (name, sprite, description, type).GetHashCode();
    }
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