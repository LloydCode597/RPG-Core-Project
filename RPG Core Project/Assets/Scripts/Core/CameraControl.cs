using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;  // Add this at the top of your script

public class CameraControl : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // Reference to your virtual camera
    public float rotationSpeed = 10f;  // How fast the camera rotates
    public Transform playerTransform;  // Reference to the player's transform

    private bool isRotating = false;

    void Update()
    {
        // Detect right mouse button press
        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            isRotating = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        if (isRotating)
        {
            RotateCamera();
        }
    }

    void RotateCamera()
    {
        // Get mouse movement
        float mouseX = Input.GetAxis("Mouse X");

        // Rotate around the player by adjusting the camera's position
        virtualCamera.transform.RotateAround(playerTransform.position, Vector3.up, mouseX * rotationSpeed * Time.deltaTime);
    }
}
