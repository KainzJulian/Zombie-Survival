using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject itemPrefab;

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount != 0)
            return;

        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

        draggableItem.parentAfterDrag = transform;

        GameObject newPrefab = Instantiate(itemPrefab, transform);

        newPrefab.GetComponent<Item>().setItem(dropped.GetComponent<Item>().getItem());
        newPrefab.GetComponent<Item>().setAmount(dropped.GetComponent<Item>().getAmount());

        Destroy(dropped);
    }
}
