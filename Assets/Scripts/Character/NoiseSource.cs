using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseSource : MonoBehaviour
{

    [SerializeField] LayerMask layer;

    public void generateNoise(int radius)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, layer);

        foreach (Collider2D item in hitColliders)
        {
            item.gameObject.GetComponent<Hearable>().heardNoise(transform);
        }
    }
}
