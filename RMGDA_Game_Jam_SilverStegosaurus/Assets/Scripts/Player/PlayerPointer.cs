using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointer : MonoBehaviour
{
   public GameObject hope;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void LateUpdate()
   {
      Vector3 hopePos = new Vector3(hope.transform.position.x, this.transform.position.y, hope.transform.position.z);

      this.transform.LookAt(hopePos);
   }
}
