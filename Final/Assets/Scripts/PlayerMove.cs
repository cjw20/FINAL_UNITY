using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 4f;
    public Rigidbody2D rb;
    Vector2 movement;
   // Vector2 mPos;
    public Animator animator;
  
   // public Camera camera;
    //public Vector2 targetDir;
   

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

       // mPos = camera.ScreenToWorldPoint(Input.mousePosition);
       // Vector2 targetDir = mPos - rb.position;


    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    
}
