using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject itemPrefab;

    [SerializeField] List<ItemType> allowedItemTypes = new List<ItemType>();

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;

        ItemType type = dropped.GetComponent<Item>().item.type;

        if (transform.childCount != 0 || !allowedItemTypes.Contains(type))
            return;

        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

        draggableItem.parentAfterDrag = transform;

        GameObject newPrefab = Instantiate(itemPrefab, transform);

        newPrefab.GetComponent<Item>().setItem(dropped.GetComponent<Item>().getItem());
        newPrefab.GetComponent<Item>().setAmount(dropped.GetComponent<Item>().getAmount());

        Destroy(dropped);
    }
}
