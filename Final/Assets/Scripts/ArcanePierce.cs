using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcanePierce : MonoBehaviour
{
    public int damage = 3;
    void Awake()
    {
        Destroy(gameObject, 5f);
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
