using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBlockingHouse : MonoBehaviour
{
   private MeshRenderer _meshRenderer;

   private void Start()
   {
      _meshRenderer = GetComponent<MeshRenderer>();
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         _meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.tag == "Player")
      {
         _meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
      }
   }
}
