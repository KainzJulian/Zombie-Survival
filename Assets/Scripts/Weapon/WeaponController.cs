using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    public WeaponConfig weaponConfig;
    private Weapon weapon;

    [SerializeField] RangeWeaponUIHandler rangeWeaponUI;

    // public MeleeWeaponConfig primaryWeaponConfig;
    // [SerializeField] MeleeWeapon primaryWeapon;

    // public RangeWeaponConfig secondaryWeaponConfig;
    // [SerializeField] RangeWeapon secondaryWeapon;

    [SerializeField] LayerMask attackLayers;
    [SerializeField] Transform attackPoint;

    [SerializeField] UnityEvent onEquipRange = new UnityEvent();
    [SerializeField] UnityEvent onEquipMelee = new UnityEvent();
    [SerializeField] UnityEvent onAttack = new UnityEvent();

    private void Start()
    {
        if (weaponConfig != null)
            weapon = setWeapon(weaponConfig);

        // primaryWeapon.initData(primaryWeaponConfig);
        // secondaryWeapon.initData(secondaryWeaponConfig);
    }

    public Weapon setWeapon(WeaponConfig config)
    {
        weaponConfig = config;

        if (config.weaponType == WeaponType.Range)
        {
            onEquipRange?.Invoke();
            return GetComponent<RangeWeapon>();
        }

        if (config.weaponType == WeaponType.Melee)
        {
            onEquipMelee?.Invoke();
            return GetComponent<MeleeWeapon>();
        }

        return null;
    }

    // public void switchWeapon(Weapon weapon, WeaponConfig weaponConfig)
    // {
    //     if (weapon.weaponType == WeaponType.Range)
    //     {
    //         onEquipRange?.Invoke();

    //         rangeWeaponUI.setCurrentAmmoText(GetComponent<RangeWeapon>().currentAmmoAmount);
    //         rangeWeaponUI.setMaxAmmoText(GetComponent<RangeWeapon>().magazinSize);
    //     }

    //     if (weapon.weaponType == WeaponType.Melee)
    //         onEquipMelee?.Invoke();

    //     this.weapon = weapon;
    //     this.weaponConfig = weaponConfig;
    // }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Alpha1))
        // {
        //     switchWeapon(primaryWeapon, primaryWeaponConfig);
        // }

        // if (Input.GetKeyDown(KeyCode.Alpha2))
        // {
        //     switchWeapon(secondaryWeapon, secondaryWeaponConfig);
        // }

        if (Input.GetKeyDown(KeyCode.R) && weapon is RangeWeapon rangeWeapon)
        {
            rangeWeapon.reload();
            rangeWeaponUI.setCurrentAmmoText(rangeWeapon.currentAmmoAmount);
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            weapon?.attack(attackPoint, attackLayers);
            onAttack?.Invoke();

            if (weapon is RangeWeapon range)
                rangeWeaponUI.setCurrentAmmoText(range.currentAmmoAmount);
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, 10);
    }
}
