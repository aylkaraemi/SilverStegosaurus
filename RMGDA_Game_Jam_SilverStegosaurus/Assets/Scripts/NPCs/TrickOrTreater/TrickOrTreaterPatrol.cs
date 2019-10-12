using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrickOrTreaterPatrol : MonoBehaviour
{
   public GameObject[] waypoints;
   public bool isHit = false;
   public bool isFrontHit = false;
   public bool isRightHit = false;
   public bool isLeftHit = false;
   public bool isTriggerSet = false;

   private NavMeshAgent _agent;
   private int _randomDestinationPoint;
   private Animator _animator;

   private void Awake()
   {
      _animator = GetComponentInChildren<Animator>();
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
      if (!isHit)
      {
         MoveToNextWaypoint();
      }
      else
      {
         if (isFrontHit)
         {
            EnterHitState("FrontHit");
         }

         if (isLeftHit)
         {
            EnterHitState("LeftHit");
         }

         if (isRightHit)
         {
            EnterHitState("RightHit");
         }
      }
      
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

   private IEnumerator ReturnToNonHitCoroutine()
   {
      yield return new WaitForSeconds(1.5f);
      isHit = false;

      if (_agent.speed == 0f)
      {
         _agent.speed = 1f;
      }

      if (isFrontHit)
      {
         isFrontHit = false;
      }

      if (isLeftHit)
      {
         isLeftHit = false;
      }

      if (isRightHit)
      {
         isRightHit = false;
      }

      isTriggerSet = false;
   }

   private void EnterHitState(string animTriggerName)
   {
      if (!isTriggerSet)
      {
         if (animTriggerName == "FrontHit")
         {
            _agent.speed = 0f;
         }

         _animator.SetTrigger(animTriggerName);
         isTriggerSet = true;
         StartCoroutine(ReturnToNonHitCoroutine());
      }
   }
}
