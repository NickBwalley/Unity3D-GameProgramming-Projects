using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // we create a variable to represent the object that we are going to follow. 
    public GameObject player;

    //We declare an offset that we wish to maintain while following the player 
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;

    }
}
