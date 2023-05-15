using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // At the beginning we declare and initialize our variables before any other functionalities.
    public float sideForce = 5f;
    public float upForce = 10f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start() // For onetime functionalities, we use the start function. This is called at the beginning of the game (only once)
    {
        
    }

    // Update is called once per frame
    void Update() //For things that we want to do it repeatedly then we can use the update function. For recursive functionalities we use the update() function as long as the game is playing. 
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
