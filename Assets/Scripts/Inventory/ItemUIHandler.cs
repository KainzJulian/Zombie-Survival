using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIHandler : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] Image image;
    [SerializeField] Item item;

    private void Start()
    {
        updateImage();
        updateInfoText();
        updateNameText();
    }

    public void updateImage(Image image)
    {
        this.image = image;
    }

    public void updateInfoText(string infoText)
    {
        this.infoText.SetText(infoText);
    }

    public void updateNameText(string name)
    {
        this.nameText.SetText(name);
    }

    public void updateNameText()
    {
        if (!isNull(nameText))
            this.nameText.SetText(item.item.name);
    }

    public void updateImage()
    {
        if (!isNull(image))
            this.image.sprite = item.item.sprite;
    }

    public void updateInfoText()
    {
        if (!isNull(infoText))
            this.infoText.SetText(item.amount.ToString());
    }

    public bool isNull(Object obj)
    {
        return obj == null;
    }
}
