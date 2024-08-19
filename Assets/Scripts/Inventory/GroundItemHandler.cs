using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Item))]
public class GroundItemHandler : MonoBehaviour
{

    [SerializeField] Item item;

    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] Image icon;

    void Start()
    {
        item = GetComponent<Item>();

        if (item == null)
            return;

        description.SetText(item.data.description);
        itemName.SetText(item.data.name);
        icon.sprite = item.data.sprite;
    }
}
