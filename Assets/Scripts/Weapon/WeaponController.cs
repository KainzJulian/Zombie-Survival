using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponConfig currentWeaponConfig;
    public Weapon currentWeapon;

    private void Start()
    {
        currentWeapon = new Weapon(currentWeaponConfig);
    }

    // private void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         // currentWeaponConfig.attack(attackPoint, attackLayers);
    //     }
    // }
}
