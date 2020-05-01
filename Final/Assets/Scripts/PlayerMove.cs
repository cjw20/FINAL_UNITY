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
    public GameObject Shockwave;
    public GameObject ArcanePierce;
    

    public int playerHealth = 10;
    public int maxHealth;
    public HealthBar HealthBar;
    public int mana = 100;
    public int maxMana;
    public HealthBar manaBar;
    public SoundManager SoundManager;

    void Start()
    {
        maxHealth = playerHealth;
        HealthBar.SetMaxHealth(maxHealth);
        maxMana = mana;
        manaBar.SetMaxMana(maxMana);
        InvokeRepeating("Regen", 0f, 1f);
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
                
                mana -= 10;
                manaBar.SetMana(mana);
                CastFire();
            }
            
        }
        if (Input.GetKeyDown("q"))
        {
            if (mana >= 50)
            {

                mana -= 50;
                manaBar.SetMana(mana);
                CastShock();
            }

        }
        if (Input.GetKeyDown("r"))
        {
            if (mana >= 20)
            {

                mana -= 20;
                manaBar.SetMana(mana);
                CastArcane();
            }

        }

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
       
    }
    void CastFire()
    {
        SoundManager.PlaySound("fire");
        GameObject firespell = Instantiate(fireball, spellOrigin.position, spellOrigin.rotation);
        Rigidbody2D rb = firespell.GetComponent<Rigidbody2D>();
        rb.AddForce(targetDir * spellForce, ForceMode2D.Impulse);
        
    }
    void CastArcane()
    {
        SoundManager.PlaySound("arcane");
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg -90f;
        GameObject arcanespell = Instantiate(ArcanePierce, spellOrigin.position, Quaternion.Euler(0,0,angle));
        Rigidbody2D rb = arcanespell.GetComponent<Rigidbody2D>();
        rb.AddForce(targetDir * spellForce, ForceMode2D.Impulse);

    }
    void CastShock()
    {
        SoundManager.PlaySound("zap");
        Instantiate(Shockwave, spellOrigin.position, spellOrigin.rotation);
       

    }
    void Regen()
    {
        if (mana < maxMana)
        {
            mana += 20;
            manaBar.SetMana(mana);
        }
    }


    public void TakeDamage(int damage)
    {
        SoundManager.PlaySound("hit");
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
        FindObjectOfType<GameManager>().EndGame();
    }
}
