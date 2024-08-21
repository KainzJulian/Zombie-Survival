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

    [Title("Wearables", 32)]
    public ItemData hat;
    public ItemData cheastwear;
    public ItemData pants;
    public ItemData boots;

    public void setHat(ItemData newItem)
    {
        Debug.Log("setHat " + newItem?.name);
        hat = newItem;
    }

    public void setChestwear(ItemData newItem)
    {
        Debug.Log("setCheastwear " + newItem.name);
        cheastwear = newItem;
    }

    public void setPants(ItemData newItem)
    {
        Debug.Log("setPants " + newItem.name);
        pants = newItem;
    }

    public void setBoots(ItemData newItem)
    {
        Debug.Log("setBoots " + newItem.name);
        boots = newItem;
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
