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
            help.GetComponent<GroundItemHandler>().setItem(item.item, item.amount);
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
