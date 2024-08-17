using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject itemPrefab;

    [SerializeField] List<ItemType> allowedItemTypes = new List<ItemType>();

    [SerializeField] InventoryController invController;

    private void Start()
    {
        invController = GetComponentInParent<InventoryController>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        Item droppedItem = dropped.GetComponent<Item>();

        ItemType type = dropped.GetComponent<Item>().item.type;

        if (transform.childCount != 0 || !allowedItemTypes.Contains(type))
            return;

        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

        draggableItem.parentAfterDrag = transform;

        GameObject newPrefab = Instantiate(itemPrefab, transform);

        newPrefab.GetComponent<Item>().setItem(dropped.GetComponent<Item>().getItem());
        newPrefab.GetComponent<Item>().setAmount(dropped.GetComponent<Item>().getAmount());

        // hier muss ich vom inventory System die entsprechenden Ground items löschen
        Debug.Log("Removed: " + dropped.name);
        Debug.Log("Should delete: " + droppedItem.name);
        Item help = invController.itemsOnGround.Find((item) =>
        {
            return item.amount == droppedItem.amount && item.item == droppedItem.item;
        });

        Debug.Log("deleted: " + help.item.name);

        Destroy(help.gameObject);

        Destroy(dropped);
    }
}
