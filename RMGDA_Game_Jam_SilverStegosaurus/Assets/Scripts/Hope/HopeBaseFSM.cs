using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HopeBaseFSM : StateMachineBehaviour
{
   public GameObject hope;
   public HopeAI hopeAI;
   public GameObject thePlayer;
   public NavMeshAgent agent;

   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      hope = animator.gameObject;
      hopeAI = hope.GetComponent<HopeAI>();
      //thePlayer 
      agent = hope.GetComponent<NavMeshAgent>();
   }

   // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {

   }

   // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {

   }
}
