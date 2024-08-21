using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wearable : MonoBehaviour
{
    public WearableConfig config;
    public WearableData data;

    private void Start()
    {
        data = new WearableData(config);
        GetComponent<Item>()?.setItem(data, config);
    }

}
