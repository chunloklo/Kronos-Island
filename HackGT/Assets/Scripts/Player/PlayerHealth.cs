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
    public GameObject menu;

    bool isDead;
    bool damaged;

    void Awake ()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = startingHealth;
        menu.SetActive(false);
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
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
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
        //Time.timeScale = 0;
        //make menu pop up
        //restart game
        menu.SetActive(true);
    }
}
