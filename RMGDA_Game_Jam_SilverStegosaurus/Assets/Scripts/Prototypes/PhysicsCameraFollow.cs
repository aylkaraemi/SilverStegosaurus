using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCameraFollow : MonoBehaviour
{
   GameObject thePlayer;

   private void Awake()
   {
      thePlayer = GameObject.FindGameObjectWithTag("Player");
   }

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void FixedUpdate()
   {
      transform.position += (thePlayer.transform.position - transform.position) * 0.05f;
   }
}
