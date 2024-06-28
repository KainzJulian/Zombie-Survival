using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    WeaponConfig currentWeaponConfig;
    Weapon currentWeapon;

    private void Start()
    {
        currentWeapon = new Weapon(currentWeaponConfig);
    }


}
