using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{

    private SceneController sceneController;

    public UnityEvent onOpenPause = new UnityEvent();
    public UnityEvent onClosePause = new UnityEvent();

    private bool isSneaking = false;
    private bool isSprinting = false;

    private void Start()
    {
        sceneController = SceneController.instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            openMap();

        if (Input.GetKeyDown(KeyCode.E))
            openInventory();

        if (Input.GetKeyDown(KeyCode.F))
            loot();

        if (Input.GetKeyDown(KeyCode.Escape))
            openPause();

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            sneak();

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
            sprint();

        if (Input.GetKeyDown(KeyCode.R))
            reload();

        if (Input.GetKeyDown(KeyCode.Alpha1))
            weapon1();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            weapon2();

        if (Input.GetKeyDown(KeyCode.Alpha3))
            weapon3();
    }

    private void loot()
    {
        Debug.Log("loot");
    }

    private void openInventory()
    {
        Debug.Log("open Inventory");
    }

    private void weapon3()
    {
        Debug.Log("equip weapon3");
    }

    private void weapon2()
    {
        Debug.Log("equip weapon2");
    }

    private void weapon1()
    {
        Debug.Log("equip weapon1");
    }

    private void openMap()
    {
        Debug.Log("open Map");
    }

    private void openPause()
    {
        Debug.Log("open pause");
        if (sceneController.isSceneLoaded("Option"))
        {
            onClosePause?.Invoke();
            sceneController.unloadScene("Option");
        }
        else
        {
            onOpenPause?.Invoke();
            sceneController.loadSceneAdditive("Option");
        }
    }

    private void reload()
    {
        Debug.Log("reload");
    }

    private void sprint()
    {
        Debug.Log("sprint");

    }

    private void sneak()
    {
        Debug.Log("sneak");
    }
}
