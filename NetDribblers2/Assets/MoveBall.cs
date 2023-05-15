using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    // At the beginning we declare and initialize our variables before any other functionalities.
    public float sideForce = 5f;
    public float upForce = 5f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            rb.AddForce(0, 0, sideForce);

        }
        if (Input.GetKey("right"))
        {
            rb.AddForce(sideForce, 0, 0);
        }
        if (Input.GetKey("left"))
        {
            rb.AddForce(-sideForce, 0, 0); // so that it moves to the opposite direction.
        }
        if (Input.GetKey("down"))
        {
            rb.AddForce(0, 0, -sideForce);
        }
        if (Input.GetKey("space"))
        {
            rb.AddForce(0, upForce, 0);
        }

    }
}
