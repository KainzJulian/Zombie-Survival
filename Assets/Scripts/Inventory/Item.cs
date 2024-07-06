using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public ItemConfig item;
    public int amount = 0;

    [SerializeField] UnityEvent onDataChange = new UnityEvent();

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
