using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    float speed = 1;
    float rot = 0f;
    float rotSpeed = 80;
    float gravity = 8;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator animate;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); //referncing character controller on player in Unity
        animate = GetComponent<Animator>(); //referencing animator on player in Unity
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)//if the character is touching the ground
        {
            //----------WALKING MOVEMENT AND ANIMATION (CONDITION 01)----------
            if (Input.GetKey(KeyCode.W))//If the 'w' key is being pressed
            {
                animate.SetInteger("Condition", 1);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);//sets transform from local space to world space

            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                animate.SetInteger("Condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }


            //----------RUNNING MOVEMENT AND ANIMATION (CONDITION 02)----------
            if (Input.GetKey(KeyCode.LeftShift))//If the 'w' key is being pressed
            {
                animate.SetInteger("Condition", 2);
                moveDir = new Vector3(0, 0, 2);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);//sets transform from local space to world space

            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                animate.SetInteger("Condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }


            //----------RUNNING BACKWARDS MOVEMENT AND ANIMATION (CONDITION 03)----------
            if (Input.GetKey(KeyCode.S))//If the 'w' key is being pressed
            {
                animate.SetInteger("Condition", 3);
                moveDir = new Vector3(0, 0, -2);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);//sets transform from local space to world space

            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                animate.SetInteger("Condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }


            //----------SPRINTING MOVEMENT AND ANIMATION (CONDITION 04)----------
            if (Input.GetKey(KeyCode.LeftControl))//If the 'w' key is being pressed
            {
                animate.SetInteger("Condition", 4);
                moveDir = new Vector3(0, 0, 4);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);//sets transform from local space to world space

            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                animate.SetInteger("Condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }


            //----------JUMPING MOVEMENT AND ANIMATION (CONDITION 05)----------
            if (Input.GetKey(KeyCode.Space))//If the 'w' key is being pressed
            {
                animate.SetInteger("Condition", 5);
                moveDir = new Vector3(3, 10, 0);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);//sets transform from local space to world space

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                animate.SetInteger("Condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }



        }

        //Rotate left and right with the 'a' and 'd' keys
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity * Time.deltaTime; //every frame, move our player on the y axis by gravity value. Essentially, lowering the character to the ground
        controller.Move(moveDir * Time.deltaTime);
    }
}
