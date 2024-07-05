using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Item))]
public class GroundItemHandler : MonoBehaviour
{

    [SerializeField] Item item;
    [SerializeField] int amount;

    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] Image icon;

    // Start is called before the first frame update
    void Start()
    {

        item = GetComponent<Item>();

        if (item == null)
            return;

        description.SetText(item.item.description);
        itemName.SetText(item.item.name);
        icon.sprite = item.item.sprite;
    }

    public void setItem(ItemConfig config, int amount)
    {
        item.setItem(config);
        item.setAmount(amount);
    }
}
