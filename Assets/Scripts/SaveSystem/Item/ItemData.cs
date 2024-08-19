using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemData
{
    [Tooltip("Sprite of the item which will be displayed in inventory or ground")]
    public Sprite sprite;

    [Tooltip("Name of the item")]
    public string name;

    [Tooltip("Description of the item for more detail")]
    public string description;

    [Tooltip("Type of Item")]
    public ItemType type;

    [Tooltip("Amount of the Item per Stack")]
    public int amount;

    [Tooltip("ID to determine whether two items are not the same")]
    public int id = 0;

    public ItemData(ItemConfig itemConfig)
    {
        sprite = itemConfig.sprite;
        name = itemConfig.name;
        description = itemConfig.description;
        type = itemConfig.type;
        amount = 1;
        id = Guid.NewGuid().GetHashCode();
    }
}
