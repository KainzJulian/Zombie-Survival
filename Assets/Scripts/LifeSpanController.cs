using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpanController : MonoBehaviour
{
    [Tooltip("Time after the gameObject should be destroyed in Seconds")]
    [SerializeField] private float lifeTime;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
