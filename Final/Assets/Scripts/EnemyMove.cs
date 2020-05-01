using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    GameObject chosenTarget;
    Transform target;
    public GameObject self;
    public float moveSpeed = 2f;
    public Rigidbody2D rb;
    public int health = 10;
    public int damage = 3;
    Vector2 difference; //angle for knockback
    public float knockbackPow = 5f;
    bool knockedBack = false;
    public float knockTime = .5f;
    

    
    
    void Start()
    {
        
        chosenTarget = GameObject.Find("House");    
        target = chosenTarget.transform;
    }
    
    void FixedUpdate()
    {
        if(target != null)
        {
            if (knockedBack == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            }

            if (knockedBack == true)
            {
                knockTime -= Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, difference, knockbackPow * Time.deltaTime);
                if (knockTime <= 0)
                {
                    knockedBack = false;
                    knockTime = .5f;
                }
            }
        }
        if(target == null)
        {
            chosenTarget = GameObject.Find("Player");
            if(chosenTarget == null)
            {
                chosenTarget = self; //stay still after killing player
            }
            target = chosenTarget.transform;
            
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
           
            

        }

        House house = hitInfo.GetComponent<House>();
        if (house != null)
        {
            house.TakeDamage(damage);
            knockedBack = true;
            difference.x = target.position.x - rb.position.x;
            difference.y = target.position.y - rb.position.y;
            difference.Normalize();
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
