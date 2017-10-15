using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{

    GameObject player;
    GameObject enemy;
    public ParticleSystem explosion;
    float bigRadius = 4.0f;
    float medRadius = 3.0f;
    float smallRadius = 2.0f;
    public int bigDmg;
    public int medDmg;
    public int smallDmg;
    public int enemyBonusDmg;
    public bool isExploding;
    int totalDmgPlayer;
    int totalDmgEnemy;
    bool hasTakenDmg;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        hasTakenDmg = false;
    }

    void Update()
    {
        isExploding = explosion.isPlaying;
        if (isExploding)
        {
            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 4);
            foreach (Collider col in hitColliders)
            {
                if (col.gameObject.tag == "Player" && !hasTakenDmg)
                {
                    player.GetComponent<PlayerHealth>().TakeDamage(10);
                    hasTakenDmg = true;
                }
            }
        }
    }
}

