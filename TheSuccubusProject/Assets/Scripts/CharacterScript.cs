using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using System.Collections.Specialized;

public class CharacterScript : MonoBehaviour
{
    public Flowchart myFlowchart; //reference to fungus flowchart
    public Button button; //reference to button
    public HealthBar healthbar; // reference to health bar
    public LifeForce lifeForceBar; // reference to life force
    public Animator animator; // reference to the animator
    public Transform enemy; // reference to enemy

    public float maxhealth = 100f; // set max health 
    public float currentLifeForce; // var for player's current lf
    public float currentHealth; // var for player's current hp
    public float maxLifeForce = 100f; // set max life force
    float nextTime; // var for next time that player can be hit
    bool isDone;


    Rigidbody2D rb;



    void Start() {

        //set max life force and health
        currentHealth = maxhealth;
        healthbar.SetMaxHealth(maxhealth);
        healthbar.SetHealth(currentHealth);
        currentLifeForce = 0f;
        lifeForceBar.SetMaxLF(maxLifeForce);
        lifeForceBar.SetLifeForce(currentLifeForce);
        nextTime = Time.time + 1f;

        rb = GetComponent<Rigidbody2D>();

    }


    //do this when player collides with something like taking damage
    void OnCollisionEnter2D(UnityEngine.Collision2D collision) {

        if (Time.time >= nextTime) {

            if (collision.gameObject.tag == "Enemy") {
                Physics2D.IgnoreLayerCollision(10, 9, true);
                Debug.Log("hit by enemy");
                StartCoroutine(TakeDamage(10));
                nextTime = Time.time + 1f;

            }

        }
        
    }

    //do this when player collides with interactibles like NPC
    void OnTriggerStay2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "NPC")
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            myFlowchart.ExecuteBlock("Start");
            isDone = myFlowchart.GetBooleanVariable("Done");

        }

    }
   


    void Update() {


        if (isDone)
        {
            GetComponent<PlayerMovement>().enabled = true;
            GetComponent<PlayerCombat>().enabled = true;
        }




        if (Input.GetButton("lifeforce")) {

            if (currentLifeForce > 0 && currentHealth < 100) {
                //play convert animation
                currentHealth+=.10f;
                currentLifeForce-=.10f;
                lifeForceBar.SetLifeForce(currentLifeForce);
                healthbar.SetHealth(currentHealth);
                PlayerPrefs.SetFloat("PlayerHP", currentHealth);
                PlayerPrefs.SetFloat("PlayerLF", currentLifeForce);
                animator.SetTrigger("isConverting");
            }

        }
        
    }




    public IEnumerator TakeDamage(float damage) {

        //character takes damage
        animator.SetTrigger("isHurt"); //animation for hurt
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //disable colliders for a while

        if (transform.position.x > enemy.position.x)
        {

            if (transform.position.y > enemy.position.y)
            {
                rb.AddForce(new Vector2(10f, 2f) * 3, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(new Vector2(10f, -2f) * 3, ForceMode2D.Impulse);
            }

        }

        else {
            if (transform.position.y > enemy.position.y)
            {
                rb.AddForce(new Vector2(-10f, 2f) * 3, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(new Vector2(-10f, -2f) * 3, ForceMode2D.Impulse);
            }

        }

        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);




        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreLayerCollision(10, 9, false);


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

    IEnumerator WaitForSeconds(float seconds) {

        yield return new WaitForSeconds(seconds);
    
    }
}
