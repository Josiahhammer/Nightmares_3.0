using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonReset : MonoBehaviour
{
    [SerializeField] public GameObject demonState;
    [SerializeField] public Transform demonResetPos;  // Set the reset position in the Inspector
    private Vector3 demonInitialPos;  // Store the initial position of demonState

    // Start is called before the first frame update
    void Start()
    {
        // Initialize demonInitialPos with the initial position of demonState
        demonInitialPos = demonState.transform.position;
    }

    public void DestroyJohnWayne()
    {
        // Move the demon to seek out the player
        // Implement your movement logic here

        // This is what happens when you drink and drive kids
        demonState.SetActive(true);
    }

    public void ResetNightmare()
    {
        // Reset the position of demonState to the initial position
        demonState.transform.position = demonInitialPos;

        // Turn off demon
        demonState.SetActive(false);
    }
}
