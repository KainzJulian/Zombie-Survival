using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MeleeWeaponData : WeaponData
{
    [Tooltip("Size of the Attack")]
    public int attackSize;

    public MeleeWeaponData(MeleeWeaponConfig config) : base(config)
    {
        attackSize = config.attackSize;
    }
}
