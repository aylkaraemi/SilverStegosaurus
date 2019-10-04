using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrickOrTreaterPatrol : MonoBehaviour
{
   public Transform[] waypoints;
   private NavMeshAgent _agent;

   private void Awake()
   {
      _agent = GetComponent<NavMeshAgent>();
   }

   // Start is called before the first frame update
   void Start()
   {
      _agent.SetDestination(waypoints[0].position);
   }

   // Update is called once per frame
   void Update()
   {

   }
}
