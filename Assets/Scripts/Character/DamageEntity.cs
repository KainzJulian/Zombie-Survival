using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEntity : MonoBehaviour, Attackable
{

    public int damage = 0;

    private Damagable damagable;

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                damagable = other.gameObject.GetComponent<Damagable>();
                break;
            default: return;
        }
    }

    public void attack()
    {
        damagable.takeDamage(damage);
    }
}
