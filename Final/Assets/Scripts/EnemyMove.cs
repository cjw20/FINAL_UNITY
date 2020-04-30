using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 2f;
    
    public int health = 10;
    public int damage = 3;


    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }



    void OnTriggerEnter2D(Collider2D hitInfo)
    {


        PlayerMove player = hitInfo.GetComponent<PlayerMove>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }

        House house = hitInfo.GetComponent<House>();
        if (house != null)
        {
            house.TakeDamage(damage);
        }
    }
    public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
