using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
   [SerializeField] AudioSource _exploreAudioSource;
   [SerializeField] AudioSource _cautionAudioSource;
   [SerializeField] AudioSource _caughtAudioSource;
   [SerializeField] AudioSource _fxAudioSource;
   [SerializeField] AudioClip _candyClip;
   private static MusicManager _instance;

   private float _fadeTimer = 0.0f;
   private string _currentState;
   private const string _EXPLORE = "explore";
   private const string _CAUTION = "caution";
   private const string _CAUGHT = "caught";
   private AudioSource _previousAudioTrack;
   private AudioSource _currentAudioTrack;

   /// <summary>
   /// for singleton access to MusicManager
   /// </summary>
   public static MusicManager Instance
   {
      get
      {
         if (_instance == null)
         {
            Debug.Log("Music Manager did not load");
         }

         return _instance;
      }
   }

   private void Awake()
   {
      _instance = this;
      _currentState = _EXPLORE;
      _previousAudioTrack = _exploreAudioSource;
   }

   private void Update()
   {
      
   }

   public void SetPreviousAudioSource(string theState)
   {
      if (theState == _EXPLORE)
      {
         _previousAudioTrack = _exploreAudioSource;
      }
      else if (theState == _CAUTION)
      {
         _previousAudioTrack = _cautionAudioSource;
      }
      else if (theState == _CAUGHT)
      {
         _previousAudioTrack = _caughtAudioSource;
      }
   }

   public void SetCurrentAudioSource(string newState)
   {
      if (newState == _EXPLORE)
      {
         _currentAudioTrack = _exploreAudioSource;
      }
      else if (newState == _CAUTION)
      {
         _currentAudioTrack = _cautionAudioSource;
      }
      else if (newState == _CAUGHT)
      {
         _currentAudioTrack = _caughtAudioSource;
      }
   }

   public void FadeTracksInOut()
   {
      if (!_currentAudioTrack.isPlaying)
      {
         _currentAudioTrack.Play();
      }

      _previousAudioTrack.volume -= (Time.deltaTime / 2.5f);
      _currentAudioTrack.volume += (Time.deltaTime / 2.5f);
   }

   public void FadeCurrentTrackOut()
   {
      _currentAudioTrack.volume -= (Time.deltaTime / 2.5f);
   }

   public void FadeCurrentTrackIn()
   {
      _currentAudioTrack.volume += (Time.deltaTime / 2.5f);
   }

   public void PlayCandySound()
   {
      _fxAudioSource.clip = _candyClip;
      _fxAudioSource.Play();

      StartCoroutine(PartlyFadeOutMusicCoroutine());
   }

   private IEnumerator PartlyFadeOutMusicCoroutine()
   {
      while (_currentAudioTrack.volume >= 0.3f)
      {
         FadeCurrentTrackOut();
         yield return null;
      }
   }

   public void FadeInPartlyFadedMusic()
   {
      //if (_instance != null)
      //{

      //}
      StartCoroutine(FadeInMusicCoroutine());
   }

   private IEnumerator FadeInMusicCoroutine()
   {
      while (_currentAudioTrack.volume < 1.0f)
      {
         FadeCurrentTrackIn();
         yield return null;
      }
   }
}
