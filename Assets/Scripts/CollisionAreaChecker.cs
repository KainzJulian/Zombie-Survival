using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionAreaChecker : MonoBehaviour
{

    public UnityEvent onAreaEnter = new UnityEvent();
    public UnityEvent onAreaExit = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D other)
    {
        onAreaEnter?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        onAreaExit?.Invoke();
    }
}
