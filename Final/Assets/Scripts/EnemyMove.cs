using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 2f;
    public Rigidbody2D rb;
    public int health = 10;
    public int damage = 3;
    Vector2 difference; //angle for knockback
    public float knockbackPow = 50f;
    bool knockedBack = false;
    public float knockTime = .5f;

    void FixedUpdate()
    {
        if(knockedBack == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
            
        if(knockedBack == true)
        {
            knockTime -= Time.deltaTime;
            if(knockTime <= 0)
            {
                knockedBack = false;
                knockTime = .5f;
            }
        }
        
    }



    void OnTriggerEnter2D(Collider2D hitInfo)
    {


        PlayerMove player = hitInfo.GetComponent<PlayerMove>();
        if (player != null)
        {
            player.TakeDamage(damage);
            knockedBack = true;
            difference.x = target.position.x - rb.position.x;
            difference.y = target.position.y - rb.position.y;
            difference.Normalize();
            rb.AddForce(difference * knockbackPow);
            

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
