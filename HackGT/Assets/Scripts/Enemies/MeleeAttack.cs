using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public GameObject sword;
    float radius;
    bool isSwing;

    void Start()
    {
        radius = GetComponentInChildren<SphereCollider>().radius;
        //Debug.Log(radius);
    }

    void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log("Start swinging!");
            isSwing = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        isSwing = false;
    }

    void Update()
    {
        if (isSwing)
        {
            startSwinging();
        } 
    }

    void startSwinging()
    {
        //sword.transform.position = sword.transform.position + new Vector3(0.3f, 0.3f, 0.3f);
        sword.transform.RotateAround(sword.transform.parent.position, Vector3.down, 500 * GameObject.Find("TimeManager").GetComponent<TimeManager>().DeltaTime());
        //sword.transform.localPosition = Vector3.Slerp(sword.transform.localPosition, new Vector3(1, 0, 1), 0.01f);
    }

}
