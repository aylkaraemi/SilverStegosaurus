﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickOrTreaterFrontHit : MonoBehaviour
{
   public TrickOrTreaterPatrol patrol; // loaded in Inspector

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         if (!patrol.isHit)
         {
            patrol.isHit = true;
         }
         patrol.isFrontHit = true;
      }
   }
}
