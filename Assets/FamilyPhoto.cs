using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyPhoto : MonoBehaviour, IInteractable
{
    public NightManager NightManagerRef;
    [ SerializeField]public JohnAnimator JohnAnimator;
    private Animator Animator;

    [SerializeField] public OverlayCam OverlayCam;
    // Start is called before the first frame update
    void Start()
    {
        JohnAnimator = JohnAnimator.GetComponent<JohnAnimator>();
        NightManagerRef = NightManagerRef.GetComponent<NightManager>();
        Animator = GetComponent<Animator>();
        OverlayCam = OverlayCam.GetComponent<OverlayCam>();
    }

    public void NightStrings()
    { 
        Animator.SetTrigger("fallTrigger");
    }
  
    public void Interact()
    {
        if (NightManagerRef.nightCounter == 2)
        {
            JohnAnimator.TaskTrigger();
            NightManagerRef.TaskCheck();
            //pick up photo in ui, press e to close
            Animator.SetTrigger("familyTrigger");
            //why u trigger johns memories wtf bro
            OverlayCam.FamilyPhoto();
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        Animator.SetTrigger("resetTrigger");
    }
}
