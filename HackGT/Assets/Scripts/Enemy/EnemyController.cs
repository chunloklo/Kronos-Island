﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private GameObject player;
    private GameObject enemy;

    public float movementSpeed;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player.transform);
        if (Vector3.Distance(transform.position, player.transform.position) >= 5) {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed);

    }
}