using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public ItemData data;
    public ItemConfig config;

    public int getID()
    {
        return data.id;
    }

    public void setID(int id)
    {
        data.id = id;
    }

    [SerializeField] UnityEvent onDataChange = new UnityEvent();

    private void Awake()
    {
        if (config != null && data == null)
            data = new ItemData(config);
    }

    public void setItem(ItemData data, ItemConfig config)
    {
        this.data = data;
        this.config = config;
        onDataChange?.Invoke();
    }

    public ItemConfig getItem()
    {
        return config;
    }

    public void setAmount(int amount)
    {
        data.amount = amount;
        onDataChange?.Invoke();
    }

    public int getAmount()
    {
        return data.amount;
    }

    public void deleteItem()
    {
        setItem(null, null);
        setAmount(0);

        onDataChange?.Invoke();
    }
}
