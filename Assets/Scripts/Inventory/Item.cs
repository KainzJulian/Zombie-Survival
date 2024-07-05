using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemConfig item;
    public int amount = 0;

    public void setItem(ItemConfig itemConfig)
    {
        item = itemConfig;
    }

    public ItemConfig getItem()
    {
        return item;
    }

    public void setAmount(int amount)
    {
        this.amount = amount;
    }

    public int getAmount()
    {
        return this.amount;
    }

    public void deleteItem()
    {
        setItem(null);
        setAmount(0);
    }
}
