using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
   [SerializeField] AudioSource _exploreAudioSource;
   [SerializeField] AudioSource _cautionAudioSource;
   [SerializeField] AudioSource _caughtAudioSource;
   private static MusicManager _instance;

   private float _fadeTimer = 0.0f;
   private string _currentState;
   private const string _EXPLORE = "explore";
   private const string _CAUTION = "caution";
   private const string _CAUGHT = "caught";
   private AudioSource _previousAudioTrack;
   private AudioSource _newAudioTrack;

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

   public void SetNewAudioSource(string newState)
   {
      if (newState == _EXPLORE)
      {
         _newAudioTrack = _exploreAudioSource;
      }
      else if (newState == _CAUTION)
      {
         _newAudioTrack = _cautionAudioSource;
      }
      else if (newState == _CAUGHT)
      {
         _newAudioTrack = _caughtAudioSource;
      }
   }

   public void FadeTracksInOut()
   {
      if (!_newAudioTrack.isPlaying)
      {
         _newAudioTrack.Play();
      }

      _previousAudioTrack.volume -= (Time.deltaTime / 2.5f);
      _newAudioTrack.volume += (Time.deltaTime / 2.5f);
   }
}
