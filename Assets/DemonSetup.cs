using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonSetup : MonoBehaviour
{
    [SerializeField] public Animator Animator;

    public int NightCount;
    // Start is called before the first frame update
    void Start()
    {
        Animator = Animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Animator.SetInteger("nightLevel", NightCount);
    }


    public void Reset()
    {
        NightCount = 0;
    }
  
    private void OnEnable()
    {
       
    }
}
