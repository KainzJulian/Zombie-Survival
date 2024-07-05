using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    [SerializeField] GameObject inventory;

    [SerializeField] GameObject groundItemPrefab;
    [SerializeField] GameObject groundPanel;

    public List<Item> itemsOnGround;

    public List<GameObject> inventorySlots;

    public void drawItemsOnGround()
    {
        GameObject help;

        foreach (Item item in itemsOnGround)
        {
            help = Instantiate(groundItemPrefab, groundPanel.transform);
            help.AddComponent<Item>();
            help.GetComponent<Item>().amount = item.amount;
            help.GetComponent<Item>().item = item.item;
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
