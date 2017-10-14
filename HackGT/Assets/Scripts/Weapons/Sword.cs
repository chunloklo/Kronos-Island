using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    GameObject player;
    public int damage;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider collider)
    {
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}
