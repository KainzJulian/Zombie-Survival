using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeWeapon", menuName = "Weapon/Melee")]
public class MeleeWeaponConfig : WeaponConfig
{
    [Tooltip("Attack radius")]
    public int attackSize;
}
