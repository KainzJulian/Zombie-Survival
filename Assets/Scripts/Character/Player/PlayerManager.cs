using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerManager : MonoBehaviour
{

    CharacterController characterController;
    Health healthComponent;
    Armor armorComponent;
    Attackable attackComponent;

    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI maxHealthText;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        attackComponent = GetComponent<Attackable>();

        armorComponent = GetComponent<Armor>();
        healthComponent = GetComponent<Health>();
        setHealthText();
        setMaxHealthText();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("attack melee");
            attackComponent.attack(null, 10);
        }
    }

    private void FixedUpdate()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        characterController.move(movement.x, movement.y);
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
