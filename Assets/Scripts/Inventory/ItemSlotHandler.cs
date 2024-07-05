using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ItemSlotHandler : MonoBehaviour
{

    [SerializeField] Item item;

    public Image icon;
    public TextMeshProUGUI info;

    public GameObject itemContainer;


    // Start is called before the first frame update
    void Start()
    {
        if (item.item == null)
            changeItemContainerState(false);
        else
        {
            changeItemContainerState(true);
            updateIcon();
            updateInfo();
        }
    }

    public void changeItemContainerState(bool state)
    {
        itemContainer.SetActive(state);
    }

    public void setItem(ItemConfig item, int amount)
    {
        this.item.setItem(item);
        this.item.setAmount(amount);

        changeItemContainerState(true);

        updateIcon();
        updateInfo();
    }

    public void updateIcon()
    {
        icon.sprite = item.item.sprite;
    }

    public void updateInfo()
    {
        info.SetText(item.amount.ToString());
    }

    private void OnDrawGizmos()
    {
        if (item.item == null)
            return;

        updateIcon();
        updateInfo();
    }
}
