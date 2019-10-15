using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void PlayerLoses()
    {
        MusicManager.Instance.FadeCurrentTrackOut();
        StartCoroutine(EndGameLoseCoroutine());
    }

   private IEnumerator EndGameWinCoroutine()
   {
      yield return new WaitForSeconds(3.0f);
      SceneLoader.Instance.LoadNextScene();
   }

    private IEnumerator EndGameLoseCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("LoseScreen", LoadSceneMode.Single);
    }
}
