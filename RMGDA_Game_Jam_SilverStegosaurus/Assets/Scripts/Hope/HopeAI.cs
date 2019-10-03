using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HopeAI : MonoBehaviour
{
   public GameObject[] waypoints;
   public const float MAX_STRUGGLE_BAR_AMOUNT = 80.0f;
   public bool wasCaught = false;

   private static HopeAI _instance;
   private Animator _animator;
   private GameObject _thePlayer;
   private float _timer = 0f;
   private Text _aText;
   private Slider _struggleBar;


   /// <summary>
   /// for singleton access to Hope
   /// </summary>
   public static HopeAI Instance
   {
      get
      {
         if (_instance == null)
         {

         }

         return _instance;
      }
   }

   private void Awake()
   {
      _instance = this;
      _thePlayer = GameObject.FindGameObjectWithTag("Player");
      _animator = GetComponent<Animator>();
      waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
      _aText = GetComponentInChildren<Text>();
      _struggleBar = GetComponentInChildren<Slider>();

      if (_struggleBar != null)
      {
         _struggleBar.value = MAX_STRUGGLE_BAR_AMOUNT;
      }
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
   /// sets the animator player speed based off player joystick press amount
   /// </summary>
   private void SetAnimatorPlayerSpeed()
   {
      _animator.SetFloat("playerSpeed", _thePlayer.GetComponent<JoystickControllerMovement>().GetMoveSpeed());
   }

   /// <summary>
   /// set the animator isCaught variable to true
   /// </summary>
   public void SetAnimatorIsCaughtToTrue()
   {
      _animator.SetBool("isCaught", true);
   }

   /// <summary>
   /// turns on the A button UI element above Hope
   /// </summary>
   public void TurnOnAButtonUI()
   {
      _aText.enabled = true;
   }

   /// <summary>
   /// turns off the A button UI element above Hope
   /// </summary>
   public void TurnOffAButtonUI()
   {
      _aText.enabled = false;
   }

   /// <summary>
   /// decreases Hope's struggle bar
   /// </summary>
   /// <param name="amount"></param>
   public void DecreaseStruggleBarValue(float amount)
   {
      _struggleBar.value -= amount;
   }

   /// <summary>
   /// increases Hope's struggle bar
   /// </summary>
   /// <param name="amount"></param>
   public void IncreaseStruggleBarValue(float amount)
   {
      _struggleBar.value += amount;
   }

   public float GetHopeStruggleBarValue()
   {
      return _struggleBar.value;
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
