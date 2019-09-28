using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopeAI : MonoBehaviour
{
   public GameObject[] waypoints;

   private Animator _animator;
   private GameObject _thePlayer;
   private float _timer = 0f;

   private void Awake()
   {
      _thePlayer = GameObject.FindGameObjectWithTag("Player");
      _animator = GetComponent<Animator>();
      waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
   }

   // Start is called before the first frame update
   void Start()
   {
      
   }

   // Update is called once per frame
   void Update()
   {
      SetAnimatorDistanceToPlayer();
      SetAnimatorPlayerSpeed();
   }

   /// <summary>
   /// Chose a random index int as the new destination
   /// </summary>
   /// <param name="waypointLength">length of waypoint array</param>
   /// <returns>random int within waypoint array bounds</returns>
   public int RandomWaypointNumber()
   {
      return Random.Range(0, waypoints.Length);
   }

   /// <summary>
   /// start the timer used for animator parameters
   /// </summary>
   /// <param name="animatorParameterName">name of animator float parameter</param>
   public void StartTimer(string animatorParameterName)
   {
      _timer += Time.deltaTime;
      _animator.SetFloat(animatorParameterName, _timer);
   }

   /// <summary>
   /// Reset the timer used for animator parameters back to zero
   /// </summary>
   /// <param name="animatorParameterName">name of animator float parameter</param>
   public void ResetTimer(string animatorParameterName)
   {
      _timer = 0f;
      _animator.SetFloat(animatorParameterName, _timer);
   }

   /// <summary>
   /// set the animator random idle action number to choose idle animation
   /// </summary>
   public void SetRandomIdleActionNumber()
   {
      _animator.SetInteger("randomIdleActionNum", Random.Range(0, 6));
   }

   /// <summary>
   /// used to determine distance between Hope and Player
   /// </summary>
   private void SetAnimatorDistanceToPlayer()
   {
      _animator.SetFloat("distanceToPlayer", Vector3.Distance(this.transform.position, _thePlayer.transform.position));
   }

   /// <summary>
   /// 
   /// </summary>
   private void SetAnimatorPlayerSpeed()
   {
      _animator.SetFloat("playerSpeed", _thePlayer.GetComponent<JoystickControllerMovement>().GetMoveSpeed());
   }

   /// <summary>
   /// gets the player gameobject in the scene
   /// </summary>
   /// <returns></returns>
   public GameObject GetPlayer()
   {
      if (_thePlayer == null)
      {
         _thePlayer = GameObject.FindGameObjectWithTag("Player");
      }

      return _thePlayer;
   }
}
