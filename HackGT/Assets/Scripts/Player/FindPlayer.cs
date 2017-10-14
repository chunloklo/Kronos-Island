using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindPlayer : MonoBehaviour {

    GameObject player;
    PlayerHealth playerhealth;
    int currentHealth;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        currentHealth = playerhealth.currentHealth;
        gameObject.GetComponent<Slider>().value = currentHealth;
    }
}
