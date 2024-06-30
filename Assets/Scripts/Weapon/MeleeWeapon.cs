using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    public int attackSize;

    public MeleeWeapon(MeleeWeaponConfig config) : base(config)
    {
        attackSize = config.attackSize;
    }

    public override void attack()
    {
        Debug.Log("melee Weapon attack");
        // throw new System.NotImplementedException();
    }
}
