using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public int houseHealth = 20;
    public int maxHealth;
    public HealthBar HealthBar;
    public SoundManager SoundManager;

    void Start()
    {
        maxHealth = houseHealth;
        HealthBar.SetMaxHouse(maxHealth);
    }
    public void TakeDamage(int damage)
    {
        SoundManager.PlaySound("hit");
        houseHealth -= damage;
        HealthBar.SetHealth(houseHealth);
        if (houseHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        //FindObjectOfType<GameManager>().EndGame();
    }
}
