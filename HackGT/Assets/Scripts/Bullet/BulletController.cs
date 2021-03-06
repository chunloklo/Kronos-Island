﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float movementSpeed;
    private float timePassed;
    public float timeAlive;
    public int damage;
    public GameObject owner;
    // Use this for initialization
    void Start() {
        timeAlive = 5;
        timePassed = 0f;
        damage = 10;
    }

    // Update is called once per frame
    void Update() {
        transform.position += transform.forward * GameObject.Find("TimeManager").GetComponent<TimeManager>().DeltaTime() * movementSpeed;
        timePassed += GameObject.Find("TimeManager").GetComponent<TimeManager>().DeltaTime();
        if (timePassed >= timeAlive) {
            Destroy(gameObject);
        }
        
    }

    public void SetOwner(GameObject obj) {
        owner = obj;
    }

    void OnCollisionEnter(Collision col) {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Player" && owner.tag == "Enemy") {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (col.gameObject.layer == 8) {
   
            Destroy(gameObject);
        }
    }
}
