using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Touched the boat");
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Portal1")
        {
            gameObject.transform.position = (GameObject.FindGameObjectWithTag("Portal2").transform.position);
        }
        if (collision.gameObject.tag == "Portal3")
        {
            gameObject.transform.position = (GameObject.FindGameObjectWithTag("Portal4").transform.position);
        }
    }
}
