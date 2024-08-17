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
    public Item hat;
    public Item cheastwear;
    public Item pants;
    public Item boots;

    public void setHat(Item newItem)
    {
        Debug.Log("setHat " + newItem.name);
        hat = newItem;
    }

    public void setCheastwear(Item newItem)
    {
        Debug.Log("setCheastwear " + newItem.name);
        cheastwear = newItem;
    }

    public void setPants(Item newItem)
    {
        Debug.Log("setPants " + newItem.name);
        pants = newItem;
    }

    public void setBoots(Item newItem)
    {
        Debug.Log("setBoots " + newItem.name);
        boots = newItem;
    }

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
