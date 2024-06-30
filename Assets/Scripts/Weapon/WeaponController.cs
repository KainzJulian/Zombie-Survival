using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    public WeaponConfig weaponConfig;
    private Weapon weapon;

    public WeaponConfig primaryWeaponConfig;
    private Weapon primaryWeapon;

    public WeaponConfig secondaryWeaponConfig;
    private Weapon secondaryWeapon;

    [SerializeField] LayerMask attackLayers;
    [SerializeField] Transform attackPoint;

    [SerializeField] TextMeshProUGUI maxAmmoText;
    [SerializeField] TextMeshProUGUI currentAmmoText;
    [SerializeField] GameObject rangeUI;

    [SerializeField] UnityEvent onEquipRange = new UnityEvent();
    [SerializeField] UnityEvent onEquipMelee = new UnityEvent();

    private void Start()
    {
        if (weaponConfig != null)
            weapon = setWeapon(weaponConfig);

        primaryWeapon = setWeapon(primaryWeaponConfig);
        secondaryWeapon = setWeapon(secondaryWeaponConfig);


    }

    private void switchUIState(bool state)
    {
        rangeUI.SetActive(state);
    }

    private void updateRangeUI()
    {
        // OK Julian von morgen viel glück beim machen ich schreib das auf damit ich es nicht vergesse
        // Wenn du das machen willst musst du das umändern damit je nach waffe RangeWeapon oder MeleeWeapon 
        // als script zum spieler hinzugefügt wird bzw. schon hinzufügen und dann aktivieren / deaktivieren
        // good luck
        //  das ist glaub ich das beste
    }

    public Weapon setWeapon(WeaponConfig config)
    {
        weaponConfig = config;

        if (config.weaponType == WeaponType.Range)
        {
            onEquipRange?.Invoke();
            return new RangeWeapon(config as RangeWeaponConfig);
        }

        if (config.weaponType == WeaponType.Melee)
        {
            onEquipMelee?.Invoke();
            return new MeleeWeapon(config as MeleeWeaponConfig);
        }

        return null;

        // if(config.weaponType == WeaponType.Throwable)
        //     currentWeapon = new RangeWeapon(config as RangeWeaponConfig);
    }

    public void switchWeapon(Weapon weapon, WeaponConfig weaponConfig)
    {
        if (weapon.weaponType == WeaponType.Range)
            onEquipRange?.Invoke();

        if (weapon.weaponType == WeaponType.Melee)
            onEquipMelee?.Invoke();

        this.weapon = weapon;
        this.weaponConfig = weaponConfig;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            switchWeapon(primaryWeapon, primaryWeaponConfig);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            switchWeapon(secondaryWeapon, secondaryWeaponConfig);
        }

        if (Input.GetMouseButtonDown(0))
        {
            weaponConfig?.attack(attackPoint, attackLayers);
            weapon?.attack();
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, 10);
    }
}
