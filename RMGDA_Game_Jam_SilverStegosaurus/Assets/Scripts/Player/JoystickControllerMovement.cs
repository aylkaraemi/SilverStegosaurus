using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControllerMovement : MonoBehaviour
{
   public float maxMoveSpeed;
   public float turnSpeed;

   float moveX;
   float moveZ;
   float turn;
   float moveSpeed;
   Vector3 moveVec;
   Vector3 rotateVec;
   Vector3 velocity;
   Rigidbody rBody;
   private Animator _animator;

   private void Awake()
   {
      rBody = GetComponent<Rigidbody>();
      _animator = GetComponent<Animator>();
   }

   // Start is called before the first frame update
   void Start()
   {
      velocity = Vector3.zero;
   }

   // Update is called once per frame
   private void Update()
   {
      
   }

   void FixedUpdate()
   {
      moveX = Input.GetAxisRaw("Horizontal");
      moveZ = Input.GetAxisRaw("Vertical");
      turn = Input.GetAxisRaw("RightJoystickTurn");

      if (moveX == 0 && moveZ == 0)
      {
         _animator.SetBool("isRunning", false);
      }
      else
      {
         _animator.SetBool("isRunning", true);
      }

      Movement(moveX, moveZ);
      Rotation(turn);

   }

   /// <summary>
   /// used for horizontal and vertical movement of the Player
   /// </summary>
   /// <param name="xDirection"></param>
   /// <param name="zDirection"></param>
   void Movement(float xDirection, float zDirection)
   {
      moveVec = new Vector3(xDirection, 0f, zDirection);

      moveSpeed = maxMoveSpeed * moveVec.magnitude;

      moveVec = moveVec.normalized * moveSpeed * Time.deltaTime;

      rBody.MovePosition(this.transform.position + moveVec);
   }

   /// <summary>
   /// used for turning the Player
   /// </summary>
   /// <param name="turnDirection"></param>
   void Rotation(float turnDirection)
   {
      rotateVec = new Vector3(0f, turnDirection, 0f) * turnSpeed * Time.deltaTime;

      Quaternion rotateQuaternion = Quaternion.Euler(rotateVec);

      rBody.MoveRotation(rBody.rotation * rotateQuaternion);
   }

   /// <summary>
   /// get's the player's movement speed
   /// </summary>
   /// <returns>moveSpeed</returns>
   public float GetMoveSpeed()
   {
      return moveSpeed;
   }
}
