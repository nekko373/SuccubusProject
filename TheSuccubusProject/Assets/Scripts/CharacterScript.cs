using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{

    public float maxhealth = 100f;
    public float currentHealth;
    public HealthBar healthbar;
    public LifeForce lifeForceBar;


    public float maxLifeForce = 100f;
    public float currentLifeForce;

    void Start() {

        currentHealth = maxhealth;
        healthbar.SetMaxHealth(maxhealth);
        currentLifeForce = 0;
        lifeForceBar.SetMaxLF(maxLifeForce);
        lifeForceBar.SetLifeForce(currentLifeForce);

    }

    
    public void TakeDamage(float damage) {
        //character takes damage
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        //take damage animation
    }
    public void acquireLifeForce(float lifeForce) {
        //character takes life force when enemy and other game obj dies
        currentLifeForce += lifeForce;
        lifeForceBar.SetLifeForce(currentLifeForce);


    }
    public void loseLifeForce(float lifeForce) {
        if (lifeForce <= 0)
        {
            return;
        }
        else
        {
            //character loses life force when using certain skills
            currentLifeForce -= lifeForce;

            lifeForceBar.SetLifeForce(currentLifeForce);
        }
    }
    public void Die() {

        //character dies
        //character death animation
    }
}
