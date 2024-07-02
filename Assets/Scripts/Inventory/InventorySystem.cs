using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            inventoryController.itemsOnGround.Clear();

            Collider2D[] items = Physics2D.OverlapCircleAll(pickupArea.transform.position, pickRange, itemLayers);

            foreach (Collider2D item in items)
            {
                inventoryController.itemsOnGround.Add(item.GetComponent<Item>());
            }

            switchInventoryUI();
        }
    }

    private void switchInventoryUI()
    {

        bool isActive = inventoryUI.activeSelf;

        if (!isActive)
            onOpenInventory?.Invoke();
        else
            onCloseInventory?.Invoke();

        inventoryUI.SetActive(!isActive);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pickupArea.transform.position, pickRange);
    }
}
