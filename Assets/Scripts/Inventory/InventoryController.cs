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

    public List<GameObject> inventorySlots = new List<GameObject>();
    public List<GameObject> armorSlots = new List<GameObject>();
    public List<GameObject> weaponSlots = new List<GameObject>();
    public List<GameObject> hotBar = new List<GameObject>();

    private int currentEquippedWeapon = 0;

    [SerializeField] MeleeWeapon baseWeapon;

    [SerializeField] WeaponController weaponController;

    [Button("Print Weapons")]
    public void _pWeapon() => printWeaponInfo(curWeaponIndex);
    [SerializeField] int curWeaponIndex = 0;

    public List<Weapon> weapons = new List<Weapon>();

    [Button("getArmor")]
    public void _getArmor() => getArmor();

    private void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0f)
        {
            currentEquippedWeapon++;

            if (currentEquippedWeapon > weapons.Count - 1)
                currentEquippedWeapon = 0;

            weaponController.setCurrentWeapon(getCurrentWeapon());
            Debug.Log(weaponController.currentWeapon.name);
        }
        else if (scrollInput < 0f)
        {
            currentEquippedWeapon--;

            if (currentEquippedWeapon < 0)
                currentEquippedWeapon = weapons.Count - 1;

            weaponController.setCurrentWeapon(getCurrentWeapon());
            Debug.Log(weaponController.currentWeapon.name);
        }
    }

    private Weapon getCurrentWeapon()
    {
        Weapon help = weapons[currentEquippedWeapon];

        if (help == null)
            return baseWeapon;

        return help;
    }

    public void saveWeaponSlots()
    {
        Weapon weapon;

        foreach (GameObject gameObject in weaponSlots)
        {
            weapon = gameObject.GetComponentInChildren<Weapon>();
            if (weapon == null)
                weapons.Add(baseWeapon);
            else
                weapons.Add(weapon);
        }
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
            itemsOnGround.Clear();
            Destroy(child.gameObject);
        }
    }
}
