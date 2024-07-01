using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] List<Item> inventory;

    [SerializeField] GameObject inventoryUI;
    [SerializeField] GameObject pickupArea;

    [SerializeField] LayerMask itemLayers;

    [SerializeField] int pickRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            switchInventoryUI();
            Collider2D[] items = Physics2D.OverlapCircleAll(pickupArea.transform.position, pickRange, itemLayers);

            foreach (Collider2D item in items)
            {
                item.GetComponent<Pickable>().pick();
            }
        }


    }

    private void switchInventoryUI()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pickupArea.transform.position, pickRange);
    }
}
