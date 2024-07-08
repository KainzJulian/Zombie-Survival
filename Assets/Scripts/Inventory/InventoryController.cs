using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    [SerializeField] GameObject inventory;

    [SerializeField] GameObject groundItemPrefab;
    [SerializeField] GameObject groundPanel;

    public List<GameObject> itemsOnGround;

    public List<GameObject> inventorySlots;

    public void drawItemsOnGround()
    {
        GameObject help;

        foreach (GameObject groundItem in itemsOnGround)
        {
            Item itemComponent = groundItem.GetComponent<Item>();

            help = Instantiate(groundItemPrefab, groundPanel.transform);

            help.AddComponent<Item>();
            help.GetComponent<Item>().setAmount(itemComponent.amount);
            help.GetComponent<Item>().setItem(itemComponent.item);
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
