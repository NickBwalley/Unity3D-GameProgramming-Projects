using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCamera : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex = 0;

    void Start()
    {
        StartCoroutine(SwitchCameras());
    }

    private IEnumerator SwitchCameras()
    {
        // Switch cameras uniformly for the first 10 seconds
        for (int i = 0; i < 10; i++)
        {
            SwitchCamera();
            yield return new WaitForSeconds(1f);
        }

        // Switch cameras every 5 seconds thereafter
        while (true)
        {
            yield return new WaitForSeconds(5f);
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        // Disable current camera
        cameras[currentCameraIndex].enabled = false;

        // Update current camera index
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

        // Enable new camera
        cameras[currentCameraIndex].enabled = true;
    }
}
