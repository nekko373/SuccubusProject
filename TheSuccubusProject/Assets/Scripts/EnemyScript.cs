using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    
   
    //reference to waypoints and index
    public Transform[] waypoints;
    private int waypointIndex= 0;

    //reference to attackpoint
    public Transform attackPoint;

    //movement speed of enemy
    public float enemy_movespeed = 10f;
    public Animator animator; //reference to animator
    public float enemy_maxHealth = 100; //max hp of enemy
    float currentHealth; // current hp of enemy
    public CharacterScript player; //reference to player
    public Transform player_t; //reference to player transform
    private float forFlip = 1f;
    public Rigidbody2D rb;


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

        //apply bump effect
       
        rb.AddForce(transform.right * 5, ForceMode2D.Impulse);
        
        
        StartCoroutine(waitForSeconds());

        if (currentHealth <= 0) {
            //play die animation
            animator.SetBool("isDead", true);

            //disable colliders
            Debug.Log("Enemy died");
            player.acquireLifeForce(enemy_maxHealth / 3);

            rb.constraints = RigidbodyConstraints2D.FreezePosition;
                Physics2D.IgnoreLayerCollision(9, 10, true);
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

    IEnumerator waitForSeconds() {

        yield return new WaitForSeconds(2f);
    }
   
    

}
