using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public GameObject sword;
    float radius;

    void Start()
    {
        radius = GetComponentInChildren<SphereCollider>().radius;
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            startSwinging();
        }
    }

    void startSwinging()
    {
        sword.transform.position = Vector3.Slerp(sword.transform.position, new Vector3(1, 0, 1), 0.01f);
    }

}
