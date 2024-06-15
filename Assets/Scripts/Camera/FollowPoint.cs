using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoint : MonoBehaviour
{

    [SerializeField]
    Transform point;

    private void FixedUpdate()
    {
        transform.position = point.transform.position + new Vector3(0, 0, -135);
    }
}
