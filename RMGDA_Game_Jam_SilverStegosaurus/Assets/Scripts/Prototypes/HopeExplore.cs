using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HopeExplore : MonoBehaviour
{
   public Transform[] waypoints;
   private int destPoint;
   private NavMeshAgent hope;


   void Start()
   {
      hope = GetComponent<NavMeshAgent>();

      // Disabling auto-braking allows for continuous movement
      // per Unity documentation
      hope.autoBraking = false;


      destPoint = Random.Range(0, waypoints.Length);

      GotoNextPoint();
   }


   void GotoNextPoint()
   {
      // Returns if no points have been set up
      if (waypoints.Length == 0)
         return;

      // Set hope to go to the currently selected destination.
      hope.destination = waypoints[destPoint].position;

      // Chose a random point as the new destination
      destPoint = Random.Range(0, waypoints.Length);
   }


   void Update()
   {
      // Selects next destination when hope gets close to
      // current destination
      if (!hope.pathPending && hope.remainingDistance < 0.5f)
         GotoNextPoint();
   }
}
