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


    void Start()
    {
        
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

        if (Input.GetKeyDown("e"))
        {
            fireballCasts++;
            CastFire();
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

}
