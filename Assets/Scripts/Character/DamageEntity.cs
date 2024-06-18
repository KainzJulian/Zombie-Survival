using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEntity : MonoBehaviour, Attackable
{

    public int damage = 0;

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                attack(other.gameObject.GetComponent<Damagable>(), damage);
                break;
            default: return;
        }
    }

    public void attack(Damagable damagable, int damageAmount = 0)
    {
        damagable.takeDamage(damageAmount);
    }
}
