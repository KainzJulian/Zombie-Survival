using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(NoiseSource))]
public abstract class Weapon : MonoBehaviour
{
    //TODO Add Throwable (Grenades, Knifes, bottle, items which are throwable)

    [HideInInspector]
    public NoiseSource noiseSource;

    protected void Start()
    {
        noiseSource = GetComponent<NoiseSource>();
    }

    public abstract void attack(Transform attackPoint, LayerMask layer);
}
