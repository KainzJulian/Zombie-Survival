using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointManager : MonoBehaviour
{
    Vector3 mousePosition;

    [Tooltip("Wether the camera should be closer to the player(0) or the mouse(1)")]
    [SerializeField, Range(0f, 1f)]
    float positionScale;

    private void FixedUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.localPosition = (mousePosition - transform.position) * positionScale;
    }
}
