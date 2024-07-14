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
            enemy.goToHuman(other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (isInLayerMask(other.gameObject))
        {
            enemy.goAFK();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isInLayerMask(other.gameObject))
        {
            enemy.goToHuman(other.transform);
        }
    }

    private bool isInLayerMask(GameObject obj)
    {
        return (layer.value & (1 << obj.layer)) != 0;
    }
}
