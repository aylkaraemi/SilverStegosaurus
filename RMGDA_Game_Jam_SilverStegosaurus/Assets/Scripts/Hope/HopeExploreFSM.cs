using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopeExploreFSM : HopeBaseFSM
{
   private int _destPoint;
   private float _moveSpeed = 3.5f;
   private const string _EXPLORE = "explore";

   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      base.OnStateEnter(animator, stateInfo, layerIndex);

      // Disabling auto-braking allows for continuous movement
      // per Unity documentation
      //agent.autoBraking = false;

      if (agent.speed == 0f || agent.speed > _moveSpeed)
      {
         agent.speed = _moveSpeed;
      }

      _destPoint = hopeAI.RandomWaypointNumber();
      hopeAI.SetRandomIdleActionNumber();
      MusicManager.Instance.SetNewAudioSource(_EXPLORE);
   }

   // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      // Returns if no points have been set up
      if (hopeAI.waypoints.Length == 0)
         return;

      MusicManager.Instance.FadeTracksInOut();

      // starts timer until Hope goes idle
      hopeAI.StartTimer("timerUntilIdle");

      // Selects next destination when hope gets close to
      // current destination
      if (!agent.pathPending && agent.remainingDistance < 0.5f)
      {
         _destPoint = hopeAI.RandomWaypointNumber();
      }

      agent.SetDestination(hopeAI.waypoints[_destPoint].transform.position);
   }

   // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      hopeAI.ResetTimer("timerUntilIdle");
      MusicManager.Instance.SetPreviousAudioSource(_EXPLORE);
   }
}
