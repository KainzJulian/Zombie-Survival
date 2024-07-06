using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIHandler : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] Image image;
    [SerializeField] Item item;

    public void updateImage(Image image)
    {
        this.image = image;
    }

    public void updateInfoText(string infoText)
    {
        this.infoText.SetText(infoText);
    }

    public void updateImage()
    {
        this.image.sprite = item.item.sprite;
    }

    public void updateInfoText()
    {
        this.infoText.SetText(item.amount.ToString());
    }
}
