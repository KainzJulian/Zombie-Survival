using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponType weaponType;
    public Vector2 attackPoint;
    public float duration;
    public int damage;
    public float attackSpeed;

    public void initData(WeaponConfig config)
    {
        weaponType = config.weaponType;
        attackPoint = config.attackPoint;
        duration = config.duration;
        damage = config.damage;
        attackSpeed = config.attackSpeed;
    }

    public virtual void attack(Transform attackPoint, LayerMask layer) { }
}
