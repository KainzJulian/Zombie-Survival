using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    public WeaponConfig weaponConfig;
    private Weapon weapon;

    public MeleeWeaponConfig primaryWeaponConfig;
    [SerializeField] MeleeWeapon primaryWeapon;

    public RangeWeaponConfig secondaryWeaponConfig;
    [SerializeField] RangeWeapon secondaryWeapon;

    [SerializeField] LayerMask attackLayers;
    [SerializeField] Transform attackPoint;

    [SerializeField] UnityEvent onEquipRange = new UnityEvent();
    [SerializeField] UnityEvent onEquipMelee = new UnityEvent();
    [SerializeField] UnityEvent onAttack = new UnityEvent();

    private float helpAttackTime = 1;

    private void Start()
    {
        if (weaponConfig != null)
            weapon = setWeapon(weaponConfig);

        primaryWeapon.initData(primaryWeaponConfig);
        secondaryWeapon.initData(secondaryWeaponConfig);
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

        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && helpAttackTime <= 0)
        {
            weapon?.attack(attackPoint, attackLayers);
            onAttack?.Invoke();
            helpAttackTime = 1;
        }

        if (helpAttackTime > 0 && weapon != null)
            helpAttackTime -= Time.deltaTime * weapon.attackSpeed;
    }

    private void OnDrawGizmos()
    {
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, 10);
    }
}
