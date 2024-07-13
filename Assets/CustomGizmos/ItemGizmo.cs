using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemUIHandler))]
public class ItemGizmo : MonoBehaviour
{
    //TODO Refactor code everywhere 
    private void OnDrawGizmos()
    {
        ItemUIHandler itemUI = GetComponent<ItemUIHandler>();
        itemUI.updateImage();
        itemUI.updateInfoText();
        itemUI.updateNameText();
    }
}
