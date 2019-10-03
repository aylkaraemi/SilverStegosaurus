using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopeCaughtFSM : HopeBaseFSM
{
   private const float _STRUGGLE_BAR_DECREASE_AMOUNT = 0.3f;

   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      base.OnStateEnter(animator, stateInfo, layerIndex);
      agent.speed = 0f;
      hopeAI.TurnOffAButtonUI();
      hopeAI.wasCaught = true;
   }

   // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      Debug.Log("Hope StruggleBarValue = " + hopeAI.GetHopeStruggleBarValue());

      if (hopeAI.GetHopeStruggleBarValue() < 90.0f && hopeAI.GetHopeStruggleBarValue() > 1.0f)
      {
         hopeAI.DecreaseStruggleBarValue(_STRUGGLE_BAR_DECREASE_AMOUNT);
      }
      else if (hopeAI.GetHopeStruggleBarValue() > 95.0f)
      {
         Debug.Log("Player caught Hope value above 95");
      }
      else if (hopeAI.GetHopeStruggleBarValue() < 1.0f)
      {
         Debug.Log("Hope broke free value below 0");
      }
      
   }

   // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      hopeAI.wasCaught = false;
   }
}
