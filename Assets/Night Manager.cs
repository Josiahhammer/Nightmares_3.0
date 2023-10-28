using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class NightManager : MonoBehaviour, IInteractable

{
    public int nightCounter = 0;
    private bool taskComplete = false;
    private int objectiveCheck = 0;
    public PlayableDirector PlayableDirectorRef;
   [ SerializeField]public JohnAnimator JohnAnimator;
   [SerializeField] public FamilyPhoto FamilyPhotoRef;
   [SerializeField] public DemonReset DemonReset;
   [SerializeField] public FamilyCar FamilyCar;
   [SerializeField] public FamilyPhone FamilyPhone;
   public bool AllowSleep = true;
   [SerializeField] public ToolBox ToolBox;
   [SerializeField]  public GeneratorController GeneratorController;
   [SerializeField] public FireExtinguisher FireExtinguisher;
   [SerializeField] public WindowScript WindowScript;

   [SerializeField] public DemonAnimator DemonAnimator;
   [SerializeField] public DemonAnimator DemonAnimator2;
   [SerializeField] public DemonSetup DemonSetup;
   // Start is called before the first frame update
    void Start()
    {
        PlayableDirectorRef = PlayableDirectorRef.GetComponentInParent<PlayableDirector>();
        JohnAnimator = JohnAnimator.GetComponent<JohnAnimator>();
        FamilyPhotoRef = FamilyPhotoRef.GetComponent<FamilyPhoto>();
        DemonReset = DemonReset.GetComponent<DemonReset>();
        FamilyCar = FamilyCar.GetComponent<FamilyCar>();
        FamilyPhone = FamilyPhone.GetComponent<FamilyPhone>();
        WindowScript = WindowScript.GetComponent<WindowScript>();
        FireExtinguisher = FireExtinguisher.GetComponent<FireExtinguisher>();
        GeneratorController = GeneratorController.GetComponent<GeneratorController>();
        ToolBox = ToolBox.GetComponent<ToolBox>();
        DemonAnimator = DemonAnimator.GetComponent<DemonAnimator>();
        DemonAnimator2 = DemonAnimator2.GetComponent<DemonAnimator>();
        DemonSetup = DemonSetup.GetComponent<DemonSetup>();
        nightCounter = 0;
        objectiveCheck = 0;
    }

  
    // Update is called once per frame
    void Update()
    {
      //  Debug.Log(taskComplete);
    }
    public void TaskCheck()
    {
        Debug.Log("TaskCheck");
        taskComplete = true;
        Debug.Log(taskComplete);
    }
    public void Interact()
    {
        Debug.Log("Sleep");
        
        Sleep();
    }
    public void NightReset()
    {
        nightCounter = 0;
        objectiveCheck = 0;
        JohnAnimator.NightIncreaseUi();
        
    }

    public void GoodNightReset()
    {
        nightCounter = 0;
        objectiveCheck = 0;
        FamilyPhotoRef.Reset();
        ToolBox.Reset();
        FireExtinguisher.Reset();
        GeneratorController.Reset();
        WindowScript.Reset();
        GeneratorController.Reset();
        FamilyPhone.Reset();
        DemonSetup.Reset();
        StartCoroutine(DelayedNightIncreaseUi(4.0f));
        JohnAnimator.GoodFade();
        FamilyCar.Reset();
    }
    public void DemonNightReset()
    {
        nightCounter = 0;
        objectiveCheck = 0;
        FamilyPhotoRef.Reset();
        ToolBox.Reset();
        FireExtinguisher.Reset();
        GeneratorController.Reset();
        WindowScript.Reset();
        GeneratorController.Reset();
        DemonSetup.Reset();
        StartCoroutine(DelayedNightIncreaseUi(4.0f));
  
    }
    private IEnumerator DelayedNightIncreaseUi(float delay)
    {
        yield return new WaitForSeconds(delay);

    
        JohnAnimator.NightIncreaseUi();
    }
    public void JohnAnimatorOverride()
    {
        JohnAnimator.TaskTrigger();
    }
   
    private void NightIncrease()
    {
       
        nightCounter++;
        JohnAnimator.NightIncreaseUi();
        PlayableDirectorRef.time = nightCounter;
        Debug.Log(nightCounter);
        
        if (nightCounter == 2)
        {
            FamilyPhotoRef.NightStrings();
            //demon setup
      
            DemonSetup.NightCount = nightCounter;
            DemonAnimator.NightStrings2();
            DemonAnimator2.NightStrings2();
        }

        if (nightCounter == 3)
        {
            FireExtinguisher.CreateFire();
            //demon setup
          
            DemonSetup.NightCount = nightCounter;
            DemonAnimator.NightStrings3();
            DemonAnimator2.NightStrings3();
        }

        if (nightCounter == 4)
        {
            DemonSetup.NightCount = nightCounter;
        }
    }

   
    public void Sleep()
    {
        if (nightCounter != 4)
        {
            NightIncrease();
            Debug.Log(taskComplete);
            Judgement();
            
        }
        //called when player sleeps
       
         



    }
   
    public void Judgement()
    {
        Debug.Log(taskComplete);
        Debug.Log(nightCounter);
        Debug.Log(objectiveCheck);
        //decides the fate of john
      
        if (taskComplete && nightCounter == 1)//w
        {
            objectiveCheck += 1;
        }
        else if (taskComplete == false && nightCounter == 1 )//l
        {
        
            Debug.Log(objectiveCheck);
        }

        if (taskComplete && nightCounter == 2)//w
        {
            objectiveCheck+= 1;
        }
        else if (taskComplete == false && nightCounter == 2 && objectiveCheck > 0 )//l
        {
            DemonCheck();
            Debug.Log(objectiveCheck);
        }
        if (taskComplete && nightCounter == 3)
        {
            objectiveCheck+= 1;
        }
        else if (taskComplete == false && nightCounter == 3 && objectiveCheck > 0)
        {
            DemonCheck();
        }
        if (taskComplete && nightCounter == 4)
        {
            objectiveCheck += 1;
        }
        
        //final night good bad or repeat
        if (taskComplete && nightCounter == 4 && objectiveCheck == 4)
        {
         
            GoodEnding();
            Debug.Log("Good Ending");
        }

        if (objectiveCheck > 0 && objectiveCheck <= 3 && nightCounter == 4)
        {
            RepeatEnding();
            Debug.Log("Repeat Ending");
        }
        if (nightCounter == 4 && objectiveCheck == 0)
        {
            BadEnding();
            Debug.Log("Bad Ending");
        }

        if (AllowSleep == true)
        {
            JohnAnimator.Fade();
        }
        taskComplete = false;
    }
    private void DemonCheck()
    {
        //Johns sins manifested

      
        DemonReset.DestroyJohnWayne();
        AllowSleep = false;

    }


    private void GoodEnding()
    {
        //connected to car animator which ends the game a different way
        //this still needs to be scripted will take a while
        FamilyCar.PullUpToTheScene();
    }

    public void RepeatEnding()
    {
      //delayed demon check

      StartCoroutine(DelayedDemon(15f));
    }
    public IEnumerator DelayedDemon(float delay)
    {
        yield return new WaitForSeconds(delay);

        DemonCheck();

    }
    private void BadEnding()
    {
        //telephone hopefully
        FamilyPhone.DemonicManifestation();
    }
    
    
    
    
}
