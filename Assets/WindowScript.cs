using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScript : MonoBehaviour, IInteractable
{
    private Animator Animator;
    public NightManager NightManager;
   
    public void Start()
    {
        NightManager = NightManager.GetComponent<NightManager>();
        Animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (NightManager.nightCounter == 0)
        {
            NightManager.JohnAnimatorOverride();
            NightManager.TaskCheck();
            Animator.SetTrigger("windowTrigger");
            Debug.Log("Bruh");
            
        }
    }

    public void WindowPlay()
    {
        Animator.SetTrigger("playTrigger");
        
    }
    public void Reset()
    {
        Animator.SetTrigger("resetTrigger");
        if (NightManager.nightCounter == 0)
        {
            Animator.SetTrigger("playTrigger");
        }
    }
}
