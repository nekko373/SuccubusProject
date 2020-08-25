using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
public class CharacterScript : MonoBehaviour
{
    public Flowchart myFlowchart;
    public Button button;
    public float maxhealth = 100f;
    public float currentHealth;
    public HealthBar healthbar;
    public LifeForce lifeForceBar;
    float nextTime;
    public Animator animator;
    public float maxLifeForce = 100f;
    public float currentLifeForce;
    


    public Transform enemy;

    void Start() {

        currentHealth = maxhealth;
        healthbar.SetMaxHealth(maxhealth);
        currentLifeForce = 0;
        lifeForceBar.SetMaxLF(maxLifeForce);
        lifeForceBar.SetLifeForce(currentLifeForce);
        nextTime = Time.time + 1f;
    }

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

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "NPC")
        {
            myFlowchart.ExecuteBlock("Start");
            /*
            gameObject.GetComponent<PlayerMovement>().enabled = false;
                collider.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue()  ;
            gameObject.GetComponent<PlayerMovement>().enabled = true ;
           */
        }

    }

    void Update() {

        if (Input.GetButton("lifeforce")) {

            if (currentLifeForce > 0 && currentHealth < 100) {
                //play convert animation
                currentHealth+=.10f;
                currentLifeForce-=.10f;
                lifeForceBar.SetLifeForce(currentLifeForce);
                healthbar.SetHealth(currentHealth);
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
}
