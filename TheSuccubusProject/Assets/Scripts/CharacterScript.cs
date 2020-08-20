using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{

    public float maxhealth = 100f;
    public float currentHealth;
    public HealthBar healthbar;
    public LifeForce lifeForceBar;
    float nextTime;
    public Animator animator;
    public float maxLifeForce = 100f;
    public float currentLifeForce;

    void Start() {

        currentHealth = maxhealth;
        healthbar.SetMaxHealth(maxhealth);
        currentLifeForce = 0;
        lifeForceBar.SetMaxLF(maxLifeForce);
        lifeForceBar.SetLifeForce(currentLifeForce);
        nextTime = Time.time + 1f;
    }

    void OnCollisionEnter2D(Collision2D collision) {

        
        if (Time.time >= nextTime) {
            
            if (collision.gameObject.tag == "Enemy") {
                Debug.Log("hit by enemy");
          TakeDamage(10);
          nextTime = Time.time + 1f;

                }
            
        }
    }






    public void TakeDamage(float damage) {
        
        //character takes damage
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 bump = transform.position + new Vector3(-10f, 3f, 0f);
        rb.AddForce(bump * 3, ForceMode2D.Impulse);
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);


        animator.SetTrigger("isHurt"); //animation for hurt
        
      
     
     

    }
    public void acquireLifeForce(float lifeForce) {
        //character takes life force when enemy and other game obj dies
        currentLifeForce += lifeForce;
        lifeForceBar.SetLifeForce(currentLifeForce);


    }
    public void loseLifeForce(float lifeForce) {
       
            //character loses life force when using certain skills
            currentLifeForce -= lifeForce;
            lifeForceBar.SetLifeForce(currentLifeForce);
        
    }
    public void Die() {

        //character dies
        //character death animation
    }
}
