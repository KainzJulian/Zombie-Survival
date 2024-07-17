using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    CharacterController2D characterController;
    Health healthComponent;
    Armor armorComponent;

    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI maxHealthText;

    [SerializeField] AttackPointController attackPointController;

    Vector2 movement;

    public static PlayerManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
        characterController.moveFixed(movement.x, movement.y, CharacterController2D.SpeedType.WALK);

        attackPointController.rotateAttackPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
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
