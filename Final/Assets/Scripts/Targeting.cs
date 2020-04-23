using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{

    private Vector2 mousePosition;
    private float moveSpeed = 10f;
    public GameObject Crosshair;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        mousePosition = Input.mousePosition;
        if(Crosshair.transform =!mousePosition)
        {
            Crosshair.transform = mousePosition;
        }    
        
    }
}
