using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }
}
