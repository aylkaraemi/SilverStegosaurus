using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
   public int candyAmount = 0;

   [SerializeField] private float _increaseStruggleBarAmount = 2.0f;
   [SerializeField] private float _pointerAppearTime = 15.0f;
   [SerializeField] private int _pointerAppearCandyAmount = 10;
   [SerializeField] private GameObject _pointer; // dragged into Inspector
   private bool _isHopeInRange = false;
   private bool _pickedUpCandy = false;
   private Animator _animator;
   private static PlayerAction _instance;

   /// <summary>
   /// for singleton access to Player
   /// </summary>
   public static PlayerAction Instance
   {
      get
      {
         if (_instance == null)
         {
            Debug.Log("PlayerAction did not load");
         }

         return _instance;
      }
   }

   private void Awake()
   {
      _instance = this;
      _animator = GetComponent<Animator>();
   }


   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetButtonDown("Fire1"))
      {
         //Debug.Log("Pressed A Button");

         // catch Hope with A Button
         if (_isHopeInRange && !HopeAI.Instance.wasCaught)
         {
            Grab();
         }

         // struggle with Hope
         if (HopeAI.Instance.wasCaught)
         {
            Struggle();
         }
      }

      if (Input.GetKeyDown(KeyCode.Q))
      {
         Application.Quit();
      }
   }

   public void SetAnimatorStruggleBool(bool isStruggling)
   {
      _animator.SetBool("isStruggling", isStruggling);
   }

   /// <summary>
   /// grab hope to win the game
   /// </summary>
   private void Grab()
   {
      HopeAI.Instance.SetAnimatorIsCaughtToTrue();
   }

   /// <summary>
   /// increase Hope struggle bar amount
   /// </summary>
   private void Struggle()
   {
      HopeAI.Instance.IncreaseStruggleBarValue(_increaseStruggleBarAmount);
   }

   /// <summary>
   /// power down the pointer pointer to Hope (sets active to false)
   /// </summary>
   /// <returns></returns>
   IEnumerator ArrowPowerDownRoutine()
   {
      yield return new WaitForSeconds(_pointerAppearTime);
      candyAmount = 0;
      _pickedUpCandy = false;
      _pointer.SetActive(false);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Hope")
      {
         //Debug.Log("Hope is in Range");
         _isHopeInRange = true;
         HopeAI.Instance.TurnOnAButtonUI();
      }

      if (other.tag == "Candy")
      {
         if (!_pickedUpCandy)
         {
            candyAmount++;
            //Debug.Log("Candy Amount now = " + candyAmount);

            Candy candy = other.GetComponent<Candy>();

            if (candy != null)
            {
               candy.DestroyOnPickUp();
            }

            _pickedUpCandy = true;
            _pointer.SetActive(true);
            StartCoroutine(ArrowPowerDownRoutine());
         }
         
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.tag == "Hope")
      {
         //Debug.Log("Hope is out of Range");
         _isHopeInRange = false;
         HopeAI.Instance.TurnOffAButtonUI();
      }


   }

}
