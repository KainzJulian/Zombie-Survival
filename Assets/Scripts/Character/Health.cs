using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, Damagable
{
    public int health = 100;

    public int maxHealth = 100;
    public int armorAmount = 0;

    public UnityEvent<int> onHealthDecrease = new UnityEvent<int>();
    public UnityEvent<int> onHealthIncrease = new UnityEvent<int>();
    public UnityEvent<int> onHealthChange = new UnityEvent<int>();
    public UnityEvent onDie = new UnityEvent();

    public void takeDamage(int amount)
    {
        int help = amount - armorAmount;

        if (help < 0)
            help = 1;

        health -= help;

        onHealthChange?.Invoke(amount);
        onHealthDecrease?.Invoke(amount);

        if (health <= 0)
            die();
    }

    public void heal(int amount)
    {
        int help = amount + health;

        if (help > maxHealth)
            help = maxHealth;

        health = help;

        onHealthChange?.Invoke(amount);
        onHealthIncrease?.Invoke(amount);
    }

    public void setHealth(int amount)
    {
        onHealthChange?.Invoke(amount);
        health = amount;
    }

    public void die()
    {
        gameObject.SetActive(false);
        onDie?.Invoke();
        Destroy(gameObject);
    }
}
