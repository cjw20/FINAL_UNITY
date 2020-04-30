using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public int houseHealth = 20;
    public void TakeDamage(int damage)
    {
        houseHealth -= damage;
        if (houseHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
