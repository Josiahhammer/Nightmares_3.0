using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class DemonScript : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;
    [ SerializeField]public JohnAnimator JohnAnimator;
   [SerializeField] public NightManager NightManagerRef;

 
  public Transform resetPosition;
  [SerializeField] public DemonReset DemonReset;
    private void Start()
    {
        
        navMeshAgent = GetComponent<NavMeshAgent>();
        NightManagerRef = NightManagerRef.GetComponent<NightManager>();
        JohnAnimator = JohnAnimator.GetComponent<JohnAnimator>();
    
        DemonReset = DemonReset.GetComponent<DemonReset>();
    }


    private void Update()
    {
      
       
            //seek out prey
            navMeshAgent.SetDestination(player.position);
        
    }
    //destroy prey
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player has a "Player" tag
        {
            Debug.Log("hrere");
            JohnAnimator.die();
            //glass breaking effect
            DemonReset.ResetNightmare();
            NightManagerRef.DemonNightReset();
            //resets night manager
            //RESET THE TIMELINE RESET EVERYTHING, I WILL BE ABSOLUTE
            //resets animators
        
        
          player.position = resetPosition.position;
          NightManagerRef.AllowSleep = true;
        }
      
    }
}
