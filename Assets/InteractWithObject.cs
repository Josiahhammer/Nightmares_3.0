using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
 public void Interact();
}
public class InteractWithObject : MonoBehaviour
{
 public Transform InteractorSource;
 public float IntereactRange;
 private bool isInteracting = false;

 private void Start()
 {

 }

 void Update()
 {
  if (isInteracting)
  {
   // Player is already interacting, do nothing
   return;
  }

  if (Input.GetKeyDown(KeyCode.E))
  {
   Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
   if (Physics.Raycast(r, out RaycastHit hitInfo, IntereactRange))
   {
    if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
    {
     StartCoroutine(InteractWithDelay(interactObj));
    }
   }
  }
 }

 IEnumerator InteractWithDelay(IInteractable interactObj)
 {
  isInteracting = true;

  // Perform the interaction
  interactObj.Interact();

  // Delay for the interaction to complete
  yield return new WaitForSeconds(5.0f); // Adjust the delay time as needed

  isInteracting = false;
 }
}
