using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    void Start()
    {
        //Destory(gameObject, 5f);
    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        Enemy enemy = hit.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage();
        }
        Destroy(gameObject);
    }
}
