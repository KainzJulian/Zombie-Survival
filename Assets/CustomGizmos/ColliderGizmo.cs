using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ColliderGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Collider2D collider = GetComponent<Collider2D>();

        if (collider is CircleCollider2D circleCollider2D)
            Gizmos.DrawWireSphere(circleCollider2D.bounds.center, circleCollider2D.radius);
        if (collider is BoxCollider2D boxCollider2D)
            Gizmos.DrawWireCube(boxCollider2D.bounds.center, boxCollider2D.size);
    }
}
