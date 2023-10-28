using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemonAnimator : MonoBehaviour
{
    public float NightCount;
    [SerializeField] private GameObject positionOne;  // Change to private
    [SerializeField] private Animator Animator;
    
    private NavMeshAgent NavMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize NavMeshAgent
        NavMeshAgent = GetComponent<NavMeshAgent>();

        if (positionOne != null)
        {
            // Store the initial position in positionOneVec
            positionOneVec = positionOne.transform.position;
        }
        else
        {
            Debug.LogError("positionOne is not assigned. Make sure to assign it in the Unity Inspector.");
        }
    }

    private Vector3 positionOneVec;  // Store the position in this variable

    // Update is called once per frame
    void Update()
    {
        if (positionOne != null)
        {
            NavMeshAgent.destination = positionOneVec;
        }
        // You can optionally add an else condition to handle cases where positionOne is null.
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger1"))  // Assuming you've set a tag for your first trigger
        {
            NightStrings2();  // Call the NightStrings2 method
        }
        else if (other.CompareTag("Trigger2"))  // Assuming you've set a tag for your second trigger
        {
            NightStrings3();  // Call the NightStrings3 method
        }

        if (other.CompareTag("Player"))
        {
            NightStrings4();
        }
    }
    public void NightStrings2()
    {
        Animator.SetTrigger("night2");
    }

    public void NightStrings3()
    {
        Animator.SetTrigger("night3");
    }

    public void NightStrings4()
    {
        Animator.SetTrigger("PlayerTrigger");
    }
    
}
