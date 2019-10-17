﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMainMenu : MonoBehaviour
{
   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetButtonDown("Fire1"))
      {
         GameManager.Instance.ReturnToMainMenu();
      }

      if (Input.GetKeyDown(KeyCode.Q))
      {
         Application.Quit();
      }
   }
}
