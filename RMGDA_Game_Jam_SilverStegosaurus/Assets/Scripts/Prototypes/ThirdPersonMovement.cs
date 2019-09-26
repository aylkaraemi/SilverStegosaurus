using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
   public float maxMoveSpeed;
   public float turnSpeed;
   public GameObject theCamera;

   float moveX;
   float moveZ;
   float turn;
   Vector3 moveVec;
   Vector3 rotateVec;
   Rigidbody rBody;

   private void Awake()
   {
      rBody = GetComponent<Rigidbody>();
   }

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void FixedUpdate()
   {
      moveX = Input.GetAxisRaw("Horizontal");
      moveZ = Input.GetAxisRaw("Vertical");
      turn = Input.GetAxisRaw("RightJoystickTurn");

      Movement(moveX, moveZ);
      RotateBody(turn);
   }

   void Movement(float xDirection, float zDirection)
   {
      float moveSpeed = maxMoveSpeed * new Vector3(xDirection, 0f, zDirection).magnitude;

      Vector3 forwardMove = this.transform.forward * zDirection * moveSpeed * Time.deltaTime;
      Vector3 sidewaysMove = this.transform.right * xDirection * moveSpeed * Time.deltaTime;

      rBody.MovePosition(this.transform.position + forwardMove + sidewaysMove);
   }

   void RotateBody(float turnDirection)
   {
      rotateVec = new Vector3(0f, turnDirection, 0f) * turnSpeed * Time.deltaTime;

      Quaternion rotateQuaternion = Quaternion.Euler(rotateVec);

      rBody.MoveRotation(rBody.rotation * rotateQuaternion);
   }

}
