using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GroundItemHandler : MonoBehaviour
{

    [SerializeField] ItemConfig config;
    [SerializeField] int amount;

    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] Image icon;

    // Start is called before the first frame update
    void Start()
    {
        if (config == null)
            return;

        description.SetText(config.description);
        itemName.SetText(config.name);
        icon.sprite = config.sprite;
    }

    public void setItem(ItemConfig config, int amount)
    {
        this.config = config;
        this.amount = amount;
    }
}
