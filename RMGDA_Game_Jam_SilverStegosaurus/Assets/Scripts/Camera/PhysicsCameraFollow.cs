using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCameraFollow : MonoBehaviour
{
   GameObject thePlayer;
   public GameObject hiddenObjectCam;

   private void Awake()
   {
      thePlayer = GameObject.FindGameObjectWithTag("Player");
   }

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void LateUpdate()
   {
      transform.position += (thePlayer.GetComponent<Rigidbody>().transform.position - transform.position) * 2f * Time.deltaTime;
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "House")
      {
         hiddenObjectCam.SetActive(true);
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.tag == "House")
      {
         hiddenObjectCam.SetActive(false);
      }
   }
}
