using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    private LineRenderer lr;

	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
        if (Physics.Raycast(ray, out hit)) {
            //Debug.Log("HIT");
            lr.transform.position = gameObject.transform.position;
            lr.SetPosition(0, new Vector3(0, 0, hit.distance));
        }

    }
}
