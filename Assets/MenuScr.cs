using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuScr : MonoBehaviour
{
  [SerializeField]  public WindowScript WindowScript;
    public Animator menuAnimator;
    // Start is called before the first frame update
    void Start()
    {
        menuAnimator = GetComponentInParent<Animator>();
        WindowScript = WindowScript.GetComponent<WindowScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        menuAnimator.SetTrigger("playTrigger");
       WindowScript.WindowPlay();
    }

    public void ExitButton()
    {
        // Call Application.Quit to exit the application
        Application.Quit();
        Debug.Log("hehehehe");
    }
}
