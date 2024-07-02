using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerManager : MonoBehaviour
{
    CharacterController2D characterController;
    Health healthComponent;
    Armor armorComponent;

    // public WeaponConfig primaryWeapon;
    // public WeaponConfig secondaryWeapon;

    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI maxHealthText;

    Vector2 movement;

    void Start()
    {
        characterController = GetComponent<CharacterController2D>();

        armorComponent = GetComponent<Armor>();
        healthComponent = GetComponent<Health>();
        setHealthText();
        setMaxHealthText();
    }

    private void FixedUpdate()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        characterController.moveFixed(movement.x, movement.y);
    }

    public void setHealthText(int amount = -1)
    {
        if (amount == -1)
            amount = healthComponent.health;

        healthText.SetText(amount.ToString());
    }

    public void setMaxHealthText(int amount = -1)
    {
        if (amount == -1)
            amount = healthComponent.health;

        maxHealthText.SetText(amount.ToString());
    }
}
