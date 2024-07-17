using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NoiseSource : MonoBehaviour
{
    [SerializeField] LayerMask layer;

    public void generateNoise(int radius)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, layer);
        Debug.Log("Noise radius: " + radius);

        Vector3 vector3 = new Vector3(transform.position.x, transform.position.y + radius);
        Debug.DrawLine(transform.position, vector3);

        foreach (Collider2D item in hitColliders)
        {
            item.gameObject.GetComponent<Hearable>()?.heardNoise(transform);
        }
    }
}
