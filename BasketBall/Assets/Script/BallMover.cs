using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    //We declare and initialize our variables before any other function
    //HERE
    public float sideForce = 5f;
    public float upForce = 5f;
    public Rigidbody rb;
    // Start is called before the first frame update
    //For one time functionalities, we use the start function
    //this is called at the beginning of the game (only once)
    void Start()
    {

    }

    // Update is called once per frame
    //For recursive functionalities we use the update() function
    //as long as the game is playing
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
            rb.AddForce(-sideForce, 0, 0);
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
