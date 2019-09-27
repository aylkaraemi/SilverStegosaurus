using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopeAI : MonoBehaviour
{
   private Animator _animator;

   // Start is called before the first frame update
   void Start()
   {
      _animator = GetComponent<Animator>();
   }

   // Update is called once per frame
   void Update()
   {

   }

   /// <summary>
   /// Chose a random index int as the new destination
   /// </summary>
   /// <param name="waypointLength">length of waypoint array</param>
   /// <returns>random int within waypoint array bounds</returns>
   public int RandomWaypointNumber(int waypointLength)
   {
      return Random.Range(0, waypointLength);
   }
}
