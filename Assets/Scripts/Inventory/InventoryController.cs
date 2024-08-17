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
        GameObject gameObject;

        foreach (Item groundItem in itemsOnGround)
        {
            gameObject = Instantiate(groundItemPrefab, groundPanel.transform);

            gameObject.AddComponent<Item>();
            gameObject.GetComponent<Item>().setAmount(groundItem.amount);
            gameObject.GetComponent<Item>().setItem(groundItem.item);
            // groundItem.SetActive(false);
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
