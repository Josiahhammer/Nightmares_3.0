using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnAnimator : MonoBehaviour
{
    [SerializeField] public OverlayCam OverlayCam;
   [SerializeField] public NightManager NightManagerRef;
    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        
        Animator = GetComponent<Animator>();
        NightManagerRef = NightManagerRef.GetComponent<NightManager>();
    }

    public void die()
    {
        OverlayCam.DeathOverlay();
        Animator.SetTrigger("death");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fade()
    {
        Debug.Log("fade");
        
        Animator.SetTrigger("fadeTrigger");
    }

    public void GoodFade()
    {
        Animator.SetTrigger("goodFadeTrigger");
    }
    public void TaskTrigger()
    {
        Animator.SetTrigger("taskTrigger");
    }
    public void NightIncreaseUi()
    {
        Animator.SetInteger("nightLevel", NightManagerRef.nightCounter);
        Animator.SetTrigger("nightLock");
       
    }
}
