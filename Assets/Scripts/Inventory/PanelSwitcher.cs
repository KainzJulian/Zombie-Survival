using System.Collections;
using System.Collections.Generic;
using EditorAttributes;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] GameObject panel1;
    [SerializeField] GameObject panel2;

    [Button("switch Panel test")]
    public void _switchPanel() => switchPanel();

    public void switchPanel()
    {
        if (panel1.activeSelf)
        {
            panel1.SetActive(false);
            panel2.SetActive(true);
        }
        else
        {
            panel1.SetActive(true);
            panel2.SetActive(false);
        }
    }
}
