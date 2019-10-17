using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopeCaughtFSM : HopeBaseFSM
{
   private float _struggleBarDecreaseAmount;
   private float _timer;

   private const float _STRUGGLE_BAR_MAX = 90.0f;
   private const float _STRUGGLE_BAR_MIN = 1.0f;
   private const float _STRUGGLE_BAR_WIN = 95.0f;
   private const float _TIMER_MAX = 20.0f;
   private const string _CAUGHT = "caught";


   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      base.OnStateEnter(animator, stateInfo, layerIndex);
      agent.speed = 0f;
      hopeAI.TurnOffAButtonUI();
      hopeAI.wasCaught = true;
      hopeAI.TurnOnStruggleBar();
      MusicManager.Instance.SetCurrentAudioSource(_CAUGHT);
      PlayerAction.Instance.SetAnimatorStruggleBool(true);
      thePlayer.GetComponent<JoystickControllerMovement>().canMove = false;
      _timer = 0.0f;
      _struggleBarDecreaseAmount = 0.3f;
   }

   // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      _timer += Time.deltaTime;

      if (hopeAI.GetHopeStruggleBarValue() < _STRUGGLE_BAR_MAX && hopeAI.GetHopeStruggleBarValue() > _STRUGGLE_BAR_MIN)
      {
         MusicManager.Instance.FadeTracksInOut();

         if (_timer > _TIMER_MAX)
         {
            _struggleBarDecreaseAmount += 0.05f;
         }
         hopeAI.DecreaseStruggleBarValue(_struggleBarDecreaseAmount);
      }
      else if (hopeAI.GetHopeStruggleBarValue() > _STRUGGLE_BAR_WIN)
      {
         //Debug.Log("Player caught Hope value above 95");
         GameManager.Instance.PlayerWins();
      }
      else if (hopeAI.GetHopeStruggleBarValue() < _STRUGGLE_BAR_MIN)
      {
         //Debug.Log("Hope broke free value below 0");
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
      PlayerAction.Instance.SetAnimatorStruggleBool(false);

      thePlayer.GetComponent<JoystickControllerMovement>().canMove = true;
   }
}
