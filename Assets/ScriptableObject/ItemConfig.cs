using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfig", menuName = "Item")]
public class ItemConfig : ScriptableObject
{
    public Sprite sprite;
    public string name;
}
