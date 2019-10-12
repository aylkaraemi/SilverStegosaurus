using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   private static GameManager _instance;
   [SerializeField] JoystickControllerMovement _playerMovement;

   public static GameManager Instance
   {
      get
      {
         if (_instance == null)
         {
            Debug.Log("GameManager did not load");
         }

         return _instance;
      }
   }

   private void Awake()
   {
      _instance = this;
   }

   public void PlayerWins()
   {
      MusicManager.Instance.FadeCurrentTrackOut();
      StartCoroutine(EndGameWinCoroutine());
   }

   private IEnumerator EndGameWinCoroutine()
   {
      yield return new WaitForSeconds(3.0f);
      SceneLoader.Instance.LoadNextScene();
   }
}
