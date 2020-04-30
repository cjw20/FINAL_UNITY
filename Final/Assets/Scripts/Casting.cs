using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
    public Transform spellOrigin;
    public GameObject fireball;
    public float spellForce = 15f;
    float fireballCasts = 0f;

    public Camera camera;
    public GameObject player;
    Vector2 mPos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mPos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetDir = mPos - player.position;

        if (Input.GetKeyDown("e"))
        {
            fireballCasts++;
            CastFire();
        }
    }
    void CastFire()
    {
        GameObject firespell = Instantiate(fireball, spellOrigin.position, spellOrigin.rotation);
        Rigidbody2D rb = firespell.GetComponent<Rigidbody2D>();
        rb.AddForce(targetDir * spellForce, ForceMode2D.Impulse);
    }
}
