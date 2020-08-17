using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    
    public Animator animator;
    public float enemy_maxHealth = 100;
    float currentHealth;
    public CharacterScript player;
    void Start()
    {
        currentHealth = enemy_maxHealth;

        
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
            this.enabled = false;
            player.acquireLifeForce(enemy_maxHealth/3);

            }


    }




}
