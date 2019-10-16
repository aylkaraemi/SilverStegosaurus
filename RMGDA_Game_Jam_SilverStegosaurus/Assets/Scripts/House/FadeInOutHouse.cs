using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOutHouse : MonoBehaviour
{
   public Material[] originalMaterials;
   public Material[] fadeMaterials;
   private MeshRenderer _meshRenderer;

   private void Start()
   {
      _meshRenderer = GetComponent<MeshRenderer>();
      originalMaterials = _meshRenderer.materials;
   }


   private void ChangeToFadeMaterial()
   {
      _meshRenderer.materials = fadeMaterials;
   }

   private void FadeOutMaterials()
   {
      foreach(Material mat in _meshRenderer.materials)
      {
         StartCoroutine(FadeOutCouroutine(mat));
      }
   }

   private IEnumerator FadeOutCouroutine(Material mat)
   {
      float timer = 0f;
      Color matColor = mat.color;

      while (timer < 2.0f)
      {
         matColor.a = Mathf.Lerp(1f, 0.3f, 1.0f * Time.deltaTime);
         yield return null;
      }

   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         Debug.Log("Player entered");
         ChangeToFadeMaterial();
         //FadeOutMaterials();
      }
   }
}
