using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeSpanController : MonoBehaviour
{
    [Tooltip("Time after the gameObject should be destroyed in Seconds")]
    [SerializeField] private float lifeTime;

    [SerializeField] UnityEvent onDestroy = new UnityEvent();
    [SerializeField] UnityEvent onStart = new UnityEvent();

    void Start()
    {
        onStart?.Invoke();
        Destroy(gameObject, lifeTime);
    }

    private void OnDestroy()
    {
        onDestroy?.Invoke();
    }

    public void setLifeTime(float time)
    {
        lifeTime = time;
    }
}
