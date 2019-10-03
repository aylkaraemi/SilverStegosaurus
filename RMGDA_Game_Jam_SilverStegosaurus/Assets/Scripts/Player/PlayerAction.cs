using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
   private bool _isHopeInRange = false;
   [SerializeField] private float _increaseStruggleBarAmount = 3.0f;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetButtonDown("Fire1"))
      {
         Debug.Log("Pressed A Button");

         // catch Hope with A Button
         if (_isHopeInRange && !HopeAI.Instance.wasCaught)
         {
            Grab();
         }

         // struggle with Hope
         if (HopeAI.Instance.wasCaught)
         {
            Struggle();
         }
        
      }

   }

   /// <summary>
   /// grab hope to win the game
   /// </summary>
   void Grab()
   {
      HopeAI.Instance.SetAnimatorIsCaughtToTrue();
   }

   /// <summary>
   /// increase Hope struggle bar amount
   /// </summary>
   void Struggle()
   {
      HopeAI.Instance.IncreaseStruggleBarValue(_increaseStruggleBarAmount);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Hope")
      {
         Debug.Log("Hope is in Range");
         _isHopeInRange = true;
         HopeAI.Instance.TurnOnAButtonUI();
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.tag == "Hope")
      {
         Debug.Log("Hope is out of Range");
         _isHopeInRange = false;
         HopeAI.Instance.TurnOffAButtonUI();
      }
   }

}
