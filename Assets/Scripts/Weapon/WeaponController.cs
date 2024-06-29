using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponConfig currentWeaponConfig;
    public Weapon currentWeapon;

    [SerializeField] LayerMask attackLayers;
    [SerializeField] Transform attackPoint;

    private void Start()
    {
        setWeapon(currentWeaponConfig);
    }

    public void setWeapon(WeaponConfig config)
    {
        currentWeapon = new Weapon(config);
        currentWeaponConfig = config;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentWeaponConfig.attack(attackPoint, attackLayers, currentWeapon);
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint != null)
            Gizmos.DrawWireSphere(attackPoint.position, 10);
    }
}
