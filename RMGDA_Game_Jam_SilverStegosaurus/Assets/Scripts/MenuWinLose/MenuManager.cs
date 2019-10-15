using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
   public SceneLoader sceneLoader; // loaded in Inspector

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetButtonDown("Fire1"))
      {
         if (sceneLoader != null)
         {
            sceneLoader.LoadNextScene();
         }
         
      }
   }
}
