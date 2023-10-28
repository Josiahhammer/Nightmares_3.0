using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour, IInteractable
{
    public NightManager NightManagerRef;
    public bool GeneratorLock = true;
    [ SerializeField]public JohnAnimator JohnAnimator;

    public Animator GenAnimator;
    // Start is called before the first frame update
    void Start()
    {
        NightManagerRef = NightManagerRef.GetComponent<NightManager>();
        JohnAnimator = JohnAnimator.GetComponent<JohnAnimator>();
        GenAnimator = GenAnimator.GetComponent<Animator>();
    }

    public void Interact()
    {
        if (GeneratorLock == false)
        {
            //animate the shed being repaired
            //set fade to black
            GenAnimator.SetTrigger("repairGen");
            JohnAnimator.Fade();
            JohnAnimator.TaskTrigger();
            NightManagerRef.TaskCheck();
            GeneratorLock = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        GenAnimator.SetTrigger("repairgen");
    }
}
