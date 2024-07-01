using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public float attackSpeed;
    public WeaponType weaponType;

    public void initData(WeaponConfig config)
    {
        damage = config.damage;
        attackSpeed = config.attackSpeed;
        weaponType = config.weaponType;
    }

    public virtual void attack(Transform attackPoint, LayerMask layer) { }
}
