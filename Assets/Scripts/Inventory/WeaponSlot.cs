using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class WeaponSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] GameObject itemPrefab;

    [SerializeField] List<ItemType> allowedItemTypes = new List<ItemType>();

    [SerializeField] InventoryController invController;

    public UnityEvent onAddItem = new UnityEvent();

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

        Weapon weapon = dropped.GetComponent<Weapon>();

        if (weapon != null)
        {
            if (weapon is RangeWeapon)
                itemPrefab.AddComponent<RangeWeapon>().setData();
            if (weapon is MeleeWeapon)
                itemPrefab.AddComponent<MeleeWeapon>().setData();
        }

        Instantiate(itemPrefab, transform);

        List<Item> itemsOnGround = invController.itemsOnGround;

        Destroy(dropped);

        if (itemsOnGround.Count == 0)
            return;

        Item help = itemsOnGround.Find((item) =>
        {
            return item.getID() == droppedItem.getID();
        });

        itemsOnGround.Remove(help);

        if (help != null && help.gameObject != null)
            Destroy(help.gameObject);

        onAddItem?.Invoke();
    }
}
