using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ToolBox : MonoBehaviour, IInteractable
{

    private Animator Animator;
    public NightManager NightManagerRef;
    public GeneratorController GeneratorController;
    
    // Start is called before the first frame update
    void Start()
    {
        NightManagerRef = NightManagerRef.GetComponent<NightManager>();
        Animator = GetComponent<Animator>();
        GeneratorController = GeneratorController.GetComponent<GeneratorController>();

    }

    public void Interact()
    {
        if (NightManagerRef.nightCounter == 1)
        {
         
            Animator.SetTrigger("toolboxTrigger");

            ReturnToShed();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToShed()
    {
        //set objective return to generator
        GeneratorController.GeneratorLock = false;

    }

    public void Reset()
    {
        Animator.SetTrigger("resetTrigger");
    }
}
