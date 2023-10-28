using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //This script is actually for the camera
    
    //sorry for bad naming lol
    
    
    public float sensitivityX = 2.0f;
    public float sensitivityY = 2.0f;

    public Transform playerCamera; 

    private float rotationX = 0;

   
     float xRotation;
float yRotation;
    private void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
       
        if (playerCamera == null)
        {
            Debug.LogError("Player Camera is not assigned. Please assign it in the Unity Inspector.");
        }

    }

    private void Update()
    {
       
      
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityY;
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        playerCamera.rotation = Quaternion.Euler(0, yRotation, 0);
     
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
