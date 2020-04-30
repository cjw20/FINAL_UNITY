using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 4f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mPos;
    public Animator animator;  
    public Camera camera;
    Vector2 targetDir;
    public Transform spellOrigin;
    public GameObject fireball;
    public float spellForce = 15f;
    float fireballCasts = 0f;

    public int playerHealth = 10;
    public int maxHealth;
    public HealthBar HealthBar;
    public int mana = 100;
    public int maxMana;
    public HealthBar manaBar;

    void Start()
    {
        maxHealth = playerHealth;
        HealthBar.SetMaxHealth(maxHealth);
        maxMana = mana;
        manaBar.SetMaxMana(maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        mPos = camera.ScreenToWorldPoint(Input.mousePosition);
        targetDir = mPos - rb.position;
        targetDir.Normalize();
        if (Input.GetKeyDown("e"))
        {
            if(mana >= 10)
            {
                fireballCasts++;
                mana -= 10;
                manaBar.SetMana(mana);
                CastFire();
            }
            
        }

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    void CastFire()
    {
        GameObject firespell = Instantiate(fireball, spellOrigin.position, spellOrigin.rotation);
        Rigidbody2D rb = firespell.GetComponent<Rigidbody2D>();
        rb.AddForce(targetDir * spellForce, ForceMode2D.Impulse);
        
    }


    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        HealthBar.SetHealth(playerHealth);
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
