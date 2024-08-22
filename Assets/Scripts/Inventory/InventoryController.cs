using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    [SerializeField] GameObject inventory;

    [SerializeField] GameObject groundItemPrefab;
    [SerializeField] GameObject groundPanel;

    public List<Item> itemsOnGround;

    public List<GameObject> inventorySlots;

    public List<GameObject> armorSlots = new List<GameObject>();

    [Button("getArmor")]
    public void _getArmor() => getArmor();

    public int getArmor()
    {
        int help = 0;

        Wearable wearable;

        foreach (GameObject slot in armorSlots)
        {
            wearable = slot.GetComponentInChildren<Wearable>();

            if (wearable != null)
                help += wearable.data.armor;
        }

        Debug.Log("Current Armor amount: " + help);

        return help;
    }

    public void drawItemsOnGround()
    {
        foreach (Item groundItem in itemsOnGround)
        {
            groundItemPrefab.GetComponent<Item>().setItem(groundItem.data, groundItem.config);
            groundItemPrefab.GetComponent<Item>().setAmount(groundItem.getAmount());
            groundItemPrefab.GetComponent<Item>().setID(groundItem.getID());

            Instantiate(groundItemPrefab, groundPanel.transform);
        }
    }

    public void deleteItemsGroundPanel()
    {
        foreach (Transform child in groundPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
