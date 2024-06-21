using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageEntity : MonoBehaviour
{

    public int damage = 0;

    private Damagable damagable;

    [Tooltip("The Tags that the Target can have")]
    [SerializeField] private List<string> targetTags = new List<string> { "Player", "NPC", "Enemy" };

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!targetTags.Contains(other.gameObject.tag))
            return;

        damagable = other.gameObject.GetComponent<Damagable>();

        if (damagable == null)
            return;

        damagable.takeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!targetTags.Contains(other.gameObject.tag))
            return;

        damagable = other.gameObject.GetComponent<Damagable>();

        if (damagable == null)
            return;

        damagable.takeDamage(damage);
    }
}
