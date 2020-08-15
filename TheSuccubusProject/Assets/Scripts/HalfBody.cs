using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfBody : MonoBehaviour
{
    
    //lower body components
    
    public SpriteRenderer Lowerhalf_sr;
    public Transform Lowerhalf_tr;

    //circle collider and rigid body of player
    public CircleCollider2D collider;
    public Rigidbody2D rigidbody;

    //transform of lowerbody_pos;
    public Transform lowerBody_transform;


    //private variables
    float zeroGravity = 0;
    float defaultGravity = 3;
    Vector3 lowerBody_Position;


    public void HalfMode() {

        // get the position of player the moment you enabled half body mode and store it in a variable
          lowerBody_Position = lowerBody_transform.position;

        //enable visibility of sprite and transform it into lowerBody_Position
        Lowerhalf_sr.enabled = true;
        Lowerhalf_tr.position = lowerBody_Position;


       
        //turn off collider and gravity of upper body
        collider.enabled = false;
        rigidbody.gravityScale = zeroGravity;
        


    }

    public void ReturnBody() {

        //go back to lower body position
        rigidbody.position = lowerBody_Position;

        //turn back collider and gravity
        collider.enabled = true;
        rigidbody.gravityScale = defaultGravity;

        //turn off visibility of lower body
        Lowerhalf_sr.enabled = false;
  



    }
    
}
