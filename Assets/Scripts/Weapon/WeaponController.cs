using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    public WeaponConfig weaponConfig;
    // public Weapon weapon;

    public GameObject weaponObject;

    public Weapon currentWeapon;

    [SerializeField] RangeWeaponUIHandler rangeWeaponUI;

    // public MeleeWeaponConfig primaryWeaponConfig;
    // [SerializeField] MeleeWeapon primaryWeapon;

    // public RangeWeaponConfig secondaryWeaponConfig;
    // [SerializeField] RangeWeapon secondaryWeapon;

    [SerializeField] LayerMask attackLayers;
    [SerializeField] Transform attackPoint;

    private void Start()
    {
        currentWeapon = weaponObject.GetComponentInChildren<Weapon>();

        getWeaponAsRange()?.onAmmoChange.AddListener(rangeWeaponUI.setCurrentAmmoText);

        // setWeapon(weaponConfig);
    }

    // public void setWeapon(WeaponConfig config)
    // {
    //     if (config is RangeWeaponConfig rangeWeaponConfig)
    //     {
    //         onEquipRange?.Invoke();

    //         // GetComponent<RangeWeapon>().initData(rangeWeaponConfig);
    //         weapon = GetComponent<RangeWeapon>();
    //     }

    //     if (config is MeleeWeaponConfig meleeWeaponConfig)
    //     {
    //         onEquipMelee?.Invoke();

    //         // GetComponent<MeleeWeapon>().initData(meleeWeaponConfig);
    //         weapon = GetComponent<MeleeWeapon>();
    //     }
    // }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentWeapon is RangeWeapon rangeWeapon)
        {
            rangeWeapon.reload();
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            currentWeapon?.attack(attackPoint, attackLayers);
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, 10);
    }

    public MeleeWeapon getWeaponAsMelee()
    {
        if (currentWeapon is MeleeWeapon meleeWeapon)
            return meleeWeapon;
        return null;
    }

    public RangeWeapon getWeaponAsRange()
    {
        if (currentWeapon is RangeWeapon rangeWeapon)
            return rangeWeapon;
        return null;
    }
}
