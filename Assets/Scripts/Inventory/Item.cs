using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Item : MonoBehaviour
{
    public ItemConfig item;
    public int amount = 1;
    private int id = 0;

    public int getID()
    {
        return id;
    }

    public void setID(int id)
    {
        this.id = id;
    }

    [SerializeField] UnityEvent onDataChange = new UnityEvent();

    private void Start()
    {
        if (id == 0)
            id = Guid.NewGuid().GetHashCode();
    }

    public void setItem(ItemConfig itemConfig)
    {
        item = itemConfig;
        onDataChange?.Invoke();
    }

    public ItemConfig getItem()
    {
        return item;
    }

    public void setAmount(int amount)
    {
        this.amount = amount;
        onDataChange?.Invoke();
    }

    public int getAmount()
    {
        return this.amount;
    }

    public void deleteItem()
    {
        setItem(null);
        setAmount(0);

        onDataChange?.Invoke();
    }
}
