using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int damage = 5;
    void Awake()
    {
        Destroy(gameObject, 5f);
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
            
        
        EnemyMove enemy = hitInfo.GetComponent<EnemyMove>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        
        
    }
}
