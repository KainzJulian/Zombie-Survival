using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    [SerializeField] GameObject inventory;

    [SerializeField] GameObject groundItemPrefab;
    [SerializeField] GameObject groundPanel;

    public List<Item> itemsOnGround;

    public List<GameObject> inventorySlots;

    public List<GameObject> armorSlots = new List<GameObject>();

    public List<GameObject> weaponSlots = new List<GameObject>();
    private int currentEquippedWeapon = 0;

    [SerializeField] int curWeaponIndex = 0;

    [Button("Print Weapons")]
    public void _pWeapon() => printWeaponInfo(curWeaponIndex);

    [SerializeField] MeleeWeapon baseWeapon;

    [SerializeField] WeaponController weaponController;

    [Button("getArmor")]
    public void _getArmor() => getArmor();

    private void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0f)
        {
            currentEquippedWeapon++;

            if (currentEquippedWeapon > weaponSlots.Count - 1)
                currentEquippedWeapon = 0;

            weaponController.currentWeapon = getCurrentWeapon();

        }
        else if (scrollInput < 0f)
        {
            currentEquippedWeapon--;

            if (currentEquippedWeapon < 0)
                currentEquippedWeapon = weaponSlots.Count - 1;

            weaponController.currentWeapon = getCurrentWeapon();
        }
    }

    private Weapon getCurrentWeapon()
    {
        Weapon help = weaponSlots[currentEquippedWeapon].GetComponentInChildren<Weapon>();

        if (help == null)
            return baseWeapon;

        return help;
    }

    public void printWeaponInfo(int currentEquippedWeapon)
    {
        Debug.Log("current Weapon: " + weaponSlots[currentEquippedWeapon].GetComponentInChildren<Weapon>().name);
    }

    public int getArmor()
    {
        int help = 0;

        Wearable wearable;

        foreach (GameObject slot in armorSlots)
        {
            wearable = slot.GetComponentInChildren<Wearable>();

            if (wearable != null)
                help += wearable.data.armor;
        }

        Debug.Log("Current Armor amount: " + help);

        return help;
    }

    public void drawItemsOnGround()
    {
        foreach (Item groundItem in itemsOnGround)
        {
            groundItemPrefab.GetComponent<Item>().setItem(groundItem.data, groundItem.config);
            groundItemPrefab.GetComponent<Item>().setAmount(groundItem.getAmount());
            groundItemPrefab.GetComponent<Item>().setID(groundItem.getID());

            Instantiate(groundItemPrefab, groundPanel.transform);
        }
    }

    public void deleteItemsGroundPanel()
    {
        foreach (Transform child in groundPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
