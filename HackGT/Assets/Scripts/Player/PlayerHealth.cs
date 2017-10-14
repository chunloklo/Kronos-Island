using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    GameObject player;

    public int startingHealth = 100;
    public int currentHealth;
    public Image damageImage;
    public Slider healthSlider;
    public float flashSpeed = 5f;
    public Color flashColour = Color.red;
    
    bool isDead;
    bool damaged;

    void Awake ()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = startingHealth;
    }

    void Update ()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage (int amount)
    {
        damaged = true;
        currentHealth -= amount;
        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void TakeHealth (int amount)
    {
        currentHealth += amount;
    }

    void Death()
    {
        isDead = true;
        Time.timeScale = 0;
        //make menu pop up
        //restart game
    }
}
