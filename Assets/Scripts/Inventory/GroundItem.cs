using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : Item
{
    private bool _isInInventory;
    public bool isInInventory
    {
        get
        {
            return _isInInventory;
        }
        set
        {
            _isInInventory = value;
            if (value)
                Destroy(gameObject);
        }
    }
}
