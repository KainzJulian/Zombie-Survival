using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEntity : MonoBehaviour
{

    public int damage = 0;


    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                takeDamage(other.gameObject.GetComponent<Damagable>());
                break;
            default: return;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ONTriggerEnter");
    }

    public void takeDamage(Damagable damagable)
    {
        damagable.takeDamage(damage);
    }
}
