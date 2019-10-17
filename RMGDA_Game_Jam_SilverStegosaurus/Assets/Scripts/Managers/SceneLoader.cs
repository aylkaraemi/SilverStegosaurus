using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   private static SceneLoader _instance;
   public GameObject fadePanel;
   private Animator animator;
   private int sceneIndex;

   public static SceneLoader Instance
   {
      get
      {
         if (_instance == null)
         {
            Debug.Log("SceneLoader did not load");
         }

         return _instance;
      }
   }

   private void Awake()
   {
      _instance = this;
      animator = fadePanel.GetComponent<Animator>();
   }

   public void LoadNextScene()
   {
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      sceneIndex = currentSceneIndex + 1;
      StartCoroutine(FadeOutSceneCoroutine());
   }

   public void LoadLoseScene()
   {
      sceneIndex = 3;
      StartCoroutine(FadeOutSceneCoroutine());
   }

   public void LoadMainMenu()
   {
      sceneIndex = 0;
      StartCoroutine(FadeOutSceneCoroutine());
   }

   private IEnumerator FadeOutSceneCoroutine()
   {
      animator.SetBool("FadeOut", true);
      //Debug.Log("Fadeout triggered");
      yield return new WaitForSeconds(1f);
      SceneManager.LoadScene(sceneIndex);
   }

}
