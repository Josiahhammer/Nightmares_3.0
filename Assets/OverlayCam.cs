using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayCam : MonoBehaviour
{
   [SerializeField] public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public void DeathOverlay()
    {
        Animator.SetTrigger("deathOverlay");
    }
    // Update is called once per frame

    public void FamilyPhoto()
    {
        Animator.SetTrigger("familyPhotoTrigger");
    }
    void Update()
    {
        
    }
}
