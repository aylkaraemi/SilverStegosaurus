using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopeExploreFSM : HopeBaseFSM
{
   public GameObject[] waypoints;
   private int _destPoint;

   private void Awake()
   {
      waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
   }

   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      base.OnStateEnter(animator, stateInfo, layerIndex);

      // Disabling auto-braking allows for continuous movement
      // per Unity documentation
      agent.autoBraking = false;

      _destPoint = hopeAI.RandomWaypointNumber(waypoints.Length);
   }

   // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      // Returns if no points have been set up
      if (waypoints.Length == 0)
         return;

      // Selects next destination when hope gets close to
      // current destination
      if (!agent.pathPending && agent.remainingDistance < 0.5f)
      {
         _destPoint = hopeAI.RandomWaypointNumber(waypoints.Length);
      }

      agent.SetDestination(waypoints[_destPoint].transform.position);
   }

   // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {

   }
}
