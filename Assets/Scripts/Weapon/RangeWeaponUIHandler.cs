using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RangeWeaponUIHandler : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI maxAmmoText;
    [SerializeField] TextMeshProUGUI currentAmmoText;
    [SerializeField] GameObject rangeUI;

    public void switchUI(bool state)
    {
        rangeUI.SetActive(state);
    }

    public void setMaxAmmoText(int magazinSize)
    {
        maxAmmoText.SetText(magazinSize.ToString());
    }

    public void setCurrentAmmoText(int currentAmmoAmount)
    {
        currentAmmoText.SetText(currentAmmoAmount.ToString());
    }
}
