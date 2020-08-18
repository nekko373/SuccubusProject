using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator; //reference to animator
    public Rigidbody2D rigidbody2D; // reference to rigidbody of player
    public CharacterController2D controller; //reference to the controller script
    float horizontalMove = 0f; //horizontal move variable
    float verticalMove = 0f; // vertical move variable
    public float runSpeed = 40f; //run speed
    public HalfBody halfBody; // reference to half body game objecct
    bool halfBodyMode = false; //boolean for determining if half body mode is on
    public CharacterScript characterScript; //reference to character script
    bool jump = false; // boolean to determine if player is jumping
    
    // Update is called once per frame
    
    void Update()
    {
        //get movement
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
        
        //animator
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
        if (Input.GetButtonDown("takedmg")) {
        
            characterScript.TakeDamage(10);

        }


        //check if lose and acquire life force is working
        /*
        if (Input.GetButtonDown("takelf"))
        {
            Debug.Log("LF Taken: " + 10);
            characterScript.acquireLifeForce(10);

        }
        if (Input.GetButtonDown("loself"))
        {
            
            Debug.Log("LF Lost: " + 10);
            characterScript.loseLifeForce(10);

        }
        */

        if (Input.GetKeyDown(KeyCode.Space)) {
            
            jump = true;
            
            animator.SetBool("IsJumping", true);
            

            
        }

    }
    void OnLanding() {


        animator.SetBool("IsJumping", false);

    }


    void FixedUpdate() {

        if (halfBodyMode == true) {

           // Debug.Log("Vertical: " + verticalMove);
            //Debug.Log("Half body mode is true: " + halfBodyMode);
            controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime, true, false);
            


        }
        else if(halfBodyMode == false) {

            //Debug.Log("Half body mode is false: " + halfBodyMode);
            controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime, false, jump);
            Debug.Log("jump should be true:  " + jump);
            jump = false;
            Debug.Log("jump is now " + jump);
        }

    }
    
}
