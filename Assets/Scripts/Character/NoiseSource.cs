using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NoiseSource : MonoBehaviour
{
    [SerializeField] LayerMask layer;

    private int noiseRadius = 0;

    public void generateNoise(int radius)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, layer);
        Debug.Log("Noise radius: " + radius);

        noiseRadius = radius;

        foreach (Collider2D item in hitColliders)
        {
            item.gameObject.GetComponent<Hearable>()?.heardNoise(transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, noiseRadius);
    }
}
