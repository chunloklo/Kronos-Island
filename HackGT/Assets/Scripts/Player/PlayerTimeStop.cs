using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimeStop : MonoBehaviour {

    bool timeStop = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T)) {
            timeStop = !timeStop;
            Debug.Log(timeStop);
            if (timeStop) {
                GameObject.Find("TimeManager").GetComponent<TimeManager>().timeScale = .3f;
            } else {
                GameObject.Find("TimeManager").GetComponent<TimeManager>().timeScale = 1f;
            }
        }
	}


}
