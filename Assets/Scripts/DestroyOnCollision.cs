using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{

    [Tooltip("The Tags that Collide with the object")]
    [SerializeField] private List<string> targetTags = new List<string> { "Player", "NPC", "Enemy" };


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!targetTags.Contains(other.gameObject.tag))
            return;

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!targetTags.Contains(other.gameObject.tag))
            return;
        Destroy(gameObject);
    }
}
