using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {
    public float timeScale = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetScale(float scale) {
        timeScale = scale;
    }

    public float DeltaTime() {
        return Time.deltaTime * timeScale;
    }
}
