using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        Debug.Log(horizontalMove);

    }

    void FixedUpdate() {

        
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);



    }




}
