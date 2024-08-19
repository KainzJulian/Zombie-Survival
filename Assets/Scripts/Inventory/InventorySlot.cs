using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject itemPrefab;

    [SerializeField] List<ItemType> allowedItemTypes = new List<ItemType>();

    [SerializeField] InventoryController invController;

    public UnityEvent<Item> onItemInput = new UnityEvent<Item>();

    private void Start()
    {
        if (invController == null)
            invController = GetComponentInParent<InventoryController>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        Item droppedItem = dropped.GetComponent<Item>();

        ItemType type = dropped.GetComponent<Item>().config.type;

        if (transform.childCount != 0 || !allowedItemTypes.Contains(type))
            return;

        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

        draggableItem.parentAfterDrag = transform;

        itemPrefab.GetComponent<Item>().setItem(droppedItem.data, droppedItem.config);

        GameObject newPrefab = Instantiate(itemPrefab, transform);


        // hier muss ich vom inventory System die entsprechenden Ground items löschen
        Debug.Log("Removed: " + dropped.name);
        Debug.Log("Should delete: " + droppedItem.name);
        Item help = invController.itemsOnGround.Find((item) =>
        {
            return item.getID() == droppedItem.getID();
        });

        invController.itemsOnGround.Remove(help);

        onItemInput?.Invoke(droppedItem);

        if (help != null && help.gameObject != null)
            Destroy(help.gameObject);

        Destroy(dropped);
    }
}
