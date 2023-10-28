using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyMovement : MonoBehaviour
{
    private Vector3 moveDirection;
    public float moveSpeed;
    private Rigidbody rb;
    public Transform orientation;
    private float horizontalInput;
    private float verticalInput;
    public float maxSlopeAngle;
    private RaycastHit slope;
    private Animator playerAnimator;
    public string footstepEventPath = "event:/Johns Footsteps";
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetBool("Walking", false);
        
    }

  

    private void Update()
    {
    MyInput();

SpeedControl();
   
    }
    private void MyInput()
    {
        Cursor.lockState = CursorLockMode.Locked;
         horizontalInput = Input.GetAxis("Horizontal");
         verticalInput = Input.GetAxis("Vertical");
 bool isMoving = (horizontalInput != 0 || verticalInput != 0);

    // Set the "IsMoving" bool in the animator
    playerAnimator.SetBool("Walking", isMoving);
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        if (Onslope())
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);
        }
        
         moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private bool Onslope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slope, 4 * 0.5f + 0.3f)) ;
        {

            float angle = Vector3.Angle(Vector3.up, slope.normal);

            return angle < maxSlopeAngle && angle != 0;
        }
        
    }

    public void WalkSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(footstepEventPath, transform.position);
        Debug.Log("walking");
    }
    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slope.normal).normalized;
    }
}
