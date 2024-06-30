using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{

    [SerializeField] GameObject inventoryUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            switchInventoryUI();


    }

    private void switchInventoryUI()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
}
