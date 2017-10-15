using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimeStop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T)) {
            //Debug.Log("PRESSED");
            GameObject.Find("TimeManager").GetComponent<TimeManager>().SwitchTime();
        }
        //if (Input.GetMouseButtonDown(1))
        //{
        //    GameObject.Find("TimeManager").GetComponent<TimeManager>().SwitchTime();
        //}
	}


}
