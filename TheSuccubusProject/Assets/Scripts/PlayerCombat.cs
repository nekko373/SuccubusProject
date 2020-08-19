using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    
    public Transform attackPoint; //reference for attackpoint
    public float attackRange = 1f; //attack radius
    public LayerMask enemyLayers; //to detect enemy in attack range
    public float attackDamage = 20f; // player's atk damage
    public Animator animator; //reference to Animator
    public float attackRate = 10f; //attack rate of player
    float nextAttackTime; //next time u are allowed to attack

    
    void Update()
    {

        if (Time.time >= nextAttackTime) {
            
        if (Input.GetKeyDown(KeyCode.K)) {

            StartCoroutine(Attack());
                nextAttackTime = Time.time + 1f / attackRate;
        }

        }

    }

    IEnumerator Attack()
    {
        
        //attack animation
        animator.SetTrigger("Attack");


        yield return new WaitForSeconds(.5f);
        //detect enemies
        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


        //loop to damage enemies hit
        foreach (Collider2D enemy in hitEnemies) {
            //take damage
            enemy.GetComponent<EnemyScript>().TakeDamage(attackDamage);

        }


    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }


        Gizmos.DrawSphere(attackPoint.position, attackRange);

    }
      
}
