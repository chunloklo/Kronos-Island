using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    GameObject healthVial;
    GameObject player;
    int healthUpAmount = 20;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == player)
        {
            player.GetComponent<PlayerHealth>().TakeHealth(healthUpAmount);
        }
        Destroy(gameObject);
    }
}