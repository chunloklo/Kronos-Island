using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float movementSpeed;
    private float timePassed;
    public float timeAlive;
    // Use this for initialization
    void Start() {
        timePassed = 0f;
    }

    // Update is called once per frame
    void Update() {
        transform.position += transform.forward * Time.deltaTime * movementSpeed;
        timePassed += Time.deltaTime;
        if (timePassed >= timeAlive) {
            Destroy(gameObject);
        }
        
    }

    void OnCollisionEnter(Collision col) {

        if (col.gameObject.tag == "Player") {
            //do something
        }
        if (col.gameObject.layer == 8) {
   
            Destroy(gameObject);
        }
    }
}
