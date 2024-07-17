using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    public WeaponConfig weaponConfig;
    public Weapon weapon;

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
        setWeapon(weaponConfig);
    }

    public void setWeapon(WeaponConfig config)
    {
        if (config is RangeWeaponConfig rangeWeaponConfig)
        {
            onEquipRange?.Invoke();

            GetComponent<RangeWeapon>().initData(rangeWeaponConfig);
            weapon = GetComponent<RangeWeapon>();
        }

        if (config is MeleeWeaponConfig meleeWeaponConfig)
        {
            onEquipMelee?.Invoke();

            GetComponent<MeleeWeapon>().initData(meleeWeaponConfig);
            weapon = GetComponent<MeleeWeapon>();
        }
    }

    private void Update()
    {
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
