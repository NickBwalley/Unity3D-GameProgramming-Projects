using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public Camera camera4;


    // Start is called before the first frame update
    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
        camera3.enabled = false;
        camera4.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s"))
        {
            camera1.enabled = !camera1.enabled;
            camera2.enabled = !camera2.enabled;
        }
        if (Input.GetKey("w"))
        {
            camera3.enabled = !camera3.enabled;
            camera4.enabled = !camera4.enabled;
        }

    }
}
