using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch2 : MonoBehaviour
{
    public Camera camera3;
    public Camera camera4;
    // Start is called before the first frame update
    void Start()
    {
        camera3.enabled = true;
        camera4.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            camera3.enabled = !camera3.enabled;
            camera4.enabled = !camera4.enabled;
        }

    }
}
