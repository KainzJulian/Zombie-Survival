using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WearableData : ItemData
{
    [Tooltip("The armor the wearable gives to the character")]
    public int armor;

    [Tooltip("Health of the wearable item in percent")]
    public int health;

    public WearableData(WearableConfig config) : base(config)
    {
        armor = config.armor;
        health = 100;
    }
}
