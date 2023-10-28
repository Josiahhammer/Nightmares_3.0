using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour, IInteractable
{
    private Animator Animator;
    public NightManager NightManagerRef;
    [ SerializeField]public JohnAnimator JohnAnimator;
   
    // Start is called before the first frame update
    void Start()
    {
        NightManagerRef = NightManagerRef.GetComponent<NightManager>();
        JohnAnimator = JohnAnimator.GetComponent<JohnAnimator>();
        Animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (NightManagerRef.nightCounter == 3)
        {
            
            JohnAnimator.Fade();
            JohnAnimator.TaskTrigger();
            NightManagerRef.TaskCheck();
            Animator.SetTrigger("fireExtTrigger");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateFire()
    {
        Animator.SetTrigger("fire");
    }
    public void Reset()
    {
        Animator.SetTrigger("resetTrigger");
    }
}
