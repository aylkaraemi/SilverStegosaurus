using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCameraFollow : MonoBehaviour
{
   GameObject thePlayer;
   public GameObject hiddenObjectCam;

   private Vector3 _playerPos;
   private RaycastHit _hit;
   private Ray _cameraRay;

   private Vector3 _offset;

   private void Awake()
   {
      thePlayer = GameObject.FindGameObjectWithTag("Player");
   }

   // Start is called before the first frame update
   void Start()
   {
      _offset = this.transform.position - thePlayer.transform.position;
      //transform.position = thePlayer.GetComponent<Rigidbody>().transform.position;
   }

   // Update is called once per frame
   void LateUpdate()
   {
      transform.position += ((thePlayer.transform.position + _offset) - transform.position) * 2f * Time.deltaTime;

      CheckForBlockingHouse();
   }

   private void CheckForBlockingHouse()
   {
      if (Physics.Raycast(this.transform.position, thePlayer.transform.position - this.transform.position, out _hit, 100f))
      {
         if (_hit.collider.gameObject.tag == "House")
         {
            hiddenObjectCam.SetActive(true);
         }

         if (_hit.collider.gameObject.tag == "Player")
         {
            if (hiddenObjectCam.activeSelf)
            {
               hiddenObjectCam.SetActive(false);
            }
         }
      }
   }

   //private void OnTriggerEnter(Collider other)
   //{
   //   if (other.tag == "House")
   //   {
   //      hiddenObjectCam.SetActive(true);
   //   }
   //}

   //private void OnTriggerExit(Collider other)
   //{
   //   if (other.tag == "House")
   //   {
   //      hiddenObjectCam.SetActive(false);
   //   }
   //}
}
