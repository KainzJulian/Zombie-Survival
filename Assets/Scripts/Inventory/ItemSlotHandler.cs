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
        if (item.config == null)
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

    public void setItem(ItemData data, ItemConfig config, int amount)
    {
        item.setItem(data, config);
        item.setAmount(amount);

        changeItemContainerState(true);

        updateIcon();
        updateInfo();
    }

    public void updateIcon()
    {
        icon.sprite = item.config.sprite;
    }

    public void updateInfo()
    {
        info.SetText(item.getAmount().ToString());
    }

    private void OnDrawGizmos()
    {
        if (item.config == null)
            return;

        updateIcon();
        updateInfo();
    }
}
