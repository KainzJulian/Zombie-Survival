using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ItemSlotHandler : MonoBehaviour
{

    [SerializeField] ItemConfig itemConfig;
    [SerializeField] ItemConfig test;

    public Image icon;
    public TextMeshProUGUI info;

    public GameObject itemContainer;


    // Start is called before the first frame update
    void Start()
    {
        if (itemConfig == null)
            changeItemContainerState(false);
        else
        {
            changeItemContainerState(true);
            updateIcon();
            updateInfo();
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            setItemConfig(test);
    }

    public void changeItemContainerState(bool state)
    {
        itemContainer.SetActive(state);
    }

    public void setItemConfig(ItemConfig item)
    {
        itemConfig = item;

        changeItemContainerState(true);

        updateIcon();
        updateInfo();
    }

    public void updateIcon()
    {
        icon.sprite = itemConfig.sprite;
    }

    public void updateInfo()
    {
        info.SetText(itemConfig.name);
    }

    private void OnDrawGizmos()
    {
        if (itemConfig == null)
            return;

        updateIcon();
        updateInfo();
    }
}
