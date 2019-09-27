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
   Vector3 moveVec;
   Vector3 rotateVec;
   Vector3 velocity;
   Rigidbody rBody;

   private void Awake()
   {
      rBody = GetComponent<Rigidbody>();
   }

   // Start is called before the first frame update
   void Start()
   {
      velocity = Vector3.zero;
   }

   // Update is called once per frame
   private void Update()
   {
      
      //rBody.velocity = velocity;
   }

   void FixedUpdate()
   {
      moveX = Input.GetAxisRaw("Horizontal");
      moveZ = Input.GetAxisRaw("Vertical");
      turn = Input.GetAxisRaw("RightJoystickTurn");

      Movement(moveX, moveZ);
      Rotation(turn);

   }

   void Movement(float xDirection, float zDirection)
   {
      moveVec = new Vector3(xDirection, 0f, zDirection);

      float moveSpeed = maxMoveSpeed * moveVec.magnitude;

      moveVec = moveVec.normalized * moveSpeed * Time.deltaTime;

      rBody.MovePosition(this.transform.position + moveVec);
   }


   void Rotation(float turnDirection)
   {
      rotateVec = new Vector3(0f, turnDirection, 0f) * turnSpeed * Time.deltaTime;

      Quaternion rotateQuaternion = Quaternion.Euler(rotateVec);

      rBody.MoveRotation(rBody.rotation * rotateQuaternion);
   }
}
