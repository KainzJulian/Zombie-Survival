using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    public GameObject weaponObject;

    public Weapon currentWeapon;

    public LayerMask attackLayers;
    public Transform attackPoint;

    private void Awake()
    {
        currentWeapon = weaponObject.GetComponentInChildren<Weapon>();
    }

    private void OnDrawGizmos()
    {
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, 10);
    }

    public void reloadWeapon()
    {
        if (currentWeapon is RangeWeapon rangeWeapon)
            rangeWeapon.reload();
    }

    public void attack()
    {
        currentWeapon?.attack(attackPoint, attackLayers);
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
