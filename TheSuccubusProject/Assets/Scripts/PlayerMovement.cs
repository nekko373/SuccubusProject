using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PlayerMovement : MonoBehaviour
{


    //REFERENCES
    public Flowchart myFlowchart; //reference to flowchart
    public Animator animator; //reference to animator
    public Rigidbody2D rigidbody2D; // reference to rigidbody of player
    public HalfBody halfBody; // reference to half body game objecct
    public CharacterController2D controller; //reference to the controller script
    public CharacterScript characterScript; //reference to character script

    //VARIABLES
    public float runSpeed = 40f; //run speed
    float horizontalMove = 0f; //horizontal move variable
    float verticalMove = 0f; // vertical move variable
    bool halfBodyMode = false; //boolean for determining if half body mode is on
    bool jump = false; // boolean to determine if player is jumping
   
    void Update()
    {
        //get movement
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
        //walk animation
        animator.SetFloat("isWalking", Mathf.Abs(horizontalMove));
    
        //detach body
        if (Input.GetKeyDown(KeyCode.L)) {
            halfBody.HalfMode();
            halfBodyMode = true;
            animator.SetBool("isDetached", true);
        }
        //release detach
      else if (Input.GetKeyUp(KeyCode.L)) {
            halfBodyMode = false;
            animator.SetBool("isDetached", false);
            halfBody.ReturnBody();
        }
       
        //jump

        if (Input.GetKeyDown(KeyCode.Space)) {
            jump = true;
            animator.SetBool("IsJumping", true);   
        }

    }

    //event to determine if player is landing
    void OnLanding() {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate() {
       
        //will check halfbodymode, can move y-axis if true, cant jump if false
        if (halfBodyMode == true) {
            controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime, true, false);
        }
        else if(halfBodyMode == false) {
            controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }

    }
    
}
