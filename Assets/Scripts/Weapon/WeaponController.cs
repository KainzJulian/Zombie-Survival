using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        if (weaponConfig != null)
            weapon = setWeapon(weaponConfig);

        primaryWeapon = setWeapon(primaryWeaponConfig);
        secondaryWeapon = setWeapon(secondaryWeaponConfig);
    }

    public Weapon setWeapon(WeaponConfig config)
    {
        weaponConfig = config;

        if (config.weaponType == WeaponType.Range)
            return new RangeWeapon(config as RangeWeaponConfig);

        if (config.weaponType == WeaponType.Melee)
            return new MeleeWeapon(config as MeleeWeaponConfig);

        return null;

        // if(config.weaponType == WeaponType.Throwable)
        //     currentWeapon = new RangeWeapon(config as RangeWeaponConfig);

    }

    public void switchWeapon(Weapon weapon, WeaponConfig weaponConfig)
    {
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
