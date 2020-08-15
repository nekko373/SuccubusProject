using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    public float runSpeed = 40f;
    public HalfBody halfBody;
    bool halfBodyMode = false;
    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
        Debug.Log(horizontalMove);
        if (Input.GetKeyDown("space")) {

            halfBody.HalfMode();
            halfBodyMode = true;


        }




    }

    void FixedUpdate() {

        
        controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime,halfBodyMode, false);

        
        halfBodyMode = false;


    }




}
