using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopeRunAwayFSM : HopeBaseFSM
{
   private int _destPoint;
   private float _moveSpeed = 9.0f;

   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      base.OnStateEnter(animator, stateInfo, layerIndex);
      animator.SetBool("inRunAwayState", true);
      agent.speed = _moveSpeed;

      _destPoint = hopeAI.RandomWaypointNumber();
   }

   // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      if (!agent.pathPending && agent.remainingDistance < 0.5f)
      {
         animator.SetBool("inRunAwayState", false);
      }

      agent.SetDestination(hopeAI.waypoints[_destPoint].transform.position);
   }

   // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      //animator.SetBool("runAwayLocationReached", false);
   }
}
