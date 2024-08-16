using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] List<Item> inventory;

    [SerializeField] InventoryController inventoryController;

    [SerializeField] GameObject inventoryUI;
    [SerializeField] GameObject pickupArea;

    [SerializeField] LayerMask itemLayers;

    [SerializeField] int pickRange;

    [SerializeField] UnityEvent onOpenInventory = new UnityEvent();
    [SerializeField] UnityEvent onCloseInventory = new UnityEvent();

    [SerializeField] List<GameObject> hotBar = new List<GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryController.itemsOnGround.Clear();

            Collider2D[] items = Physics2D.OverlapCircleAll(pickupArea.transform.position, pickRange, itemLayers);

            foreach (Collider2D item in items)
            {
                inventoryController.itemsOnGround.Add(item.gameObject);
            }

            switchInventoryUI();
        }
    }

    private void switchInventoryUI()
    {

        bool isActive = inventoryUI.activeSelf;

        if (!isActive)
        {
            switchHotbar(true);
            onOpenInventory?.Invoke();
        }
        else
        {
            switchHotbar(false);
            onCloseInventory?.Invoke();
        }
        inventoryUI.SetActive(!isActive);
    }

    public void switchHotbar(bool state)
    {
        foreach (GameObject item in hotBar)
        {
            item.GetComponent<Image>().raycastTarget = state;

            foreach (Image image in item.GetComponentsInChildren<Image>())
            {
                image.raycastTarget = state;
            }
        }
    }

    public void disableInput()
    {

    }

    public void enableInput()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pickupArea.transform.position, pickRange);
    }
}
