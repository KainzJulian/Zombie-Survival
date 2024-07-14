using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAreaHandler : MonoBehaviour
{

    [SerializeField] LayerMask layer;
    [SerializeField] Enemy enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isInLayerMask(other.gameObject))
        {
            enemy.goToHuman();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (isInLayerMask(other.gameObject))
        {
            enemy.goAFK();
        }
    }

    private bool isInLayerMask(GameObject obj)
    {
        return (layer.value & (1 << obj.layer)) != 0;
    }
}
