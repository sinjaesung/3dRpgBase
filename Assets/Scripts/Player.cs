using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterStats characterStats;
    public int CurrentHealth;
    public int MaxHealth;
    public PlayerLevel PlayerLevel { get; set; }
    private void Start()
    {
        PlayerLevel = GetComponent<PlayerLevel>();
        Debug.Log("Player init");
        this.CurrentHealth = this.MaxHealth;
        characterStats = new CharacterStats(10, 10, 10);
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("player takes " + amount + " damage");
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
            Die();
        UIEventHandler.HealthChanged(this.CurrentHealth, this.MaxHealth);
    }

    private void Die()
    {
        Debug.Log("Player dead. Reset health.");
        this.CurrentHealth = this.MaxHealth;
        UIEventHandler.HealthChanged(this.CurrentHealth, this.MaxHealth);
    }
}
