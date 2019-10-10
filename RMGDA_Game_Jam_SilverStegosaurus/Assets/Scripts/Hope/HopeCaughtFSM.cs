using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopeCaughtFSM : HopeBaseFSM
{
   private const float _STRUGGLE_BAR_DECREASE_AMOUNT = 0.3f;
   private const float _STRUGGLE_BAR_MAX = 90.0f;
   private const float _STRUGGLE_BAR_MIN = 1.0f;
   private const float _STRUGGLE_BAR_WIN = 95.0f;
   private const string _CAUGHT = "caught";

   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      base.OnStateEnter(animator, stateInfo, layerIndex);
      agent.speed = 0f;
      hopeAI.TurnOffAButtonUI();
      hopeAI.wasCaught = true;
      hopeAI.TurnOnStruggleBar();
      MusicManager.Instance.SetNewAudioSource(_CAUGHT);
   }

   // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      MusicManager.Instance.FadeTracksInOut();

      if (hopeAI.GetHopeStruggleBarValue() < _STRUGGLE_BAR_MAX && hopeAI.GetHopeStruggleBarValue() > _STRUGGLE_BAR_MIN)
      {
         hopeAI.DecreaseStruggleBarValue(_STRUGGLE_BAR_DECREASE_AMOUNT);
      }
      else if (hopeAI.GetHopeStruggleBarValue() > _STRUGGLE_BAR_WIN)
      {
         Debug.Log("Player caught Hope value above 95");
      }
      else if (hopeAI.GetHopeStruggleBarValue() < _STRUGGLE_BAR_MIN)
      {
         Debug.Log("Hope broke free value below 0");
         animator.SetBool("isCaught", false);
         hopeAI.wasCaught = false;
      }
      
   }

   // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      hopeAI.TurnOffStruggleBar();
      // reset to 80 if Hope got away
      if (hopeAI.GetHopeStruggleBarValue() < 80)
      {
         hopeAI.ResetStruggleBarToStartValue();
      }
      MusicManager.Instance.SetPreviousAudioSource(_CAUGHT);
   }
}
