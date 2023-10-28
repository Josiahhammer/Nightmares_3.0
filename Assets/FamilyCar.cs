using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FamilyCar : MonoBehaviour, IInteractable
{
    public Animator Animator;
    [SerializeField] public NightManager NightManagerRef;
    public Transform player;
    public Transform resetPosition;
    // Start is called before the first frame update
    void Start()
    {
        Animator = Animator.GetComponentInParent<Animator>();
        NightManagerRef = NightManagerRef.GetComponent<NightManager>();
    }

    public void Interact()
    {
        Debug.Log("gggg");
        StartCoroutine(InteractWithDelay2());
        NightManagerRef.GoodNightReset();
    }

    IEnumerator InteractWithDelay2()
    {
     
     
        // Wait for 2 seconds
        yield return new WaitForSeconds(4.0f);
       //John Animator reset
       //
//Reset nights
       

player.position = resetPosition.position;
    }
    

    public void PullUpToTheScene()
    {
        Animator.SetTrigger("familyCar");
    }


    public void Reset()
    {
        Animator.SetTrigger("familyCarReset");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
