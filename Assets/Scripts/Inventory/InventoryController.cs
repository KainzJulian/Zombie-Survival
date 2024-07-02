using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    [SerializeField] GameObject inventory;

    [SerializeField] GameObject groundItemPrefab;
    [SerializeField] GameObject ground;

    public List<Item> itemsOnGround;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void drawItemsOnGround()
    {
        foreach (Item item in itemsOnGround)
        {

        }
    }
}
