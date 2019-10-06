using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HopeUI : MonoBehaviour
{
   private Camera _camera;

   // Start is called before the first frame update
   void Start()
   {
      _camera = Camera.main;

   }

   // Update is called once per frame
   void Update()
   {
      transform.rotation = _camera.transform.rotation;
   }
}
