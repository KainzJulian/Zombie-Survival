using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageEntity : MonoBehaviour
{

    public int damage = 0;

    private Damagable damagable;

    private void OnCollisionEnter2D(Collision2D other)
    {
        damagable = other.gameObject.GetComponent<Damagable>();

        if (damagable == null)
            return;

        damagable.takeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        damagable = other.gameObject.GetComponent<Damagable>();

        if (damagable == null)
            return;

        damagable.takeDamage(damage);
    }
}
