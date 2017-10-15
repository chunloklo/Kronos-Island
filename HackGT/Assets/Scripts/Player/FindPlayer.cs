using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindPlayer : MonoBehaviour {

    GameObject player;
    PlayerHealth playerhealth;
    PlayerFireController firecon;
    int currentHealth;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<PlayerHealth>();
        firecon = player.GetComponentInChildren<PlayerFireController>();
        Debug.Log(player);
    }

    void Update()
    {
        //firecon = player.GetComponentInChildren<PlayerFireController>();
        currentHealth = playerhealth.currentHealth;
        if (gameObject.name == "HealthBar")
        {
            gameObject.GetComponent<Slider>().value = currentHealth;
        }
        if (gameObject.name == "ReloadBullets")
        {
            //Debug.Log("RELB");
            gameObject.GetComponent<Slider>().maxValue = firecon.reloadTime;
            //Debug.Log(firecon.reloadTime);
            gameObject.GetComponent<Slider>().value = firecon.reloadTime - firecon.timer;
            //Debug.Log(firecon.timer);
        }
    }
}
