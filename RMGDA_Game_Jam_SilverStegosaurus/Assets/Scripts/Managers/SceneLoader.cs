using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   private static SceneLoader _instance;

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
   }

   public void LoadNextScene()
   {
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentSceneIndex + 1);
   }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
