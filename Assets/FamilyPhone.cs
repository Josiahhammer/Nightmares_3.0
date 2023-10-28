using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyPhone : MonoBehaviour
{
    private Animator Animator;

    public DemonReset DemonReset;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        DemonReset = DemonReset.GetComponent<DemonReset>();
    }

    public void DemonicManifestation()
    {
        Animator.SetTrigger("dialTone");
        Animator.SetTrigger("demonTalk");
        //start coroutine for playing phone ringing sound, will be very long. Then spawn in demon.
        StartCoroutine(DelayedDestroyJohn(40.0f));
    }

    private IEnumerator DelayedDestroyJohn(float delay)
    {
        yield return new WaitForSeconds(delay);
        DemonReset.DestroyJohnWayne();
        
    }

    public void Reset()
    {
        Animator.SetTrigger("resetPhone");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
