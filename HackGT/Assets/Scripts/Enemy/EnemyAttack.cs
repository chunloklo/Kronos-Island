using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public int attackDamage = 10;

    GameObject player;
    PlayerHealth playerhealth;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<PlayerHealth>();

    }

    void Update()
    {

    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Touching rn");
    //    playerhealth.TakeDamage(attackDamage);
    //}
}
