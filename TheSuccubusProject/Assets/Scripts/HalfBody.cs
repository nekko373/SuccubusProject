using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfBody : MonoBehaviour
{

    public GameObject Lowerhalf_body;
    public CircleCollider2D collider;
    public Rigidbody2D rigidbody;
    public Transform transform;
    float zeroGravity = 0;
    Vector3 lowerBody_Position;
    public void HalfMode() {
        lowerBody_Position = transform.position;
        Instantiate(Lowerhalf_body, transform.position, Quaternion.identity);
        collider.enabled = false;
        rigidbody.gravityScale = zeroGravity;
        


    }
    
}
