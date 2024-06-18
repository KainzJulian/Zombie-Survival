using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Attackable
{
    void attack(Damagable damagable, int damageAmount);
}
