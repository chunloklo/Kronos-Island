using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour {

    GameObject player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            player.GetComponent<PlayerHealth>().Win();
        }
    }

}
