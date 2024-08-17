using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "WearableConfig", menuName = "Item/Wearable")]
public class WearableConfig : ItemConfig
{
    public int armor;
}
