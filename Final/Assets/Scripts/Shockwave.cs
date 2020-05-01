using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    public int damage = 10;
    void Awake()
    {
        Destroy(gameObject, 1f);
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {


        EnemyMove enemy = hitInfo.GetComponent<EnemyMove>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            
        }


    }
}
