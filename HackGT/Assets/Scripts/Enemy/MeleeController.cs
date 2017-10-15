using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour {

    private GameObject player;
    private GameObject enemy;
    private Rigidbody rb;

    public float movementSpeed;
    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(100, 0, 0);

    }

    // Update is called once per frame
    void Update() {
        transform.LookAt(player.transform);
        //Debug.Log(player);
        if (Vector3.Distance(transform.position, player.transform.position) < 50  && Vector3.Distance(transform.position, player.transform.position) > .5f) {
            rb.velocity = transform.forward * movementSpeed * GameObject.Find("TimeManager").GetComponent<TimeManager>().timeScale;
        }
        
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed);

    }
}
