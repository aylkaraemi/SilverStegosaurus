using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopeCautionFSM : HopeBaseFSM
{
   private const string _CAUTION = "caution";

   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      base.OnStateEnter(animator, stateInfo, layerIndex);
      agent.speed = 0f;
      MusicManager.Instance.SetCurrentAudioSource(_CAUTION);
   }

   // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      MusicManager.Instance.FadeTracksInOut();

      Vector3 playerPosition = new Vector3(thePlayer.transform.position.x, animator.transform.position.y,
         thePlayer.transform.position.z);
      hope.transform.LookAt(playerPosition);
   }

   // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      MusicManager.Instance.SetPreviousAudioSource(_CAUTION);
   }
}
