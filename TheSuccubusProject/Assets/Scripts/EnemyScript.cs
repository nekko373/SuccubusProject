using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
   
    //reference to waypoints and index
    public Transform[] waypoints;
    private int waypointIndex= 0;
    public Rigidbody2D rb;
    //movement speed of enemy
    public float enemy_movespeed = 10f;
    public Animator animator; //reference to animator
    public float enemy_maxHealth = 100; //max hp of enemy
    float currentHealth; // current hp of enemy
    public CharacterScript player; //reference to player
    private float forFlip = 1f;

    void Start()
    {
        currentHealth = enemy_maxHealth;
        transform.position = waypoints[waypointIndex].position;
      
        
    }

    public void TakeDamage(float damage) {
        
        //subtract damage to current health
        currentHealth -= damage;

        //play hurt animation
        Debug.Log(damage+" damage taken");
        animator.SetTrigger("Hurt");


        if (currentHealth <= 0) {
            //play die animation
            animator.SetBool("isDead", true);
           
            //disable colliders
            Debug.Log("Enemy died");
            GetComponent<Collider2D>().enabled = false;
            player.acquireLifeForce(enemy_maxHealth / 3);
            this.enabled = false;
            

            }


    }

    void FixedUpdate() {


        Move();

       
            
        
        
    }

    void Move() {
        //move enemy
        if (waypointIndex <= waypoints.Length - 1) {

            transform.position = Vector3.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position, enemy_movespeed * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex].transform.position) {
                forFlip *= -1;
                transform.localScale = new Vector3(forFlip, 1, 1);
                waypointIndex++;
                    }

        }

        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }

       

    }




}
