using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = Color.red;

    public ParticleSystem ds;

    bool isDead;
    bool damaged;

    void Awake() {
        currentHealth = startingHealth;
    }

    void Update() {
    }

    public void TakeDamage(int amount) {
        damaged = true;
        currentHealth -= amount;
        if (currentHealth <= 0 && !isDead) {
            Death();
        }
    }

    void Death() {
        ParticleSystem pe = Instantiate(ds, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(pe, 1);
        Destroy(gameObject);
        isDead = true;
        //make menu pop up
        //restart game
    }
}