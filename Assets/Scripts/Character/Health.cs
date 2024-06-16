using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, Damagable
{
    public int health = 100;
    [SerializeField]
    private int maxHealth = 100;

    public UnityEvent<int> onHealthDecrease = new UnityEvent<int>();
    public UnityEvent<int> onHealthIncrease = new UnityEvent<int>();
    public UnityEvent<int> onHealthChange = new UnityEvent<int>();

    public void takeDamage(int amount)
    {
        int help = amount - GetComponent<Armor>().armor;

        if (help < 0)
            help = 1;

        health -= help;

        onHealthChange?.Invoke(amount);
        onHealthDecrease?.Invoke(amount);
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
}
