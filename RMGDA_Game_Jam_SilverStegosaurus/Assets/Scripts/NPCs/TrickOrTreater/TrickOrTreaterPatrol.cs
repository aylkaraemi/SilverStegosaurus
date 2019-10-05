using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrickOrTreaterPatrol : MonoBehaviour
{
   public GameObject[] waypoints;
   private NavMeshAgent _agent;
   private int _randomDestinationPoint;

   private void Awake()
   {
      _agent = GetComponent<NavMeshAgent>();
      waypoints = GameObject.FindGameObjectsWithTag("TrickOrTreatWaypoint");
   }

   // Start is called before the first frame update
   void Start()
   {
      _randomDestinationPoint = Random.Range(0, waypoints.Length);
   }

   // Update is called once per frame
   void Update()
   {
      MoveToNextWaypoint();
   }

   void MoveToNextWaypoint()
   {
      if (waypoints.Length == 0)
      {
         return;
      }

      if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
      {
         _randomDestinationPoint = Random.Range(0, waypoints.Length);
      }

      _agent.SetDestination(waypoints[_randomDestinationPoint].transform.position);
   }
}
