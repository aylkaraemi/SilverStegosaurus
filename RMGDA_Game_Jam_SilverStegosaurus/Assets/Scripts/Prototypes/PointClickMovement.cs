using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointClickMovement : MonoBehaviour
{
   public int moveMask;
   public NavMeshAgent agent;

   private void Awake()
   {
      moveMask = LayerMask.GetMask("MoveArea");
      agent = GetComponent<NavMeshAgent>();
   }


   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetMouseButton(0))
      {
         MoveToClickLocation();
      }
   }

   void MoveToClickLocation()
   {
      Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

      RaycastHit hit;

      if (Physics.Raycast(cameraRay, out hit, 500f, moveMask))
      {
         agent.SetDestination(hit.point);
      }
   }
}
