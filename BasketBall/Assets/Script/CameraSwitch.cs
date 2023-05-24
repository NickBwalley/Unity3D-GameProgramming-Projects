using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{

    public Camera[] cameras;
    private int currentCameraIndex;
    public KeyCode switchKey = KeyCode.Tab;

    // Start is called before the first frame update
    void Start()
    {
        // Enable the first camera and disable the rest
        currentCameraIndex = 0;
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == currentCameraIndex)
            {
                cameras[i].enabled = true;
            }
            else
            {
                cameras[i].enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Switch to the next camera on input
        if (Input.GetKeyDown(switchKey))
        {
            // Disable the current camera
            cameras[currentCameraIndex].enabled = false;

            // Increment the index and wrap around if necessary
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

            // Enable the new camera
            cameras[currentCameraIndex].enabled = true;
        }
    }
}
